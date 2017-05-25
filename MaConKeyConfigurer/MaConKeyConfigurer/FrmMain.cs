using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace MaConKeyConfigurer
{
    public partial class FrmMain : Form
    {
        SerialPort currentPort = null;
        KeySettings settings;
        bool settingsReady = false;
        int selectedSideKey = 0;
        Graphics g;

        public FrmMain()
        {
            InitializeComponent();
            this.refreshPorts();
            this.initMidKeys();
            tbData.Enabled = false;
        }

        private void initMidKeys()
        {
            dgMid.AllowUserToAddRows = false;
            for (int i = 0; i < KeyConsts.MID_KEY_COUNT; i++)
            {
                dgMid.Rows.Add("主键" + (i + 1) + (i % 2 == 0 ? "（白）" : "（黑）"), "");
            }
        }

        private void refreshPorts()
        {
            var portNames = Serial.getPortNames();
            this.cbPort.Items.Clear();
            this.cbPort.Items.AddRange(portNames);
            this.gbSerial.Text = "串口:" + portNames.Length.ToString();
            this.lbExpect.Text = KeyConsts.getStructSize().ToString();
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            this.refreshPorts();
        }

        private void btnHandshake_Click(object sender, EventArgs e)
        {
            if (cbPort.SelectedItem == null || cbPort.SelectedItem.ToString().Equals(""))
            {
                MessageBox.Show("未选择端口");
                return;
            }
            if (currentPort != null && currentPort.IsOpen)
                Serial.closePort(currentPort.PortName);
            currentPort = Serial.openPort(cbPort.SelectedItem.ToString());
            this.readKeyConfig();
            cbSide.SelectedIndex = 0;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentPort == null)
                return;
            Serial.closePort(currentPort.PortName);
        }

        private void readKeyConfig()
        {
            currentPort.WriteLine(KeyConsts.STR_COM_READ);
            string line = currentPort.ReadLine();
            tbData.Text = "";
            tbData.AppendText(line + "\n");
            int size = int.Parse(line);
            lbExact.Text = line;
            byte[] data = new byte[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = (byte)currentPort.ReadByte();
            }
            tbData.AppendText(byte2Hex(data));
            currentPort.ReadByte();
            settings = KeySettings.readFromBytes(data);
            settingsReady = true;
            fillControls();
            enableControls();
        }

        private string byte2Hex(byte[] data)
        {
            StringBuilder builder = new StringBuilder(data.Length * 3 + data.Length / 8 + 1);
            for (int i = 0; i < data.Length; i++)
            {
                if (i > 0 && i % 8 == 0)
                    builder.Append("\r\n");
                builder.Append(string.Format("{0:X2} ", data[i]));
            }
            return builder.ToString();
        }

        private void fillControls()
        {
            lbStat.Text = settings.statMark == 1 ? "OK" : "Error";
            for (int i = 0; i < KeyConsts.MID_KEY_COUNT; i++)
            {
                dgMid[1, i].Value = (char)settings.midKeyChar[i];
            }
            tbHoldThreshold.Text = settings.holdThreshold.ToString();
        }

        private void enableControls()
        {
            dgMid.Enabled = true;
            cbSide.Enabled = true;
            tbHoldThreshold.Enabled = true;
            btnSwap.Enabled = true;
        }

        private void cbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.sideKeyStyle[selectedSideKey] = (byte)cbStyle.SelectedIndex;
            if (cbStyle.SelectedIndex == 0)
            {
                tbMapping.Enabled = true;
                cbAxis.Enabled = false;
                tbFrameMove.Enabled = false;
                tbReverseMove.Enabled = false;
            }
            else
            {
                tbMapping.Enabled = false;
                cbAxis.Enabled = true;
                tbFrameMove.Enabled = true;
                tbReverseMove.Enabled = true;
            }
            renewTbData();
        }

        private void cbSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSide.SelectedIndex < 0 || cbSide.SelectedIndex > 1)
                return;
            int index = cbSide.SelectedIndex;
            int mode = settings.sideKeyStyle[index];
            char mapping = (char)settings.sideKeyChar[index];
            int axis = settings.sideKeyMoveDirection[index];
            int mov = settings.sideKeyMovePixel[index];
            int rev = settings.sideKeyReversePixel[index];
            this.selectedSideKey = index;
            cbStyle.Enabled = true;
            cbStyle.SelectedIndex = mode;
            tbMapping.Text = "" + mapping;
            cbAxis.SelectedIndex = axis;
            tbFrameMove.Text = mov.ToString();
            tbReverseMove.Text = rev.ToString();
        }

        private int swapIndex(int i)
        {
            return i == 0 ? 1 : 0;
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            var copy = settings.copy();
            for (int i = 0; i < 2; i++)
            {
                settings.sideKeyChar[i] = copy.sideKeyChar[swapIndex(i)];
                settings.sideKeyMoveDirection[i] = copy.sideKeyMoveDirection[swapIndex(i)];
                settings.sideKeyMovePixel[i] = copy.sideKeyMovePixel[swapIndex(i)];
                settings.sideKeyReversePixel[i] = copy.sideKeyReversePixel[swapIndex(i)];
                settings.sideKeyStyle[i] = copy.sideKeyStyle[swapIndex(i)];
            }
            cbSide.SelectedIndex = swapIndex(cbSide.SelectedIndex);
            renewTbData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            settings.statMark = 1;
            for (int i = 0; i < KeyConsts.MID_KEY_COUNT; i++)
            {
                settings.midKeyChar[i] = (byte)(dgMid[1, i].Value.ToString()[0]);
            }
            byte[] data = settings.toBytes();
            tbData.Text = KeyConsts.getStructSize().ToString() + "\n";
            tbData.AppendText(byte2Hex(data));
            currentPort.ReadExisting();
            currentPort.WriteLine(KeyConsts.STR_COM_UPDATE);
            currentPort.Write(data, 0, data.Length);
            currentPort.WriteLine("");
            MessageBox.Show(currentPort.ReadLine());
            string confirm = "数据确认\n" + currentPort.ReadLine() + "\n";
            int nl = 0;
            int pos = 0;
            while (true)
            {
                byte r = (byte)currentPort.ReadByte();
                if (r == (byte)'\r')
                    break;
                confirm += string.Format("{0:X2} ", r);
                if (nl == 7)
                {
                    confirm += "\n";
                    nl = 0;
                }
                else
                    nl++;
            }
            currentPort.ReadExisting();
            MessageBox.Show(confirm);
        }

        private void tbMapping_TextChanged(object sender, EventArgs e)
        {
            string line = tbMapping.Text;
            if (line.Length > 1)
                line = line.Substring(0, 1);
            if (line.Length == 1)
                settings.sideKeyChar[selectedSideKey] = (byte)line[0];
            tbMapping.Text = line;
            renewTbData();
        }

        private void cbAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = cbAxis.SelectedIndex;
            settings.sideKeyMoveDirection[selectedSideKey] = (byte)val;
            renewTbData();
        }

        private void tbFrameMove_TextChanged(object sender, EventArgs e)
        {
            string line = tbFrameMove.Text;
            int val = 1;
            try
            {
                val = int.Parse(line);
            }
            catch (Exception)
            {
                line = "1";
            }
            settings.sideKeyMovePixel[selectedSideKey] = (short)val;
            tbFrameMove.Text = line;
            renewTbData();
        }

        private void tbReverseMove_TextChanged(object sender, EventArgs e)
        {
            string line = tbReverseMove.Text;
            int val = -100;
            try
            {
                val = int.Parse(line);
            }
            catch (Exception)
            {
                line = "-100";
            }
            settings.sideKeyReversePixel[selectedSideKey] = (short)val;
            tbReverseMove.Text = line;
            renewTbData();
        }

        private void tbHoldThreshold_TextChanged(object sender, EventArgs e)
        {
            string line = tbHoldThreshold.Text;
            int val = 100;
            try
            {
                val = int.Parse(line);
            }
            catch (Exception)
            {
                line = "100";
            }
            settings.holdThreshold = (ushort)val;
            tbHoldThreshold.Text = line;
            renewTbData();
        }

        private void renewTbData()
        {
            tbData.Text = "";
            tbData.AppendText(KeyConsts.getStructSize().ToString() + "\n");
            tbData.AppendText(byte2Hex(settings.toBytes()));
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            if (cbPort.Items.Count >= 1)
                this.cbPort.SelectedIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (g == null)
                g = pb.CreateGraphics();
            int w = pb.Width - 2;
            int h = pb.Height - 2;
            Bitmap bmp = new Bitmap(w+2, h+2);
            Graphics g2 = Graphics.FromImage(bmp);
            double r = Math.Min(w, h) / 2;
            double cl = r * Math.PI * 2;
            double[] ang = new double[2];
            ang[0] = MousePosition.X / cl;
            ang[1] = MousePosition.Y / cl;
            PointF ct = new PointF(w / 2, h / 2);
            PointF[] p = new PointF[2];
            g2.FillRectangle(Brushes.White, 0, 0, w, h);
            g2.DrawEllipse(Pens.Black, 0, 0, w, h);
            for (int i = 0; i < 2; i++)
            {
                p[i] = new PointF((float)(ct.X + Math.Cos(ang[i]) * r),
                    (float)(ct.Y - Math.Sin(ang[i]) * r));
                g2.DrawLine(i == 0 ? Pens.Red : Pens.Blue, ct, p[i]);
            }
            g.DrawImage(bmp, 0, 0);
        }
    }
}
