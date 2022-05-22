using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class IPForm : Form
    {
        string persistance = null;
        string regime = null;
        Form1 form1;

        public IPForm(Form1 owner)
        {
            form1 = owner;
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Close();
        }

        private void IPForm_Load(object sender, EventArgs e)
        {
            get_environment();
        }

        public void get_environment()
        {
            string ipAdress = class_Route_parameters.adress;
            string mask = class_Route_parameters.mask;
            string gateway = class_Route_parameters.gateway;
            string eth_interface = class_Route_parameters.outinterface;
            string metric = class_Route_parameters.metric;
            string IntefaceIndex = class_Route_parameters.IntefaceIndex;
            regime = class_Route_parameters.cMS_string_select;


            Control_ipAddress.Text = ipAdress;
            Control_mask.Text = mask;
            Control_Gateway.Text = gateway;
            Control_eth_interfaceIndex.Text = IntefaceIndex;
            txb_metric.Text = metric;
        }

        private void CMD_Cstart(string cmd_action, string persistance, string ip, string mask, string gateway, string metric)
        {
            var process = new ProcessStartInfo()
            {
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                CreateNoWindow = true,
                Arguments = " /C " + cmd_action + " " + persistance + " " + ip + " mask " + mask + " " + gateway + " metric " + metric,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(process);
        }

        private void cbx_static_route_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_static_route.Checked) 
                 { persistance = "-p"; }
            else { persistance = null; }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            {
                Opacity = 0;
            }
            switch (regime)
            {
                case "Add":
                    CMD_Cstart(" route add ", persistance, Control_ipAddress.Text, Control_mask.Text, Control_Gateway.Text, txb_metric.Text);
                    break;

                case "Change":
                    CMD_Cstart(" route delete ", null , class_Route_parameters.adress, class_Route_parameters.mask, class_Route_parameters.gateway, null);
                    CMD_Cstart(" route add ", persistance, Control_ipAddress.Text, Control_mask.Text, Control_Gateway.Text, txb_metric.Text);
                    break;
            }
            //           IPForm.ActiveForm.Visible = false;
            form1.get_routes();
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txb_metric.Enabled = true;
            }
            else 
            { 
                txb_metric.Enabled = false;
                txb_metric.Text = null;
            }
        }
    }
    
}
