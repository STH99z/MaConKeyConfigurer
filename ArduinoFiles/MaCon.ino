#include <EEPROM.h>
#include <Keyboard.h>
#include <Mouse.h>
#include <string.h>

const unsigned short MID_KEY_COUNT = 7;
const unsigned short SIDE_KEY_COUNT = 2;
const unsigned short MID_KEY_PIN[MID_KEY_COUNT] = {
  0, 1, 2, 3, 4, 5, 6
};
const unsigned short MID_KEY_LED[MID_KEY_COUNT] = {
  7, 8, 9, 10, 11, 12, 13
};
const unsigned short SIDE_KEY_PIN[SIDE_KEY_COUNT] = {
  A0, A1
};
const unsigned short SIDE_KEY_LED[SIDE_KEY_COUNT] = {
  A2, A3
};
bool prevMidStat[MID_KEY_COUNT] = {0};
bool prevSideStat[SIDE_KEY_COUNT] = {0};
unsigned long prevSideDownTime[SIDE_KEY_COUNT] = {0};
char serialString[64] = {0};
char serialStat = 0;
unsigned int serialStringPos = 0;
String STR_COM_READ = "COM_R";
String STR_COM_UPDATE = "COM_U";

typedef struct
{
  char statMark; //EEPROM status mark. 1=already_set, others=not_set
  char midKeyChar[MID_KEY_COUNT];
  char sideKeyChar[SIDE_KEY_COUNT];
  char sideKeyStyle[SIDE_KEY_COUNT];         //0=key, 1=scratch no reverse, 2=scratch with reverse
  char sideKeyMoveDirection[SIDE_KEY_COUNT]; //0=x, 1=y
  int sideKeyMovePixel[SIDE_KEY_COUNT];
  int sideKeyReversePixel[SIDE_KEY_COUNT];
  unsigned int holdThreshold; //hold time limit to trigger reverse scratch.
} KeySettings;

//sizeof KeySettings == 24B
//sizeof int == 2B
//sizeof unsigned int 2B

KeySettings keySettings;

inline bool getInput(unsigned int pin)
{
  return digitalRead(pin) == LOW;
}

inline bool getMidKeyInput(unsigned int keyIndex)
{
  return getInput(MID_KEY_PIN[keyIndex]);
}

inline bool getSideKeyInput(unsigned int keyIndex)
{
  return getInput(SIDE_KEY_PIN[keyIndex]);
}

void resetKeySettings()
{
  keySettings.statMark = 1;
  for (int i = 0; i < MID_KEY_COUNT; i++)
  {
    keySettings.midKeyChar[i] = 'a' + i;
  }
  for (int i = 0; i < SIDE_KEY_COUNT; i++)
  {
    keySettings.sideKeyChar[i] = 'a' + MID_KEY_COUNT + i;
    keySettings.sideKeyStyle[i] = 0;
    keySettings.sideKeyMoveDirection[i] = i;
    keySettings.sideKeyMovePixel[i] = 1;
    keySettings.sideKeyReversePixel[i] = -100;
  }
  keySettings.holdThreshold = 100;
}

inline bool isKeySettingsWritten()
{
  return keySettings.statMark == 1;
}

inline void readEEPROM()
{
  EEPROM.get(0, keySettings);
}

inline void updateEEPROM()
{
  EEPROM.put(0, keySettings);
}

void initEEPROM()
{
  readEEPROM();
  if (!isKeySettingsWritten())
  {
    resetKeySettings();
    updateEEPROM();
  }
}

void initBoardPin()
{
  for (int i = 0; i < MID_KEY_COUNT; i++)
  {
    pinMode(MID_KEY_PIN[i], INPUT_PULLUP);
    pinMode(MID_KEY_LED[i], OUTPUT);
  }
  for (int i = 0; i < SIDE_KEY_COUNT; i++)
  {
    pinMode(SIDE_KEY_PIN[i], INPUT_PULLUP);
    pinMode(SIDE_KEY_LED[i], OUTPUT);
  }
}

