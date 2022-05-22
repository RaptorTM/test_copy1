namespace WindowsFormsApp1
{
    partial class Form2_TMS_RBS_Backup
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
            this.txb_save_bkp_path = new System.Windows.Forms.TextBox();
            this.btn_Form2_Close = new System.Windows.Forms.Button();
            this.btn_Create_TMS_RBS_Backup = new System.Windows.Forms.Button();
            this.chbx_RBS_Create_backup = new System.Windows.Forms.CheckBox();
            this.chbx_TMS_Create_backup = new System.Windows.Forms.CheckBox();
            this.rbs_ok = new System.Windows.Forms.Label();
            this.tms_ok = new System.Windows.Forms.Label();
            this.cb_TMS_CFG = new System.Windows.Forms.CheckBox();
            this.cb_TMS_ARRAY = new System.Windows.Forms.CheckBox();
            this.cb_TMS_ALARMS = new System.Windows.Forms.CheckBox();
            this.cb_TMS_SECUR = new System.Windows.Forms.CheckBox();
            this.cb_RBS_BASES = new System.Windows.Forms.CheckBox();
            this.cb_RBS_SECUR = new System.Windows.Forms.CheckBox();
            this.lbl_PC_Name = new System.Windows.Forms.Label();
            this.lbl_RES_PS_Name = new System.Windows.Forms.Label();
            this.lbl_PO_Name = new System.Windows.Forms.Label();
            this.label_PC_name = new System.Windows.Forms.Label();
            this.label_PO_Name = new System.Windows.Forms.Label();
            this.label_RES_PS_Name = new System.Windows.Forms.Label();
            this.btn_SavePath = new System.Windows.Forms.Button();
            this.OIK_server_install_path = new System.Windows.Forms.TextBox();
            this.btn_OIKServerPath = new System.Windows.Forms.Button();
            this.btn_Browse_bkp_folder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txb_save_bkp_path
            // 
            this.txb_save_bkp_path.Location = new System.Drawing.Point(58, 161);
            this.txb_save_bkp_path.Name = "txb_save_bkp_path";
            this.txb_save_bkp_path.Size = new System.Drawing.Size(230, 20);
            this.txb_save_bkp_path.TabIndex = 1;
            this.txb_save_bkp_path.Text = "C:\\";
            // 
            // btn_Form2_Close
            // 
            this.btn_Form2_Close.Location = new System.Drawing.Point(243, 375);
            this.btn_Form2_Close.Name = "btn_Form2_Close";
            this.btn_Form2_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Form2_Close.TabIndex = 11;
            this.btn_Form2_Close.Text = "Выход";
            this.btn_Form2_Close.UseVisualStyleBackColor = true;
            this.btn_Form2_Close.Click += new System.EventHandler(this.Form2_Close_Click);
            // 
            // btn_Create_TMS_RBS_Backup
            // 
            this.btn_Create_TMS_RBS_Backup.Enabled = false;
            this.btn_Create_TMS_RBS_Backup.Location = new System.Drawing.Point(28, 375);
            this.btn_Create_TMS_RBS_Backup.Name = "btn_Create_TMS_RBS_Backup";
            this.btn_Create_TMS_RBS_Backup.Size = new System.Drawing.Size(75, 23);
            this.btn_Create_TMS_RBS_Backup.TabIndex = 10;
            this.btn_Create_TMS_RBS_Backup.Text = "Создать";
            this.btn_Create_TMS_RBS_Backup.UseVisualStyleBackColor = true;
            this.btn_Create_TMS_RBS_Backup.Click += new System.EventHandler(this.btn_Create_TMS_RBS_Backup_Click);
            // 
            // chbx_RBS_Create_backup
            // 
            this.chbx_RBS_Create_backup.AutoSize = true;
            this.chbx_RBS_Create_backup.Location = new System.Drawing.Point(30, 198);
            this.chbx_RBS_Create_backup.Name = "chbx_RBS_Create_backup";
            this.chbx_RBS_Create_backup.Size = new System.Drawing.Size(104, 17);
            this.chbx_RBS_Create_backup.TabIndex = 2;
            this.chbx_RBS_Create_backup.Text = "Сохранить RBS";
            this.chbx_RBS_Create_backup.UseVisualStyleBackColor = true;
            this.chbx_RBS_Create_backup.CheckedChanged += new System.EventHandler(this.chbx_RBS_Create_backup_CheckedChanged);
            // 
            // chbx_TMS_Create_backup
            // 
            this.chbx_TMS_Create_backup.AutoSize = true;
            this.chbx_TMS_Create_backup.Location = new System.Drawing.Point(28, 283);
            this.chbx_TMS_Create_backup.Name = "chbx_TMS_Create_backup";
            this.chbx_TMS_Create_backup.Size = new System.Drawing.Size(105, 17);
            this.chbx_TMS_Create_backup.TabIndex = 5;
            this.chbx_TMS_Create_backup.Text = "Сохранить TMS";
            this.chbx_TMS_Create_backup.UseVisualStyleBackColor = true;
            this.chbx_TMS_Create_backup.CheckedChanged += new System.EventHandler(this.chbx_TMS_Create_backup_CheckedChanged);
            // 
            // rbs_ok
            // 
            this.rbs_ok.AutoSize = true;
            this.rbs_ok.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbs_ok.ForeColor = System.Drawing.Color.ForestGreen;
            this.rbs_ok.Location = new System.Drawing.Point(151, 198);
            this.rbs_ok.Name = "rbs_ok";
            this.rbs_ok.Size = new System.Drawing.Size(51, 16);
            this.rbs_ok.TabIndex = 13;
            this.rbs_ok.Text = "Готово";
            this.rbs_ok.Visible = false;
            // 
            // tms_ok
            // 
            this.tms_ok.AutoSize = true;
            this.tms_ok.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tms_ok.ForeColor = System.Drawing.Color.ForestGreen;
            this.tms_ok.Location = new System.Drawing.Point(149, 284);
            this.tms_ok.Name = "tms_ok";
            this.tms_ok.Size = new System.Drawing.Size(51, 16);
            this.tms_ok.TabIndex = 14;
            this.tms_ok.Text = "Готово";
            this.tms_ok.Visible = false;
            // 
            // cb_TMS_CFG
            // 
            this.cb_TMS_CFG.AutoSize = true;
            this.cb_TMS_CFG.Enabled = false;
            this.cb_TMS_CFG.Location = new System.Drawing.Point(43, 306);
            this.cb_TMS_CFG.Name = "cb_TMS_CFG";
            this.cb_TMS_CFG.Size = new System.Drawing.Size(99, 17);
            this.cb_TMS_CFG.TabIndex = 6;
            this.cb_TMS_CFG.Text = "Конфигурация";
            this.cb_TMS_CFG.UseVisualStyleBackColor = true;
            this.cb_TMS_CFG.CheckedChanged += new System.EventHandler(this.cb_TMS_CFG_CheckedChanged);
            // 
            // cb_TMS_ARRAY
            // 
            this.cb_TMS_ARRAY.AutoSize = true;
            this.cb_TMS_ARRAY.Enabled = false;
            this.cb_TMS_ARRAY.Location = new System.Drawing.Point(43, 330);
            this.cb_TMS_ARRAY.Name = "cb_TMS_ARRAY";
            this.cb_TMS_ARRAY.Size = new System.Drawing.Size(115, 17);
            this.cb_TMS_ARRAY.TabIndex = 7;
            this.cb_TMS_ARRAY.Text = "Массив значений";
            this.cb_TMS_ARRAY.UseVisualStyleBackColor = true;
            this.cb_TMS_ARRAY.CheckedChanged += new System.EventHandler(this.cb_TMS_ARRAY_CheckedChanged);
            // 
            // cb_TMS_ALARMS
            // 
            this.cb_TMS_ALARMS.AutoSize = true;
            this.cb_TMS_ALARMS.Enabled = false;
            this.cb_TMS_ALARMS.Location = new System.Drawing.Point(159, 306);
            this.cb_TMS_ALARMS.Name = "cb_TMS_ALARMS";
            this.cb_TMS_ALARMS.Size = new System.Drawing.Size(123, 17);
            this.cb_TMS_ALARMS.TabIndex = 8;
            this.cb_TMS_ALARMS.Text = "Состояние уставок";
            this.cb_TMS_ALARMS.UseVisualStyleBackColor = true;
            this.cb_TMS_ALARMS.CheckedChanged += new System.EventHandler(this.cb_TMS_ALARMS_CheckedChanged);
            // 
            // cb_TMS_SECUR
            // 
            this.cb_TMS_SECUR.AutoSize = true;
            this.cb_TMS_SECUR.Enabled = false;
            this.cb_TMS_SECUR.Location = new System.Drawing.Point(159, 329);
            this.cb_TMS_SECUR.Name = "cb_TMS_SECUR";
            this.cb_TMS_SECUR.Size = new System.Drawing.Size(159, 17);
            this.cb_TMS_SECUR.TabIndex = 9;
            this.cb_TMS_SECUR.Text = "Параметры безопасности";
            this.cb_TMS_SECUR.UseVisualStyleBackColor = true;
            this.cb_TMS_SECUR.CheckedChanged += new System.EventHandler(this.cb_TMS_SECUR_CheckedChanged);
            // 
            // cb_RBS_BASES
            // 
            this.cb_RBS_BASES.AutoSize = true;
            this.cb_RBS_BASES.Enabled = false;
            this.cb_RBS_BASES.Location = new System.Drawing.Point(43, 221);
            this.cb_RBS_BASES.Name = "cb_RBS_BASES";
            this.cb_RBS_BASES.Size = new System.Drawing.Size(91, 17);
            this.cb_RBS_BASES.TabIndex = 3;
            this.cb_RBS_BASES.Text = "База данных";
            this.cb_RBS_BASES.UseVisualStyleBackColor = true;
            this.cb_RBS_BASES.CheckedChanged += new System.EventHandler(this.cb_RBS_BASES_CheckedChanged);
            // 
            // cb_RBS_SECUR
            // 
            this.cb_RBS_SECUR.AutoSize = true;
            this.cb_RBS_SECUR.Enabled = false;
            this.cb_RBS_SECUR.Location = new System.Drawing.Point(43, 245);
            this.cb_RBS_SECUR.Name = "cb_RBS_SECUR";
            this.cb_RBS_SECUR.Size = new System.Drawing.Size(159, 17);
            this.cb_RBS_SECUR.TabIndex = 4;
            this.cb_RBS_SECUR.Text = "Параметры безопасности";
            this.cb_RBS_SECUR.UseVisualStyleBackColor = true;
            this.cb_RBS_SECUR.CheckedChanged += new System.EventHandler(this.cb_RBS_SECUR_CheckedChanged);
            // 
            // lbl_PC_Name
            // 
            this.lbl_PC_Name.AutoSize = true;
            this.lbl_PC_Name.Location = new System.Drawing.Point(128, 40);
            this.lbl_PC_Name.Name = "lbl_PC_Name";
            this.lbl_PC_Name.Size = new System.Drawing.Size(71, 13);
            this.lbl_PC_Name.TabIndex = 23;
            this.lbl_PC_Name.Text = "lbl_PC_Name";
            // 
            // lbl_RES_PS_Name
            // 
            this.lbl_RES_PS_Name.AutoSize = true;
            this.lbl_RES_PS_Name.Location = new System.Drawing.Point(80, 76);
            this.lbl_RES_PS_Name.Name = "lbl_RES_PS_Name";
            this.lbl_RES_PS_Name.Size = new System.Drawing.Size(99, 13);
            this.lbl_RES_PS_Name.TabIndex = 28;
            this.lbl_RES_PS_Name.Text = "lbl_RES_PS_Name";
            // 
            // lbl_PO_Name
            // 
            this.lbl_PO_Name.AutoSize = true;
            this.lbl_PO_Name.Location = new System.Drawing.Point(55, 59);
            this.lbl_PO_Name.Name = "lbl_PO_Name";
            this.lbl_PO_Name.Size = new System.Drawing.Size(72, 13);
            this.lbl_PO_Name.TabIndex = 27;
            this.lbl_PO_Name.Text = "lbl_PO_Name";
            // 
            // label_PC_name
            // 
            this.label_PC_name.AutoSize = true;
            this.label_PC_name.Location = new System.Drawing.Point(29, 40);
            this.label_PC_name.Name = "label_PC_name";
            this.label_PC_name.Size = new System.Drawing.Size(98, 13);
            this.label_PC_name.TabIndex = 29;
            this.label_PC_name.Text = "Имя компьютера:";
            // 
            // label_PO_Name
            // 
            this.label_PO_Name.AutoSize = true;
            this.label_PO_Name.Location = new System.Drawing.Point(29, 59);
            this.label_PO_Name.Name = "label_PO_Name";
            this.label_PO_Name.Size = new System.Drawing.Size(26, 13);
            this.label_PO_Name.TabIndex = 30;
            this.label_PO_Name.Text = "ПО:";
            // 
            // label_RES_PS_Name
            // 
            this.label_RES_PS_Name.AutoSize = true;
            this.label_RES_PS_Name.Location = new System.Drawing.Point(29, 76);
            this.label_RES_PS_Name.Name = "label_RES_PS_Name";
            this.label_RES_PS_Name.Size = new System.Drawing.Size(51, 13);
            this.label_RES_PS_Name.TabIndex = 31;
            this.label_RES_PS_Name.Text = "РЭС\\ПС:";
            // 
            // btn_SavePath
            // 
            this.btn_SavePath.Location = new System.Drawing.Point(17, 158);
            this.btn_SavePath.Name = "btn_SavePath";
            this.btn_SavePath.Size = new System.Drawing.Size(35, 23);
            this.btn_SavePath.TabIndex = 94;
            this.btn_SavePath.Text = "...";
            this.btn_SavePath.UseVisualStyleBackColor = true;
            this.btn_SavePath.Click += new System.EventHandler(this.btn_SavePath_Click);
            // 
            // OIK_server_install_path
            // 
            this.OIK_server_install_path.Location = new System.Drawing.Point(58, 118);
            this.OIK_server_install_path.Name = "OIK_server_install_path";
            this.OIK_server_install_path.Size = new System.Drawing.Size(230, 20);
            this.OIK_server_install_path.TabIndex = 96;
            // 
            // btn_OIKServerPath
            // 
            this.btn_OIKServerPath.Location = new System.Drawing.Point(17, 116);
            this.btn_OIKServerPath.Name = "btn_OIKServerPath";
            this.btn_OIKServerPath.Size = new System.Drawing.Size(35, 23);
            this.btn_OIKServerPath.TabIndex = 97;
            this.btn_OIKServerPath.Text = "...";
            this.btn_OIKServerPath.UseVisualStyleBackColor = true;
            this.btn_OIKServerPath.Click += new System.EventHandler(this.btn_OIKServerPath_Click);
            // 
            // btn_Browse_bkp_folder
            // 
            this.btn_Browse_bkp_folder.Enabled = false;
            this.btn_Browse_bkp_folder.Location = new System.Drawing.Point(122, 375);
            this.btn_Browse_bkp_folder.Name = "btn_Browse_bkp_folder";
            this.btn_Browse_bkp_folder.Size = new System.Drawing.Size(96, 23);
            this.btn_Browse_bkp_folder.TabIndex = 98;
            this.btn_Browse_bkp_folder.Text = "Открыть папку";
            this.btn_Browse_bkp_folder.UseVisualStyleBackColor = true;
            this.btn_Browse_bkp_folder.Click += new System.EventHandler(this.btn_Browse_bkp_folder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 11);
            this.label2.TabIndex = 99;
            this.label2.Text = "Рабочая папка сервера ОИК:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(15, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 11);
            this.label3.TabIndex = 100;
            this.label3.Text = "Папка для резервных копий:";
            // 
            // Form2_TMS_RBS_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 420);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Browse_bkp_folder);
            this.Controls.Add(this.btn_OIKServerPath);
            this.Controls.Add(this.OIK_server_install_path);
            this.Controls.Add(this.btn_SavePath);
            this.Controls.Add(this.label_RES_PS_Name);
            this.Controls.Add(this.label_PO_Name);
            this.Controls.Add(this.label_PC_name);
            this.Controls.Add(this.lbl_RES_PS_Name);
            this.Controls.Add(this.lbl_PO_Name);
            this.Controls.Add(this.lbl_PC_Name);
            this.Controls.Add(this.cb_RBS_SECUR);
            this.Controls.Add(this.cb_RBS_BASES);
            this.Controls.Add(this.cb_TMS_SECUR);
            this.Controls.Add(this.cb_TMS_ALARMS);
            this.Controls.Add(this.cb_TMS_ARRAY);
            this.Controls.Add(this.cb_TMS_CFG);
            this.Controls.Add(this.tms_ok);
            this.Controls.Add(this.rbs_ok);
            this.Controls.Add(this.chbx_TMS_Create_backup);
            this.Controls.Add(this.chbx_RBS_Create_backup);
            this.Controls.Add(this.btn_Create_TMS_RBS_Backup);
            this.Controls.Add(this.btn_Form2_Close);
            this.Controls.Add(this.txb_save_bkp_path);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2_TMS_RBS_Backup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Резервное копирование";
            this.Load += new System.EventHandler(this.Form2_TMS_RBS_Backup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_save_bkp_path;
        private System.Windows.Forms.Button btn_Form2_Close;
        private System.Windows.Forms.Button btn_Create_TMS_RBS_Backup;
        private System.Windows.Forms.CheckBox chbx_RBS_Create_backup;
        private System.Windows.Forms.CheckBox chbx_TMS_Create_backup;
        private System.Windows.Forms.Label rbs_ok;
        private System.Windows.Forms.Label tms_ok;
        private System.Windows.Forms.CheckBox cb_TMS_CFG;
        private System.Windows.Forms.CheckBox cb_TMS_ARRAY;
        private System.Windows.Forms.CheckBox cb_TMS_ALARMS;
        private System.Windows.Forms.CheckBox cb_TMS_SECUR;
        private System.Windows.Forms.CheckBox cb_RBS_BASES;
        private System.Windows.Forms.CheckBox cb_RBS_SECUR;
        private System.Windows.Forms.Label lbl_PC_Name;
        public System.Windows.Forms.Label lbl_RES_PS_Name;
        public System.Windows.Forms.Label lbl_PO_Name;
        private System.Windows.Forms.Label label_PC_name;
        private System.Windows.Forms.Label label_PO_Name;
        private System.Windows.Forms.Label label_RES_PS_Name;
        private System.Windows.Forms.Button btn_SavePath;
        private System.Windows.Forms.TextBox OIK_server_install_path;
        private System.Windows.Forms.Button btn_OIKServerPath;
        private System.Windows.Forms.Button btn_Browse_bkp_folder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}