
namespace WindowsFormsApp1
{
    partial class IPForm
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.Control_ipAddress = new IPAddressControlLib.IPAddressControl();
            this.Control_mask = new IPAddressControlLib.IPAddressControl();
            this.Control_Gateway = new IPAddressControlLib.IPAddressControl();
            this.txb_metric = new System.Windows.Forms.TextBox();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.lbl_mask = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_static_route = new System.Windows.Forms.CheckBox();
            this.Control_eth_interfaceIndex = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(110, 195);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Отмена";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(29, 195);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 7;
            this.btn_Ok.Text = "Применить";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // Control_ipAddress
            // 
            this.Control_ipAddress.AllowInternalTab = false;
            this.Control_ipAddress.AutoHeight = true;
            this.Control_ipAddress.BackColor = System.Drawing.SystemColors.Window;
            this.Control_ipAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Control_ipAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Control_ipAddress.Location = new System.Drawing.Point(83, 42);
            this.Control_ipAddress.MinimumSize = new System.Drawing.Size(87, 20);
            this.Control_ipAddress.Name = "Control_ipAddress";
            this.Control_ipAddress.ReadOnly = false;
            this.Control_ipAddress.Size = new System.Drawing.Size(87, 20);
            this.Control_ipAddress.TabIndex = 1;
            this.Control_ipAddress.Text = "...";
            // 
            // Control_mask
            // 
            this.Control_mask.AllowInternalTab = false;
            this.Control_mask.AutoHeight = true;
            this.Control_mask.BackColor = System.Drawing.SystemColors.Window;
            this.Control_mask.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Control_mask.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Control_mask.Location = new System.Drawing.Point(83, 68);
            this.Control_mask.MinimumSize = new System.Drawing.Size(87, 20);
            this.Control_mask.Name = "Control_mask";
            this.Control_mask.ReadOnly = false;
            this.Control_mask.Size = new System.Drawing.Size(87, 20);
            this.Control_mask.TabIndex = 2;
            this.Control_mask.Text = "...";
            // 
            // Control_Gateway
            // 
            this.Control_Gateway.AllowInternalTab = false;
            this.Control_Gateway.AutoHeight = true;
            this.Control_Gateway.BackColor = System.Drawing.SystemColors.Window;
            this.Control_Gateway.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Control_Gateway.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Control_Gateway.Location = new System.Drawing.Point(83, 94);
            this.Control_Gateway.MinimumSize = new System.Drawing.Size(87, 20);
            this.Control_Gateway.Name = "Control_Gateway";
            this.Control_Gateway.ReadOnly = false;
            this.Control_Gateway.Size = new System.Drawing.Size(87, 20);
            this.Control_Gateway.TabIndex = 3;
            this.Control_Gateway.Text = "...";
            // 
            // txb_metric
            // 
            this.txb_metric.Enabled = false;
            this.txb_metric.Location = new System.Drawing.Point(105, 120);
            this.txb_metric.Name = "txb_metric";
            this.txb_metric.Size = new System.Drawing.Size(42, 20);
            this.txb_metric.TabIndex = 5;
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Location = new System.Drawing.Point(60, 45);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(17, 13);
            this.lbl_IP.TabIndex = 8;
            this.lbl_IP.Text = "IP";
            // 
            // lbl_mask
            // 
            this.lbl_mask.AutoSize = true;
            this.lbl_mask.Location = new System.Drawing.Point(37, 71);
            this.lbl_mask.Name = "lbl_mask";
            this.lbl_mask.Size = new System.Drawing.Size(40, 13);
            this.lbl_mask.TabIndex = 9;
            this.lbl_mask.Text = "Маска";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Шлюз";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Интерфейс";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Метрика";
            // 
            // cbx_static_route
            // 
            this.cbx_static_route.AutoSize = true;
            this.cbx_static_route.Location = new System.Drawing.Point(48, 146);
            this.cbx_static_route.Name = "cbx_static_route";
            this.cbx_static_route.Size = new System.Drawing.Size(137, 17);
            this.cbx_static_route.TabIndex = 6;
            this.cbx_static_route.Text = "Статический маршрут";
            this.cbx_static_route.UseVisualStyleBackColor = true;
            this.cbx_static_route.CheckedChanged += new System.EventHandler(this.cbx_static_route_CheckedChanged);
            // 
            // Control_eth_interfaceIndex
            // 
            this.Control_eth_interfaceIndex.Location = new System.Drawing.Point(128, 169);
            this.Control_eth_interfaceIndex.Name = "Control_eth_interfaceIndex";
            this.Control_eth_interfaceIndex.Size = new System.Drawing.Size(42, 20);
            this.Control_eth_interfaceIndex.TabIndex = 14;
            this.Control_eth_interfaceIndex.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(84, 124);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // IPForm
            // 
            this.AcceptButton = this.btn_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(208, 235);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Control_eth_interfaceIndex);
            this.Controls.Add(this.cbx_static_route);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_mask);
            this.Controls.Add(this.lbl_IP);
            this.Controls.Add(this.txb_metric);
            this.Controls.Add(this.Control_Gateway);
            this.Controls.Add(this.Control_mask);
            this.Controls.Add(this.Control_ipAddress);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IPForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры маршрута";
            this.Load += new System.EventHandler(this.IPForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ok;
        private IPAddressControlLib.IPAddressControl Control_ipAddress;
        private IPAddressControlLib.IPAddressControl Control_mask;
        private IPAddressControlLib.IPAddressControl Control_Gateway;
        private System.Windows.Forms.TextBox txb_metric;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Label lbl_mask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbx_static_route;
        private System.Windows.Forms.TextBox Control_eth_interfaceIndex;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}