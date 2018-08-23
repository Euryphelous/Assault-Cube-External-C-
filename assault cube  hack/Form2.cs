using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;

namespace assault_cube__hack
{
    public partial class Form2 : Form
    {
        public Form2()

        {
            InitializeComponent();

        }

        VAMemory vam = new VAMemory("ac_client");

        public static int BASE = 0x00509B74;
        public static int health = 0xF8;
        public static int armor = 0xFC;

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form2 Form2 = new Form2();
            Hide();

            Form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int LocalPlayer = vam.ReadInt32((IntPtr)BASE);

            int HPAdress = LocalPlayer + health;

            int hpRead = vam.ReadInt32((IntPtr)HPAdress);

            string showHPRead = hpRead.ToString();

            label2.Text = showHPRead;

            int APAdress = LocalPlayer + health;

            int apRead = vam.ReadInt32((IntPtr)APAdress);

            string showAPRead = apRead.ToString();

            label4.Text = showAPRead;

            IntPtr xBase = Process.GetProcessesByName("ac_client").FirstOrDefault().MainModule.BaseAddress + 0x000987A4;

            IntPtr xoff = IntPtr.Add((IntPtr)vam.ReadInt32(xBase), 0x4);

            float readX = vam.ReadFloat((IntPtr)xoff);

            string showReadx = readX.ToString();

            label6.Text = showReadx;

            IntPtr yBase = Process.GetProcessesByName("ac_client").FirstOrDefault().MainModule.BaseAddress + 0x00007738;

            IntPtr yoff = IntPtr.Add((IntPtr)vam.ReadInt32(yBase), 0x0);

            float ready = vam.ReadFloat((IntPtr)yoff);

            string showReady = ready.ToString();

            label8.Text = showReady;

            IntPtr zBase = Process.GetProcessesByName("ac_client").FirstOrDefault().MainModule.BaseAddress + 0x00006FFC;

            IntPtr zoff = IntPtr.Add((IntPtr)vam.ReadInt32(zBase), 0x0);

            float readz = vam.ReadFloat((IntPtr)zoff);

            string showReadz = readz.ToString();

            label10.Text = showReadz;
        }
    }

}
