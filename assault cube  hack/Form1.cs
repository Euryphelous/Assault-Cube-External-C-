using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace assault_cube__hack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        VAMemory vam = new VAMemory("ac_client");

        // [DllImport("kernel32.dll")]
        // public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte lpBuffer, int nSize, int lpNumberOfBytesWritten);

        // [DllImport("kernel32.dll")]
        // public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        /// <summary>
        /// Entity Base + offsets
        /// </summary>
        public static int EntityBase = 0x0010F4F4;
        public static int nameOffset = 0x225;

/// <summary>
/// Player Base + offsets
/// </summary>
        public static int BASE = 0x00509B74;
        public static int grenade = 0x158;
        public static int small = 0x5C;
        public static int fly = 0x338;
        public static int x = 0x34;
        public static int y = 0x38;    //public static int z_1 = 0x360;         public static int z_2 = 0x140;
        public static int z = 0x3C;
        public static int ghost = 0x80;
        public static int health = 0xF8;
        public static int armor = 0xFC;

        private void checkbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox1.Checked)
            {
                int LocalPlayer = vam.ReadInt32((IntPtr)BASE);
                int hpadress = LocalPlayer + health;
                vam.WriteInt32((IntPtr)hpadress, 999999);
            }
            else if (checkbox1.Checked == false)
            {
                int LocalPlayer = vam.ReadInt32((IntPtr)BASE);
                int hpadress = LocalPlayer + health;
                vam.WriteInt32((IntPtr)hpadress, 100);
            }
        }

        private void infAP_CheckedChanged(object sender, EventArgs e)
        {
            if (infAP.Checked)
            {
                int LocalPlayer = vam.ReadInt32((IntPtr)BASE);
                int armoradress = LocalPlayer + armor;
                vam.WriteInt32((IntPtr)armoradress, 999999);
            }
            else if (infAP.Checked == false)
            {
                int LocalPlayer = vam.ReadInt32((IntPtr)BASE);
                int armoradress = LocalPlayer + armor;
                vam.WriteInt32((IntPtr)armoradress, 100);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                int LocalPlayer = vam.ReadInt32((IntPtr)BASE);
                int ghostmode = LocalPlayer + ghost;
                vam.WriteInt32((IntPtr)ghostmode, 262144);
            }
            else if (checkBox2.Checked == false)
            {
                int LocalPlayer = vam.ReadInt32((IntPtr)BASE);
                int ghostmode = LocalPlayer + ghost;
                vam.WriteInt32((IntPtr)ghostmode, 0);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float value = (float)double.Parse(textBox1.Text);

            int LocalPlayer = vam.ReadInt32((IntPtr)BASE);
            float z_teleport = LocalPlayer + z;
            vam.WriteFloat((IntPtr)z_teleport, value);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            float value = (float)double.Parse(textBox3.Text);

            int LocalPlayer = vam.ReadInt32((IntPtr)BASE);
            float x_teleport = LocalPlayer + x;
            vam.WriteFloat((IntPtr)x_teleport, value);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            float value = (float)double.Parse(textBox2.Text);

            int LocalPlayer = vam.ReadInt32((IntPtr)BASE);
            float y_teleport = LocalPlayer + y;
            vam.WriteFloat((IntPtr)y_teleport, value);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            VAMemory vam = new VAMemory("ac_client");
            System.Threading.Thread.Sleep(1500);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                int LocalPlayer = vam.ReadInt32((IntPtr)BASE);
                int flyhack = LocalPlayer + fly;
                vam.WriteInt32((IntPtr)flyhack, 5);
            }
            else if (checkBox3.Checked == false)
            {
                int LocalPlayer = vam.ReadInt32((IntPtr)BASE);
                int flyhack = LocalPlayer + fly;
                vam.WriteInt32((IntPtr)flyhack, 0);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                VAMemory vam = new VAMemory("ac_client");

                IntPtr acBase = Process.GetProcessesByName("ac_client").FirstOrDefault().MainModule.BaseAddress + 0x0003D3A4;
                IntPtr off = IntPtr.Add((IntPtr)vam.ReadInt32(acBase), 0x108);

                int readEdit = vam.ReadInt32((IntPtr)off);

                vam.WriteInt32((IntPtr)off, 16777472);

                //string showEdit = readEdit.ToString();

                //MessageBox.Show(showEdit);

            }
            else if (checkBox4.Checked == false)
            {

                VAMemory vam = new VAMemory("ac_client");

                IntPtr acBase = Process.GetProcessesByName("ac_client").FirstOrDefault().MainModule.BaseAddress + 0x0003D3A4;

                IntPtr off = IntPtr.Add((IntPtr)vam.ReadInt32(acBase), 0x108);

                int readEdit = vam.ReadInt32((IntPtr)off);

                vam.WriteInt32((IntPtr)off, 0);

                //string showEdit = readEdit.ToString();

                //MessageBox.Show(showEdit);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form2 Form2 = new Form2();
            this.Hide();

            Form2.Show();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                int LocalPlayer = vam.ReadInt32((IntPtr)BASE);

                int SmallPlayer = LocalPlayer + small;

                vam.WriteInt32((IntPtr)SmallPlayer, 1065353216);
            }
            else if (checkBox5.Checked == false)
            {
                int LocalPlayer = vam.ReadInt32((IntPtr)BASE);

                int SmallPlayer = LocalPlayer + small;

                vam.WriteInt32((IntPtr)SmallPlayer, 1083179008);
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox6.Checked)
                {
                VAMemory vam = new VAMemory("ac_client");

                IntPtr grenadeBase = Process.GetProcessesByName("ac_client").FirstOrDefault().MainModule.BaseAddress + 0x00109B74;
                IntPtr grenadeOffset = IntPtr.Add((IntPtr)vam.ReadInt32(grenadeBase), grenade);

                vam.WriteInt32((IntPtr)grenadeOffset, 9999999);
               }

            else if(checkBox6.Checked == false)
            {
                VAMemory vam = new VAMemory("ac_client");

                IntPtr grenadeBase = Process.GetProcessesByName("ac_client").FirstOrDefault().MainModule.BaseAddress + 0x00109B74;
                IntPtr grenadeOffset = IntPtr.Add((IntPtr)vam.ReadInt32(grenadeBase), grenade);

                vam.WriteInt32((IntPtr)grenadeOffset, 0);
            }

        }
    }


}
      