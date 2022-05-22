
namespace WindowsFormsApp1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_adapter_name = new System.Windows.Forms.Label();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.lbl_MAC = new System.Windows.Forms.Label();
            this.lbl_GW = new System.Windows.Forms.Label();
            this.lbl_Mask = new System.Windows.Forms.Label();
            this.lbl_metric = new System.Windows.Forms.Label();
            this.lbl_DNS1 = new System.Windows.Forms.Label();
            this.lbl_DNS2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtxb_IP = new IPAddressControlLib.IPAddressControl();
            this.mtxb_GW = new IPAddressControlLib.IPAddressControl();
            this.mtxb_Mask = new IPAddressControlLib.IPAddressControl();
            this.mtxb_Metric = new IPAddressControlLib.IPAddressControl();
            this.mtxb_DNS_1 = new IPAddressControlLib.IPAddressControl();
            this.mtxb_DNS_2 = new IPAddressControlLib.IPAddressControl();
            this.txb_MAC = new System.Windows.Forms.TextBox();
            this.lbl_ConnectionID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(140, 316);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_adapter_name
            // 
            this.lbl_adapter_name.AutoSize = true;
            this.lbl_adapter_name.Location = new System.Drawing.Point(12, 58);
            this.lbl_adapter_name.Name = "lbl_adapter_name";
            this.lbl_adapter_name.Size = new System.Drawing.Size(69, 13);
            this.lbl_adapter_name.TabIndex = 8;
            this.lbl_adapter_name.Text = "DeviceName";
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Location = new System.Drawing.Point(36, 117);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(20, 13);
            this.lbl_IP.TabIndex = 11;
            this.lbl_IP.Text = "IP:";
            // 
            // lbl_MAC
            // 
            this.lbl_MAC.AutoSize = true;
            this.lbl_MAC.Location = new System.Drawing.Point(26, 88);
            this.lbl_MAC.Name = "lbl_MAC";
            this.lbl_MAC.Size = new System.Drawing.Size(33, 13);
            this.lbl_MAC.TabIndex = 12;
            this.lbl_MAC.Text = "MAC:";
            // 
            // lbl_GW
            // 
            this.lbl_GW.AutoSize = true;
            this.lbl_GW.Location = new System.Drawing.Point(17, 144);
            this.lbl_GW.Name = "lbl_GW";
            this.lbl_GW.Size = new System.Drawing.Size(39, 13);
            this.lbl_GW.TabIndex = 13;
            this.lbl_GW.Text = "Шлюз:";
            // 
            // lbl_Mask
            // 
            this.lbl_Mask.AutoSize = true;
            this.lbl_Mask.Location = new System.Drawing.Point(16, 171);
            this.lbl_Mask.Name = "lbl_Mask";
            this.lbl_Mask.Size = new System.Drawing.Size(43, 13);
            this.lbl_Mask.TabIndex = 14;
            this.lbl_Mask.Text = "Маска:";
            this.lbl_Mask.Click += new System.EventHandler(this.lbl_Mask_Click);
            // 
            // lbl_metric
            // 
            this.lbl_metric.AutoSize = true;
            this.lbl_metric.Location = new System.Drawing.Point(5, 197);
            this.lbl_metric.Name = "lbl_metric";
            this.lbl_metric.Size = new System.Drawing.Size(54, 13);
            this.lbl_metric.TabIndex = 15;
            this.lbl_metric.Text = "Метрика:";
            // 
            // lbl_DNS1
            // 
            this.lbl_DNS1.AutoSize = true;
            this.lbl_DNS1.Location = new System.Drawing.Point(17, 233);
            this.lbl_DNS1.Name = "lbl_DNS1";
            this.lbl_DNS1.Size = new System.Drawing.Size(42, 13);
            this.lbl_DNS1.TabIndex = 16;
            this.lbl_DNS1.Text = "DNS 1:";
            // 
            // lbl_DNS2
            // 
            this.lbl_DNS2.AutoSize = true;
            this.lbl_DNS2.Location = new System.Drawing.Point(17, 259);
            this.lbl_DNS2.Name = "lbl_DNS2";
            this.lbl_DNS2.Size = new System.Drawing.Size(42, 13);
            this.lbl_DNS2.TabIndex = 17;
            this.lbl_DNS2.Text = "DNS 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(16, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 96;
            this.label3.Text = "label3";
            // 
            // mtxb_IP
            // 
            this.mtxb_IP.AllowInternalTab = false;
            this.mtxb_IP.AutoHeight = true;
            this.mtxb_IP.BackColor = System.Drawing.SystemColors.Window;
            this.mtxb_IP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mtxb_IP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mtxb_IP.Location = new System.Drawing.Point(65, 114);
            this.mtxb_IP.MinimumSize = new System.Drawing.Size(87, 20);
            this.mtxb_IP.Name = "mtxb_IP";
            this.mtxb_IP.ReadOnly = false;
            this.mtxb_IP.Size = new System.Drawing.Size(111, 20);
            this.mtxb_IP.TabIndex = 98;
            this.mtxb_IP.Text = "...";
            // 
            // mtxb_GW
            // 
            this.mtxb_GW.AllowInternalTab = false;
            this.mtxb_GW.AutoHeight = true;
            this.mtxb_GW.BackColor = System.Drawing.SystemColors.Window;
            this.mtxb_GW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mtxb_GW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mtxb_GW.Location = new System.Drawing.Point(65, 141);
            this.mtxb_GW.MinimumSize = new System.Drawing.Size(87, 20);
            this.mtxb_GW.Name = "mtxb_GW";
            this.mtxb_GW.ReadOnly = false;
            this.mtxb_GW.Size = new System.Drawing.Size(111, 20);
            this.mtxb_GW.TabIndex = 99;
            this.mtxb_GW.Text = "...";
            // 
            // mtxb_Mask
            // 
            this.mtxb_Mask.AllowInternalTab = false;
            this.mtxb_Mask.AutoHeight = true;
            this.mtxb_Mask.BackColor = System.Drawing.SystemColors.Window;
            this.mtxb_Mask.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mtxb_Mask.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mtxb_Mask.Location = new System.Drawing.Point(65, 168);
            this.mtxb_Mask.MinimumSize = new System.Drawing.Size(87, 20);
            this.mtxb_Mask.Name = "mtxb_Mask";
            this.mtxb_Mask.ReadOnly = false;
            this.mtxb_Mask.Size = new System.Drawing.Size(111, 20);
            this.mtxb_Mask.TabIndex = 100;
            this.mtxb_Mask.Text = "...";
            // 
            // mtxb_Metric
            // 
            this.mtxb_Metric.AllowInternalTab = false;
            this.mtxb_Metric.AutoHeight = true;
            this.mtxb_Metric.BackColor = System.Drawing.SystemColors.Window;
            this.mtxb_Metric.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mtxb_Metric.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mtxb_Metric.Location = new System.Drawing.Point(65, 194);
            this.mtxb_Metric.MinimumSize = new System.Drawing.Size(87, 20);
            this.mtxb_Metric.Name = "mtxb_Metric";
            this.mtxb_Metric.ReadOnly = false;
            this.mtxb_Metric.Size = new System.Drawing.Size(111, 20);
            this.mtxb_Metric.TabIndex = 101;
            this.mtxb_Metric.Text = "...";
            // 
            // mtxb_DNS_1
            // 
            this.mtxb_DNS_1.AllowInternalTab = false;
            this.mtxb_DNS_1.AutoHeight = true;
            this.mtxb_DNS_1.BackColor = System.Drawing.SystemColors.Window;
            this.mtxb_DNS_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mtxb_DNS_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mtxb_DNS_1.Location = new System.Drawing.Point(65, 230);
            this.mtxb_DNS_1.MinimumSize = new System.Drawing.Size(87, 20);
            this.mtxb_DNS_1.Name = "mtxb_DNS_1";
            this.mtxb_DNS_1.ReadOnly = false;
            this.mtxb_DNS_1.Size = new System.Drawing.Size(111, 20);
            this.mtxb_DNS_1.TabIndex = 102;
            this.mtxb_DNS_1.Text = "...";
            // 
            // mtxb_DNS_2
            // 
            this.mtxb_DNS_2.AllowInternalTab = false;
            this.mtxb_DNS_2.AutoHeight = true;
            this.mtxb_DNS_2.BackColor = System.Drawing.SystemColors.Window;
            this.mtxb_DNS_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mtxb_DNS_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mtxb_DNS_2.Location = new System.Drawing.Point(65, 256);
            this.mtxb_DNS_2.MinimumSize = new System.Drawing.Size(87, 20);
            this.mtxb_DNS_2.Name = "mtxb_DNS_2";
            this.mtxb_DNS_2.ReadOnly = false;
            this.mtxb_DNS_2.Size = new System.Drawing.Size(111, 20);
            this.mtxb_DNS_2.TabIndex = 103;
            this.mtxb_DNS_2.Text = "...";
            // 
            // txb_MAC
            // 
            this.txb_MAC.Enabled = false;
            this.txb_MAC.Location = new System.Drawing.Point(65, 85);
            this.txb_MAC.Name = "txb_MAC";
            this.txb_MAC.ReadOnly = true;
            this.txb_MAC.Size = new System.Drawing.Size(111, 20);
            this.txb_MAC.TabIndex = 104;
            // 
            // lbl_ConnectionID
            // 
            this.lbl_ConnectionID.AutoSize = true;
            this.lbl_ConnectionID.Location = new System.Drawing.Point(12, 45);
            this.lbl_ConnectionID.Name = "lbl_ConnectionID";
            this.lbl_ConnectionID.Size = new System.Drawing.Size(72, 13);
            this.lbl_ConnectionID.TabIndex = 105;
            this.lbl_ConnectionID.Text = "ConnectionID";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 401);
            this.Controls.Add(this.lbl_ConnectionID);
            this.Controls.Add(this.txb_MAC);
            this.Controls.Add(this.mtxb_DNS_2);
            this.Controls.Add(this.mtxb_DNS_1);
            this.Controls.Add(this.mtxb_Metric);
            this.Controls.Add(this.mtxb_Mask);
            this.Controls.Add(this.mtxb_GW);
            this.Controls.Add(this.mtxb_IP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_DNS2);
            this.Controls.Add(this.lbl_DNS1);
            this.Controls.Add(this.lbl_metric);
            this.Controls.Add(this.lbl_Mask);
            this.Controls.Add(this.lbl_GW);
            this.Controls.Add(this.lbl_MAC);
            this.Controls.Add(this.lbl_IP);
            this.Controls.Add(this.lbl_adapter_name);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка адаптера";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_adapter_name;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Label lbl_MAC;
        private System.Windows.Forms.Label lbl_GW;
        private System.Windows.Forms.Label lbl_Mask;
        private System.Windows.Forms.Label lbl_metric;
        private System.Windows.Forms.Label lbl_DNS1;
        private System.Windows.Forms.Label lbl_DNS2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private IPAddressControlLib.IPAddressControl mtxb_IP;
        private IPAddressControlLib.IPAddressControl mtxb_GW;
        private IPAddressControlLib.IPAddressControl mtxb_Mask;
        private IPAddressControlLib.IPAddressControl mtxb_Metric;
        private IPAddressControlLib.IPAddressControl mtxb_DNS_1;
        private IPAddressControlLib.IPAddressControl mtxb_DNS_2;
        private System.Windows.Forms.TextBox txb_MAC;
        private System.Windows.Forms.Label lbl_ConnectionID;
    }
}