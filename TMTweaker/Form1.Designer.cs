namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.monitor_optimize_off = new System.Windows.Forms.CheckBox();
            this.hdd_optimize_off = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sleep_mode_off = new System.Windows.Forms.CheckBox();
            this.hybernation_off = new System.Windows.Forms.CheckBox();
            this.uac_off = new System.Windows.Forms.CheckBox();
            this.firewall_off = new System.Windows.Forms.CheckBox();
            this.nla_off = new System.Windows.Forms.CheckBox();
            this.rdp_on = new System.Windows.Forms.CheckBox();
            this.winsearch_off = new System.Windows.Forms.CheckBox();
            this.superFetch_off = new System.Windows.Forms.CheckBox();
            this.checkBox_NumLock_on = new System.Windows.Forms.CheckBox();
            this.SetTimeSyncServer = new System.Windows.Forms.CheckBox();
            this.Change_System_Install_Time_СheckBox = new System.Windows.Forms.CheckBox();
            this.SetKMSServer = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.run_programm = new System.Windows.Forms.Button();
            this.changes_backup = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.OIK_folder_install_BrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ChangeWInSetupTime_Button = new System.Windows.Forms.Button();
            this.TimeZone = new System.Windows.Forms.Label();
            this.SystemTime = new System.Windows.Forms.Label();
            this.KMS_Server_Adress = new System.Windows.Forms.TextBox();
            this.Main_SNTP_Adress = new System.Windows.Forms.TextBox();
            this.Reserve_SNTP_Adress = new System.Windows.Forms.TextBox();
            this.Main_SNTP_Label = new System.Windows.Forms.Label();
            this.Reserve_SNTP_Label = new System.Windows.Forms.Label();
            this.W32Time_Servie_Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.System_Install_Date_Time_Label = new System.Windows.Forms.Label();
            this.Text_label_win_install_date = new System.Windows.Forms.Label();
            this.New_Instal_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label_Sync_interval = new System.Windows.Forms.Label();
            this.textBox_Sync_interval = new System.Windows.Forms.TextBox();
            this.button_user_add = new System.Windows.Forms.Button();
            this.textBox_user_name = new System.Windows.Forms.TextBox();
            this.button_user_initialise = new System.Windows.Forms.Button();
            this.checkBox_user_add_section = new System.Windows.Forms.CheckBox();
            this.textBox_user_pass = new System.Windows.Forms.TextBox();
            this.label_user_name = new System.Windows.Forms.Label();
            this.label_user_pass = new System.Windows.Forms.Label();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.chbx_admin_group = new System.Windows.Forms.CheckBox();
            this.chbx_Iface_operators_group = new System.Windows.Forms.CheckBox();
            this.chbx_users_groups = new System.Windows.Forms.CheckBox();
            this.chbx_users_RDP_group = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbx_Event_reader_group = new System.Windows.Forms.CheckBox();
            this.button_user_delete = new System.Windows.Forms.Button();
            this.panel_user_add = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.OS_Tweak_tab = new System.Windows.Forms.TabPage();
            this.chbx_NoInternetIcon = new System.Windows.Forms.CheckBox();
            this.cbx_check_All_OS = new System.Windows.Forms.CheckBox();
            this.lbl_need_reboot_UAC = new System.Windows.Forms.Label();
            this.lbl_need_reboot_WinDefender = new System.Windows.Forms.Label();
            this.cbx_WinTimeSVC_On = new System.Windows.Forms.CheckBox();
            this.checkBox_WindowsDefenderOff = new System.Windows.Forms.CheckBox();
            this.OIK_client_tab = new System.Windows.Forms.TabPage();
            this.chbx_ModusFontsDefault = new System.Windows.Forms.CheckBox();
            this.chbx_OIKFontsDefault = new System.Windows.Forms.CheckBox();
            this.chbx_SystemFontsDefault = new System.Windows.Forms.CheckBox();
            this.btn_TMS_Backup = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_win_folders_optimize = new System.Windows.Forms.CheckBox();
            this.checkBox_folder_OIK_rules = new System.Windows.Forms.CheckBox();
            this.checkBox_change_owner_OIK_folder = new System.Windows.Forms.CheckBox();
            this.OIK_install_path = new System.Windows.Forms.TextBox();
            this.Browse_oik_install_folder = new System.Windows.Forms.Button();
            this.btn_OIK_configTAB = new System.Windows.Forms.Button();
            this.cmb_mapping_disk = new System.Windows.Forms.ComboBox();
            this.textBox_path_modus_file_destination = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox_OIK_styles_copy = new System.Windows.Forms.CheckBox();
            this.textBox_path_modus_file = new System.Windows.Forms.TextBox();
            this.button_path_modus_file_copy = new System.Windows.Forms.Button();
            this.check_box_clear_clien_oik_settings = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.index_nuber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SID_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_LocalPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_loaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Network = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.Dinamic_Routes = new System.Windows.Forms.TabPage();
            this.lv_dynamic_route = new System.Windows.Forms.ListView();
            this.Numb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mask = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gateway = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Interface = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Metric = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WorkOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button5 = new System.Windows.Forms.Button();
            this.Static_Routes = new System.Windows.Forms.TabPage();
            this.lv_static_route = new System.Windows.Forms.ListView();
            this.Num_colum_static = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adress_colum_static = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mask_colum_static = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gateway_colum_static = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Metric_colum_static = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_adapters = new System.Windows.Forms.ListView();
            this.Num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Index_column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NetConnectionID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP_Adr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MAC_Adress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Net_Online = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_get_network_adapters = new System.Windows.Forms.Button();
            this.lbl_PC_name = new System.Windows.Forms.Label();
            this.lbl_VendorName = new System.Windows.Forms.Label();
            this.lbl_CPU = new System.Windows.Forms.Label();
            this.lbl_OS_info = new System.Windows.Forms.Label();
            this.lbl_hdd_model = new System.Windows.Forms.Label();
            this.lbl_Memory_modules = new System.Windows.Forms.Label();
            this.lbl_MB = new System.Windows.Forms.Label();
            this.btn_PC_conf_update = new System.Windows.Forms.Button();
            this.btn_PC_conf_export = new System.Windows.Forms.Button();
            this.lbl_BIOS_Vendor = new System.Windows.Forms.Label();
            this.lbl_BIOS_ver = new System.Windows.Forms.Label();
            this.lbl_GPU = new System.Windows.Forms.Label();
            this.lbl_BIOS_relese_date = new System.Windows.Forms.Label();
            this.cmbox_memory = new System.Windows.Forms.ComboBox();
            this.cmbox_hdd = new System.Windows.Forms.ComboBox();
            this.lbl_OS_version = new System.Windows.Forms.Label();
            this.cMS_adapters = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_Adatres_Copy_Cell = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_Adatres_Copy_MAC = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_Adatres_Copy_String = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_Adatres_Config_Adapter = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_OIK_User = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cMS_OIK_User_Open_Profile_Folder = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_OIK_Copy_UserName = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_OIK_CopySID = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_OIK_Copy_User_Path = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_OIK_Reg_path_open = new System.Windows.Forms.ToolStripMenuItem();
            this.Prog_Version = new System.Windows.Forms.Label();
            this.lbl_SerialNumber = new System.Windows.Forms.Label();
            this.cMS_route_edit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Refres = new System.Windows.Forms.ToolStripMenuItem();
            this.Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.Change = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.button6 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.OS_Tweak_tab.SuspendLayout();
            this.OIK_client_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Network.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.Dinamic_Routes.SuspendLayout();
            this.Static_Routes.SuspendLayout();
            this.cMS_adapters.SuspendLayout();
            this.cMS_OIK_User.SuspendLayout();
            this.cMS_route_edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // monitor_optimize_off
            // 
            this.monitor_optimize_off.AutoSize = true;
            this.monitor_optimize_off.Location = new System.Drawing.Point(480, 298);
            this.monitor_optimize_off.Name = "monitor_optimize_off";
            this.monitor_optimize_off.Size = new System.Drawing.Size(254, 17);
            this.monitor_optimize_off.TabIndex = 32;
            this.monitor_optimize_off.Text = "Отключить энергосбережение для монитора";
            this.monitor_optimize_off.UseVisualStyleBackColor = true;
            // 
            // hdd_optimize_off
            // 
            this.hdd_optimize_off.AutoSize = true;
            this.hdd_optimize_off.Location = new System.Drawing.Point(480, 321);
            this.hdd_optimize_off.Name = "hdd_optimize_off";
            this.hdd_optimize_off.Size = new System.Drawing.Size(158, 17);
            this.hdd_optimize_off.TabIndex = 33;
            this.hdd_optimize_off.Text = "Отключить парковку HDD";
            this.hdd_optimize_off.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(477, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Параметры энергосбережения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(477, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Настройки ОС Windows 7-10";
            // 
            // sleep_mode_off
            // 
            this.sleep_mode_off.AutoSize = true;
            this.sleep_mode_off.Location = new System.Drawing.Point(480, 367);
            this.sleep_mode_off.Name = "sleep_mode_off";
            this.sleep_mode_off.Size = new System.Drawing.Size(211, 17);
            this.sleep_mode_off.TabIndex = 35;
            this.sleep_mode_off.Text = "Запретить переход в спящий режим";
            this.sleep_mode_off.UseVisualStyleBackColor = true;
            // 
            // hybernation_off
            // 
            this.hybernation_off.AutoSize = true;
            this.hybernation_off.Location = new System.Drawing.Point(480, 344);
            this.hybernation_off.Name = "hybernation_off";
            this.hybernation_off.Size = new System.Drawing.Size(145, 17);
            this.hybernation_off.TabIndex = 34;
            this.hybernation_off.Text = "Отключить гибернацию";
            this.hybernation_off.UseVisualStyleBackColor = true;
            // 
            // uac_off
            // 
            this.uac_off.AutoSize = true;
            this.uac_off.Location = new System.Drawing.Point(480, 62);
            this.uac_off.Name = "uac_off";
            this.uac_off.Size = new System.Drawing.Size(251, 17);
            this.uac_off.TabIndex = 23;
            this.uac_off.Text = "Отключить UAC (Контроль учётных записей)";
            this.uac_off.UseVisualStyleBackColor = true;
            this.uac_off.CheckedChanged += new System.EventHandler(this.uac_off_CheckedChanged);
            // 
            // firewall_off
            // 
            this.firewall_off.AutoSize = true;
            this.firewall_off.Location = new System.Drawing.Point(480, 39);
            this.firewall_off.Name = "firewall_off";
            this.firewall_off.Size = new System.Drawing.Size(193, 17);
            this.firewall_off.TabIndex = 22;
            this.firewall_off.Text = "Отключить Брандмауэр Windows";
            this.firewall_off.UseVisualStyleBackColor = true;
            // 
            // nla_off
            // 
            this.nla_off.AutoSize = true;
            this.nla_off.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nla_off.Cursor = System.Windows.Forms.Cursors.Default;
            this.nla_off.Location = new System.Drawing.Point(480, 108);
            this.nla_off.Name = "nla_off";
            this.nla_off.Size = new System.Drawing.Size(240, 17);
            this.nla_off.TabIndex = 25;
            this.nla_off.Text = "Отключить проверку на уровне сети (NLA)";
            this.nla_off.UseVisualStyleBackColor = false;
            // 
            // rdp_on
            // 
            this.rdp_on.AutoSize = true;
            this.rdp_on.Location = new System.Drawing.Point(480, 200);
            this.rdp_on.Name = "rdp_on";
            this.rdp_on.Size = new System.Drawing.Size(101, 17);
            this.rdp_on.TabIndex = 29;
            this.rdp_on.Text = "Включить RDP";
            this.rdp_on.UseVisualStyleBackColor = true;
            // 
            // winsearch_off
            // 
            this.winsearch_off.AutoSize = true;
            this.winsearch_off.Location = new System.Drawing.Point(480, 154);
            this.winsearch_off.Name = "winsearch_off";
            this.winsearch_off.Size = new System.Drawing.Size(165, 17);
            this.winsearch_off.TabIndex = 27;
            this.winsearch_off.Text = "Отключить Windows Search";
            this.winsearch_off.UseVisualStyleBackColor = true;
            // 
            // superFetch_off
            // 
            this.superFetch_off.AutoSize = true;
            this.superFetch_off.Location = new System.Drawing.Point(480, 131);
            this.superFetch_off.Name = "superFetch_off";
            this.superFetch_off.Size = new System.Drawing.Size(139, 17);
            this.superFetch_off.TabIndex = 26;
            this.superFetch_off.Text = "Отключить SuperFetch";
            this.superFetch_off.UseVisualStyleBackColor = true;
            // 
            // checkBox_NumLock_on
            // 
            this.checkBox_NumLock_on.AutoSize = true;
            this.checkBox_NumLock_on.Location = new System.Drawing.Point(480, 223);
            this.checkBox_NumLock_on.Name = "checkBox_NumLock_on";
            this.checkBox_NumLock_on.Size = new System.Drawing.Size(124, 17);
            this.checkBox_NumLock_on.TabIndex = 30;
            this.checkBox_NumLock_on.Text = "Включить NumLock";
            this.checkBox_NumLock_on.UseVisualStyleBackColor = true;
            // 
            // SetTimeSyncServer
            // 
            this.SetTimeSyncServer.AutoSize = true;
            this.SetTimeSyncServer.Location = new System.Drawing.Point(15, 75);
            this.SetTimeSyncServer.Name = "SetTimeSyncServer";
            this.SetTimeSyncServer.Size = new System.Drawing.Size(249, 17);
            this.SetTimeSyncServer.TabIndex = 3;
            this.SetTimeSyncServer.Text = "Настроить сервер синхронизации времени:";
            this.SetTimeSyncServer.UseVisualStyleBackColor = true;
            this.SetTimeSyncServer.CheckedChanged += new System.EventHandler(this.SetTimeSyncServer_CheckedChanged);
            // 
            // Change_System_Install_Time_СheckBox
            // 
            this.Change_System_Install_Time_СheckBox.AutoSize = true;
            this.Change_System_Install_Time_СheckBox.Location = new System.Drawing.Point(15, 177);
            this.Change_System_Install_Time_СheckBox.Name = "Change_System_Install_Time_СheckBox";
            this.Change_System_Install_Time_СheckBox.Size = new System.Drawing.Size(175, 17);
            this.Change_System_Install_Time_СheckBox.TabIndex = 7;
            this.Change_System_Install_Time_СheckBox.Text = "Изменить дату установки ОС";
            this.Change_System_Install_Time_СheckBox.UseVisualStyleBackColor = true;
            this.Change_System_Install_Time_СheckBox.CheckedChanged += new System.EventHandler(this.Change_System_Install_Time_СheckBox_CheckedChanged);
            // 
            // SetKMSServer
            // 
            this.SetKMSServer.AutoSize = true;
            this.SetKMSServer.Location = new System.Drawing.Point(15, 52);
            this.SetKMSServer.Name = "SetKMSServer";
            this.SetKMSServer.Size = new System.Drawing.Size(196, 17);
            this.SetKMSServer.TabIndex = 1;
            this.SetKMSServer.Text = "Настроить сервер активации ОС:";
            this.SetKMSServer.UseVisualStyleBackColor = true;
            this.SetKMSServer.CheckedChanged += new System.EventHandler(this.SetKMSServer_CheckedChanged);
            // 
            // run_programm
            // 
            this.run_programm.Location = new System.Drawing.Point(581, 436);
            this.run_programm.Name = "run_programm";
            this.run_programm.Size = new System.Drawing.Size(75, 23);
            this.run_programm.TabIndex = 38;
            this.run_programm.Text = "Применить";
            this.run_programm.UseVisualStyleBackColor = true;
            this.run_programm.Click += new System.EventHandler(this.run_programm_Click);
            // 
            // changes_backup
            // 
            this.changes_backup.Location = new System.Drawing.Point(394, 453);
            this.changes_backup.Name = "changes_backup";
            this.changes_backup.Size = new System.Drawing.Size(137, 23);
            this.changes_backup.TabIndex = 39;
            this.changes_backup.Text = "Отменить изменения";
            this.changes_backup.UseVisualStyleBackColor = true;
            this.changes_backup.Visible = false;
            this.changes_backup.Click += new System.EventHandler(this.changes_backup_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(1049, 514);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 40;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ChangeWInSetupTime_Button
            // 
            this.ChangeWInSetupTime_Button.Enabled = false;
            this.ChangeWInSetupTime_Button.Location = new System.Drawing.Point(225, 200);
            this.ChangeWInSetupTime_Button.Name = "ChangeWInSetupTime_Button";
            this.ChangeWInSetupTime_Button.Size = new System.Drawing.Size(76, 21);
            this.ChangeWInSetupTime_Button.TabIndex = 9;
            this.ChangeWInSetupTime_Button.Text = "Применить";
            this.ChangeWInSetupTime_Button.UseVisualStyleBackColor = true;
            this.ChangeWInSetupTime_Button.Click += new System.EventHandler(this.ChangeWInSetupTime_Click);
            // 
            // TimeZone
            // 
            this.TimeZone.AutoSize = true;
            this.TimeZone.Location = new System.Drawing.Point(12, 441);
            this.TimeZone.Name = "TimeZone";
            this.TimeZone.Size = new System.Drawing.Size(55, 13);
            this.TimeZone.TabIndex = 47;
            this.TimeZone.Text = "TimeZone";
            // 
            // SystemTime
            // 
            this.SystemTime.AutoSize = true;
            this.SystemTime.Location = new System.Drawing.Point(12, 416);
            this.SystemTime.Name = "SystemTime";
            this.SystemTime.Size = new System.Drawing.Size(59, 13);
            this.SystemTime.TabIndex = 49;
            this.SystemTime.Text = "Date_Time";
            // 
            // KMS_Server_Adress
            // 
            this.KMS_Server_Adress.Enabled = false;
            this.KMS_Server_Adress.Location = new System.Drawing.Point(214, 50);
            this.KMS_Server_Adress.MaxLength = 32;
            this.KMS_Server_Adress.Name = "KMS_Server_Adress";
            this.KMS_Server_Adress.Size = new System.Drawing.Size(113, 20);
            this.KMS_Server_Adress.TabIndex = 2;
            this.KMS_Server_Adress.Text = "10.62.4.101";
            // 
            // Main_SNTP_Adress
            // 
            this.Main_SNTP_Adress.Enabled = false;
            this.Main_SNTP_Adress.Location = new System.Drawing.Point(182, 98);
            this.Main_SNTP_Adress.MaxLength = 24;
            this.Main_SNTP_Adress.Name = "Main_SNTP_Adress";
            this.Main_SNTP_Adress.Size = new System.Drawing.Size(100, 20);
            this.Main_SNTP_Adress.TabIndex = 4;
            this.Main_SNTP_Adress.Text = "10.31.127.10";
            // 
            // Reserve_SNTP_Adress
            // 
            this.Reserve_SNTP_Adress.Enabled = false;
            this.Reserve_SNTP_Adress.Location = new System.Drawing.Point(182, 124);
            this.Reserve_SNTP_Adress.MaxLength = 24;
            this.Reserve_SNTP_Adress.Name = "Reserve_SNTP_Adress";
            this.Reserve_SNTP_Adress.Size = new System.Drawing.Size(100, 20);
            this.Reserve_SNTP_Adress.TabIndex = 5;
            this.Reserve_SNTP_Adress.Text = "10.40.127.10";
            // 
            // Main_SNTP_Label
            // 
            this.Main_SNTP_Label.AutoSize = true;
            this.Main_SNTP_Label.Location = new System.Drawing.Point(44, 101);
            this.Main_SNTP_Label.Name = "Main_SNTP_Label";
            this.Main_SNTP_Label.Size = new System.Drawing.Size(131, 13);
            this.Main_SNTP_Label.TabIndex = 53;
            this.Main_SNTP_Label.Text = "Основной сервер SNTP:";
            // 
            // Reserve_SNTP_Label
            // 
            this.Reserve_SNTP_Label.AutoSize = true;
            this.Reserve_SNTP_Label.Location = new System.Drawing.Point(44, 127);
            this.Reserve_SNTP_Label.Name = "Reserve_SNTP_Label";
            this.Reserve_SNTP_Label.Size = new System.Drawing.Size(138, 13);
            this.Reserve_SNTP_Label.TabIndex = 54;
            this.Reserve_SNTP_Label.Text = "Резервный сервер SNTP:";
            // 
            // W32Time_Servie_Label
            // 
            this.W32Time_Servie_Label.AutoSize = true;
            this.W32Time_Servie_Label.Location = new System.Drawing.Point(12, 468);
            this.W32Time_Servie_Label.Name = "W32Time_Servie_Label";
            this.W32Time_Servie_Label.Size = new System.Drawing.Size(89, 13);
            this.W32Time_Servie_Label.TabIndex = 55;
            this.W32Time_Servie_Label.Text = "W32Time_Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(10, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Новая дата:";
            // 
            // System_Install_Date_Time_Label
            // 
            this.System_Install_Date_Time_Label.AutoSize = true;
            this.System_Install_Date_Time_Label.Location = new System.Drawing.Point(119, 492);
            this.System_Install_Date_Time_Label.Name = "System_Install_Date_Time_Label";
            this.System_Install_Date_Time_Label.Size = new System.Drawing.Size(132, 13);
            this.System_Install_Date_Time_Label.TabIndex = 61;
            this.System_Install_Date_Time_Label.Text = "System_Install_Date_Time";
            // 
            // Text_label_win_install_date
            // 
            this.Text_label_win_install_date.AutoSize = true;
            this.Text_label_win_install_date.Location = new System.Drawing.Point(12, 492);
            this.Text_label_win_install_date.Name = "Text_label_win_install_date";
            this.Text_label_win_install_date.Size = new System.Drawing.Size(109, 13);
            this.Text_label_win_install_date.TabIndex = 62;
            this.Text_label_win_install_date.Text = "Дата установки ОС:";
            // 
            // New_Instal_dateTimePicker
            // 
            this.New_Instal_dateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.New_Instal_dateTimePicker.Enabled = false;
            this.New_Instal_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.New_Instal_dateTimePicker.Location = new System.Drawing.Point(81, 200);
            this.New_Instal_dateTimePicker.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.New_Instal_dateTimePicker.Name = "New_Instal_dateTimePicker";
            this.New_Instal_dateTimePicker.Size = new System.Drawing.Size(138, 20);
            this.New_Instal_dateTimePicker.TabIndex = 8;
            // 
            // label_Sync_interval
            // 
            this.label_Sync_interval.AutoSize = true;
            this.label_Sync_interval.Location = new System.Drawing.Point(45, 153);
            this.label_Sync_interval.Name = "label_Sync_interval";
            this.label_Sync_interval.Size = new System.Drawing.Size(159, 13);
            this.label_Sync_interval.TabIndex = 64;
            this.label_Sync_interval.Text = "Частота синхронизации (сек):";
            // 
            // textBox_Sync_interval
            // 
            this.textBox_Sync_interval.Enabled = false;
            this.textBox_Sync_interval.Location = new System.Drawing.Point(206, 151);
            this.textBox_Sync_interval.MaxLength = 8;
            this.textBox_Sync_interval.Name = "textBox_Sync_interval";
            this.textBox_Sync_interval.Size = new System.Drawing.Size(72, 20);
            this.textBox_Sync_interval.TabIndex = 6;
            this.textBox_Sync_interval.Text = "300";
            this.textBox_Sync_interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Sync_interval.TextChanged += new System.EventHandler(this.textBox_Sync_interval_TextChanged);
            // 
            // button_user_add
            // 
            this.button_user_add.Enabled = false;
            this.button_user_add.Location = new System.Drawing.Point(26, 365);
            this.button_user_add.Name = "button_user_add";
            this.button_user_add.Size = new System.Drawing.Size(75, 23);
            this.button_user_add.TabIndex = 19;
            this.button_user_add.Text = "Создать";
            this.button_user_add.UseVisualStyleBackColor = true;
            this.button_user_add.Click += new System.EventHandler(this.button_user_add_Click);
            // 
            // textBox_user_name
            // 
            this.textBox_user_name.Enabled = false;
            this.textBox_user_name.Location = new System.Drawing.Point(110, 301);
            this.textBox_user_name.MaxLength = 32;
            this.textBox_user_name.Name = "textBox_user_name";
            this.textBox_user_name.Size = new System.Drawing.Size(100, 20);
            this.textBox_user_name.TabIndex = 12;
            // 
            // button_user_initialise
            // 
            this.button_user_initialise.Enabled = false;
            this.button_user_initialise.Location = new System.Drawing.Point(108, 365);
            this.button_user_initialise.Name = "button_user_initialise";
            this.button_user_initialise.Size = new System.Drawing.Size(114, 23);
            this.button_user_initialise.TabIndex = 20;
            this.button_user_initialise.Text = "Инициализировать";
            this.button_user_initialise.UseVisualStyleBackColor = true;
            // 
            // checkBox_user_add_section
            // 
            this.checkBox_user_add_section.AutoSize = true;
            this.checkBox_user_add_section.Location = new System.Drawing.Point(14, 277);
            this.checkBox_user_add_section.Name = "checkBox_user_add_section";
            this.checkBox_user_add_section.Size = new System.Drawing.Size(208, 17);
            this.checkBox_user_add_section.TabIndex = 11;
            this.checkBox_user_add_section.Text = "Настройка пользователей Windows";
            this.checkBox_user_add_section.UseVisualStyleBackColor = true;
            this.checkBox_user_add_section.CheckedChanged += new System.EventHandler(this.checkBox_user_add_section_CheckedChanged);
            // 
            // textBox_user_pass
            // 
            this.textBox_user_pass.Enabled = false;
            this.textBox_user_pass.Location = new System.Drawing.Point(110, 328);
            this.textBox_user_pass.MaxLength = 16;
            this.textBox_user_pass.Name = "textBox_user_pass";
            this.textBox_user_pass.Size = new System.Drawing.Size(100, 20);
            this.textBox_user_pass.TabIndex = 13;
            // 
            // label_user_name
            // 
            this.label_user_name.AutoSize = true;
            this.label_user_name.Location = new System.Drawing.Point(49, 304);
            this.label_user_name.Name = "label_user_name";
            this.label_user_name.Size = new System.Drawing.Size(29, 13);
            this.label_user_name.TabIndex = 72;
            this.label_user_name.Text = "Имя";
            // 
            // label_user_pass
            // 
            this.label_user_pass.AutoSize = true;
            this.label_user_pass.Location = new System.Drawing.Point(50, 334);
            this.label_user_pass.Name = "label_user_pass";
            this.label_user_pass.Size = new System.Drawing.Size(45, 13);
            this.label_user_pass.TabIndex = 73;
            this.label_user_pass.Text = "Пароль";
            // 
            // chbx_admin_group
            // 
            this.chbx_admin_group.AutoSize = true;
            this.chbx_admin_group.Enabled = false;
            this.chbx_admin_group.Location = new System.Drawing.Point(242, 300);
            this.chbx_admin_group.Name = "chbx_admin_group";
            this.chbx_admin_group.Size = new System.Drawing.Size(113, 17);
            this.chbx_admin_group.TabIndex = 14;
            this.chbx_admin_group.Text = "Администраторы";
            this.chbx_admin_group.UseVisualStyleBackColor = true;
            // 
            // chbx_Iface_operators_group
            // 
            this.chbx_Iface_operators_group.AutoSize = true;
            this.chbx_Iface_operators_group.Enabled = false;
            this.chbx_Iface_operators_group.Location = new System.Drawing.Point(242, 322);
            this.chbx_Iface_operators_group.Name = "chbx_Iface_operators_group";
            this.chbx_Iface_operators_group.Size = new System.Drawing.Size(100, 17);
            this.chbx_Iface_operators_group.TabIndex = 15;
            this.chbx_Iface_operators_group.Text = "Iface_operators";
            this.chbx_Iface_operators_group.UseVisualStyleBackColor = true;
            this.chbx_Iface_operators_group.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chbx_users_groups
            // 
            this.chbx_users_groups.AutoSize = true;
            this.chbx_users_groups.Enabled = false;
            this.chbx_users_groups.Location = new System.Drawing.Point(242, 345);
            this.chbx_users_groups.Name = "chbx_users_groups";
            this.chbx_users_groups.Size = new System.Drawing.Size(99, 17);
            this.chbx_users_groups.TabIndex = 16;
            this.chbx_users_groups.Text = "Пользователи";
            this.chbx_users_groups.UseVisualStyleBackColor = true;
            // 
            // chbx_users_RDP_group
            // 
            this.chbx_users_RDP_group.AutoSize = true;
            this.chbx_users_RDP_group.Enabled = false;
            this.chbx_users_RDP_group.Location = new System.Drawing.Point(242, 368);
            this.chbx_users_RDP_group.Name = "chbx_users_RDP_group";
            this.chbx_users_RDP_group.Size = new System.Drawing.Size(125, 17);
            this.chbx_users_RDP_group.TabIndex = 17;
            this.chbx_users_RDP_group.Text = "Пользователи RDP";
            this.chbx_users_RDP_group.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Добавить пользователя в группу";
            // 
            // chbx_Event_reader_group
            // 
            this.chbx_Event_reader_group.AutoSize = true;
            this.chbx_Event_reader_group.Enabled = false;
            this.chbx_Event_reader_group.Location = new System.Drawing.Point(242, 391);
            this.chbx_Event_reader_group.Name = "chbx_Event_reader_group";
            this.chbx_Event_reader_group.Size = new System.Drawing.Size(166, 17);
            this.chbx_Event_reader_group.TabIndex = 18;
            this.chbx_Event_reader_group.Text = "Читатели журнала событий";
            this.chbx_Event_reader_group.UseVisualStyleBackColor = true;
            // 
            // button_user_delete
            // 
            this.button_user_delete.Enabled = false;
            this.button_user_delete.Location = new System.Drawing.Point(108, 395);
            this.button_user_delete.Name = "button_user_delete";
            this.button_user_delete.Size = new System.Drawing.Size(75, 23);
            this.button_user_delete.TabIndex = 21;
            this.button_user_delete.Text = "Удалить";
            this.button_user_delete.UseVisualStyleBackColor = true;
            this.button_user_delete.Click += new System.EventHandler(this.button_user_delete_Click);
            // 
            // panel_user_add
            // 
            this.panel_user_add.AutoSize = true;
            this.panel_user_add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_user_add.Location = new System.Drawing.Point(6, 264);
            this.panel_user_add.Name = "panel_user_add";
            this.panel_user_add.Size = new System.Drawing.Size(414, 170);
            this.panel_user_add.TabIndex = 82;
            this.panel_user_add.Tag = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.OS_Tweak_tab);
            this.tabControl1.Controls.Add(this.OIK_client_tab);
            this.tabControl1.Controls.Add(this.Network);
            this.tabControl1.Location = new System.Drawing.Point(321, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(807, 508);
            this.tabControl1.TabIndex = 88;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // OS_Tweak_tab
            // 
            this.OS_Tweak_tab.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OS_Tweak_tab.Controls.Add(this.chbx_NoInternetIcon);
            this.OS_Tweak_tab.Controls.Add(this.cbx_check_All_OS);
            this.OS_Tweak_tab.Controls.Add(this.lbl_need_reboot_UAC);
            this.OS_Tweak_tab.Controls.Add(this.lbl_need_reboot_WinDefender);
            this.OS_Tweak_tab.Controls.Add(this.cbx_WinTimeSVC_On);
            this.OS_Tweak_tab.Controls.Add(this.checkBox_WindowsDefenderOff);
            this.OS_Tweak_tab.Controls.Add(this.label4);
            this.OS_Tweak_tab.Controls.Add(this.button_user_delete);
            this.OS_Tweak_tab.Controls.Add(this.chbx_Event_reader_group);
            this.OS_Tweak_tab.Controls.Add(this.label2);
            this.OS_Tweak_tab.Controls.Add(this.label1);
            this.OS_Tweak_tab.Controls.Add(this.New_Instal_dateTimePicker);
            this.OS_Tweak_tab.Controls.Add(this.chbx_users_RDP_group);
            this.OS_Tweak_tab.Controls.Add(this.Reserve_SNTP_Label);
            this.OS_Tweak_tab.Controls.Add(this.chbx_users_groups);
            this.OS_Tweak_tab.Controls.Add(this.label_Sync_interval);
            this.OS_Tweak_tab.Controls.Add(this.chbx_Iface_operators_group);
            this.OS_Tweak_tab.Controls.Add(this.Main_SNTP_Label);
            this.OS_Tweak_tab.Controls.Add(this.chbx_admin_group);
            this.OS_Tweak_tab.Controls.Add(this.textBox_Sync_interval);
            this.OS_Tweak_tab.Controls.Add(this.label_user_pass);
            this.OS_Tweak_tab.Controls.Add(this.Reserve_SNTP_Adress);
            this.OS_Tweak_tab.Controls.Add(this.label_user_name);
            this.OS_Tweak_tab.Controls.Add(this.Main_SNTP_Adress);
            this.OS_Tweak_tab.Controls.Add(this.textBox_user_pass);
            this.OS_Tweak_tab.Controls.Add(this.KMS_Server_Adress);
            this.OS_Tweak_tab.Controls.Add(this.checkBox_user_add_section);
            this.OS_Tweak_tab.Controls.Add(this.ChangeWInSetupTime_Button);
            this.OS_Tweak_tab.Controls.Add(this.button_user_initialise);
            this.OS_Tweak_tab.Controls.Add(this.changes_backup);
            this.OS_Tweak_tab.Controls.Add(this.SetTimeSyncServer);
            this.OS_Tweak_tab.Controls.Add(this.run_programm);
            this.OS_Tweak_tab.Controls.Add(this.textBox_user_name);
            this.OS_Tweak_tab.Controls.Add(this.Change_System_Install_Time_СheckBox);
            this.OS_Tweak_tab.Controls.Add(this.button_user_add);
            this.OS_Tweak_tab.Controls.Add(this.SetKMSServer);
            this.OS_Tweak_tab.Controls.Add(this.checkBox_NumLock_on);
            this.OS_Tweak_tab.Controls.Add(this.winsearch_off);
            this.OS_Tweak_tab.Controls.Add(this.superFetch_off);
            this.OS_Tweak_tab.Controls.Add(this.nla_off);
            this.OS_Tweak_tab.Controls.Add(this.rdp_on);
            this.OS_Tweak_tab.Controls.Add(this.uac_off);
            this.OS_Tweak_tab.Controls.Add(this.panel_user_add);
            this.OS_Tweak_tab.Controls.Add(this.sleep_mode_off);
            this.OS_Tweak_tab.Controls.Add(this.firewall_off);
            this.OS_Tweak_tab.Controls.Add(this.hybernation_off);
            this.OS_Tweak_tab.Controls.Add(this.label3);
            this.OS_Tweak_tab.Controls.Add(this.monitor_optimize_off);
            this.OS_Tweak_tab.Controls.Add(this.hdd_optimize_off);
            this.OS_Tweak_tab.Location = new System.Drawing.Point(4, 22);
            this.OS_Tweak_tab.Name = "OS_Tweak_tab";
            this.OS_Tweak_tab.Padding = new System.Windows.Forms.Padding(3);
            this.OS_Tweak_tab.Size = new System.Drawing.Size(799, 482);
            this.OS_Tweak_tab.TabIndex = 0;
            this.OS_Tweak_tab.Text = "Настройка ОС";
            // 
            // chbx_NoInternetIcon
            // 
            this.chbx_NoInternetIcon.AutoSize = true;
            this.chbx_NoInternetIcon.Location = new System.Drawing.Point(480, 177);
            this.chbx_NoInternetIcon.Name = "chbx_NoInternetIcon";
            this.chbx_NoInternetIcon.Size = new System.Drawing.Size(318, 17);
            this.chbx_NoInternetIcon.TabIndex = 28;
            this.chbx_NoInternetIcon.Text = "Отключить уведомление \"Нет соединения с интернетом\"";
            this.chbx_NoInternetIcon.UseVisualStyleBackColor = true;
            // 
            // cbx_check_All_OS
            // 
            this.cbx_check_All_OS.AutoSize = true;
            this.cbx_check_All_OS.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbx_check_All_OS.Location = new System.Drawing.Point(480, 390);
            this.cbx_check_All_OS.Name = "cbx_check_All_OS";
            this.cbx_check_All_OS.Size = new System.Drawing.Size(101, 19);
            this.cbx_check_All_OS.TabIndex = 36;
            this.cbx_check_All_OS.Text = "Выбрать всё";
            this.cbx_check_All_OS.UseVisualStyleBackColor = true;
            this.cbx_check_All_OS.CheckedChanged += new System.EventHandler(this.cbx_check_All_OS_CheckedChanged);
            // 
            // lbl_need_reboot_UAC
            // 
            this.lbl_need_reboot_UAC.AutoSize = true;
            this.lbl_need_reboot_UAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_need_reboot_UAC.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_need_reboot_UAC.Location = new System.Drawing.Point(341, 63);
            this.lbl_need_reboot_UAC.Name = "lbl_need_reboot_UAC";
            this.lbl_need_reboot_UAC.Size = new System.Drawing.Size(133, 13);
            this.lbl_need_reboot_UAC.TabIndex = 86;
            this.lbl_need_reboot_UAC.Text = "Требуется перезагрузка";
            this.lbl_need_reboot_UAC.Visible = false;
            // 
            // lbl_need_reboot_WinDefender
            // 
            this.lbl_need_reboot_WinDefender.AutoSize = true;
            this.lbl_need_reboot_WinDefender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_need_reboot_WinDefender.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_need_reboot_WinDefender.Location = new System.Drawing.Point(341, 85);
            this.lbl_need_reboot_WinDefender.Name = "lbl_need_reboot_WinDefender";
            this.lbl_need_reboot_WinDefender.Size = new System.Drawing.Size(133, 13);
            this.lbl_need_reboot_WinDefender.TabIndex = 85;
            this.lbl_need_reboot_WinDefender.Text = "Требуется перезагрузка";
            this.lbl_need_reboot_WinDefender.Visible = false;
            // 
            // cbx_WinTimeSVC_On
            // 
            this.cbx_WinTimeSVC_On.AutoSize = true;
            this.cbx_WinTimeSVC_On.Location = new System.Drawing.Point(480, 246);
            this.cbx_WinTimeSVC_On.Name = "cbx_WinTimeSVC_On";
            this.cbx_WinTimeSVC_On.Size = new System.Drawing.Size(272, 17);
            this.cbx_WinTimeSVC_On.TabIndex = 31;
            this.cbx_WinTimeSVC_On.Text = "Включить автозапуск службы времени Windows";
            this.cbx_WinTimeSVC_On.UseVisualStyleBackColor = true;
            // 
            // checkBox_WindowsDefenderOff
            // 
            this.checkBox_WindowsDefenderOff.AutoSize = true;
            this.checkBox_WindowsDefenderOff.Location = new System.Drawing.Point(480, 85);
            this.checkBox_WindowsDefenderOff.Name = "checkBox_WindowsDefenderOff";
            this.checkBox_WindowsDefenderOff.Size = new System.Drawing.Size(196, 17);
            this.checkBox_WindowsDefenderOff.TabIndex = 24;
            this.checkBox_WindowsDefenderOff.Text = "Отключить защитник Windows 10";
            this.checkBox_WindowsDefenderOff.UseVisualStyleBackColor = true;
            this.checkBox_WindowsDefenderOff.CheckedChanged += new System.EventHandler(this.checkBox_WindowsDefenderOff_CheckedChanged);
            // 
            // OIK_client_tab
            // 
            this.OIK_client_tab.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OIK_client_tab.Controls.Add(this.chbx_ModusFontsDefault);
            this.OIK_client_tab.Controls.Add(this.chbx_OIKFontsDefault);
            this.OIK_client_tab.Controls.Add(this.chbx_SystemFontsDefault);
            this.OIK_client_tab.Controls.Add(this.btn_TMS_Backup);
            this.OIK_client_tab.Controls.Add(this.label5);
            this.OIK_client_tab.Controls.Add(this.label6);
            this.OIK_client_tab.Controls.Add(this.checkBox_win_folders_optimize);
            this.OIK_client_tab.Controls.Add(this.checkBox_folder_OIK_rules);
            this.OIK_client_tab.Controls.Add(this.checkBox_change_owner_OIK_folder);
            this.OIK_client_tab.Controls.Add(this.OIK_install_path);
            this.OIK_client_tab.Controls.Add(this.Browse_oik_install_folder);
            this.OIK_client_tab.Controls.Add(this.btn_OIK_configTAB);
            this.OIK_client_tab.Controls.Add(this.cmb_mapping_disk);
            this.OIK_client_tab.Controls.Add(this.textBox_path_modus_file_destination);
            this.OIK_client_tab.Controls.Add(this.button2);
            this.OIK_client_tab.Controls.Add(this.checkBox_OIK_styles_copy);
            this.OIK_client_tab.Controls.Add(this.textBox_path_modus_file);
            this.OIK_client_tab.Controls.Add(this.button_path_modus_file_copy);
            this.OIK_client_tab.Controls.Add(this.check_box_clear_clien_oik_settings);
            this.OIK_client_tab.Controls.Add(this.dataGridView1);
            this.OIK_client_tab.Controls.Add(this.panel1);
            this.OIK_client_tab.Location = new System.Drawing.Point(4, 22);
            this.OIK_client_tab.Name = "OIK_client_tab";
            this.OIK_client_tab.Padding = new System.Windows.Forms.Padding(3);
            this.OIK_client_tab.Size = new System.Drawing.Size(799, 482);
            this.OIK_client_tab.TabIndex = 2;
            this.OIK_client_tab.Text = "Настройка клиента ОИК";
            // 
            // chbx_ModusFontsDefault
            // 
            this.chbx_ModusFontsDefault.AutoSize = true;
            this.chbx_ModusFontsDefault.Location = new System.Drawing.Point(6, 249);
            this.chbx_ModusFontsDefault.Name = "chbx_ModusFontsDefault";
            this.chbx_ModusFontsDefault.Size = new System.Drawing.Size(262, 17);
            this.chbx_ModusFontsDefault.TabIndex = 108;
            this.chbx_ModusFontsDefault.Text = "Восстановить шрифты Модус \"По умолчанию\"";
            this.chbx_ModusFontsDefault.UseVisualStyleBackColor = true;
            this.chbx_ModusFontsDefault.CheckedChanged += new System.EventHandler(this.chbx_ModusFontsDefault_CheckedChanged);
            // 
            // chbx_OIKFontsDefault
            // 
            this.chbx_OIKFontsDefault.AutoSize = true;
            this.chbx_OIKFontsDefault.Location = new System.Drawing.Point(6, 226);
            this.chbx_OIKFontsDefault.Name = "chbx_OIKFontsDefault";
            this.chbx_OIKFontsDefault.Size = new System.Drawing.Size(253, 17);
            this.chbx_OIKFontsDefault.TabIndex = 107;
            this.chbx_OIKFontsDefault.Text = "Восстановить шрифты ОИК \"По умолчанию\"";
            this.chbx_OIKFontsDefault.UseVisualStyleBackColor = true;
            this.chbx_OIKFontsDefault.CheckedChanged += new System.EventHandler(this.chbx_OIKFontsDefault_CheckedChanged);
            // 
            // chbx_SystemFontsDefault
            // 
            this.chbx_SystemFontsDefault.AutoSize = true;
            this.chbx_SystemFontsDefault.Location = new System.Drawing.Point(6, 203);
            this.chbx_SystemFontsDefault.Name = "chbx_SystemFontsDefault";
            this.chbx_SystemFontsDefault.Size = new System.Drawing.Size(287, 17);
            this.chbx_SystemFontsDefault.TabIndex = 106;
            this.chbx_SystemFontsDefault.Text = "Восстановить системные шрифты \"По умолчанию\"";
            this.chbx_SystemFontsDefault.UseVisualStyleBackColor = true;
            this.chbx_SystemFontsDefault.CheckedChanged += new System.EventHandler(this.chbx_SystemFontsDefault_CheckedChanged);
            // 
            // btn_TMS_Backup
            // 
            this.btn_TMS_Backup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_TMS_Backup.Image = ((System.Drawing.Image)(resources.GetObject("btn_TMS_Backup.Image")));
            this.btn_TMS_Backup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TMS_Backup.Location = new System.Drawing.Point(432, 325);
            this.btn_TMS_Backup.Name = "btn_TMS_Backup";
            this.btn_TMS_Backup.Size = new System.Drawing.Size(136, 37);
            this.btn_TMS_Backup.TabIndex = 104;
            this.btn_TMS_Backup.Text = "TMS\\RBS Backup";
            this.btn_TMS_Backup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TMS_Backup.UseVisualStyleBackColor = true;
            this.btn_TMS_Backup.Click += new System.EventHandler(this.btn_TMS_Backup_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(282, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 17);
            this.label5.TabIndex = 103;
            this.label5.Text = "Настройка клиента ОИК";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label6.Location = new System.Drawing.Point(225, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(282, 17);
            this.label6.TabIndex = 97;
            this.label6.Text = "Настройка параметров для сервера ОИК";
            // 
            // checkBox_win_folders_optimize
            // 
            this.checkBox_win_folders_optimize.AutoSize = true;
            this.checkBox_win_folders_optimize.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.WindowFrame;
            this.checkBox_win_folders_optimize.Location = new System.Drawing.Point(6, 325);
            this.checkBox_win_folders_optimize.Name = "checkBox_win_folders_optimize";
            this.checkBox_win_folders_optimize.Size = new System.Drawing.Size(389, 17);
            this.checkBox_win_folders_optimize.TabIndex = 98;
            this.checkBox_win_folders_optimize.Text = "Настроить файлы конфигурации сервера ОИК файлы в папке Windows";
            this.checkBox_win_folders_optimize.UseVisualStyleBackColor = true;
            // 
            // checkBox_folder_OIK_rules
            // 
            this.checkBox_folder_OIK_rules.AutoSize = true;
            this.checkBox_folder_OIK_rules.Enabled = false;
            this.checkBox_folder_OIK_rules.Location = new System.Drawing.Point(18, 371);
            this.checkBox_folder_OIK_rules.Name = "checkBox_folder_OIK_rules";
            this.checkBox_folder_OIK_rules.Size = new System.Drawing.Size(236, 17);
            this.checkBox_folder_OIK_rules.TabIndex = 99;
            this.checkBox_folder_OIK_rules.Text = "Настроить права доступа для папок ОИК";
            this.checkBox_folder_OIK_rules.UseVisualStyleBackColor = true;
            // 
            // checkBox_change_owner_OIK_folder
            // 
            this.checkBox_change_owner_OIK_folder.AutoSize = true;
            this.checkBox_change_owner_OIK_folder.Location = new System.Drawing.Point(6, 348);
            this.checkBox_change_owner_OIK_folder.Name = "checkBox_change_owner_OIK_folder";
            this.checkBox_change_owner_OIK_folder.Size = new System.Drawing.Size(232, 17);
            this.checkBox_change_owner_OIK_folder.TabIndex = 100;
            this.checkBox_change_owner_OIK_folder.Text = "Заменить владельца папки InterfaseSSH";
            this.checkBox_change_owner_OIK_folder.UseVisualStyleBackColor = true;
            this.checkBox_change_owner_OIK_folder.CheckedChanged += new System.EventHandler(this.checkBox_change_owner_OIK_folder_CheckedChanged);
            // 
            // OIK_install_path
            // 
            this.OIK_install_path.Location = new System.Drawing.Point(55, 395);
            this.OIK_install_path.MaxLength = 255;
            this.OIK_install_path.Name = "OIK_install_path";
            this.OIK_install_path.ReadOnly = true;
            this.OIK_install_path.Size = new System.Drawing.Size(278, 20);
            this.OIK_install_path.TabIndex = 101;
            this.OIK_install_path.Text = "C:\\Program Files (x86)\\InterfaceSSH\\";
            // 
            // Browse_oik_install_folder
            // 
            this.Browse_oik_install_folder.Enabled = false;
            this.Browse_oik_install_folder.Location = new System.Drawing.Point(17, 394);
            this.Browse_oik_install_folder.Name = "Browse_oik_install_folder";
            this.Browse_oik_install_folder.Size = new System.Drawing.Size(35, 23);
            this.Browse_oik_install_folder.TabIndex = 102;
            this.Browse_oik_install_folder.Text = "....";
            this.Browse_oik_install_folder.UseVisualStyleBackColor = true;
            this.Browse_oik_install_folder.Click += new System.EventHandler(this.Browse_oik_install_folder_Click_1);
            // 
            // btn_OIK_configTAB
            // 
            this.btn_OIK_configTAB.Location = new System.Drawing.Point(581, 436);
            this.btn_OIK_configTAB.Name = "btn_OIK_configTAB";
            this.btn_OIK_configTAB.Size = new System.Drawing.Size(75, 23);
            this.btn_OIK_configTAB.TabIndex = 96;
            this.btn_OIK_configTAB.Text = "Применить";
            this.btn_OIK_configTAB.UseVisualStyleBackColor = true;
            this.btn_OIK_configTAB.Click += new System.EventHandler(this.btn_OIK_configTAB_Click);
            // 
            // cmb_mapping_disk
            // 
            this.cmb_mapping_disk.Enabled = false;
            this.cmb_mapping_disk.FormattingEnabled = true;
            this.cmb_mapping_disk.Location = new System.Drawing.Point(359, 205);
            this.cmb_mapping_disk.Name = "cmb_mapping_disk";
            this.cmb_mapping_disk.Size = new System.Drawing.Size(94, 21);
            this.cmb_mapping_disk.TabIndex = 95;
            // 
            // textBox_path_modus_file_destination
            // 
            this.textBox_path_modus_file_destination.Enabled = false;
            this.textBox_path_modus_file_destination.Location = new System.Drawing.Point(356, 232);
            this.textBox_path_modus_file_destination.MaxLength = 255;
            this.textBox_path_modus_file_destination.Name = "textBox_path_modus_file_destination";
            this.textBox_path_modus_file_destination.Size = new System.Drawing.Size(300, 20);
            this.textBox_path_modus_file_destination.TabIndex = 94;
            this.textBox_path_modus_file_destination.Text = "C:\\Program Files (x86)\\InterfaceSSH\\";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(318, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 23);
            this.button2.TabIndex = 93;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // checkBox_OIK_styles_copy
            // 
            this.checkBox_OIK_styles_copy.AutoSize = true;
            this.checkBox_OIK_styles_copy.Location = new System.Drawing.Point(307, 180);
            this.checkBox_OIK_styles_copy.Name = "checkBox_OIK_styles_copy";
            this.checkBox_OIK_styles_copy.Size = new System.Drawing.Size(200, 17);
            this.checkBox_OIK_styles_copy.TabIndex = 91;
            this.checkBox_OIK_styles_copy.Text = "Скопировать стили пользователю";
            this.checkBox_OIK_styles_copy.UseVisualStyleBackColor = true;
            this.checkBox_OIK_styles_copy.CheckedChanged += new System.EventHandler(this.checkBox_OIK_styles_copy_CheckedChanged);
            // 
            // textBox_path_modus_file
            // 
            this.textBox_path_modus_file.Enabled = false;
            this.textBox_path_modus_file.Location = new System.Drawing.Point(459, 205);
            this.textBox_path_modus_file.MaxLength = 255;
            this.textBox_path_modus_file.Name = "textBox_path_modus_file";
            this.textBox_path_modus_file.Size = new System.Drawing.Size(300, 20);
            this.textBox_path_modus_file.TabIndex = 89;
            this.textBox_path_modus_file.MouseHover += new System.EventHandler(this.textBox_path_modus_file_MouseHover);
            // 
            // button_path_modus_file_copy
            // 
            this.button_path_modus_file_copy.Enabled = false;
            this.button_path_modus_file_copy.Location = new System.Drawing.Point(318, 203);
            this.button_path_modus_file_copy.Name = "button_path_modus_file_copy";
            this.button_path_modus_file_copy.Size = new System.Drawing.Size(35, 23);
            this.button_path_modus_file_copy.TabIndex = 88;
            this.button_path_modus_file_copy.Text = "...";
            this.button_path_modus_file_copy.UseVisualStyleBackColor = true;
            this.button_path_modus_file_copy.Click += new System.EventHandler(this.button_path_modus_file_copy_Click);
            // 
            // check_box_clear_clien_oik_settings
            // 
            this.check_box_clear_clien_oik_settings.AutoSize = true;
            this.check_box_clear_clien_oik_settings.Location = new System.Drawing.Point(6, 180);
            this.check_box_clear_clien_oik_settings.Name = "check_box_clear_clien_oik_settings";
            this.check_box_clear_clien_oik_settings.Size = new System.Drawing.Size(200, 17);
            this.check_box_clear_clien_oik_settings.TabIndex = 87;
            this.check_box_clear_clien_oik_settings.Text = "Сбросить настройки клиента ОИК";
            this.check_box_clear_clien_oik_settings.UseVisualStyleBackColor = true;
            this.check_box_clear_clien_oik_settings.CheckedChanged += new System.EventHandler(this.check_box_clear_clien_oik_settings_CheckedChanged);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index_nuber,
            this.User_Name_Column,
            this.SID_Column,
            this.User_LocalPath,
            this.user_loaded});
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(5, 24);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(711, 150);
            this.dataGridView1.TabIndex = 85;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // index_nuber
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.index_nuber.DefaultCellStyle = dataGridViewCellStyle2;
            this.index_nuber.HeaderText = "№";
            this.index_nuber.MaxInputLength = 4;
            this.index_nuber.Name = "index_nuber";
            this.index_nuber.ReadOnly = true;
            this.index_nuber.Width = 35;
            // 
            // User_Name_Column
            // 
            this.User_Name_Column.HeaderText = "Учётная запись";
            this.User_Name_Column.MaxInputLength = 256;
            this.User_Name_Column.Name = "User_Name_Column";
            this.User_Name_Column.ReadOnly = true;
            this.User_Name_Column.Width = 128;
            // 
            // SID_Column
            // 
            this.SID_Column.HeaderText = "SID";
            this.SID_Column.MaxInputLength = 256;
            this.SID_Column.Name = "SID_Column";
            this.SID_Column.ReadOnly = true;
            this.SID_Column.Width = 300;
            // 
            // User_LocalPath
            // 
            this.User_LocalPath.HeaderText = "Рабочая папка";
            this.User_LocalPath.MaxInputLength = 256;
            this.User_LocalPath.Name = "User_LocalPath";
            this.User_LocalPath.ReadOnly = true;
            this.User_LocalPath.Width = 130;
            // 
            // user_loaded
            // 
            this.user_loaded.HeaderText = "Состояние";
            this.user_loaded.MaxInputLength = 12;
            this.user_loaded.Name = "user_loaded";
            this.user_loaded.ReadOnly = true;
            this.user_loaded.Width = 80;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Location = new System.Drawing.Point(49, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 3);
            this.panel1.TabIndex = 107;
            // 
            // Network
            // 
            this.Network.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Network.Controls.Add(this.tabControl2);
            this.Network.Controls.Add(this.lv_adapters);
            this.Network.Controls.Add(this.btn_get_network_adapters);
            this.Network.Location = new System.Drawing.Point(4, 22);
            this.Network.Name = "Network";
            this.Network.Padding = new System.Windows.Forms.Padding(3);
            this.Network.Size = new System.Drawing.Size(799, 482);
            this.Network.TabIndex = 3;
            this.Network.Text = "Сеть";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.Dinamic_Routes);
            this.tabControl2.Controls.Add(this.Static_Routes);
            this.tabControl2.Location = new System.Drawing.Point(6, 142);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(776, 337);
            this.tabControl2.TabIndex = 107;
            // 
            // Dinamic_Routes
            // 
            this.Dinamic_Routes.Controls.Add(this.lv_dynamic_route);
            this.Dinamic_Routes.Controls.Add(this.button5);
            this.Dinamic_Routes.Location = new System.Drawing.Point(4, 22);
            this.Dinamic_Routes.Name = "Dinamic_Routes";
            this.Dinamic_Routes.Padding = new System.Windows.Forms.Padding(3);
            this.Dinamic_Routes.Size = new System.Drawing.Size(768, 311);
            this.Dinamic_Routes.TabIndex = 0;
            this.Dinamic_Routes.Text = "Все маршруты";
            this.Dinamic_Routes.UseVisualStyleBackColor = true;
            // 
            // lv_dynamic_route
            // 
            this.lv_dynamic_route.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_dynamic_route.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Numb,
            this.Address,
            this.Mask,
            this.Gateway,
            this.Interface,
            this.Metric,
            this.Index,
            this.WorkOn});
            this.lv_dynamic_route.FullRowSelect = true;
            this.lv_dynamic_route.GridLines = true;
            this.lv_dynamic_route.HideSelection = false;
            this.lv_dynamic_route.Location = new System.Drawing.Point(0, 0);
            this.lv_dynamic_route.Name = "lv_dynamic_route";
            this.lv_dynamic_route.Size = new System.Drawing.Size(772, 312);
            this.lv_dynamic_route.TabIndex = 3;
            this.lv_dynamic_route.UseCompatibleStateImageBehavior = false;
            this.lv_dynamic_route.View = System.Windows.Forms.View.Details;
            this.lv_dynamic_route.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_dynamic_route_MouseClick);
            this.lv_dynamic_route.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lv_dynamic_route_PreviewKeyDown);
            // 
            // Numb
            // 
            this.Numb.Text = "№";
            this.Numb.Width = 29;
            // 
            // Address
            // 
            this.Address.Text = "IP адрес";
            this.Address.Width = 100;
            // 
            // Mask
            // 
            this.Mask.Text = "Маска";
            this.Mask.Width = 100;
            // 
            // Gateway
            // 
            this.Gateway.Text = "Шлюз";
            this.Gateway.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Gateway.Width = 100;
            // 
            // Interface
            // 
            this.Interface.Text = "Интерфейс";
            this.Interface.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Interface.Width = 100;
            // 
            // Metric
            // 
            this.Metric.Text = "Метрика";
            this.Metric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Metric.Width = 57;
            // 
            // Index
            // 
            this.Index.Text = "Index";
            // 
            // WorkOn
            // 
            this.WorkOn.Text = "Имя адаптера";
            this.WorkOn.Width = 209;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(657, 36);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 117;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Static_Routes
            // 
            this.Static_Routes.Controls.Add(this.lv_static_route);
            this.Static_Routes.Location = new System.Drawing.Point(4, 22);
            this.Static_Routes.Name = "Static_Routes";
            this.Static_Routes.Padding = new System.Windows.Forms.Padding(3);
            this.Static_Routes.Size = new System.Drawing.Size(768, 311);
            this.Static_Routes.TabIndex = 1;
            this.Static_Routes.Text = "Статические маршруты";
            this.Static_Routes.UseVisualStyleBackColor = true;
            // 
            // lv_static_route
            // 
            this.lv_static_route.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_static_route.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Num_colum_static,
            this.Adress_colum_static,
            this.Mask_colum_static,
            this.Gateway_colum_static,
            this.Metric_colum_static});
            this.lv_static_route.FullRowSelect = true;
            this.lv_static_route.GridLines = true;
            this.lv_static_route.HideSelection = false;
            this.lv_static_route.Location = new System.Drawing.Point(0, 0);
            this.lv_static_route.Name = "lv_static_route";
            this.lv_static_route.Size = new System.Drawing.Size(772, 315);
            this.lv_static_route.TabIndex = 4;
            this.lv_static_route.UseCompatibleStateImageBehavior = false;
            this.lv_static_route.View = System.Windows.Forms.View.Details;
            this.lv_static_route.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lv_static_route_KeyDown);
            this.lv_static_route.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_static_route_MouseClick);
            // 
            // Num_colum_static
            // 
            this.Num_colum_static.Text = "№";
            this.Num_colum_static.Width = 29;
            // 
            // Adress_colum_static
            // 
            this.Adress_colum_static.Text = "IP адрес";
            this.Adress_colum_static.Width = 135;
            // 
            // Mask_colum_static
            // 
            this.Mask_colum_static.Text = "Маска";
            this.Mask_colum_static.Width = 130;
            // 
            // Gateway_colum_static
            // 
            this.Gateway_colum_static.Text = "Шлюз";
            this.Gateway_colum_static.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Gateway_colum_static.Width = 103;
            // 
            // Metric_colum_static
            // 
            this.Metric_colum_static.Text = "Метрика";
            this.Metric_colum_static.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Metric_colum_static.Width = 61;
            // 
            // lv_adapters
            // 
            this.lv_adapters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_adapters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Num,
            this.ID,
            this.Index_column,
            this.NetConnectionID,
            this.Description,
            this.IP_Adr,
            this.MAC_Adress,
            this.Net_Online});
            this.lv_adapters.FullRowSelect = true;
            this.lv_adapters.GridLines = true;
            this.lv_adapters.HideSelection = false;
            this.lv_adapters.Location = new System.Drawing.Point(10, 7);
            this.lv_adapters.MultiSelect = false;
            this.lv_adapters.Name = "lv_adapters";
            this.lv_adapters.Size = new System.Drawing.Size(772, 129);
            this.lv_adapters.TabIndex = 2;
            this.lv_adapters.UseCompatibleStateImageBehavior = false;
            this.lv_adapters.View = System.Windows.Forms.View.Details;
            this.lv_adapters.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_adapters_MouseClick);
            this.lv_adapters.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lv_adapters_PreviewKeyDown);
            // 
            // Num
            // 
            this.Num.Text = "№";
            this.Num.Width = 29;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 36;
            // 
            // Index_column
            // 
            this.Index_column.Text = "Index";
            this.Index_column.Width = 40;
            // 
            // NetConnectionID
            // 
            this.NetConnectionID.Text = "Имя";
            this.NetConnectionID.Width = 112;
            // 
            // Description
            // 
            this.Description.Text = "Устройство";
            this.Description.Width = 250;
            // 
            // IP_Adr
            // 
            this.IP_Adr.Text = "IP";
            this.IP_Adr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IP_Adr.Width = 100;
            // 
            // MAC_Adress
            // 
            this.MAC_Adress.Text = "MAC";
            this.MAC_Adress.Width = 120;
            // 
            // Net_Online
            // 
            this.Net_Online.Text = "Состояние";
            this.Net_Online.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Net_Online.Width = 66;
            // 
            // btn_get_network_adapters
            // 
            this.btn_get_network_adapters.Location = new System.Drawing.Point(695, 142);
            this.btn_get_network_adapters.Name = "btn_get_network_adapters";
            this.btn_get_network_adapters.Size = new System.Drawing.Size(75, 23);
            this.btn_get_network_adapters.TabIndex = 1;
            this.btn_get_network_adapters.Text = "Get Net";
            this.btn_get_network_adapters.UseVisualStyleBackColor = true;
            this.btn_get_network_adapters.Visible = false;
            this.btn_get_network_adapters.Click += new System.EventHandler(this.btn_get_network_routes_Click);
            // 
            // lbl_PC_name
            // 
            this.lbl_PC_name.AutoSize = true;
            this.lbl_PC_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_PC_name.Location = new System.Drawing.Point(16, 43);
            this.lbl_PC_name.Name = "lbl_PC_name";
            this.lbl_PC_name.Size = new System.Drawing.Size(98, 13);
            this.lbl_PC_name.TabIndex = 89;
            this.lbl_PC_name.Text = "Имя компьютера:";
            // 
            // lbl_VendorName
            // 
            this.lbl_VendorName.AutoSize = true;
            this.lbl_VendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_VendorName.Location = new System.Drawing.Point(16, 60);
            this.lbl_VendorName.Name = "lbl_VendorName";
            this.lbl_VendorName.Size = new System.Drawing.Size(89, 13);
            this.lbl_VendorName.TabIndex = 90;
            this.lbl_VendorName.Text = "Производитель:";
            // 
            // lbl_CPU
            // 
            this.lbl_CPU.AutoSize = true;
            this.lbl_CPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_CPU.Location = new System.Drawing.Point(16, 128);
            this.lbl_CPU.Name = "lbl_CPU";
            this.lbl_CPU.Size = new System.Drawing.Size(32, 13);
            this.lbl_CPU.TabIndex = 92;
            this.lbl_CPU.Text = "CPU:";
            // 
            // lbl_OS_info
            // 
            this.lbl_OS_info.AutoSize = true;
            this.lbl_OS_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_OS_info.Location = new System.Drawing.Point(16, 9);
            this.lbl_OS_info.Name = "lbl_OS_info";
            this.lbl_OS_info.Size = new System.Drawing.Size(28, 13);
            this.lbl_OS_info.TabIndex = 91;
            this.lbl_OS_info.Text = "ОС: ";
            // 
            // lbl_hdd_model
            // 
            this.lbl_hdd_model.AutoSize = true;
            this.lbl_hdd_model.Location = new System.Drawing.Point(16, 191);
            this.lbl_hdd_model.Name = "lbl_hdd_model";
            this.lbl_hdd_model.Size = new System.Drawing.Size(83, 13);
            this.lbl_hdd_model.TabIndex = 95;
            this.lbl_hdd_model.Text = "Жёсткий диск:";
            // 
            // lbl_Memory_modules
            // 
            this.lbl_Memory_modules.AutoSize = true;
            this.lbl_Memory_modules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Memory_modules.Location = new System.Drawing.Point(16, 145);
            this.lbl_Memory_modules.Name = "lbl_Memory_modules";
            this.lbl_Memory_modules.Size = new System.Drawing.Size(117, 13);
            this.lbl_Memory_modules.TabIndex = 94;
            this.lbl_Memory_modules.Text = "Оперативная память:";
            // 
            // lbl_MB
            // 
            this.lbl_MB.AutoSize = true;
            this.lbl_MB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_MB.Location = new System.Drawing.Point(16, 111);
            this.lbl_MB.Name = "lbl_MB";
            this.lbl_MB.Size = new System.Drawing.Size(62, 13);
            this.lbl_MB.TabIndex = 93;
            this.lbl_MB.Text = "Мат.плата:";
            // 
            // btn_PC_conf_update
            // 
            this.btn_PC_conf_update.Location = new System.Drawing.Point(15, 306);
            this.btn_PC_conf_update.Name = "btn_PC_conf_update";
            this.btn_PC_conf_update.Size = new System.Drawing.Size(75, 23);
            this.btn_PC_conf_update.TabIndex = 97;
            this.btn_PC_conf_update.Text = "Обновить";
            this.btn_PC_conf_update.UseVisualStyleBackColor = true;
            this.btn_PC_conf_update.Click += new System.EventHandler(this.btn_PC_conf_update_Click);
            // 
            // btn_PC_conf_export
            // 
            this.btn_PC_conf_export.Enabled = false;
            this.btn_PC_conf_export.Location = new System.Drawing.Point(108, 306);
            this.btn_PC_conf_export.Name = "btn_PC_conf_export";
            this.btn_PC_conf_export.Size = new System.Drawing.Size(75, 23);
            this.btn_PC_conf_export.TabIndex = 98;
            this.btn_PC_conf_export.Text = "Сохранить";
            this.btn_PC_conf_export.UseVisualStyleBackColor = true;
            this.btn_PC_conf_export.Click += new System.EventHandler(this.btn_PC_conf_export_Click);
            // 
            // lbl_BIOS_Vendor
            // 
            this.lbl_BIOS_Vendor.AutoSize = true;
            this.lbl_BIOS_Vendor.Location = new System.Drawing.Point(16, 235);
            this.lbl_BIOS_Vendor.Name = "lbl_BIOS_Vendor";
            this.lbl_BIOS_Vendor.Size = new System.Drawing.Size(117, 13);
            this.lbl_BIOS_Vendor.TabIndex = 99;
            this.lbl_BIOS_Vendor.Text = "Производитель BIOS:";
            // 
            // lbl_BIOS_ver
            // 
            this.lbl_BIOS_ver.AutoSize = true;
            this.lbl_BIOS_ver.Location = new System.Drawing.Point(16, 252);
            this.lbl_BIOS_ver.Name = "lbl_BIOS_ver";
            this.lbl_BIOS_ver.Size = new System.Drawing.Size(75, 13);
            this.lbl_BIOS_ver.TabIndex = 100;
            this.lbl_BIOS_ver.Text = "Версия BIOS:";
            // 
            // lbl_GPU
            // 
            this.lbl_GPU.AutoSize = true;
            this.lbl_GPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_GPU.Location = new System.Drawing.Point(16, 94);
            this.lbl_GPU.Name = "lbl_GPU";
            this.lbl_GPU.Size = new System.Drawing.Size(33, 13);
            this.lbl_GPU.TabIndex = 101;
            this.lbl_GPU.Text = "GPU:";
            // 
            // lbl_BIOS_relese_date
            // 
            this.lbl_BIOS_relese_date.AutoSize = true;
            this.lbl_BIOS_relese_date.Location = new System.Drawing.Point(16, 269);
            this.lbl_BIOS_relese_date.Name = "lbl_BIOS_relese_date";
            this.lbl_BIOS_relese_date.Size = new System.Drawing.Size(101, 13);
            this.lbl_BIOS_relese_date.TabIndex = 102;
            this.lbl_BIOS_relese_date.Text = "Дата компоновки:";
            // 
            // cmbox_memory
            // 
            this.cmbox_memory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_memory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbox_memory.FormattingEnabled = true;
            this.cmbox_memory.ItemHeight = 15;
            this.cmbox_memory.Location = new System.Drawing.Point(18, 164);
            this.cmbox_memory.Name = "cmbox_memory";
            this.cmbox_memory.Size = new System.Drawing.Size(297, 23);
            this.cmbox_memory.TabIndex = 104;
            // 
            // cmbox_hdd
            // 
            this.cmbox_hdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_hdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbox_hdd.FormattingEnabled = true;
            this.cmbox_hdd.ItemHeight = 15;
            this.cmbox_hdd.Location = new System.Drawing.Point(19, 208);
            this.cmbox_hdd.Name = "cmbox_hdd";
            this.cmbox_hdd.Size = new System.Drawing.Size(296, 23);
            this.cmbox_hdd.TabIndex = 105;
            // 
            // lbl_OS_version
            // 
            this.lbl_OS_version.AutoSize = true;
            this.lbl_OS_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_OS_version.Location = new System.Drawing.Point(16, 26);
            this.lbl_OS_version.Name = "lbl_OS_version";
            this.lbl_OS_version.Size = new System.Drawing.Size(50, 13);
            this.lbl_OS_version.TabIndex = 106;
            this.lbl_OS_version.Text = "Версия: ";
            // 
            // cMS_adapters
            // 
            this.cMS_adapters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Refresh,
            this.cMS_Adatres_Copy_Cell,
            this.cMS_Adatres_Copy_MAC,
            this.cMS_Adatres_Copy_String,
            this.cMS_Adatres_Config_Adapter});
            this.cMS_adapters.Name = "cMS_adapters";
            this.cMS_adapters.Size = new System.Drawing.Size(170, 114);
            // 
            // Refresh
            // 
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(169, 22);
            this.Refresh.Text = "Обновить (F5)";
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // cMS_Adatres_Copy_Cell
            // 
            this.cMS_Adatres_Copy_Cell.Name = "cMS_Adatres_Copy_Cell";
            this.cMS_Adatres_Copy_Cell.Size = new System.Drawing.Size(169, 22);
            this.cMS_Adatres_Copy_Cell.Text = "Копировать IP";
            this.cMS_Adatres_Copy_Cell.Click += new System.EventHandler(this.cMS_Adatres_Copy_Cell_Click);
            // 
            // cMS_Adatres_Copy_MAC
            // 
            this.cMS_Adatres_Copy_MAC.Name = "cMS_Adatres_Copy_MAC";
            this.cMS_Adatres_Copy_MAC.Size = new System.Drawing.Size(169, 22);
            this.cMS_Adatres_Copy_MAC.Text = "Копировать MAC";
            this.cMS_Adatres_Copy_MAC.Click += new System.EventHandler(this.cMS_Adatres_Copy_MAC_Click);
            // 
            // cMS_Adatres_Copy_String
            // 
            this.cMS_Adatres_Copy_String.Name = "cMS_Adatres_Copy_String";
            this.cMS_Adatres_Copy_String.Size = new System.Drawing.Size(169, 22);
            this.cMS_Adatres_Copy_String.Text = "Копировать всё";
            this.cMS_Adatres_Copy_String.Click += new System.EventHandler(this.cMS_Adatres_Copy_String_Click);
            // 
            // cMS_Adatres_Config_Adapter
            // 
            this.cMS_Adatres_Config_Adapter.Enabled = false;
            this.cMS_Adatres_Config_Adapter.Name = "cMS_Adatres_Config_Adapter";
            this.cMS_Adatres_Config_Adapter.Size = new System.Drawing.Size(169, 22);
            this.cMS_Adatres_Config_Adapter.Text = "Настроить";
            this.cMS_Adatres_Config_Adapter.Click += new System.EventHandler(this.cMS_Adatres_Config_Adapter_Click);
            // 
            // cMS_OIK_User
            // 
            this.cMS_OIK_User.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cMS_OIK_User_Open_Profile_Folder,
            this.cMS_OIK_Copy_UserName,
            this.cMS_OIK_CopySID,
            this.cMS_OIK_Copy_User_Path,
            this.cMS_OIK_Reg_path_open});
            this.cMS_OIK_User.Name = "cMS_OIK_User";
            this.cMS_OIK_User.Size = new System.Drawing.Size(243, 114);
            // 
            // cMS_OIK_User_Open_Profile_Folder
            // 
            this.cMS_OIK_User_Open_Profile_Folder.Name = "cMS_OIK_User_Open_Profile_Folder";
            this.cMS_OIK_User_Open_Profile_Folder.Size = new System.Drawing.Size(242, 22);
            this.cMS_OIK_User_Open_Profile_Folder.Text = "Открыть профиль";
            this.cMS_OIK_User_Open_Profile_Folder.Click += new System.EventHandler(this.cMS_OIK_User_Open_Profile_Folder_Click);
            // 
            // cMS_OIK_Copy_UserName
            // 
            this.cMS_OIK_Copy_UserName.Name = "cMS_OIK_Copy_UserName";
            this.cMS_OIK_Copy_UserName.Size = new System.Drawing.Size(242, 22);
            this.cMS_OIK_Copy_UserName.Text = "Копировать имя пользователя";
            this.cMS_OIK_Copy_UserName.Click += new System.EventHandler(this.cMS_OIK_Copy_UserName_Click);
            // 
            // cMS_OIK_CopySID
            // 
            this.cMS_OIK_CopySID.Name = "cMS_OIK_CopySID";
            this.cMS_OIK_CopySID.Size = new System.Drawing.Size(242, 22);
            this.cMS_OIK_CopySID.Text = "Копировать SID";
            this.cMS_OIK_CopySID.Click += new System.EventHandler(this.cMS_OIK_CopySID_Click);
            // 
            // cMS_OIK_Copy_User_Path
            // 
            this.cMS_OIK_Copy_User_Path.Name = "cMS_OIK_Copy_User_Path";
            this.cMS_OIK_Copy_User_Path.Size = new System.Drawing.Size(242, 22);
            this.cMS_OIK_Copy_User_Path.Text = "Копировать путь до профиля";
            this.cMS_OIK_Copy_User_Path.Click += new System.EventHandler(this.cMS_OIK_Copy_User_Path_Click);
            // 
            // cMS_OIK_Reg_path_open
            // 
            this.cMS_OIK_Reg_path_open.Name = "cMS_OIK_Reg_path_open";
            this.cMS_OIK_Reg_path_open.Size = new System.Drawing.Size(242, 22);
            this.cMS_OIK_Reg_path_open.Text = "Открыть реестр";
            this.cMS_OIK_Reg_path_open.Click += new System.EventHandler(this.cMS_OIK_Reg_path_open_Click);
            // 
            // Prog_Version
            // 
            this.Prog_Version.AutoSize = true;
            this.Prog_Version.Location = new System.Drawing.Point(1043, 5);
            this.Prog_Version.Name = "Prog_Version";
            this.Prog_Version.Size = new System.Drawing.Size(42, 13);
            this.Prog_Version.TabIndex = 106;
            this.Prog_Version.Text = "Version";
            this.Prog_Version.Click += new System.EventHandler(this.Prog_Version_Click);
            // 
            // lbl_SerialNumber
            // 
            this.lbl_SerialNumber.AutoSize = true;
            this.lbl_SerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_SerialNumber.Location = new System.Drawing.Point(16, 77);
            this.lbl_SerialNumber.Name = "lbl_SerialNumber";
            this.lbl_SerialNumber.Size = new System.Drawing.Size(30, 13);
            this.lbl_SerialNumber.TabIndex = 107;
            this.lbl_SerialNumber.Text = "S\\N:";
            // 
            // cMS_route_edit
            // 
            this.cMS_route_edit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Refres,
            this.Add,
            this.Copy,
            this.Change,
            this.Delete});
            this.cMS_route_edit.Name = "cMS_route_edit";
            this.cMS_route_edit.Size = new System.Drawing.Size(155, 114);
            // 
            // Refres
            // 
            this.Refres.Name = "Refres";
            this.Refres.Size = new System.Drawing.Size(154, 22);
            this.Refres.Text = "Обновить (F5)";
            this.Refres.Click += new System.EventHandler(this.Refres_Click);
            // 
            // Add
            // 
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(154, 22);
            this.Add.Text = "Добавить";
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Copy
            // 
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(154, 22);
            this.Copy.Text = "Копировать";
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Change
            // 
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(154, 22);
            this.Change.Text = "Редактировать";
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(154, 22);
            this.Delete.Text = "Удалить";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(15, 518);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 23);
            this.button6.TabIndex = 108;
            this.button6.Text = "OpenNewForm";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 553);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.lbl_SerialNumber);
            this.Controls.Add(this.Prog_Version);
            this.Controls.Add(this.lbl_OS_version);
            this.Controls.Add(this.cmbox_hdd);
            this.Controls.Add(this.cmbox_memory);
            this.Controls.Add(this.lbl_BIOS_relese_date);
            this.Controls.Add(this.lbl_GPU);
            this.Controls.Add(this.lbl_BIOS_ver);
            this.Controls.Add(this.lbl_BIOS_Vendor);
            this.Controls.Add(this.btn_PC_conf_export);
            this.Controls.Add(this.btn_PC_conf_update);
            this.Controls.Add(this.lbl_hdd_model);
            this.Controls.Add(this.lbl_Memory_modules);
            this.Controls.Add(this.lbl_MB);
            this.Controls.Add(this.lbl_CPU);
            this.Controls.Add(this.lbl_OS_info);
            this.Controls.Add(this.lbl_VendorName);
            this.Controls.Add(this.lbl_PC_name);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Text_label_win_install_date);
            this.Controls.Add(this.System_Install_Date_Time_Label);
            this.Controls.Add(this.W32Time_Servie_Label);
            this.Controls.Add(this.SystemTime);
            this.Controls.Add(this.TimeZone);
            this.Controls.Add(this.Exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ТМ Tweaker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.OS_Tweak_tab.ResumeLayout(false);
            this.OS_Tweak_tab.PerformLayout();
            this.OIK_client_tab.ResumeLayout(false);
            this.OIK_client_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Network.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.Dinamic_Routes.ResumeLayout(false);
            this.Static_Routes.ResumeLayout(false);
            this.cMS_adapters.ResumeLayout(false);
            this.cMS_OIK_User.ResumeLayout(false);
            this.cMS_route_edit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox monitor_optimize_off;
        private System.Windows.Forms.CheckBox hdd_optimize_off;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox sleep_mode_off;
        private System.Windows.Forms.CheckBox hybernation_off;
        private System.Windows.Forms.CheckBox uac_off;
        private System.Windows.Forms.CheckBox firewall_off;
        private System.Windows.Forms.CheckBox nla_off;
        private System.Windows.Forms.CheckBox rdp_on;
        private System.Windows.Forms.CheckBox winsearch_off;
        private System.Windows.Forms.CheckBox superFetch_off;
        private System.Windows.Forms.CheckBox checkBox_NumLock_on;
        private System.Windows.Forms.CheckBox SetTimeSyncServer;
        private System.Windows.Forms.CheckBox Change_System_Install_Time_СheckBox;
        private System.Windows.Forms.CheckBox SetKMSServer;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button run_programm;
        private System.Windows.Forms.Button changes_backup;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.FolderBrowserDialog OIK_folder_install_BrowserDialog;
        private System.Windows.Forms.Button ChangeWInSetupTime_Button;
        private System.Windows.Forms.Label TimeZone;
        private System.Windows.Forms.Label SystemTime;
        private System.Windows.Forms.TextBox KMS_Server_Adress;
        private System.Windows.Forms.TextBox Main_SNTP_Adress;
        private System.Windows.Forms.TextBox Reserve_SNTP_Adress;
        private System.Windows.Forms.Label Main_SNTP_Label;
        private System.Windows.Forms.Label Reserve_SNTP_Label;
        private System.Windows.Forms.Label W32Time_Servie_Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label System_Install_Date_Time_Label;
        private System.Windows.Forms.Label Text_label_win_install_date;
        private System.Windows.Forms.DateTimePicker New_Instal_dateTimePicker;
        private System.Windows.Forms.Label label_Sync_interval;
        private System.Windows.Forms.TextBox textBox_Sync_interval;
        private System.Windows.Forms.Button button_user_add;
        private System.Windows.Forms.TextBox textBox_user_name;
        private System.Windows.Forms.Button button_user_initialise;
        private System.Windows.Forms.CheckBox checkBox_user_add_section;
        private System.Windows.Forms.TextBox textBox_user_pass;
        private System.Windows.Forms.Label label_user_name;
        private System.Windows.Forms.Label label_user_pass;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.CheckBox chbx_admin_group;
        private System.Windows.Forms.CheckBox chbx_Iface_operators_group;
        private System.Windows.Forms.CheckBox chbx_users_groups;
        private System.Windows.Forms.CheckBox chbx_users_RDP_group;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbx_Event_reader_group;
        private System.Windows.Forms.Button button_user_delete;
        private System.Windows.Forms.Panel panel_user_add;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage OS_Tweak_tab;
        private System.Windows.Forms.TabPage OIK_client_tab;
        private System.Windows.Forms.CheckBox check_box_clear_clien_oik_settings;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage Network;
        private System.Windows.Forms.TextBox textBox_path_modus_file;
        private System.Windows.Forms.Button button_path_modus_file_copy;
        private System.Windows.Forms.CheckBox checkBox_OIK_styles_copy;
        private System.Windows.Forms.TextBox textBox_path_modus_file_destination;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_PC_name;
        private System.Windows.Forms.Label lbl_VendorName;
        private System.Windows.Forms.Label lbl_CPU;
        private System.Windows.Forms.Label lbl_OS_info;
        private System.Windows.Forms.Label lbl_hdd_model;
        private System.Windows.Forms.Label lbl_Memory_modules;
        private System.Windows.Forms.Label lbl_MB;
        private System.Windows.Forms.Button btn_PC_conf_update;
        private System.Windows.Forms.Button btn_PC_conf_export;
        private System.Windows.Forms.Label lbl_BIOS_Vendor;
        private System.Windows.Forms.Label lbl_BIOS_ver;
        private System.Windows.Forms.Label lbl_GPU;
        private System.Windows.Forms.Label lbl_BIOS_relese_date;
        private System.Windows.Forms.ComboBox cmbox_memory;
        private System.Windows.Forms.ComboBox cmbox_hdd;
        private System.Windows.Forms.ComboBox cmb_mapping_disk;
        private System.Windows.Forms.Label lbl_OS_version;
        private System.Windows.Forms.Button btn_get_network_adapters;
        private System.Windows.Forms.ListView lv_adapters;
        private System.Windows.Forms.ColumnHeader Num;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader MAC_Adress;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Net_Online;
        private System.Windows.Forms.ColumnHeader IP_Adr;
        private System.Windows.Forms.ListView lv_dynamic_route;
        private System.Windows.Forms.ColumnHeader Numb;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader Mask;
        private System.Windows.Forms.ColumnHeader Gateway;
        private System.Windows.Forms.ColumnHeader Interface;
        private System.Windows.Forms.ColumnHeader Metric;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage Dinamic_Routes;
        private System.Windows.Forms.TabPage Static_Routes;
        private System.Windows.Forms.ListView lv_static_route;
        private System.Windows.Forms.ColumnHeader Num_colum_static;
        private System.Windows.Forms.ColumnHeader Adress_colum_static;
        private System.Windows.Forms.ColumnHeader Mask_colum_static;
        private System.Windows.Forms.ColumnHeader Gateway_colum_static;
        private System.Windows.Forms.ColumnHeader Metric_colum_static;
        private System.Windows.Forms.Button btn_OIK_configTAB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_win_folders_optimize;
        private System.Windows.Forms.CheckBox checkBox_folder_OIK_rules;
        private System.Windows.Forms.CheckBox checkBox_change_owner_OIK_folder;
        private System.Windows.Forms.TextBox OIK_install_path;
        private System.Windows.Forms.Button Browse_oik_install_folder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cMS_adapters;
        private System.Windows.Forms.ToolStripMenuItem cMS_Adatres_Copy_Cell;
        private System.Windows.Forms.ToolStripMenuItem cMS_Adatres_Copy_String;
        private System.Windows.Forms.ToolStripMenuItem cMS_Adatres_Config_Adapter;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn index_nuber;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Name_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn SID_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_LocalPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_loaded;
        private System.Windows.Forms.ContextMenuStrip cMS_OIK_User;
        private System.Windows.Forms.ToolStripMenuItem cMS_OIK_User_Open_Profile_Folder;
        private System.Windows.Forms.ToolStripMenuItem cMS_OIK_Copy_UserName;
        private System.Windows.Forms.ToolStripMenuItem cMS_OIK_CopySID;
        private System.Windows.Forms.ToolStripMenuItem cMS_OIK_Copy_User_Path;
        private System.Windows.Forms.Button btn_TMS_Backup;
        private System.Windows.Forms.ToolStripMenuItem cMS_OIK_Reg_path_open;
        private System.Windows.Forms.Label Prog_Version;
        private System.Windows.Forms.ColumnHeader NetConnectionID;
        private System.Windows.Forms.ToolStripMenuItem cMS_Adatres_Copy_MAC;
        private System.Windows.Forms.CheckBox chbx_ModusFontsDefault;
        private System.Windows.Forms.CheckBox chbx_OIKFontsDefault;
        private System.Windows.Forms.CheckBox chbx_SystemFontsDefault;
        private System.Windows.Forms.CheckBox cbx_WinTimeSVC_On;
        private System.Windows.Forms.CheckBox checkBox_WindowsDefenderOff;
        private System.Windows.Forms.Label lbl_need_reboot_UAC;
        private System.Windows.Forms.Label lbl_need_reboot_WinDefender;
        private System.Windows.Forms.CheckBox cbx_check_All_OS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chbx_NoInternetIcon;
        private System.Windows.Forms.Label lbl_SerialNumber;
        private System.Windows.Forms.ContextMenuStrip cMS_route_edit;
        private System.Windows.Forms.ToolStripMenuItem Copy;
        private System.Windows.Forms.ToolStripMenuItem Change;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ToolStripMenuItem Add;
        private System.Windows.Forms.ColumnHeader Index;
        private System.Windows.Forms.ColumnHeader Index_column;
        private System.Windows.Forms.ToolStripMenuItem Refres;
        private System.Windows.Forms.ToolStripMenuItem Refresh;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ColumnHeader WorkOn;
    }
}

