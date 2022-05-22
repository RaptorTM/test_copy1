using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WindowsFormsApp1
{
    public partial class Form2_TMS_RBS_Backup : Form
    {
        string OIK_install_path = null;
        bool RBSstatus = false;
        bool TMSstatus = false;
        string CSName = null;
        string save_bkp_path = null;
        string[] file_list = null;
        string str_TBS_FBASES, str_TBS_FSECUR = null; //Параметры бэкапа RBS
        string str_TMS_FCFG, str_TMS_FARRAY, str_TMS_FALARMS, str_TMS_FSECUR = null; //Параметры бэкапа TMS

        public Form2_TMS_RBS_Backup()
        {
            InitializeComponent();
            check_OIK_Server_Install_Path();
        }

        //Ищем место установки сервера ОИК
        private void check_OIK_Server_Install_Path()
        {
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var reg = hklm.OpenSubKey(@"SOFTWARE\Wow6432Node\InterfaceSSH"))
                if (reg != null)
                {
                    string OIK_Reg_ServerPath = reg.GetValue("ServerPath").ToString();
                    reg.Close();
                    OIK_server_install_path.Text = OIK_Reg_ServerPath;
                }
                else
                {
                    /*
                    if (Directory.Exists("C:\\Program Files (x86)\\InterfaceSSH\\Server"))
                    {
                        OIK_server_install_path.Text = "C:\\Program Files (x86)\\InterfaceSSH\\Server";
                        return;
                    }
                    if (Directory.Exists("D:\\NTDISP\\InterfaceSSH\\Server"))
                    {
                        OIK_server_install_path.Text = "D:\\NTDISP\\InterfaceSSH\\Server";
                        return;
                    }
                    if (Directory.Exists("D:\\InterfaceSSH\\Server"))
                    {
                        OIK_server_install_path.Text = "D:\\InterfaceSSH\\Server";
                        return;
                    }
                    if (Directory.Exists("D:\\OIK\\InterfaceSSH\\Server"))
                    {
                        OIK_server_install_path.Text = "D:\\OIK\\InterfaceSSH\\Server";
                        return;
                    }
                    else
                    {
                        OIK_server_install_path.Text = "Не удалось найти сервер ОИК";
                    }
                    */
                    OIK_server_install_path.Text = "Не удалось найти сервер ОИК";
                }
        }

        public void Form2_TMS_RBS_Backup_Load(object sender, EventArgs e)
        {
            CSName = SystemInformation.ComputerName.ToString();
            lbl_PC_Name.Text = CSName;
            string[] separ_CSName;
            char[] separators = { '-', '_' };

            if (CSName.StartsWith("TM-"))
            {
                separ_CSName = CSName.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (separ_CSName.Length < 1)
                {
                    CSName = separ_CSName[0];
                    label_PO_Name.Visible = false; // ПО:
                    lbl_PO_Name.Visible = false; // Текст справа от ПО:
                    lbl_PO_Name.Text = null; //Обнуляем значение ПО, значит запущено на простой машине
                    label_RES_PS_Name.Visible = false; // РЭС:
                    lbl_RES_PS_Name.Visible = false; // Текст справа от РЭС:
                    lbl_RES_PS_Name.Text = null; //Обнуляем значение РЭС, значит запущено на простой машине
                }

                if (separ_CSName.Length <= 2)
                {
                    CSName = separ_CSName[0] + "-" + separ_CSName[1]; // Берём название ПО.
                    lbl_PO_Name.Text = separ_CSName[0] + "-" + separ_CSName[1]; // Берём название ПО.
                    lbl_RES_PS_Name.Text = null; //Обнуляем значение РЭС
                    label_RES_PS_Name.Visible = false; // РЭС:
                    lbl_RES_PS_Name.Visible = false; // Текст справа от РЭС:
                }

                if (separ_CSName.Length == 3)
                {
                    CSName = separ_CSName[0] + "-" + separ_CSName[1];
                    lbl_PO_Name.Text = separ_CSName[0] + "-" + separ_CSName[1];
                    lbl_RES_PS_Name.Text = separ_CSName[2];
                }

            }
            else
            {
                label_PO_Name.Visible = false; // ПО:
                lbl_PO_Name.Visible = false; // Текст справа от ПО:
                lbl_PO_Name.Text = null; //Обнуляем значение ПО, значит запущено на простой машине
                label_RES_PS_Name.Visible = false; // РЭС:
                lbl_RES_PS_Name.Visible = false; // Текст справа от РЭС:
                lbl_RES_PS_Name.Text = null; //Обнуляем значение РЭС, значит запущено на простой машине
            }

            txb_save_bkp_path.Text = txb_save_bkp_path.Text + CSName;
        }

        private void Form2_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region checkboxes
        private void chbx_RBS_Create_backup_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_RBS_Create_backup.Checked)
            {
                cb_RBS_BASES.Enabled = true;
                cb_RBS_BASES.Checked = true;
                cb_RBS_SECUR.Enabled = true;
                cb_RBS_SECUR.Checked = true;
                btn_Create_TMS_RBS_Backup.Enabled = true;
                rbs_ok.Visible = false;
            }
            else
            {
                cb_RBS_BASES.Enabled = false;
                cb_RBS_BASES.Checked = false;
                cb_RBS_SECUR.Enabled = false;
                cb_RBS_SECUR.Checked = false;
                if (!chbx_TMS_Create_backup.Checked) { btn_Create_TMS_RBS_Backup.Enabled = false; }
            }
        }

        private void chbx_TMS_Create_backup_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_TMS_Create_backup.Checked)
            {
                cb_TMS_ALARMS.Enabled = true;
                cb_TMS_ALARMS.Checked = true;
                cb_TMS_ARRAY.Enabled = true;
                cb_TMS_ARRAY.Checked = true;
                cb_TMS_CFG.Enabled = true;
                cb_TMS_CFG.Checked = true;
                cb_TMS_SECUR.Enabled = true;
                cb_TMS_SECUR.Checked = true;
                tms_ok.Visible = false;
                btn_Create_TMS_RBS_Backup.Enabled = true;
            }
            else
            {
                cb_TMS_ALARMS.Enabled = false;
                cb_TMS_ALARMS.Checked = false;
                cb_TMS_ARRAY.Enabled = false;
                cb_TMS_ARRAY.Checked = false;
                cb_TMS_CFG.Enabled = false;
                cb_TMS_CFG.Checked = false;
                cb_TMS_SECUR.Enabled = false;
                cb_TMS_SECUR.Checked = false;
                if (!chbx_RBS_Create_backup.Checked) { btn_Create_TMS_RBS_Backup.Enabled = false; }
            }
        }

        private void cb_RBS_BASES_CheckedChanged(object sender, EventArgs e) // База RBS
        {
            if (cb_RBS_BASES.Checked == true) { str_TBS_FBASES = " -FBASES "; } else { str_TBS_FBASES = null; };
        }

        private void cb_RBS_SECUR_CheckedChanged(object sender, EventArgs e)// Параметры безопасности RBS
        {
            if (cb_RBS_SECUR.Checked == true) { str_TBS_FSECUR = " -FSECUR"; } else { str_TBS_FSECUR = null; };
        }

        private void cb_TMS_CFG_CheckedChanged(object sender, EventArgs e) // Конфигурация TMS
        {
            if (cb_TMS_CFG.Checked == true) { str_TMS_FCFG = " -FCFG"; } else { str_TMS_FCFG = null; };
        }

        private void cb_TMS_ARRAY_CheckedChanged(object sender, EventArgs e) // Массив значений TMS
        {
            if (cb_TMS_ARRAY.Checked == true) { str_TMS_FARRAY = " -FARRAY"; } else { str_TMS_FARRAY = null; };
        }

        private void cb_TMS_ALARMS_CheckedChanged(object sender, EventArgs e) // Уставки TMS
        {
            if (cb_TMS_ALARMS.Checked == true) { str_TMS_FALARMS = " -FALARMS"; } else { str_TMS_FALARMS = null; };
        }

        private void cb_TMS_SECUR_CheckedChanged(object sender, EventArgs e) // Параметры безопасности TMS
        {
            if (cb_TMS_SECUR.Checked == true) { str_TMS_FSECUR = " -FSECUR"; } else { str_TMS_FSECUR = null; };
        }
        #endregion checkboxes


        #region Создание бэкапа RBS TMS ОИК

        
        private void Create_RBS_Backup()
        {
            //ifs_bkup RB -M. -SRBS(где RBS имя сервера RBS) -D\Путь к месту сохранения str_TBS_FBASES + str_TBS_FSECUR
            OIK_install_path = OIK_server_install_path.Text;
            string RBS = "\"" + OIK_install_path + "ifs_bkup.exe\"" + " RB -M." + " -SRBS " + "-D" + save_bkp_path.Replace(@"\\", @"\") + str_TBS_FBASES + str_TBS_FSECUR;

            var startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = @"C:\Windows\System32";
            startInfo.FileName = @"C:\Windows\System32\cmd.exe";
            startInfo.Arguments = "cmd " + "/C " + RBS;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            var cmd_proc = new Process();
            cmd_proc.StartInfo = startInfo;
            cmd_proc.Start();
            cmd_proc.WaitForExit();

 //           File.WriteAllText(save_bkp_path + @"\rbs.txt", RBS);
        }

        private void Create_TMS_Backup()
        {
            OIK_install_path = OIK_server_install_path.Text;
            //ifs_bkup TM -M. -STMS(где TMS имя сервера TMS) -D\Путь к месту сохранения str_TMS_FCFG + str_TMS_FARRAY + str_TMS_FALARMS + str_TMS_FSECUR
            string TMS = "\"" + OIK_install_path + "ifs_bkup.exe\"" + " TM" + " -M." + " -STMS " + "-D" + save_bkp_path.Replace(@"\\", @"\") + str_TMS_FCFG + str_TMS_FARRAY + str_TMS_FALARMS + str_TMS_FSECUR;

            var startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = @"C:\Windows\System32";
            startInfo.FileName = @"C:\Windows\System32\cmd.exe";
            startInfo.Arguments = "cmd " + "/C " + TMS;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            var cmd_proc = new Process();
            cmd_proc.StartInfo = startInfo;
            cmd_proc.Start();
            cmd_proc.WaitForExit();

//            File.WriteAllText(save_bkp_path + @"\tms.txt", TMS);


        }

        //Отображаем "Готово" при наличии файлов
        private void Check_RBS_bkp()
        {
            for (int i = 0; i < file_list.Length; i++)
            {
                if (chbx_RBS_Create_backup.Checked)
                    if (file_list[i].Contains("RbsBackup"))
                    {
                        rbs_ok.Visible = true;
                        chbx_RBS_Create_backup.Checked = false;
                        btn_Create_TMS_RBS_Backup.Enabled = false;
                        RBSstatus = true;
                        return;
                    }
            }
        }

        private void btn_Browse_bkp_folder_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(save_bkp_path))
            {
                Process explorer = new Process();
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.CreateNoWindow = true;
                StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                StartInfo.FileName = "explorer";
                StartInfo.Arguments = @save_bkp_path.Replace(@"\\",@"\");
                StartInfo.UseShellExecute = false;
                explorer.StartInfo = StartInfo;
                explorer.Start();
                
            }
        }

        //Отображаем "Готово" при наличии файлов
        private void Check_TMS_bkp()
        {
            for (int i = 0; i < file_list.Length; i++)
            {
                if (chbx_TMS_Create_backup.Checked)
                {
                    if (file_list[i].Contains("TmsBackup"))
                    {
                        tms_ok.Visible = true;
                        chbx_TMS_Create_backup.Checked = false;
                        btn_Create_TMS_RBS_Backup.Enabled = false;
                        TMSstatus = true;
                        return;
                    }
                }
            }
        }
        #endregion


        private void btn_OIKServerPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (dialog.SelectedPath != "") { OIK_server_install_path.Text = dialog.SelectedPath; };
        }


        private void btn_SavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (dialog.SelectedPath != "" && dialog.SelectedPath.EndsWith(@"\\")) { txb_save_bkp_path.Text = dialog.SelectedPath.EndsWith(@"\\") + CSName; }
            else { { txb_save_bkp_path.Text = dialog.SelectedPath + @"\" + CSName; }; }
        }


        private void btn_Create_TMS_RBS_Backup_Click(object sender, EventArgs e)
        {

            //            save_bkp_path = txb_save_bkp_path.Text + @"\" + CSName + @"\" + DateTime.Now.ToString().Replace(":", ".").Replace(" ", "_").Replace("/", ".").Replace(@"\", ".");
            save_bkp_path = txb_save_bkp_path.Text + @"\" + DateTime.Now.ToString().Replace(":", ".").Replace(" ", "_").Replace("/", ".").Replace(@"\", ".");
            if (!save_bkp_path.Contains(" "))
            {
                Directory.CreateDirectory(save_bkp_path);
                if (chbx_RBS_Create_backup.Checked == true) { Create_RBS_Backup(); };
                if (chbx_TMS_Create_backup.Checked == true) { Create_TMS_Backup(); };
                file_list = Directory.GetFiles(save_bkp_path);
                if (chbx_RBS_Create_backup.Checked == true) { Check_RBS_bkp(); };
                if (chbx_TMS_Create_backup.Checked == true) { Check_TMS_bkp(); };

                //Отображаем ошибку если нет файла RBS
                if (chbx_RBS_Create_backup.Checked && !RBSstatus)
                {
                    chbx_RBS_Create_backup.Checked = false;
                    rbs_ok.ForeColor = Color.Red;
                    rbs_ok.Visible = true;
                    rbs_ok.Text = "Ошибка";
                }
                //Отображаем ошибку если нет файла TMS
                if (chbx_TMS_Create_backup.Checked && !TMSstatus)
                {
                    chbx_TMS_Create_backup.Checked = false;
                    tms_ok.ForeColor = Color.Red;
                    tms_ok.Visible = true;
                    tms_ok.Text = "Ошибка";
                }
                btn_Create_TMS_RBS_Backup.BringToFront();

                if (RBSstatus || TMSstatus) { btn_Browse_bkp_folder.Enabled = true; }
            }
            else
            {
                ToolTip tt = new ToolTip();
                tt.Active = true;
                tt.Show("Путь не должен содержать пробелы", txb_save_bkp_path, 5, 18, 5000); //Всплывающее окошко с ошибкой при наличии такого пользователя в системе
            }
        }




    }
}
