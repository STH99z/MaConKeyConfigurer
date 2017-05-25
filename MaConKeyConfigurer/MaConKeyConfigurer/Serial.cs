using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace MaConKeyConfigurer
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct KeySettings
    {
        public byte statMark;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = KeyConsts.MID_KEY_COUNT)]
        public byte[] midKeyChar;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = KeyConsts.SIDE_KEY_COUNT)]
        public byte[] sideKeyChar;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = KeyConsts.SIDE_KEY_COUNT)]
        public byte[] sideKeyStyle;         //0=key, 1=scratch no reverse, 2=scratch with reverse
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = KeyConsts.SIDE_KEY_COUNT)]
        public byte[] sideKeyMoveDirection; //0=x, 1=y
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = KeyConsts.SIDE_KEY_COUNT)]
        public short[] sideKeyMovePixel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = KeyConsts.SIDE_KEY_COUNT)]
        public short[] sideKeyReversePixel;
        public ushort holdThreshold; //hold time limit to trigger reverse scratch.

        public static KeySettings readFromBytes(byte[] data)
        {
            if (data.Length < KeyConsts.getStructSize())
                return new KeySettings();
            IntPtr ptr = Marshal.AllocHGlobal(KeyConsts.getStructSize());
            Marshal.Copy(data, 0, ptr, KeyConsts.getStructSize());
            var ks = (KeySettings)Marshal.PtrToStructure(ptr, typeof(KeySettings));
            Marshal.FreeHGlobal(ptr);
            return ks;
        }

        public KeySettings copy()
        {
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(this));
            Marshal.StructureToPtr(this, p, true);
            KeySettings copyOne = (KeySettings)Marshal.PtrToStructure(p, typeof(KeySettings));
            Marshal.FreeHGlobal(p);
            return copyOne;
        }

        public byte[] toBytes()
        {
            int size = KeyConsts.getStructSize();
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(this, ptr, true);
            byte[] data = new byte[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = Marshal.ReadByte(ptr, i);
            }
            Marshal.FreeHGlobal(ptr);
            return data;
        }
    }

    static class KeyConsts
    {
        public const ushort MID_KEY_COUNT = 7;
        public const ushort SIDE_KEY_COUNT = 2;
        public const string STR_COM_READ = "COM_R";
        public const string STR_COM_UPDATE = "COM_U";
        public static int getStructSize()
        {
            return Marshal.SizeOf(typeof(KeySettings));
        }
    }

    class Serial
    {
        static List<SerialPort> portPool = new List<SerialPort>();

        public static string[] getPortNames()
        {
            return SerialPort.GetPortNames();
        }

        public static SerialPort openPort(string name)
        {
            var port = new SerialPort(name, 9600);
            portPool.Add(port);
            port.NewLine = "\n";
            port.DtrEnable = true;
            port.ReadTimeout = 1000;
            port.WriteTimeout = 1000;
            port.Open();
            if (!port.IsOpen)
                throw new Exception("端口打开失败");
            return port;
        }

        public static void closePort(string name)
        {
            foreach (var port in portPool)
            {
                if (port.PortName.Equals(name))
                {
                    port.Close();
                    portPool.Remove(port);
                    port.Dispose();
                    return;
                }
            }
        }
    }
}
