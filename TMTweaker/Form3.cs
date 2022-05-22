using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label3.Text = "Данный раздел находится в разработе";
            lbl_ConnectionID.Text = "Имя: " + class_NetworkAdapter_Settings.ConnectionName;
            lbl_adapter_name.Text = "Устройство: " + class_NetworkAdapter_Settings.Description;

            txb_MAC.Text = class_NetworkAdapter_Settings.MAC_Adress;
            mtxb_IP.Text = class_NetworkAdapter_Settings.IP_adress;
            mtxb_GW.Text = class_NetworkAdapter_Settings.Gateway;
            mtxb_Mask.Text = class_NetworkAdapter_Settings.Mask;
            mtxb_Metric.Text = class_NetworkAdapter_Settings.Metric;
            mtxb_DNS_1.Text = class_NetworkAdapter_Settings.DNS_1;
            mtxb_DNS_2.Text = class_NetworkAdapter_Settings.DNS_2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            void SendToCMD(string args, Encoding encoding)
            {
                var si = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    Arguments = args,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Normal,
                    StandardOutputEncoding = encoding
                };

                var cmd = Process.Start(si);

//                if (cmd != null)
//                    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            }

                try
                {
                    var rus = Encoding.GetEncoding(1251);
                    SendToCMD(@"/K ping ya.ru", null);
                    /*
                    SendToCMD(@"/C ipconfig /release", rus);
                    SendToCMD(@"/C ipconfig /renew", rus);
                    SendToCMD(@"/C arp -d *", rus);
                    SendToCMD(@"/C nbtstat -R", null);
                    SendToCMD(@"/C nbtstat -RR", null);
                    SendToCMD(@"/C ipconfig /flushdns", rus);
                    SendToCMD(@"/C ipconfig /registerdns", rus);
                    */
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            
        }

        private void lbl_Mask_Click(object sender, EventArgs e)
        {

        }
    }
}