inline void initSerial()
{
  Serial.begin(9600);
}

void commSendKeySettings()
{
  Serial.println(sizeof(keySettings));
  Serial.write((byte *)&keySettings, sizeof(keySettings));
  Serial.println();
}

void commReceiveKeySettings()
{
  int bufLen = sizeof(keySettings) + 4;
  int pos = 0;
  char buf[bufLen] = {0};
  char lastRead;
  while(1){
    if(!Serial.available()){
      delay(1);
      continue;
    }
    lastRead = Serial.read();
    if(lastRead == '\n')
      break;
    buf[pos++]=lastRead;
  }
  keySettings = *(KeySettings*)buf;
  Serial.println("OK");
  commSendKeySettings();
  updateEEPROM();
}

void procSerial() //Serial Comm, change settings;
{
  while (Serial.available())
  {
    serialString[serialStringPos] = Serial.read();
    if (serialString[serialStringPos] == '\n')
    {
      serialString[serialStringPos] = 0;
      serialStringPos = 0;
      serialStat = 1;
      break;
    }
    serialStringPos++;
  }
  if (serialStat == 1)
  {
    serialStat = 0;
    String comp = String(serialString);
    if (comp.equals(STR_COM_READ))
      commSendKeySettings();
    else if (comp.equals(STR_COM_UPDATE))
      commReceiveKeySettings();
    else
    {
      Serial.print("unknown command: ");
      Serial.println(serialString);
    }
  }
}

void procKeys()
{
  bool stat;
  for (int i = 0; i < MID_KEY_COUNT; i++)
  {
    stat = getMidKeyInput(i);
    if (stat != prevMidStat[i])
    {
      prevMidStat[i] = stat;
      if (stat)
      {
        Keyboard.press(keySettings.midKeyChar[i]);
        digitalWrite(MID_KEY_LED[i], HIGH);
      }
      else
      {
        Keyboard.release(keySettings.midKeyChar[i]);
        digitalWrite(MID_KEY_LED[i], LOW);
      }
    }
  }
  for (int i = 0; i < SIDE_KEY_COUNT; i++)
  {
    if (keySettings.sideKeyStyle[i] != 0)
      continue;
    stat = getSideKeyInput(i);
    if (stat != prevSideStat[i])
    {
      prevSideStat[i] = stat;
      if (stat)
      {
        Keyboard.press(keySettings.sideKeyChar[i]);
        digitalWrite(SIDE_KEY_LED[i], HIGH);
      }
      else
      {
        Keyboard.release(keySettings.sideKeyChar[i]);
        digitalWrite(SIDE_KEY_LED[i], LOW);
      }
    }
  }
}

void scratch(char axis, int dist)
{
  if (axis)
    Mouse.move(0, dist, 0);
  else
    Mouse.move(dist, 0, 0);
}

void procMouse()
{
  bool stat;
  for (int i = 0; i < SIDE_KEY_COUNT; i++)
  {
    if (keySettings.sideKeyStyle[i] == 0)
      continue;
    stat = getSideKeyInput(i);
    if (stat)
      scratch(keySettings.sideKeyMoveDirection[i], keySettings.sideKeyMovePixel[i]);
    if (stat != prevSideStat[i])
    {
      prevSideStat[i] = stat;
      if (stat)
      {
        prevSideDownTime[i] = millis();
        digitalWrite(SIDE_KEY_LED[i], HIGH);
      }
      else
      {
        if (keySettings.sideKeyStyle[i] == 2)
        {
          int t = millis() - prevSideDownTime[i];
          if (t >= keySettings.holdThreshold)
            scratch(keySettings.sideKeyMoveDirection[i], keySettings.sideKeyReversePixel[i]);
        }
        digitalWrite(SIDE_KEY_LED[i], LOW);
      }
    }
  }
}

void setup()
{
  initEEPROM();
  initBoardPin();
  initSerial();
  Keyboard.begin();
  Mouse.begin();
}

void loop()
{
  procSerial();
  procKeys();
  procMouse();
  delay(1);
}
