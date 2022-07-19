using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using Microsoft.Win32;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.AccessControl;
using System.Deployment.Application;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
//        public const string V = " \n";
        public bool check_oik_folder = false;
        Boolean tab_control = false;
        string CurrentOS = null;
        string selected_DTG_username = null;
        string selected_DTG_userSID = null;
        string selected_DTG_user_local_path = null;
        string selected_DTG_user_loaded = null;
        string lbl_PC_export_name = null;
        string set_owner_all_users = null;
        string System_lang = null;
        string copy_path_to = null;
        string OIK_install_path_str = "C:\\Program Files (x86)\\InterfaceSSH\\Server"; //Путь где хранится сервер ОИК поумочанию. Путь хранится в свойстве Text в текстбокса OIK_install_path.
        public readonly System.Windows.Forms.Timer Update_Time; // Это идет до public Form1()
        public readonly System.Windows.Forms.Timer Update_Time_Zone;
        bool runningAsAdmin = WindowsIdentity.GetCurrent().Owner.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid); //Проверяем права администратора у текущего пользователя
        
        


        public Form1()
        {   
            InitializeComponent();

            //Получаем версию ОС
            #region Получаем версию ОС
            if (runningAsAdmin)
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var reg = hklm.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    CurrentOS = reg.GetValue("ProductName").ToString();
                    reg.Close();
                    if (!CurrentOS.Contains("Windows 10"))
                    {
                        checkBox_WindowsDefenderOff.Enabled = false;
                        chbx_NoInternetIcon.Enabled = false;
                    }
                }
            }
            #endregion

            //Получаем язык системы для задания пользователей либо Вcе либо Everyone
            #region Проверка языка системы
            System_lang = System.Globalization.CultureInfo.CurrentCulture.Name;
            if (System_lang == "ru-RU") { set_owner_all_users = "Все"; } else { set_owner_all_users = "Everyone"; };

            if (System_lang != "ru-RU" && System_lang != "en-EN" && System_lang != "en-US") //Если язык не соответствует рус и англ выключаем настройку владель и прав
            { checkBox_change_owner_OIK_folder.Enabled = false; 
              checkBox_folder_OIK_rules.Enabled = false;
              Browse_oik_install_folder.Enabled = false;
              OIK_install_path.Enabled = false;
            };
            #endregion Проверка языка системы

            //Начало отображаем на основной форме время в TextBox и часовой пояс, обновляем их по таймеру
            TimeZoneInfo.ClearCachedData();
            SystemTime.Text = DateTime.Now.ToString(@"HH:mm:ss dd\MM\yyyy");
            TimeZone.Text = TimeZoneInfo.Local.DisplayName;
            Update_Time = new System.Windows.Forms.Timer();
            Update_Time_Zone = new System.Windows.Forms.Timer();
            Update_Time.Interval = 500;
            Update_Time_Zone.Interval = 2000;
            Update_Time.Enabled = true;
            Update_Time_Zone.Enabled = true;
            Update_Time.Tick += new EventHandler(timer_Tick);
            Update_Time_Zone.Tick += new EventHandler(clearcacheddata_for_time_zone);
            //Конец
            TakeWInSetupTime(); //При нажатии на кнопку, вызываем функцию TakeWInSetupTime_Click(считываем текущую дату установки ОС) и ибновляем дату установки ОС в главном окне System_Install_Date_Time_Label
            #region //Проверяем состояние службы времени Windows
            //Начало 
            ServiceController sc_W32Time = new ServiceController();
            sc_W32Time.ServiceName = "W32Time";
            if (sc_W32Time.Status == ServiceControllerStatus.Running)  //Проверяем запущена ли служба
            {
                W32Time_Servie_Label.Text = "Служба времени Windows - Запущена";
            }
            else
            {
                W32Time_Servie_Label.Text = "Служба времени Windows - Остановлена";
            }
            //Конец проверяем состояние службы времени Windows
            #endregion

            #region // Считываем дату установки ОС в System_Install_Date_Time_Label на главной форме
            //Начало (Универсальный подход для чтения параметров в реестре. (Проблема перенаправления в х64 в ветку WoW6432)
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var reg = hklm.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"))
            {
                TimeZoneInfo.ClearCachedData(); //Очищаем кэш TimeZoneInfo, что бы дата корректно обновлялась после смены часового пояса
                var timeZone = TimeZoneInfo.Local.BaseUtcOffset.Hours; //Получаем значение часового пояса.
                string reg1 = (string)reg.GetValue("InstallDate").ToString();
                decimal dec_unix_seconds = Convert.ToDecimal(reg1);                             //Приводим string со значением в (reg1) к десятичному значению в (f111)
                Int32 int_unix_seconds = (Int32)dec_unix_seconds;                                           //Приводим десятичное значение в (f111) к int в (f222)
                DateTime pDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(int_unix_seconds); //Преобразуем Unix время в нормальное время                                                                                                                     //                var installDateUTC = DateTimeOffset.FromUnixTimeSeconds(int_unix_seconds).UtcDateTime.AddHours(timeZone); // Полностью рабочий метод, аналог DateTime pDate = new DateTime
                System_Install_Date_Time_Label.Text = pDate.AddHours(timeZone).ToString(); // Выводим дату и время установки + текущий часовой пояс timeZone ко времени UTC для коррекции смещения часовых поясов
                reg.Close();
            }
            #endregion

            #region //Задаём серый фон по умолчанию для dataGridView1 
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;
            #endregion
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //Проверяем наличе прав администратора, если нет закрываем программу.
            if (!runningAsAdmin)
            {
                MessageBox.Show("Запустите программу от имени администратора", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            string version = Application.ProductVersion;

            Prog_Version.Text = "Версия: " + version;

        }

        #region //Таймеры обновления параметров на главной форме
        //Функция обновления времени на основной форме время по таймеру
        void timer_Tick(object sender, EventArgs e)
        {
            SystemTime.Text = DateTime.Now.ToString(@"HH:mm:ss dd MM yyyy");
            TimeZone.Text = TimeZoneInfo.Local.DisplayName;
        }

        // Очищаем значение TimeZoneInfo.ClearCachedData по таймеру, для своевременного отображения актуального часового пояса
        void clearcacheddata_for_time_zone(object sender, EventArgs e)
        {
            TimeZoneInfo.ClearCachedData();
            TimeZone.Text = TimeZoneInfo.Local.DisplayName;
        }
        #endregion

        //Твики ОС
        #region Раздел твиков Windows
        #region Интерфейс
        //Выводит соосбщение "Требуется перезагрузка возле чекбокса" "Отключить UAC (Контроль учётных записей)"
        private void uac_off_CheckedChanged(object sender, EventArgs e)
        {
            if (uac_off.Checked) { lbl_need_reboot_UAC.Visible = true; }
            else { lbl_need_reboot_UAC.Visible = false; };
        }

        private void cbx_check_All_OS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_check_All_OS.Checked)
            {
                //Твики ОС
                firewall_off.Checked = true;
                uac_off.Checked = true;
                rdp_on.Checked = true;
                nla_off.Checked = true;
                superFetch_off.Checked = true;
                winsearch_off.Checked = true;
                chbx_NoInternetIcon.Checked = true;
                checkBox_NumLock_on.Checked = true;
                if (checkBox_WindowsDefenderOff.Enabled) { checkBox_WindowsDefenderOff.Checked = true; }
                cbx_WinTimeSVC_On.Checked = true;
                cbx_check_All_OS.Text = "Отменить всё";
                //Параметры Энергосбережения
                monitor_optimize_off.Checked = true;
                hdd_optimize_off.Checked = true;
                hybernation_off.Checked = true;
                sleep_mode_off.Checked = true;
            }
            if(!cbx_check_All_OS.Checked)
            {
                //Твики ОС
                firewall_off.Checked = false;
                uac_off.Checked = false;
                rdp_on.Checked = false;
                nla_off.Checked = false;
                superFetch_off.Checked = false;
                winsearch_off.Checked = false;
                chbx_NoInternetIcon.Checked = false;
                checkBox_NumLock_on.Checked = false;
                if (checkBox_WindowsDefenderOff.Enabled) { checkBox_WindowsDefenderOff.Checked = false; }
                cbx_WinTimeSVC_On.Checked = false;
                cbx_check_All_OS.Text = "Выбрать всё";
                //Параметры Энергосбережения
                monitor_optimize_off.Checked = false;
                hdd_optimize_off.Checked = false;
                hybernation_off.Checked = false;
                sleep_mode_off.Checked = false;
            }
        }

        //Выводит соосбщение "Требуется перезагрузка возле чекбокса" "Отключить защитник Windows"
        private void checkBox_WindowsDefenderOff_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_WindowsDefenderOff.Checked) { lbl_need_reboot_WinDefender.Visible = true; }
            else { lbl_need_reboot_WinDefender.Visible = false; };
        }

        //Снимает галки после выполнения
        private void CheckBoxUncheck()
        {

            cbx_WinTimeSVC_On.Checked = false;

            //Твики ОС
            firewall_off.Checked = false;
            uac_off.Checked = false;
            rdp_on.Checked = false;
            nla_off.Checked = false;
            superFetch_off.Checked = false;
            winsearch_off.Checked = false;
            checkBox_NumLock_on.Checked = false;
            checkBox_WindowsDefenderOff.Checked = false;
            chbx_NoInternetIcon.Checked = false;

            //Параметры Энергосбережения
            monitor_optimize_off.Checked = false;
            hdd_optimize_off.Checked = false;
            hybernation_off.Checked = false;
            sleep_mode_off.Checked = false;
            cbx_check_All_OS.Checked = false;
        }
        #endregion Интерфейс


        private void run_programm_Click(object sender, EventArgs e) // Раздел отключения функций
        {
            // Отключение сна для монитора
            if (monitor_optimize_off.Checked == true)
            {
                string cmd = "cmd.exe";
                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd + "/C POWERCFG - Change - monitor - timeout - ac 0 & POWERCFG - Change - monitor - timeout - dc 0",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);
                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG - Change - monitor - timeout - ac 0");
                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG - Change - monitor - timeout - dc 0");
            }

            // Отключение парковки HDD (По умолчанию через 20 минут)
            if (hdd_optimize_off.Checked == true)
            {

                string cmd = "cmd.exe";
                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd + "/C POWERCFG -Change -disk-timeout-ac 0 & POWERCFG -Change -disk-timeout-dc 0",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);

                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -disk-timeout-ac 0");
                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -disk-timeout-dc 0");
            }

            // Отключение Гибернации
            if (hybernation_off.Checked == true)
            {
                string cmd = "cmd.exe";
                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd + "/C POWERCFG -Change -hibernate-timeout-ac 0 & POWERCFG -Change -hibernate-timeout-dc 0",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);

                string cmd1 = "cmd.exe";
                var proc1 = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd1 + "/C powercfg -hibernate off",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc1);

                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -hibernate-timeout-ac 0");
                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -hibernate-timeout-dc 0");
                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K powercfg -hibernate off");
            }

            // Отключение Сна
            if (sleep_mode_off.Checked == true)
            {
                string cmd = "cmd.exe";
                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd + "/C POWERCFG -Change -standby-timeout-ac 0 & POWERCFG -Change -standby-timeout-dc 0",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);

                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -standby-timeout-ac 0");
                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -standby-timeout-dc 0");
            }

            // Отключение Брандмауера
            if (firewall_off.Checked == true)
            {
                string cmd = "cmd.exe";
                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd + "/C NetSh Advfirewall set allprofiles state off",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);

                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K NetSh Advfirewall set allprofiles state off");
            }

            // Отключение UAC
            if (uac_off.Checked == true)
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var reg = hklm.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"))
                {
                    reg.SetValue("EnableLUA", 0, RegistryValueKind.DWord);
                    reg.Close();
                }

                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K reg add \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" /v EnableLUA /t REG_DWORD /d 0 /f");
            }

            // Включение RDP
            if (rdp_on.Checked == true)
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var reg = hklm.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server"))
                {
                    reg.SetValue("fDenyTSConnections", 0, RegistryValueKind.DWord);
                    reg.Close();
                }

                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Terminal Server\" /v fDenyTSConnections /t REG_DWORD /d 1 /f");
            }

            // Отключение NLA (Network Level Authentication) аутентификация на уровне сети
            if (nla_off.Checked == true)
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var reg = hklm.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp"))
                {
                    reg.SetValue("UserAuthentication", 0, RegistryValueKind.DWord);
                    reg.Close();
                }
                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Terminal Server\\WinStations\\RDP-Tcp\" /v UserAuthentication /t REG_DWORD /d 0 /f");
            }

            // Отключение службы SuperFetch
            if (superFetch_off.Checked == true)
            {
                string cmd = "cmd.exe";
                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd + "/C sc stop SysMain & sc config SysMain start=disabled",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);
                //                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K sc stop SysMain & sc config SysMain start=disabled");
            }

            // Отключение службы Windows Search
            if (winsearch_off.Checked == true)
            {
                string cmd = "cmd.exe";
                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd + "/C sc stop wsearch & sc config wsearch start=disabled",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);

                //               Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K sc stop wsearch & sc config wsearch start=disabled");
            }

            //Включение NumLock
            if (checkBox_NumLock_on.Checked)
            {
                using (var HKU = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                using (var reg = HKU.CreateSubKey(@".DEFAULT\Control Panel\Keyboard"))
                {
                    if (reg.GetValue("InitialKeyboardIndicators") != null)
                    {
                        reg.SetValue("InitialKeyboardIndicators", "2147483650");
                        reg.Close();
                    }
                    else
                    {
                        reg.SetValue("InitialKeyboardIndicators", "2147483650", RegistryValueKind.String);
                        reg.Close();
                    }
                }
            }

            // Отключение Защитника Windows
            if (checkBox_WindowsDefenderOff.Checked == true)
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var reg = hklm.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender"))
                {
                    reg.SetValue("DisableAntiSpyware", 1, RegistryValueKind.DWord);
                    reg.SetValue("AllowFastServiceStartup", 0, RegistryValueKind.DWord);
                    reg.SetValue("ServiceKeepAlive", 0, RegistryValueKind.DWord);
                    reg.CreateSubKey("Real-Time Protection");
                    var reg1 = hklm.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection");
                    reg1.SetValue("DisableAntiSpywareRealtimeProtection", 1, RegistryValueKind.DWord);
                    reg1.SetValue("DisableRealtimeMonitoring", 1, RegistryValueKind.DWord);
                    reg1.SetValue("DpaDisabled", 1, RegistryValueKind.DWord);
                    reg1.SetValue("DisableBehaviorMonitoring", 1, RegistryValueKind.DWord);
                    reg1.SetValue("DisableOnAccessProtection", 1, RegistryValueKind.DWord);
                    reg1.SetValue("DisableScanOnRealtimeEnable", 1, RegistryValueKind.DWord);
                    reg1.SetValue("DisableIOAVProtection", 1, RegistryValueKind.DWord);
                    reg.CreateSubKey("Spynet");
                    var reg2 = hklm.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Spynet");
                    reg2.SetValue("DisableBlockAtFirstSeen", 1, RegistryValueKind.DWord);
                    reg2.SetValue("LocalSettingOverrideSpynetReporting", 0, RegistryValueKind.DWord);
                    reg2.SetValue("SubmitSamplesConsent", 2, RegistryValueKind.DWord);
                    var reg3 = hklm.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\SmartScreen");
                    reg3.SetValue("ConfigureAppInstallControl", "Anywhere", RegistryValueKind.String);
                    reg3.SetValue("ConfigureAppInstallControlEnabled", 1, RegistryValueKind.DWord);
                    reg3.Close();
                    /*
                    var reg4 = hklm.CreateSubKey(@"SOFTWARE\Microsoft\Windows Defender");
                    reg4.SetValue("DisableAntiSpyware", 1, RegistryValueKind.DWord);
                    reg4.SetValue("DisableAntiVirus", 1, RegistryValueKind.DWord);
                    var reg5 = hklm.CreateSubKey(@"SOFTWARE\Microsoft\Windows Defender\Features");
                    reg5.SetValue("TamperProtection", 0, RegistryValueKind.DWord);
                    reg5.SetValue("TamperProtectionSource", 5, RegistryValueKind.DWord);
                    */
                }
            }

            // Отключить уведомление "Нет соединения с интернетом"
            if (chbx_NoInternetIcon.Checked == true)
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var reg = hklm.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Network Connections"))
                {
                    reg.SetValue("NC_PersonalFirewallConfig", 1, RegistryValueKind.DWord);
                    reg.Close();
                }
            }

            // Настройка сервера Активации KMS
            if (SetKMSServer.Checked == true)
            {
                string cmd = "cmd.exe";
                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd + "/C slmgr /skms " + KMS_Server_Adress.Text,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);

            }

            // Настройка сервера синхронизации времени
            if (SetTimeSyncServer.Checked == true)
            {

                ServiceController sc_W32Time = new ServiceController();
                sc_W32Time.ServiceName = "W32Time";

                if (sc_W32Time.Status == ServiceControllerStatus.Running)  //Проверяем запущена ли служба
                {
                    try
                    {
                        // Останавливаем службу если она запущена
                        sc_W32Time.Stop();
                        sc_W32Time.WaitForStatus(ServiceControllerStatus.Stopped);
                        W32Time_Servie_Label.Text = "Служба времени Windows - Остановлена";
                    }
                    catch (InvalidOperationException)
                    {
                        DialogResult error = MessageBox.Show("Не удалось остановить службу времени Windows", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        W32Time_Servie_Label.Text = "Служба времени Windows - Запущена";
                    }
                }

                // Удаляем все сервера NTP существующие в системе
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var regcheck = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\DateTime\Servers"))
                using (var regdel = hklm.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\DateTime"))
                {
                    if (regcheck == null) //Если папка Servers отсутствует в реестре то создаём папку
                    {
                        regdel.CreateSubKey("Servers");
                        regdel.Close();
                        hklm.Close();
                    }
                    else // Если папка Servers существует, то удаляем её и создаём снова(для удаления всех ключей)
                    {
                        regdel.DeleteSubKey("Servers");
                        regdel.CreateSubKey("Servers");
                        regdel.Close();
                        hklm.Close();
                    }
                }


                //Добавляем новые сервера NTP
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var reg0 = hklm.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\DateTime\Servers"))
                {
                    reg0.SetValue(null, 1, RegistryValueKind.String); //Записываем значение "По умолчанию" в реестр
                    reg0.SetValue("1", Main_SNTP_Adress.Text, RegistryValueKind.String); //Записываем адрес основного сервера в реестр
                    reg0.SetValue("2", Reserve_SNTP_Adress.Text, RegistryValueKind.String); //Записываем адрес резервного сервера в реестр
                    reg0.Close();
                }

                //Добавляем новые сервера NTP в параметры NTPserver с префиксом ,0x1
                RegistryKey reg1 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\W32Time\Parameters"); //Переходим по пути и пткрываем ветку реестра в режиме модификации
                reg1.SetValue("Type", "NTP", RegistryValueKind.String);
                string NTP_server_adress_arrov = Main_SNTP_Adress.Text + ",0x1 " + Reserve_SNTP_Adress.Text + ",0x1"; //Собираем строку из значений IP адресов осн. и рез сервера NTP
                reg1.SetValue("NtpServer", NTP_server_adress_arrov, RegistryValueKind.String); //Записываем значение в реестр
                reg1.Close();

                //Изменяем интервал синхронизации в параметре SpecialPollInterval
                RegistryKey reg2 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\W32Time\TimeProviders\NtpClient");//Переходим по пути и пткрываем ветку реестра в режиме модификации
                reg2.SetValue("SpecialPollInterval", textBox_Sync_interval.Text, RegistryValueKind.DWord); //Записываем значение в реестр
                reg2.Close();

                //Изменяем интервал синхронизации в параметре UpdateInterval
                RegistryKey reg3 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\W32Time\Config");//Переходим по пути и пткрываем ветку реестра в режиме модификации
                reg3.SetValue("UpdateInterval", textBox_Sync_interval.Text, RegistryValueKind.DWord); //Записываем значение в реестр
                reg3.Close();

                //Задаём максимально возможное отклонение показания часов при которых может выполнятся синхронизация(для того что бы синхронизация работала  
                //даже при очень большой разнице между локальным временем ПК и временем сервера NTP
                RegistryKey reg5 = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\W32Time\Config");
                reg5.SetValue("MaxNegPhaseCorrection", unchecked((int)0xffffffff), RegistryValueKind.DWord);
                reg5.SetValue("MaxPosPhaseCorrection ", unchecked((int)0xffffffff), RegistryValueKind.DWord);
                reg5.Close();

                if (sc_W32Time.Status == ServiceControllerStatus.Stopped)  //Проверяем запущена ли служба
                {
                    try
                    {
                        //Запускаем службу если она остановлена
                        sc_W32Time.Start();
                        sc_W32Time.WaitForStatus(ServiceControllerStatus.Running);
                        W32Time_Servie_Label.Text = "Служба времени Windows - Запущена";
                    }

                    catch (InvalidOperationException)
                    {
                        W32Time_Servie_Label.Text = "Служба времени Windows - Остановлена";
                    }

                }
            }

            // Включаем автозапуск службы времени Windows
            if (cbx_WinTimeSVC_On.Checked)
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var reg = hklm.CreateSubKey(@"SYSTEM\ControlSet001\Services\W32Time"))
                {
                    reg.SetValue("Start", 2, RegistryValueKind.DWord);
                    reg.CreateSubKey("Real-Time Protection");
                    reg.Close();
                }

                string cmd = "cmd.exe";
                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd + "/C sc start W32Time",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);


            }    

            MessageBox.Show("Готово", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CheckBoxUncheck();
        }
        #endregion

        //Регион настройки пользователей и групп
        #region Настройка времени, активации и пользователей ОС

        //Проверяем CheckBox на KMS сервере
        private void SetKMSServer_CheckedChanged(object sender, EventArgs e)
        {
            if (SetKMSServer.Checked)
            {
                KMS_Server_Adress.Enabled = true;
            }
            else
            {
                KMS_Server_Adress.Enabled = false;
            }
        }

        //Проверяем CheckBox на Синхронизации времени
        private void SetTimeSyncServer_CheckedChanged(object sender, EventArgs e)
        {
            int Sync_interval = 300; //Время синхронизации поумочанию отображаемое в textBox_Sync_interval ghb вкл\выкл checkbox
            if (SetTimeSyncServer.Checked)
            {

                Main_SNTP_Adress.Enabled = true;
                Reserve_SNTP_Adress.Enabled = true;
                textBox_Sync_interval.Enabled = true;
                textBox_Sync_interval.Text = Sync_interval.ToString();
            }
            else
            {
                Main_SNTP_Adress.Enabled = false;
                Reserve_SNTP_Adress.Enabled = false;
                textBox_Sync_interval.Text = Sync_interval.ToString();
                textBox_Sync_interval.Enabled = false;
            }
        }

        //Проверка символов вводимых в textBox_Sync_interval, если не число то ввод игнорируется 
        #region Проверка значения вводимого в textBox_Sync_interval
        private void textBox_Sync_interval_TextChanged(object sender, EventArgs e) //Проверка символов вводимых в textBox_Sync_interval, если не число то ввод игнорируется 
        {
            if (!int.TryParse(textBox_Sync_interval.Text, out int a))
            {
                textBox_Sync_interval.Text = "300";
            }
        }
        #endregion //Проверка символов вводимых в textBox_Sync_interval, если не число то ввод игнорируется  

        //Считывание и изменение даты установки ОС
        #region Считывание и изменение даты установки ОС

        //Чек бокс для изменения времени ОС
        private void Change_System_Install_Time_СheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Change_System_Install_Time_СheckBox.Checked)
            {
                label2.Enabled = true;
                New_Instal_dateTimePicker.Enabled = true;
                ChangeWInSetupTime_Button.Enabled = true;
            }
            else
            {
                label2.Enabled = false;
                New_Instal_dateTimePicker.Enabled = false;
                ChangeWInSetupTime_Button.Enabled = false;
            }
        }

        //Получаем время установки ОС
        private void TakeWInSetupTime()
        {
            //Начало (Универсальный подход для чтения параметров в реестре. (Проблема перенаправления в х64 в ветку WoW6432)
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var reg = hklm.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"))
            {
                TimeZoneInfo.ClearCachedData();                                                             //Очищаем кэш TimeZoneInfo, что бы дата корректно обновлялась после смены часового пояса
                var timeZone = TimeZoneInfo.Local.BaseUtcOffset.Hours;                                      //Получаем значение часового пояса.
                string reg1 = (string)reg.GetValue("InstallDate").ToString();                               //Инициализируем string reg1 и помещаем в неё значение installdate приведнное к string при считывании
                decimal dec_unix_seconds = Convert.ToDecimal(reg1);                                         //Приводим string со значением в (reg1) к десятичному значению в (f111)
                Int32 int_unix_seconds = (Int32)dec_unix_seconds;                                           //Приводим десятичное значение в (f111) к int в (f222)
                DateTime pDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(int_unix_seconds); //Преобразуем Unix время в нормальное время                                                                                                                     //                var installDateUTC = DateTimeOffset.FromUnixTimeSeconds(int_unix_seconds).UtcDateTime.AddHours(timeZone); // Полностью рабочий метод, аналог DateTime pDate = new DateTime
                System_Install_Date_Time_Label.Text = pDate.AddHours(timeZone).ToString();                  // Выводим дату и время установки + текущий часовой пояс timeZone ко времени UTC для коррекции смещения часовых поясов
                reg.Close();
            }
        }

        //Функция получения времени установки ОС
        private void ChangeWInSetupTime_Click(object sender, EventArgs e)
        {
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var reg = hklm.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"))
            {
                var timeZone = TimeZoneInfo.Local.BaseUtcOffset.Hours;
                var now_date_time = DateTimeOffset.UtcNow.DateTime.AddHours(timeZone);
                double unixTime = (New_Instal_dateTimePicker.Value - new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
                int UTC_date_time = Convert.ToInt32(unixTime) - (timeZone * 3600);
                reg.SetValue("InstallDate", unchecked(UTC_date_time), RegistryValueKind.DWord);
                reg.Close();
            }
            TakeWInSetupTime();
        }
        #endregion

        //Область управления checkbox в разделе добавления пользователей
        public void checkBox_user_add_section_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_user_add_section.Checked)
            {
                button_user_add.Enabled = true;
                button_user_initialise.Enabled = true;
                button_user_delete.Enabled = true;
                textBox_user_name.Enabled = true;
                textBox_user_pass.Enabled = true;
                panel_user_add.Enabled = true;
                chbx_admin_group.Enabled = true;
                chbx_Iface_operators_group.Enabled = true;
                chbx_users_groups.Enabled = true;
                chbx_users_RDP_group.Enabled = true;
                chbx_Event_reader_group.Enabled = true;
            }

            else
            {
                button_user_add.Enabled = false;
                button_user_initialise.Enabled = false;
                button_user_delete.Enabled = false;
                textBox_user_name.Enabled = false;
                textBox_user_pass.Enabled = false;
                panel_user_add.Enabled = false;
                chbx_admin_group.Enabled = false;
                chbx_Iface_operators_group.Enabled = false;
                chbx_users_groups.Enabled = false;
                chbx_users_RDP_group.Enabled = false;
                chbx_Event_reader_group.Enabled = false;
                chbx_admin_group.Checked = false;
                chbx_Iface_operators_group.Checked = false;
                chbx_users_groups.Checked = false;
                chbx_users_RDP_group.Checked = false;
                chbx_Event_reader_group.Checked = false;
                textBox_user_name.Text = "";
                textBox_user_pass.Text = "";
            }
        }

        //Раздел добавления пользователей и настройка групп пользователей
        private void button_user_add_Click(object sender, EventArgs e)
        {
            //            CreateLocalWindowsAccount(textBox_user_name.Text, textBox_user_pass.Text, "", textBox_user_name.Text, true, false);

            try
            {
                PrincipalContext context = new PrincipalContext(ContextType.Machine);
                UserPrincipal user = new UserPrincipal(context);
                user.SetPassword(textBox_user_pass.Text);
                user.DisplayName = "";
                user.Name = textBox_user_name.Text;
                user.Description = "";
                user.UserCannotChangePassword = false;
                user.PasswordNeverExpires = true;
                user.Save();

                if (chbx_admin_group.Checked) // Группа администратора 
                {
                    string cmd = "cmd.exe";
                    var proc = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        WorkingDirectory = @"C:\Windows\System32",
                        FileName = @"C:\Windows\System32\cmd.exe",
                        Arguments = cmd + "/C net localgroup " + chbx_admin_group.Text + " " + textBox_user_name.Text + " /add & net localgroup Administrators " + textBox_user_name.Text + " /add",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process.Start(proc);
                }
                if (chbx_Iface_operators_group.Checked) // Группа iface operators
                {
                    string cmd = "cmd.exe";
                    var proc = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        WorkingDirectory = @"C:\Windows\System32",
                        FileName = @"C:\Windows\System32\cmd.exe",
                        Arguments = cmd + "/C net localgroup " + chbx_Iface_operators_group.Text + " " + textBox_user_name.Text + " /add",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process.Start(proc);
                }
                if (chbx_users_groups.Checked) //Пользователи
                {
                    string cmd = "cmd.exe";
                    var proc = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        WorkingDirectory = @"C:\Windows\System32",
                        FileName = @"C:\Windows\System32\cmd.exe",
                        Arguments = cmd + " /C net localgroup " + chbx_users_groups.Text + " " + textBox_user_name.Text + " /add & net localgroup Users " + textBox_user_name.Text + " /add",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process.Start(proc);
                }
                if (chbx_users_RDP_group.Checked) //Пользователи удаленного рабочего стола
                {
                    string cmd = "cmd.exe";
                    var proc = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        WorkingDirectory = @"C:\Windows\System32",
                        FileName = @"C:\Windows\System32\cmd.exe",
                        Arguments = cmd + " /C net localgroup " + "\"" + "Пользователи удаленного рабочего стола" + "\"" + " " + textBox_user_name.Text + " /add & net localgroup \"Remote Desktop Users users\" " + textBox_user_name.Text + " /add",                       
                        WindowStyle = ProcessWindowStyle.Hidden
                    };
                  
                    Process.Start(proc);
                }
                if (chbx_Event_reader_group.Checked) //Читатели журнала событий 
                {
                    string cmd = "cmd.exe";
                    var proc = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        WorkingDirectory = @"C:\Windows\System32",
                        FileName = @"C:\Windows\System32\cmd.exe",
                        Arguments = cmd + " /C net localgroup " + "\"" + "Читатели журнала событий" + "\"" + " " + textBox_user_name.Text + " /add & net localgroup \"Event Log Readers\" " + textBox_user_name.Text + " /add",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process.Start(proc);
                }
            }
            catch (Exception ex)
            {
                ToolTip tt = new ToolTip();
                tt.Active = true;
                tt.Show(ex.Message, textBox_user_name, 5000); //Всплывающее окошко с ошибкой при наличии такого пользователя в системе
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) //Iface operators создание группы при установке галочки на checkBox Iface operators
        {
            string cmd = "cmd.exe";
            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = cmd + "/C net localgroup iface_operators /add",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(proc);
        }

        private void button_user_delete_Click(object sender, EventArgs e) //Удалить пользователя Windows
        {
            string cmd = "cmd.exe";
            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = cmd + "/C net user " + textBox_user_name.Text + " /delete",
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(proc);
            textBox_user_name.Text = "";
            textBox_user_pass.Text = "";
        }


        #endregion



        #region Включение функций
        
        private void changes_backup_Click(object sender, EventArgs e) // Раздел включения функций
        {
            //CheckBoxes для настройки ОС
            #region
            if (monitor_optimize_off.Checked == true)
            {
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG - Change - monitor - timeout - ac 5");
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG - Change - monitor - timeout - dc 10");
            }

            if (hdd_optimize_off.Checked == true)
            {
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -disk-timeout-ac 10");
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -disk-timeout-dc 20");
            }

            if (hybernation_off.Checked == true)
            {
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -hibernate-timeout-ac 15");
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -hibernate-timeout-dc 60");
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K powercfg -hibernate on");
            }

            if (sleep_mode_off.Checked == true)
            {
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -standby-timeout-ac 15");
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K POWERCFG -Change -standby-timeout-dc 60");
            }

            if (firewall_off.Checked == true)
            {
                Process.Start(@"cmd.exe", "/K NetSh Advfirewall set allprofiles state on");
            }

            if (uac_off.Checked == true)
            {
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K reg add \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" /v EnableLUA /t REG_DWORD /d 1 /f");
            }

            if (rdp_on.Checked == true)
            {
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Terminal Server\" /v fDenyTSConnections /t REG_DWORD /d 1 /f");
            }

            if (nla_off.Checked == true)
            {
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Terminal Server\\WinStations\\RDP-Tcp\" /v UserAuthentication /t REG_DWORD /d 1 /f");
            }

            if (superFetch_off.Checked == true)
            {
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K sc config SysMain start=auto & sc start SysMain");
            }

            if (winsearch_off.Checked == true)
            {
                Process.Start(@"C:\\Windows\\system32\\cmd.exe", "/K sc config wsearch start=auto & sc start wsearch");
            }
            #endregion


            if (checkBox_win_folders_optimize.Checked == true)
            {
                DialogResult res = MessageBox.Show("Внимание! \n " +
                    "Выбран пункт \"Конфигурация служебных файлов в папке Windows\" если вы продолжите работы будут удалены следующие файлы: \n" +
                     "C:\\Windows\\dntmon.INI \n" +
                     "C:\\Windows\\s_setup.INI \n" +
                     "C:\\Windows\\tmsmon.INI \n", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    Directory.SetCurrentDirectory(@"C:\\Windows");
                    File.Delete("C:\\Windows\\dntmon.ini");
                    File.Delete("C:\\Windows\\s_setup.ini");
                    File.Delete("C:\\Windows\\tmsmon.ini");
                }
                if (res == DialogResult.Cancel)
                {
                }

            }
        }
        
        #endregion




        //Настройки ОИК
        #region Вкладка настроек ОИК

        #region Сервер ОИК

        //Ищем место установки сервера ОИК
        private void check_OIK_Server_Install_Path()
        {
            RegistryKey reg;
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (reg = hklm.OpenSubKey(@"SOFTWARE\Wow6432Node\InterfaceSSH"))
            {
                if (reg == null)
                { reg = hklm.OpenSubKey(@"SOFTWARE\InterfaceSSH\"); }

                if (reg != null)
                {
                    try
                    {
                        string OIK_Reg_ServerPath = reg.GetValue("ServerPath").ToString();
                        reg.Close();
                        OIK_install_path_str = OIK_Reg_ServerPath;
                        int result = OIK_Reg_ServerPath.IndexOf("Server");
                        if (result == -1) 
                        { 
                            result = 0;
                            OIK_install_path.Text = OIK_Reg_ServerPath;
                        }
                        else
                        {
                            int delete_position = OIK_Reg_ServerPath.Length - result;
                            OIK_install_path.Text = OIK_Reg_ServerPath.Remove(OIK_Reg_ServerPath.Length - delete_position);
                        }

                    }
                    catch(Exception ex)
                    { MessageBox.Show(ex.Message, " ", MessageBoxButtons.OK); };
                }
                else
                {
                    /*
                    if (Directory.Exists("C:\\Program Files (x86)\\InterfaceSSH\\Server"))
                    {
                        OIK_install_path.Text = "C:\\Program Files (x86)\\InterfaceSSH";
                        return;
                    }
                    if (Directory.Exists("C:\\Program Files\\InterfaceSSH\\Server"))
                    {
                        OIK_install_path.Text = "C:\\Program Files\\InterfaceSSH";
                        return;
                    }
                    if (Directory.Exists("D:\\NTDISP\\InterfaceSSH\\Server"))
                    {
                        OIK_install_path.Text = "D:\\NTDISP\\InterfaceSSH";
                        return;
                    }
                    if (Directory.Exists("D:\\InterfaceSSH\\Server"))
                    {
                        OIK_install_path.Text = "D:\\InterfaceSSH";
                        return;
                    }
                    if (Directory.Exists("D:\\OIK\\InterfaceSSH\\Server"))
                    {
                        OIK_install_path.Text = "D:\\OIK\\InterfaceSSH";
                        return;
                    }
                                        else
                    {
                        
                    }
                    */


                    OIK_install_path.Text = "Сервер не установлен.";
                }
            }
        }

        //Проверяем наличие папки C:\\Program Files(x86)\\InterfaceSSH\\Server изменении чек бокса "Заменить владельца папки InterfaseSSH"
        private void checkBox_change_owner_OIK_folder_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_change_owner_OIK_folder.Checked == true)
            {
                Browse_oik_install_folder.Enabled = true;
                checkBox_folder_OIK_rules.Enabled = true;
                OIK_install_path.ReadOnly = false;
                check_OIK_Server_Install_Path();
            }
            else
            {
                Browse_oik_install_folder.Enabled = false;
                checkBox_folder_OIK_rules.Checked = false;
                checkBox_folder_OIK_rules.Enabled = false;
                OIK_install_path.ReadOnly = true;
            }
        }

        // Настроки кнопки "Обзор" для выбора пути установки сервера ОИК
        private void Browse_oik_install_folder_Click_1(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                SelectedPath = OIK_install_path.Text
            };
            dialog.Description = "Укажите расположение сервера ОИК \\InterfaceSSH";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OIK_install_path_str = dialog.SelectedPath;
                if (File.Exists(OIK_install_path_str + @"\s_setup.exe"))
                {
                    if (OIK_install_path_str.IndexOf("Server") > 0)
                    {
                        int result = OIK_install_path_str.IndexOf("Server");
                        int delete_position = OIK_install_path_str.Length - result;
                        OIK_install_path.Text = OIK_install_path_str.Remove(OIK_install_path_str.Length - delete_position);
                    }
                    else { OIK_install_path.Text = OIK_install_path_str; }
                }
                else { MessageBox.Show("Укажите правильный путь до сервера ОИК", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        // Создаём конфигурационные файлы Настройки Серверов в C:\Windows\
        private void Win_Folders_optimize_Method()
        {
            if (checkBox_win_folders_optimize.Checked == true)
            {
                Directory.SetCurrentDirectory(@"C:\\Windows");

                File.Create("C:\\Windows\\dntmon.ini").Close();
                File.Create("C:\\Windows\\s_setup.ini").Close();
                File.Create("C:\\Windows\\tmsmon.ini").Close();
                File.Create("C:\\Windows\\s_trace.ini").Close();
                for (int i=0; i<8; i++)
                {
                    string cmd = null;
                    if (i == 0) { cmd = @" /K icacls C:\Windows\dntmon.ini /setowner " + set_owner_all_users + " /C "; }
                    if (i == 1) { cmd = @" /K icacls C:\Windows\dntmon.ini /grant " + set_owner_all_users + ":F "; }
                    if (i == 2) { cmd = @" /K icacls C:\Windows\s_setup.ini /setowner " + set_owner_all_users + " /C "; }
                    if (i == 3) { cmd = @" /K icacls C:\Windows\s_setup.ini /grant " + set_owner_all_users + ":F "; }
                    if (i == 4) { cmd = @" /K icacls C:\Windows\tmsmon.ini /setowner " + set_owner_all_users + " /C "; }
                    if (i == 5) { cmd = @" /K icacls C:\Windows\tmsmon.ini /grant " + set_owner_all_users + ":F "; }
                    if (i == 6) { cmd = @" /K icacls C:\Windows\s_trace.ini /setowner " + set_owner_all_users + " /C "; }
                    if (i == 7) { cmd = @" /K icacls C:\Windows\s_trace.ini /grant " + set_owner_all_users + ":F "; }
                    var cmd_start = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        WorkingDirectory = @"C:\Windows\System32",
                        FileName = @"C:\Windows\System32\cmd.exe",
                        Arguments = "cmd.exe "+ cmd,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };
                    Process.Start(cmd_start);
                }

                MessageBox.Show(
                     "Созданы следующие файлы: \n" +
                     "C:\\Windows\\dntmon.INI \n" +
                     "C:\\Windows\\s_setup.INI \n" +
                     "C:\\Windows\\tmsmon.INI \n" +
                     "C:\\Windows\\s_trace.INI \n");
            }
        }

        // Настройка владельца на папку с сервером ОИК
        public void Change_Owner_OIK_server_foled()
        {
            if (checkBox_change_owner_OIK_folder.Checked == true)
            {
                if (Directory.Exists(OIK_install_path_str) == true) // Проверяем наличие папки  
                {
                    check_oik_folder = true;
                    SetOwner(OIK_install_path.Text, set_owner_all_users);
                    MessageBox.Show("Владелец изменён на пользователя: Все", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    DialogResult errormsg = MessageBox.Show("В указанной папке отсутствует сервер ОИК укажите правильный путь!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FolderBrowserDialog dialog = new FolderBrowserDialog
                    {
                        SelectedPath = OIK_install_path.Text
                    };
                    dialog.Description = "Выбор места установки InterfaceSSH\\Server";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        OIK_install_path.Text = dialog.SelectedPath;
                        OIK_install_path_str = dialog.SelectedPath;
                        if (Directory.Exists(OIK_install_path_str)) //== true && File.Exists(OIK_install_path_str+@"\s_setup.exe"))
                        {
                            OIK_install_path_str = OIK_install_path.Text;
                            SetOwner(OIK_install_path.Text, set_owner_all_users);
                            MessageBox.Show("Владелец изменён на пользователя: Все", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            DialogResult error_path_msg = MessageBox.Show("Путь указан не верно!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            OIK_install_path.Text = "Сервер не установлен.";
                        }
                        OIK_install_path_str = null;
                    }
                }
            }
        }

        //Метод предоставления прав на директорию
        static public bool SetFullControl(string nameDir, string userName)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(nameDir);
                DirectorySecurity ds = dirInfo.GetAccessControl(AccessControlSections.Access);

                //Только для папок
                ds.AddAccessRule(new FileSystemAccessRule(userName,
                    FileSystemRights.FullControl,
                    InheritanceFlags.ContainerInherit,
                    PropagationFlags.InheritOnly,
                    AccessControlType.Allow));
                //Только для файлов
                ds.AddAccessRule(new FileSystemAccessRule(userName,
                    FileSystemRights.FullControl,
                    InheritanceFlags.ObjectInherit,
                    PropagationFlags.InheritOnly,
                    AccessControlType.Allow));
                dirInfo.SetAccessControl(ds);
                return true;
            }
            catch
            { return false; }
        }

        // Метод смены владельца папки с сервером ОИК
        public void SetOwner(string nameDir, string userName)
        {
            if (nameDir.Length-1 == nameDir.LastIndexOf(@"\")) //Проверка на наличие \ - лишний символ в пути папки
            {
                nameDir = nameDir.Remove(nameDir.Length - 1, 1); // Удаляем лишний символ \
            }

            string arg2 = "/k icacls " + "\"" + nameDir + "\"" + " /setowner " + userName + " /T /C";
            string arg3 = @"" + arg2;
            var cmd_start1 = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = arg3,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(cmd_start1);
        }

        // Меняем права на папку с сервером ОИК
        private void Folder_IK_Rusles_Change()
        {
            if (checkBox_folder_OIK_rules.Checked == true && File.Exists(OIK_install_path_str + @"\s_setup.exe"))
            {
                SetFullControl(OIK_install_path.Text, set_owner_all_users);
                MessageBox.Show("Полный доступ предоставлен пользователю: Все", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
        }

        //Кнопка Выполнить на вкладке ОИК
        private void btn_OIK_configTAB_Click(object sender, EventArgs e)
        {
            if(chbx_SystemFontsDefault.Checked || chbx_OIKFontsDefault.Checked || chbx_ModusFontsDefault.Checked)
            {
                SetDefaultFonts();
                WorkDone();
            }

            if (check_box_clear_clien_oik_settings.Checked)
            {
                Clean_OIK_Config_on_SID();
            }
            if(checkBox_OIK_styles_copy.Checked)
            {
                Copy_Styles_to_User();
            }
            if(checkBox_win_folders_optimize.Checked)
            {
                Win_Folders_optimize_Method();
            }
            if(checkBox_change_owner_OIK_folder.Checked)
            {
                Change_Owner_OIK_server_foled();
            }
            if(checkBox_folder_OIK_rules.Checked)
            {
                Folder_IK_Rusles_Change();
            }
        }
        #endregion Сервер ОИК


        #region Клиент ОИК и МОДУС
        //Передаём значение ячеек из dataGridView1 в selected_DTG_username и selected_DTG_userSID при клипе по строке
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            datadridView_Get_Cell_data();
            FontCheckBoxDropStatus();
        }

        private void datadridView_Get_Cell_data()
        {
            if (dataGridView1.SelectedRows[0].Cells[1].Value != null)
            {
                selected_DTG_username = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                selected_DTG_userSID = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                selected_DTG_user_local_path = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                if (checkBox_OIK_styles_copy.Checked)
                {
                    Mapped_Disk_Find();
                    MODUS_Check();
                }
            }
        }

        private void FontCheckBoxDropStatus()
        {
            check_box_clear_clien_oik_settings.ForeColor = Color.Black;
            chbx_SystemFontsDefault.ForeColor = Color.Black;
            chbx_OIKFontsDefault.ForeColor = Color.Black;
            chbx_ModusFontsDefault.ForeColor = Color.Black;
        }

        //Указываем путь для таблиц стилей ОИК
        private void button_path_modus_file_copy_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox_path_modus_file.Text) == true) // Проверяем наличие папки  
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog
                {
                    SelectedPath = textBox_path_modus_file.Text
                };
                dialog.Description = "Укажите расположение таблиц стилей ОИК";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_path_modus_file.Text = dialog.SelectedPath;
                }
            }
            else
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog
                {
                    SelectedPath = "C:\\"
                };
                dialog.Description = "Пусть не найден, расположение таблиц стилей ОИК";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_path_modus_file.Text = dialog.SelectedPath;
                }
            }
        }

        //Копируем таблицы стилей в папку пользователя
        private void Copy_Styles_to_User()
        {
            copy_path_to = textBox_path_modus_file_destination.Text;
            string[] file_list = null;
            string[] file_list_dest = null;

            try
            {
                file_list = Directory.GetFiles(textBox_path_modus_file.Text);
                file_list_dest = Directory.GetFileSystemEntries(copy_path_to);
                if (Directory.Exists(textBox_path_modus_file.Text) == true) // Проверяем наличие папки  
                {
                    //                    listBox1.Items.AddRange(file_list);
                    //Проверяем наличие в целевой папке аналогичных файлов, если есть выводим запрос на замену
                    int n = file_list.Length;
                    if (file_list_dest.Length != 0)
                    {

                        DialogResult dialogResult = MessageBox.Show("В папке уже существуют файлы, заменить?", "Совпадение файлов", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                string s = System.IO.Path.GetFileName(file_list.GetValue(i).ToString());
                                string copy_path = copy_path_to + "\\" + s;

                                try
                                {
                                    File.Copy(file_list.GetValue(i).ToString(), copy_path, true);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("" + ex.Message);
                                }
                            }

                            //Нумеруем строки в file_list, в начало строки вставляем i+1 для вывода в сообщении списка скопированных файлов
                            for (int i = 0; i < file_list.Length; i++)
                            {
                                file_list[i] = file_list[i].Insert(0, i + 1 + ") ");
                            }

                            string toDisplay = string.Join(Environment.NewLine, file_list);
                            MessageBox.Show("Файлы скопированные с заменой: \n" + toDisplay.Replace(textBox_path_modus_file.Text + "\\", ""), "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    //Если в папке нет совпадения файлов, копируем файлы по списку file_list
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            string s = System.IO.Path.GetFileName(file_list.GetValue(i).ToString());
                            string copy_path = copy_path_to + "\\" + s;

                            try
                            {
                                File.Copy(file_list.GetValue(i).ToString(), copy_path);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("" + ex.Message);
                            }
                        }
                        //Нумеруем строки в file_list, в начало строки вставляем i+1 для вывода в сообщении списка скопированных файлов
                        for (int y = 0; y < file_list.Length; y++)
                        {
                            file_list[y] = file_list[y].Insert(0, y + 1 + ") ");
                        }
                        string toDisplay = string.Join(Environment.NewLine, file_list);
                        MessageBox.Show("Файлы скопированы \n" + toDisplay.Replace(textBox_path_modus_file.Text + "\\", ""), "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //                MessageBox.Show("В папку пользователя перемещены следующие файлы: \n", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "\n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Заполняем datagrid при переходе во вкладку "Настройки клиента ОИК"
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                check_OIK_Server_Install_Path();
                if (tab_control == true)
                {
                    dataGridView1.Rows.Clear();
                }
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.DefaultCellStyle.BackColor = Color.White;
                dataGridView1.EnableHeadersVisualStyles = true;
                dataGridView1.Enabled = true;

                try
                {
                    int length_index = 0;
                    string username = null;
                    string username_tmp = null;
                    int username_index = 0;
                    string userSID = null;
                    string user_local_path = null;
                    string user_loaded = null;
                    int datagrid_idex = 1;

                    // Получаем путь к профилю LocalPath, SID и состояние уч.записи пользователя (загружена или нет). Из LocalPath перебором строки получаем имя пользователя
                    ManagementObjectSearcher searcher1 =
                        new ManagementObjectSearcher("root\\CIMV2",
                        "SELECT * FROM Win32_UserProfile");
                    foreach (ManagementObject queryObj1 in searcher1.Get())
                    {
                        char find_char = '\\';
                        user_local_path = queryObj1["LocalPath"].ToString();
                        length_index = user_local_path.LastIndexOf(find_char);
                        username_tmp = user_local_path.Substring(length_index + 1);
                        username_index = username_tmp.IndexOf(".");

                        if (username_index >= 0) { username = username_tmp.Remove(username_index); }
                        else { username = username_tmp; };

                        user_loaded = queryObj1["Loaded"].ToString().Replace("True", "Активна").Replace("False", "Выгружена");
                        userSID = queryObj1["SID"].ToString();
                        if (userSID.Length > 9)
                        {
                            dataGridView1.Rows.Add(datagrid_idex++, username, userSID, user_local_path, user_loaded); // Собранную информацию записываем по столбцам в datagridview1                        
                        }
                        else { }
                    }
                    //Нумеруем строки в столбце № dataGridView1
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        datagrid_idex = i;
                    }
                }
                catch (ManagementException ex)
                {
                    MessageBox.Show("Ошибка! Ответ WMI: " + ex.Message);
                }

                selected_DTG_username = dataGridView1.Rows[0].Cells[1].Value.ToString();
                selected_DTG_userSID = dataGridView1.Rows[0].Cells[2].Value.ToString();
                selected_DTG_user_local_path = dataGridView1.Rows[0].Cells[3].Value.ToString();
                selected_DTG_user_loaded = dataGridView1.Rows[0].Cells[4].Value.ToString();
                tab_control = true;
            }

            if (tabControl1.SelectedIndex == 2)
            {
                if(lv_adapters.Items.Count > 0)
                {

                }
                else
                {
                    network_adapters();
                    Task.Run(() => { get_routes(); });
                }
            }

        }

        //Удаляем запись в реестре по SID пользователя
        private void Clean_OIK_Config_on_SID()
        {
            if (check_box_clear_clien_oik_settings.Checked)
            {
                if (selected_DTG_user_loaded == "Выгружена")
                {
                    //Подключаем куст реестра для выбранного пользователя(для активного в системе пользователя куст не подключается, т.к. он уже подключен)
                    string cmd = "cmd.exe";
                    var proc_reg_load = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        WorkingDirectory = @"C:\Windows\System32",
                        FileName = @"C:\Windows\System32\cmd.exe",
                        Arguments = cmd + @" /K reg load HKU\" + selected_DTG_userSID + " " + selected_DTG_user_local_path + @"\ntuser.dat",
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process.Start(proc_reg_load);
                    Thread.Sleep(1500);
                }


                using (var HKEY_USERS = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                using (var reg_user_check = HKEY_USERS.OpenSubKey(selected_DTG_userSID))
                    if (reg_user_check != null)
                    {
                        using (var HKU = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                        using (var regcheck = HKU.OpenSubKey(selected_DTG_userSID + @"\SOFTWARE\InterfaceSSH\WinDisp", true))
                        using (var regdel = HKU.CreateSubKey(selected_DTG_userSID + @"\SOFTWARE\InterfaceSSH\"))
                        {
                            if (regcheck != null) //Если папка WinDisp существует, то удаляем её
                            {
                                regdel.DeleteSubKeyTree("WinDisp");
                                regdel.Close();
                                HKU.Close();
                                MessageBox.Show("Настройки клиента ОИК сброшены для пользователя: " + selected_DTG_username, "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else // Если папка WinDisp несуществует, выводим окно с сообщением)
                            {
                                MessageBox.Show("У пользователя " + selected_DTG_username + " нет настроек для клиента ОИК Диспетчер. \n" +
                                    "Запустите ОИК Диспетчер от имени: " + selected_DTG_username);
                            }
                        }
                    }

                if (selected_DTG_user_loaded == "Выгружена")
                {
                    //Выгружаем реестр после изменений
                    string cmd1 = "cmd.exe";
                    var proc_reg_unload = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        WorkingDirectory = @"C:\Windows\System32",
                        FileName = @"C:\Windows\System32\cmd.exe",
                        Arguments = cmd1 + @" /K reg unload HKU\" + selected_DTG_userSID,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };
                    Process.Start(proc_reg_unload);
                }
            }
        }

        //CheckBox копирование стилей ОИК
        private void checkBox_OIK_styles_copy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OIK_styles_copy.Checked)
            {
                button_path_modus_file_copy.Enabled = true;
                textBox_path_modus_file.Enabled = true;
                textBox_path_modus_file_destination.Enabled = true;
                cmb_mapping_disk.Enabled = true;
                button2.Enabled = true;

                Mapped_Disk_Find();
                MODUS_Check();
            }
            else
            {
                button_path_modus_file_copy.Enabled = false;
                textBox_path_modus_file.Enabled = false;
                textBox_path_modus_file_destination.Enabled = false;
                cmb_mapping_disk.Enabled = false;
                button2.Enabled = false;
                cmb_mapping_disk.Items.Clear();
            }
        }

        //Поиск примапленного диска
        private void Mapped_Disk_Find()
        {
            //Пролучаем значение providerName примапленного сетевого диска и задаём значение в строке адреса откуда копируются таблицы стилей в зависимости от результата
            string providerName = null;
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_MappedLogicalDisk");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    providerName = queryObj["ProviderName"].ToString();
                    cmb_mapping_disk.Items.Add(providerName);
                    cmb_mapping_disk.Text = cmb_mapping_disk.Items[0].ToString();
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Ищем примапленный диск и стили ОИК
            if (providerName != null)
            {
                textBox_path_modus_file.Text = cmb_mapping_disk.SelectedItem.ToString() + @"\IT\Install\TM\OIK\!Клиент ОИК\Таблицы стилей\Габдуллин";
                copy_path_to = cmb_mapping_disk.SelectedItem.ToString() + @"\IT\Install\TM\OIK\!Клиент ОИК\Таблицы стилей\Габдуллин";
            }
            else
            {
                cmb_mapping_disk.Enabled = false;
                textBox_path_modus_file.Text = @"\\10.62.8.4\dfs\IT\Install\TM\OIK\!Клиент ОИК\Таблицы стилей\Габдуллин";
            }
        }

        // Проверка наличия клиента MODUS
        private void MODUS_Check()
        {
            //Ищем клиент Modus
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var reg = hklm.OpenSubKey(@"SOFTWARE\Wow6432Node\Modus\5.20"))
                if (reg != null)
                {
                    if (Directory.Exists(selected_DTG_user_local_path + @"\AppData\Roaming\Modus 5.20"))
                    {
                        textBox_path_modus_file_destination.Text = selected_DTG_user_local_path + @"\AppData\Roaming\Modus 5.20";
                        reg.Close();
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("У пользователя " + selected_DTG_username +
                            " отсутствет папка Modus, создать папку?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            Directory.CreateDirectory(selected_DTG_user_local_path + @"\AppData\Roaming\Modus 5.20");
                            textBox_path_modus_file_destination.Text = selected_DTG_user_local_path + @"\AppData\Roaming\Modus 5.20";
                            MessageBox.Show("Для пользователя " + selected_DTG_username + " создана папка Modus", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            checkBox_OIK_styles_copy.Checked = false;
                            reg.Close();
                        }
                    }
                }
                else
                {
                    string find_WinDips_unistall = null;
                    using (var hklm1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var reg1 = hklm1.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{5C001F99-2289-491E-B4F2-707BFCADBC6B}_is1"))

                        if (reg1 != null)
                        {
                            // "Клиент 'ОИК Диспетчер'"
                            find_WinDips_unistall = reg1.GetValue("InstallLocation").ToString();
                            reg1.Close();
                        }

                    if (Directory.Exists(find_WinDips_unistall))
                    {
                        textBox_path_modus_file_destination.Text = find_WinDips_unistall;
                    }
                    else
                    {
                        textBox_path_modus_file_destination.Text = " Укажите путь до клиента ОИК или Modus";
                        MessageBox.Show("Не удалось найти клиент ОИК", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
        }

        //Выбирает куда копировать стили ОИК
        private void button2_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog { };
            folder.ShowDialog();
            if (folder.SelectedPath != "")
            {
                textBox_path_modus_file_destination.Text = folder.SelectedPath;
            }
            else
            {
                return;
            }
        }

        //Высплывающая подсказка при наведении на textBox_path_modus_file     
        private void textBox_path_modus_file_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(textBox_path_modus_file.Text, textBox_path_modus_file);
        }

        //Сборс системных шрифтов По Умолчанию
        private void SetDefaultFonts()
        {
            //Подключаем реестр если пользователь не вошёл в систему
            if (selected_DTG_user_loaded == "Выгружена")
            {
                //Подключаем куст реестра для выбранного пользователя(для активного в системе пользователя куст не подключается, т.к. он уже подключен)
                string cmd = "cmd.exe";
                var proc_reg_load = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd + @" /K reg load HKU\" + selected_DTG_userSID + " " + selected_DTG_user_local_path + @"\ntuser.dat",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc_reg_load);
                Thread.Sleep(2500);
            }

            
            //Сброс шрифтов ОС
            #region Сброс шрифтов ОС
            if (chbx_SystemFontsDefault.Checked)
            {
                using (var HKEY_USERS = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                using (var reg_user_check = HKEY_USERS.OpenSubKey(selected_DTG_userSID))
                    if (reg_user_check != null)
                    {
                        using (var HKU = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                        using (var regcheck = HKU.OpenSubKey(selected_DTG_userSID + @"\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Font Management", true))
                        {
                            //Проверяем наличие пути, если null создаём папку
                            if (regcheck == null)
                            {
                                using (var HKU1 = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                                using (var regcheck1 = HKU1.OpenSubKey(selected_DTG_userSID + @"\SOFTWARE\Microsoft\Windows NT\CurrentVersion\", true))
                                {
                                    regcheck1.CreateSubKey("Font Management");                                   
                                    regcheck1.Close();
                                }
                            }
                        }
                        //Создаём или задаём ключи реестра
                        using (var HKU2 = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                        using (var regcheck2 = HKU2.OpenSubKey(selected_DTG_userSID + @"\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Font Management", true))
                        {
                            regcheck2.SetValue("Auto Activation Mode", 1, RegistryValueKind.DWord);
                            regcheck2.SetValue("InstallAsLink", 0, RegistryValueKind.DWord);

                            string AutoActivationMode = regcheck2.OpenSubKey("").GetValue("Auto Activation Mode")?.ToString(); //regcheck2.GetValue("Auto Activation Mode").ToString();
                            string InstallAsLink = regcheck2.GetValue("InstallAsLink")?.ToString();
                            if(AutoActivationMode != "1" || InstallAsLink != "0")
                            {
                                MessageBox.Show("Не удалось сбросить настройки системных шрифтов", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                chbx_SystemFontsDefault.ForeColor = Color.Red;
                            }
                            chbx_SystemFontsDefault.ForeColor = Color.Green;
                        }
                        reg_user_check.Close();
                    }
            }
            #endregion Сброс шрифтов ОС

            //Сброс шрифтов ОИК
            #region Сброс шрифтов ОИК
            if (chbx_OIKFontsDefault.Checked)
            {
                bool CodeEdit = false;
                bool CodeEdit_Font = false;
                bool SchemView = false;
                bool NoOIKSetting = false;
                #region Раздел ОИКа CodeEdit
                try
                {
                    using (var HKEY_USERS = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                    using (var reg_user_check = HKEY_USERS.OpenSubKey(selected_DTG_userSID))
                        if (reg_user_check != null)
                        {
                            using (var HKU = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                            using (var regcheck = HKU.OpenSubKey(selected_DTG_userSID + @"\SOFTWARE\InterfaceSSH\WinDisp\CurrentVersion\CodeEdit", true))
                            {
                                //Проверяем наличие пути для папки реестра CodeEdit
                                if (regcheck != null)
                                {
                                    regcheck.SetValue("Color", 4278190085, RegistryValueKind.String);
                                    regcheck.SetValue("GutterWidth", 32, RegistryValueKind.DWord);
                                    regcheck.SetValue("KeyMapping", "Default", RegistryValueKind.String);
                                    regcheck.SetValue("MarginPos", 80, RegistryValueKind.DWord);
                                    regcheck.SetValue("Options", 23, RegistryValueKind.DWord);
                                    regcheck.SetValue("ReadOnlyColor", 4278190085, RegistryValueKind.DWord);
                                    //                                regcheck.SetValue("TextStyles", 4278190085, RegistryValueKind.MultiString);
                                    regcheck.SetValue("UseMonoFont", 1, RegistryValueKind.DWord);

                                    CodeEdit = true;

                                    HKU.Close();
                                    regcheck.Close();
                                    chbx_OIKFontsDefault.ForeColor = Color.Green;

                                }
                                else
                                {
                                    MessageBox.Show("Для данного пользователя настройки ОИК не обнаружены", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    NoOIKSetting = true;
                                    chbx_OIKFontsDefault.ForeColor = Color.Red;
                                }
                                HKEY_USERS.Close();
                                reg_user_check.Close();
                            }
                        }
                    }

                catch (Exception) 
                {
                    MessageBox.Show("Для данного пользователя настройки ОИК не обнаружены", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion Раздел ОИКа CodeEdit

                #region Раздел ОИКа CodeEdit_Font
                if (!NoOIKSetting)
                {
                    using (var HKEY_USERS = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                    using (var reg_user_check = HKEY_USERS.OpenSubKey(selected_DTG_userSID))
                        if (reg_user_check != null)
                        {
                            using (var HKU = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                            using (var regcheck = HKU.OpenSubKey(selected_DTG_userSID + @"\SOFTWARE\InterfaceSSH\WinDisp\CurrentVersion\CodeEdit\Font", true))
                            {
                                //Проверяем наличие пути для папки реестра CodeEdit
                                if (regcheck != null)
                                {
                                    regcheck.SetValue("Charset", 1, RegistryValueKind.DWord);
                                    regcheck.SetValue("Color", 0, RegistryValueKind.DWord);
                                    //                                  regcheck.SetValue("Height", 4294967283, RegistryValueKind.DWord);
                                    regcheck.SetValue("Name", "Courier New", RegistryValueKind.MultiString);
                                    regcheck.SetValue("Pitch", 0, RegistryValueKind.DWord);
                                    regcheck.SetValue("Style", 0, RegistryValueKind.DWord);

                                    CodeEdit_Font = true;
                                    string AutoActivationMode = regcheck.OpenSubKey("").GetValue("Name")?.ToString();

                                    chbx_OIKFontsDefault.ForeColor = Color.Green;
                                    if (AutoActivationMode != "Courier New")
                                    {
                                        MessageBox.Show("Не удалось сбросить настройки шрифтов ОИК", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        chbx_OIKFontsDefault.ForeColor = Color.Red;
                                    }
                                }
                                HKU.Close();
                                regcheck.Close();
                            }
                            HKEY_USERS.Close();
                            reg_user_check.Close();
                        }
                }
                #endregion Раздел ОИКа CodeEdit_Font

                #region Раздел ОИКа SchemView
                if (!NoOIKSetting)
                {
                    using (var HKEY_USERS = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                    using (var reg_user_check = HKEY_USERS.OpenSubKey(selected_DTG_userSID))
                        if (reg_user_check != null)
                        {
                            using (var HKU = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                            using (var regcheck = HKU.OpenSubKey(selected_DTG_userSID + @"\SOFTWARE\InterfaceSSH\WinDisp\CurrentVersion\SchemView", true))
                            {
                                //Проверяем наличие пути для папки реестра SchemView
                                if (regcheck != null)
                                {
                                    #region AccumGrid
                                    regcheck.SetValue("AccumGrid.ColWidths[1]", "240", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AccumGrid.ColWidths[2]", "75", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AccumGrid.ColWidths[3]", "35", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AccumGrid_DefaultRowHeight", "18", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AccumGrid_FontCharset", "204", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AccumGrid_FontColor", "-16777208", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AccumGrid_FontHeight", "-15", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AccumGrid_FontName", "MS Sans Serif", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AccumGrid_FontPitch", "fpDefault", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AccumGrid_FontSize", "11", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AccumGrid_FontStyle", "[]", RegistryValueKind.MultiString);
                                    #endregion AccumGrid

                                    #region AnalogGrid
                                    regcheck.SetValue("AnalogGrid.ColWidths[1]", "240", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AnalogGrid.ColWidths[2]", "75", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AnalogGrid.ColWidths[3]", "35", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AnalogGrid_DefaultRowHeight", "18", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AnalogGrid_FontCharset", "204", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AnalogGrid_FontColor", "-16777208", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AnalogGrid_FontHeight", "-15", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AnalogGrid_FontName", "MS Sans Serif", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AnalogGrid_FontPitch", "fpDefault", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AnalogGrid_FontSize", "11", RegistryValueKind.MultiString);
                                    regcheck.SetValue("AnalogGrid_FontStyle", "[]", RegistryValueKind.MultiString);
                                    #endregion AnalogGrid

                                    #region StatusGrid
                                    regcheck.SetValue("StatusGrid.ColWidths[1]", "240", RegistryValueKind.MultiString);
                                    regcheck.SetValue("StatusGrid.ColWidths[2]", "75", RegistryValueKind.MultiString);
                                    regcheck.SetValue("StatusGrid.ColWidths[3]", "35", RegistryValueKind.MultiString);
                                    regcheck.SetValue("StatusGrid_DefaultRowHeight", "18", RegistryValueKind.MultiString);
                                    regcheck.SetValue("StatusGrid_FontCharset", "204", RegistryValueKind.MultiString);
                                    regcheck.SetValue("StatusGrid_FontColor", " -16777208", RegistryValueKind.MultiString);
                                    regcheck.SetValue("StatusGrid_FontHeight", "-15", RegistryValueKind.MultiString);
                                    regcheck.SetValue("StatusGrid_FontName", "MS Sans Serif", RegistryValueKind.MultiString);
                                    regcheck.SetValue("StatusGrid_FontPitch", "fpDefault", RegistryValueKind.MultiString);
                                    regcheck.SetValue("StatusGrid_FontSize", "11", RegistryValueKind.MultiString);
                                    regcheck.SetValue("StatusGrid_FontStyle", "[]", RegistryValueKind.MultiString);
                                    #endregion StatusGrid

                                }
                                else
                                {
                                    SchemView = false;
                                }
                                HKU.Close();
                                regcheck.Close();
                            }
                            HKEY_USERS.Close();
                            reg_user_check.Close();
                        }

                }
                #endregion Раздел ОИКа SchemView

                if (!NoOIKSetting) //Если NoOIKSetting получит значение true значит настроек нет и сообщения о статусе выводить не нужно, по умолчанию false.
                {
                    if (!CodeEdit && !CodeEdit_Font && !SchemView)
                    {
                        MessageBox.Show("Не удалось сбросить настройки шрифтов ОИК", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chbx_OIKFontsDefault.ForeColor = Color.Red;
                    }

                    if (!CodeEdit || !CodeEdit_Font || !SchemView)
                    {
                        MessageBox.Show("Некоторые настройки шрифтов ОИК не удалось восстановить", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        chbx_OIKFontsDefault.ForeColor = Color.Yellow;
                    }

                    if (CodeEdit && CodeEdit_Font && SchemView)
                    {
                        MessageBox.Show("Настройки шрифтов ОИК успешно восстановлены", "Oк", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        chbx_OIKFontsDefault.ForeColor = Color.Green;
                    }
                }
            }
            #endregion Сброс шрифтов ОИК

            //Сброс настроек MODUS
            #region Сброс настроек MODUS
            if (chbx_ModusFontsDefault.Checked)
            {
                #region Раздел MODUS Common
                using (var HKEY_USERS = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                using (var reg_user_check = HKEY_USERS.OpenSubKey(selected_DTG_userSID))
                    if (reg_user_check != null)
                    {
                        using (var HKU = RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Default))
                        using (var regcheck = HKU.OpenSubKey(selected_DTG_userSID + @"\SOFTWARE\Modus\5.20\Common", true))
                        {
                            //Проверяем наличие пути для папки реестра Common
                            if (regcheck != null)
                            {
                                regcheck.SetValue("FontBold", 0, RegistryValueKind.DWord);
                                regcheck.SetValue("FontItalic", 0, RegistryValueKind.DWord);
                                regcheck.SetValue("FontName", "Lucida Sans Unicode", RegistryValueKind.String);
                                regcheck.SetValue("FontSize", 8, RegistryValueKind.DWord);
                                regcheck.SetValue("GridbgColor", 16777215, RegistryValueKind.DWord);
                                regcheck.SetValue("GridFontAlignHor", "ALTLEFT", RegistryValueKind.String);
                                regcheck.SetValue("GridFontAlignVert", "TOP", RegistryValueKind.String);
                                regcheck.SetValue("GridFontCharSet", 204, RegistryValueKind.DWord);
                                regcheck.SetValue("GridFontColor", 0, RegistryValueKind.DWord);
                                regcheck.SetValue("GridFontName", "Lucida Sans Unicode", RegistryValueKind.String);
                                regcheck.SetValue("GridFontScale", 0, RegistryValueKind.DWord);
                                regcheck.SetValue("GridFontSize", 8, RegistryValueKind.DWord);
                                regcheck.SetValue("GridFontStyle", "", RegistryValueKind.String);
                                regcheck.SetValue("GridFontProfile", "", RegistryValueKind.String);
                                regcheck.Close();
                                HKU.Close();
                                chbx_ModusFontsDefault.ForeColor = Color.Green;
                            }

                            else
                            {
                                MessageBox.Show("Для данного пользователя настройки MODUS не обнаружены", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                chbx_ModusFontsDefault.ForeColor = Color.Red;
                            }
                            
                        }
                        HKEY_USERS.Close();
                        reg_user_check.Close();
                    }
                #endregion Раздел ОИКа CodeEdit
            }
            #endregion Сброс настроек MODUS

            using (var HKEY_USERS = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default))
            { HKEY_USERS.Close(); }

                //Выгружаем ветку реестра
            if (selected_DTG_user_loaded == "Выгружена")
            {
                //Выгружаем реестр после изменений
                string cmd1 = "cmd.exe";
                var proc_reg_unload = new ProcessStartInfo()
                    {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = cmd1 + @" /K reg unload HKU\" + selected_DTG_userSID,
                    WindowStyle = ProcessWindowStyle.Hidden
                    };
                Process.Start(proc_reg_unload);
            }
            chbx_SystemFontsDefault.Checked = false;
            chbx_OIKFontsDefault.Checked = false;
            chbx_ModusFontsDefault.Checked = false;
//            
        }



        #endregion Клиент ОИК и МОДУС

        #endregion Вкладка настроек ОИК

        void WorkDone()
        {
            if (chbx_SystemFontsDefault.ForeColor == Color.Green || chbx_OIKFontsDefault.ForeColor == Color.Green || chbx_ModusFontsDefault.ForeColor == Color.Green)
            {
                MessageBox.Show("Готово", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        //Считываем конфигурацию ПК
        #region Считываем конфигурацию ПК
        private void btn_PC_conf_update_Click(object sender, EventArgs e)
        {
                get_PC_Conf();            
        }

        async private void get_PC_Conf()
    {
        await Task.Run(() =>
        {
            //PC Name
            string ProductName = null;
            string DisplayVersion = null;
            string CurrentBuild = null;
            string ReleaseId = null;
            string CSDVersion = null;
            using (var HKLM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var reg_Get_Value = HKLM.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"))
            {
                if (reg_Get_Value.GetValue("ProductName")?.ToString() != null)
                {
                    ProductName = " " + reg_Get_Value.GetValue("ProductName").ToString();
                }
                else
                {
                    ProductName = "";
                }

                if (reg_Get_Value.GetValue("DisplayVersion")?.ToString() != null)
                {
                    DisplayVersion = " " + reg_Get_Value.GetValue("DisplayVersion").ToString();
                }
                else
                {
                    DisplayVersion = "";
                }

                if (reg_Get_Value.GetValue("CurrentBuild")?.ToString() != null)
                {
                    CurrentBuild = "" + reg_Get_Value.GetValue("CurrentBuild").ToString();
                }
                else
                {
                    CurrentBuild = "";
                }

                if (reg_Get_Value.GetValue("ReleaseId")?.ToString() != null)
                {
                    ReleaseId = " " + reg_Get_Value.GetValue("ReleaseId").ToString();
                }
                else
                {
                    ReleaseId = "";
                }

                if (reg_Get_Value.GetValue("CSDVersion")?.ToString() != null)
                {
                    CSDVersion = " " + reg_Get_Value.GetValue("CSDVersion").ToString();
                }
                else
                {
                    CSDVersion = "";
                }
                reg_Get_Value.Close();
                HKLM.Close();
                lbl_OS_version.Invoke(new Action(() => lbl_OS_version.Text = "Версия: " + ReleaseId + CSDVersion + "      Сборка: " + CurrentBuild));
            }
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    lbl_PC_export_name = queryObj["CSName"].ToString();
                    lbl_PC_name.Invoke(new Action(() => lbl_PC_name.Text = "Имя компьютера: " + lbl_PC_export_name));
                    lbl_OS_info.Invoke(new Action(() => lbl_OS_info.Text = "ОС: " + ProductName + DisplayVersion + " " + queryObj["OSArchitecture"].ToString()));
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Vendor и MB
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_BaseBoard");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    lbl_VendorName.Invoke(new Action(() => lbl_VendorName.Text = "Производитель: " + queryObj["Manufacturer"]?.ToString()));
                    lbl_MB.Invoke(new Action(() => lbl_MB.Text = "Мат.плата: " + queryObj["Product"]?.ToString()));
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message);
            }

            //CPU
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string core = queryObj["NumberOfCores"]?.ToString();
                    string threads = queryObj["NumberOfLogicalProcessors"]?.ToString();
                    lbl_CPU.Invoke(new Action(() => lbl_CPU.Text = "CPU: " + queryObj["Name"]?.ToString().Replace("CPU", "") + " Cores:" + core + "/" + threads));
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message);
            }

            //GPU
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_VideoController");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    lbl_GPU.Invoke(new Action(() => lbl_GPU.Text = "GPU: " + queryObj["Caption"]?.ToString()));
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message);
            }

            //DDR RAM
            try
            {
                cmbox_memory.Invoke(new Action(() => cmbox_memory.Items.Clear()));
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_PhysicalMemory");
                int i = 0;
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    double memory_size = 0;
                    i++;
                    string Manufacturer = queryObj["Manufacturer"]?.ToString();
                    string PartNumber = queryObj["PartNumber"]?.ToString().Replace(" ", "");
                    string memory_size_tmp = (queryObj["Capacity"]?.ToString());
                    if (memory_size_tmp != null) { memory_size = Convert.ToDouble(queryObj["Capacity"]?.ToString()); } else { memory_size = 0; };
                    string Speed = queryObj["Speed"]?.ToString();
                    if (Manufacturer == null) { Manufacturer = "Производитель: N/A"; } else if (Manufacturer == "Manufacturer00") { Manufacturer.Replace("Manufacturer00", "Производитель: N\\A"); };
                    if (PartNumber == null) { PartNumber = "Модель: N/A"; } else if (PartNumber == "ModulePartNumber00") { PartNumber.Replace("ModulePartNumber00", "Модель: N\\A"); };
                    if (Speed == null) { Speed = "Частота: N/A"; };
                    if (memory_size != 0) { memory_size = +memory_size / 1048576; };
                    cmbox_memory.Invoke(new Action(() => cmbox_memory.Items.Add(i + ". " + Manufacturer + " " + PartNumber + " " + memory_size.ToString() + "Мб " + Speed + "MHz")));
                }

                if (cmbox_memory.Items.Count != 0)
                {
                    cmbox_memory.Invoke(new Action(() => cmbox_memory.Text = cmbox_memory.Items[0].ToString()));
                }
                else
                {
                    cmbox_memory.Invoke(new Action(() => cmbox_memory.Items.Add("N/A")));
                    cmbox_memory.Invoke(new Action(() => cmbox_memory.Text = "N/A"));
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message);
            }

            //HDD 
            try
            {
                cmbox_hdd.Invoke(new Action(() => cmbox_hdd.Items.Clear()));
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_DiskDrive");
                int i = 0;
                foreach (ManagementObject queryObj in searcher.Get())
                {

                    string chek_param_1 = queryObj["TotalHeads"]?.ToString();
                    if (chek_param_1 != null)
                    {
                        i++;
                        double memory_size = Convert.ToDouble(queryObj["Size"].ToString());
                        memory_size = +memory_size / 1073741824;
                        int memory_size_Gb = Convert.ToInt16(memory_size);
                        cmbox_hdd.Invoke(new Action(() => cmbox_hdd.Items.Add(i + ". " + queryObj["Model"]?.ToString())));
                        cmbox_hdd.Invoke(new Action(() => cmbox_hdd.Items.Add("    " + "Объём: " + memory_size_Gb.ToString() + " Гб ")));
                        cmbox_hdd.Invoke(new Action(() => cmbox_hdd.Items.Add("    " + "S\\N: " + queryObj["SerialNumber"]?.ToString().Replace(" ", ""))));
                        cmbox_hdd.Invoke(new Action(() => cmbox_hdd.Items.Add("----------------------------------------------------------------------------------")));
                    }
                    else { }
                }
                if (cmbox_hdd.Items.Count != 0)
                {
                    cmbox_hdd.Invoke(new Action(() => cmbox_hdd.Text = cmbox_hdd.Items[0].ToString()));
                }
                else
                {
                    cmbox_hdd.Invoke(new Action(() => cmbox_hdd.Items.Add("N/A")));
                    cmbox_hdd.Invoke(new Action(() => cmbox_hdd.Text = "N/A"));
                }

            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message);
            }

            // BIOS
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_BIOS");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    lbl_SerialNumber.Invoke(new Action(() => lbl_SerialNumber.Text = "S\\N: " + queryObj["SerialNumber"]?.ToString().Replace("null", "N/A")));
                    lbl_BIOS_Vendor.Invoke(new Action(() => lbl_BIOS_Vendor.Text = "Производитель BIOS: " + queryObj["Manufacturer"]?.ToString().Replace("null", "N/A")));
                    lbl_BIOS_ver.Invoke(new Action(() => lbl_BIOS_ver.Text = "Версия BIOS: " + queryObj["Caption"]?.ToString().Replace("null", "N/A")));
                    lbl_BIOS_relese_date.Invoke(new Action(() => lbl_BIOS_relese_date.Text = "Дата компоновки: " + queryObj["ReleaseDate"]?.ToString().Substring(0, 8).Replace("null", "N/A")));
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message);
            }
            btn_PC_conf_export.Invoke(new Action(() => btn_PC_conf_export.Enabled = true));
        });
        }


        //Сохраняем конфигурацию в .txt
        private void btn_PC_conf_export_Click(object sender, EventArgs e)

        {
            bool create_file = true;
            string file_save_path = "C:\\";
            FolderBrowserDialog dialog = new FolderBrowserDialog { };

            if (dialog.ShowDialog() == DialogResult.OK)

            {
                file_save_path = dialog.SelectedPath;
                if (file_save_path.EndsWith("\\")) { }
                else { file_save_path = file_save_path + "\\"; }

                if (File.Exists(file_save_path + "Export_" + lbl_PC_export_name + ".txt"))

                {
                    DialogResult msg = MessageBox.Show("Файл " + "Export_" + lbl_PC_export_name + ".txt" + " уже существует, заменить?",
                    "Сохранение конфигурации", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (msg == DialogResult.OK) { create_file = true; }
                    else { create_file = false; }
                }
                if (create_file)
                {
                    StreamWriter export = new StreamWriter(file_save_path + "Export_" + lbl_PC_export_name + ".txt");

                    export.WriteLine("Конфигурация ПК: \n");
                    export.WriteLine(lbl_OS_info.Text);
                    export.WriteLine(lbl_OS_version.Text);
                    export.WriteLine(lbl_PC_name.Text);
                    export.WriteLine(lbl_VendorName.Text);
                    export.WriteLine(lbl_SerialNumber.Text);
                    export.WriteLine(lbl_GPU.Text);
                    export.WriteLine(lbl_MB.Text);
                    export.WriteLine(lbl_CPU.Text);
                    export.WriteLine("Оперативная память:" + "\n" + "----------------------------------------------------------------------------------");
                    for (int i = 0; i < cmbox_memory.Items.Count; i++)
                    {
                        export.WriteLine(cmbox_memory.Items[i].ToString());
                    }
                    export.WriteLine("\n" + "Жёсткие диски:" + "\n" + "----------------------------------------------------------------------------------");
                    for (int i = 0; i < cmbox_hdd.Items.Count; i++)
                    {
                        export.WriteLine(cmbox_hdd.Items[i].ToString());
                    }
                    export.WriteLine(lbl_BIOS_Vendor.Text);
                    export.WriteLine(lbl_BIOS_ver.Text);
                    export.WriteLine(lbl_BIOS_relese_date.Text);
                    export.Close();
                }
            }
        }
        #endregion




        //Cетевые настройки
        #region Вкладка сетевых настроек

        //Считваем Раздел Net и заполняем параметры ListView
        private void btn_get_network_routes_Click(object sender, EventArgs e)
        {
            network_adapters();
        }

        private void network_adapters()
        {
            
            lv_adapters.Items.Clear();
            int i = 0;
            try
            {
                ManagementObjectSearcher searcher_adapter =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_NetworkAdapter Where PhysicalAdapter=True");

                foreach (ManagementObject queryObj in searcher_adapter.Get())
                {
                    i++;
                    ListViewItem item = new ListViewItem(i.ToString());
                    item.SubItems.Add(queryObj["DeviceID"].ToString());
                    item.SubItems.Add(queryObj["InterfaceIndex"].ToString());
                    item.SubItems.Add(queryObj["NetConnectionID"]?.ToString());
                    item.SubItems.Add(queryObj["Description"].ToString());
                    string DID = queryObj["DeviceID"]?.ToString();
                    if (DID == null)
                    {
                        return;
                    }
                    else
                    {
                        ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher("root\\CIMV2",
                        "SELECT * FROM Win32_NetworkAdapterConfiguration Where Index=" + DID);
                        foreach (ManagementObject queryObj1 in searcher.Get())
                        {
                            String[] arrIPAddress = (String[])(queryObj1["IPAddress"]);
                            if (arrIPAddress == null)
                            {
                                item.SubItems.Add(" ");
                            }
                            else { item.SubItems.Add(arrIPAddress.FirstOrDefault().Replace(" ", "")); }

                        }
                    }
                    item.SubItems.Add(queryObj["MACAddress"]?.ToString());
                    item.SubItems.Add(queryObj["NetEnabled"]?.ToString().Replace("False", "Down").Replace("True", "Up"));

                    lv_adapters.Items.Add(item);

                    lv_adapters.Items[i-1].UseItemStyleForSubItems = false;

                    if (item.SubItems[7].Text == "Up")
                    {
                        lv_adapters.Items[i-1].SubItems[7].BackColor = Color.LightGreen;
                    }
                    else if (item.SubItems[7].Text == "Down")
                    {
                        {
                            lv_adapters.Items[i - 1].SubItems[7].BackColor = Color.FromArgb(0xf8, 0x8d, 0x85); //LightRed Color
                        } 
                    }                  
                }

            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Refresh_Click(object sender, EventArgs e)
        {
            network_adapters();
        }

        public async void get_routes()
        {
            this.Invoke(new Action(() =>
            {
                lv_dynamic_route.Items.Clear();
            }));
            
            int i = 0;
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_IP4RouteTable");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    i++;
                    ListViewItem item = new ListViewItem(i.ToString());
                    item.SubItems.Add(queryObj["Destination"]?.ToString());
                    item.SubItems.Add(queryObj["Mask"]?.ToString());
                    string iface_index = queryObj["InterfaceIndex"]?.ToString();
                    item.SubItems.Add(queryObj["NextHop"]?.ToString().Replace("0.0.0.0", "On-Line")); //Gateway

                    int check_ip = 0;
                    ManagementObjectSearcher searcher_ip =
                        new ManagementObjectSearcher("root\\CIMV2",
                            "SELECT * FROM Win32_NetworkAdapterConfiguration Where InterfaceIndex=" + iface_index);
                    foreach (ManagementObject queryObj1 in searcher_ip.Get())
                    {
                        String[] arrIPAddress = (String[])(queryObj1["IPAddress"]);
                        if (arrIPAddress != null)
                        {
                            item.SubItems.Add(arrIPAddress.FirstOrDefault().Replace(" ", ""));
                            check_ip = 1;
                        }
                        else { item.SubItems.Add(" "); }
                    }
                    if (check_ip == 0) { item.SubItems.Add("127.0.0.1"); } //Проверка на случай, если по InterfaceIndex вернулся пустой arrIPAddress
                    item.SubItems.Add(queryObj["Metric1"].ToString());
                    if(Convert.ToInt32(queryObj["InterfaceIndex"].ToString()) == 1)
                    {
                        item.SubItems.Add("localhost");
                    }
                    else { item.SubItems.Add(queryObj["InterfaceIndex"].ToString()); }
                    this.Invoke(new Action(() =>
                    {
                        item.SubItems.Add(Get_AdapterNameOnIndex(queryObj["InterfaceIndex"].ToString()));
                    }));



                    this.Invoke(new Action(() =>
                    {
                        lv_dynamic_route.Items.Add(item);
                    }
                    ));
                    
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Invoke(new Action(() =>
            {
                lv_static_route.Items.Clear();
            }));
            
            int it = 1;
            ListViewItem item1 = new ListViewItem(it.ToString());
            try
            {
                ManagementObjectSearcher searcher_2 =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_IP4PersistedRouteTable");

                foreach (ManagementObject queryObj2 in searcher_2.Get())
                {
                    this.Invoke(new Action(() => { Adress_colum_static.Width = 100; }));                    
                    it++;
                    item1.SubItems.Add(queryObj2["Destination"]?.ToString());
                    item1.SubItems.Add(queryObj2["Mask"]?.ToString());
                    item1.SubItems.Add(queryObj2["NextHop"]?.ToString());//Gateway
                    item1.SubItems.Add(queryObj2["Metric1"]?.ToString());
                }
                if (lv_static_route.Items.Count < 1)
                {
                    item1.SubItems.Add("Нет статических маршрутов".ToString());
                    this.Invoke(new Action(() => { Adress_colum_static.Width = 160; }));                   
                    it = 0;
                }
                this.Invoke(new Action(() => { lv_static_route.Items.Add(item1); }));              
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private string Get_AdapterNameOnIndex(string index)
        {
            string item = "";
            for (int i = 0; i < lv_adapters.Items.Count; i++)
            {
                if (index == lv_adapters.Items[i].SubItems[2].Text)
                {
                    item = lv_adapters.Items[i].SubItems[3].Text;
                    break;       
                }
            }
            return item;
        }

        #endregion Вкладка сетевых настроек







        #region Выпадающие списки
        //Выпадающий список на адаптерах, копируем IP
        private void cMS_Adatres_Copy_Cell_Click(object sender, EventArgs e)
        {
            string Collumn_IP = lv_adapters.FocusedItem.SubItems[4].Text;
            Clipboard.Clear();
            Clipboard.SetText(Collumn_IP);
        }

        //Выпадающий список на адаптерах, копируем MAC
        private void cMS_Adatres_Copy_MAC_Click(object sender, EventArgs e)
        {
            string Collumn_MAC = lv_adapters.FocusedItem.SubItems[5].Text;
            Clipboard.Clear();
            Clipboard.SetText(Collumn_MAC);
        }

        //Выпадающий список на адаптерах, копируем всю строку
        private void cMS_Adatres_Copy_String_Click(object sender, EventArgs e)
        {
            string Collum_1, Collum_2, Collum_3, Collum_4, Collum_5, Collum_6, Collum_7, Collum_8, result = null;
            int i = lv_adapters.FocusedItem.Index;
            Collum_1 = lv_adapters.FocusedItem.SubItems[0].Text;
            Collum_2 = lv_adapters.FocusedItem.SubItems[1].Text;
            Collum_3 = lv_adapters.FocusedItem.SubItems[2].Text;
            Collum_4 = lv_adapters.FocusedItem.SubItems[3].Text;
            Collum_5 = lv_adapters.FocusedItem.SubItems[4].Text;
            Collum_6 = lv_adapters.FocusedItem.SubItems[5].Text;
            Collum_7 = lv_adapters.FocusedItem.SubItems[6].Text;
            Collum_8 = lv_adapters.FocusedItem.SubItems[7].Text;
            result = "№: "+Collum_1+ "\nID: " + Collum_2+ "\nInterface Index: " + Collum_3 + "\nName: " + Collum_4 + "\nDescription: " + Collum_5 + "\nIP: " + Collum_6+ "\nMAC: " + Collum_7+ "\nState: " + Collum_8;
            Clipboard.Clear();
            Clipboard.SetText(result);
        }

        //Обработчик для вызова выпадающиего списка(cMS_Adapters) при нажатии ПКМ на listview(lv_adapters)
        private void lv_adapters_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cMS_adapters.Show(Cursor.Position);
            }
        }


        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right & dataGridView1.SelectedRows[0].Cells[2].Value != null)
            {
                // Получаем координаты ячеем на которые было нажатие ПКМ и выделяем строку
                DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    dataGridView1.CurrentCell = dataGridView1[hit.ColumnIndex, hit.RowIndex ];
                    dataGridView1.CurrentRow.Selected = true;
                    datadridView_Get_Cell_data();
                }
                // Отображаем Контекстное меню и выключаем пункт открытия реестра если уч.запись пользователя выгружена из системы
                cMS_OIK_User.Show(Cursor.Position);
                if (dataGridView1.SelectedRows[0].Cells[4].Value.ToString() == "Выгружена")
                {
                    cMS_OIK_Reg_path_open.Enabled = false;
                }
                else { cMS_OIK_Reg_path_open.Enabled = true; }
            }
        }

        private void cMS_OIK_User_Open_Profile_Folder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", selected_DTG_user_local_path);
        }

        private void cMS_OIK_Copy_UserName_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(selected_DTG_username);
        }

        private void cMS_OIK_CopySID_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(selected_DTG_userSID);
        }

        private void cMS_OIK_Copy_User_Path_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(selected_DTG_user_local_path);
        }

        private void cMS_OIK_Reg_path_open_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.Users.OpenSubKey(selected_DTG_userSID);
            RegistryKey RegeditLastKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Applets\Regedit");
            if (reg != null)
            {
                if (RegeditLastKey != null)
                {
                    RegeditLastKey.SetValue("LastKey", reg);
                    reg.Close();
                    RegeditLastKey.Close();
                }
            }
            else
            {
                RegeditLastKey.SetValue("LastKey", "");
                RegeditLastKey.Close();
            }

            Process.Start("regedit.exe");
        }
        #endregion  Выпадающие списки

        //Переход на форму 2 Бэкап ОИК
        public void btn_TMS_Backup_Click(object sender, EventArgs e)
        {

            Form Form2 = new Form2_TMS_RBS_Backup();
            {

            }
            Form2.ShowDialog();
        }

        //Переход на форму 3 настройка сетевых адаптеров
        private void cMS_Adatres_Config_Adapter_Click(object sender, EventArgs e)
        {
            class_NetworkAdapter_Settings.ConnectionName = lv_adapters.FocusedItem.SubItems[3].Text;
            class_NetworkAdapter_Settings.Description = lv_adapters.FocusedItem.SubItems[4].Text;
            class_NetworkAdapter_Settings.IP_adress = lv_adapters.FocusedItem.SubItems[5].Text;
            class_NetworkAdapter_Settings.MAC_Adress = lv_adapters.FocusedItem.SubItems[6].Text;
            
            Form Form3 = new Form3();
            Form3.ShowDialog();
        }

        private void Prog_Version_Click(object sender, EventArgs e)
        {
            Form about = new AboutForm();
            about.ShowDialog();
        }








        private void lv_dynamic_route_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lv_dynamic_route.Items.Count > 0)
                {
                    cMS_Route_edit_menu(2);
                    class_Route_parameters.adress = lv_dynamic_route.SelectedItems[0].SubItems[1].Text.ToString();
                    class_Route_parameters.mask = lv_dynamic_route.SelectedItems[0].SubItems[2].Text.ToString();
                    class_Route_parameters.gateway = lv_dynamic_route.SelectedItems[0].SubItems[3].Text.Replace("On-Line", "127.0.0.1").ToString();
                    class_Route_parameters.outinterface = lv_dynamic_route.SelectedItems[0].SubItems[4].Text.ToString();
                    class_Route_parameters.metric = lv_dynamic_route.SelectedItems[0].SubItems[5].Text.ToString();
                    class_Route_parameters.IntefaceIndex = lv_dynamic_route.SelectedItems[0].SubItems[6].Text.ToString(); 
                }
                else
                {
                    cMS_Route_edit_menu(1);
                }
            }
        }

        private void lv_static_route_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { 
                if (lv_static_route.Items.Count > 0 && lv_static_route.SelectedItems[0].SubItems[1]?.Text.ToString() != "Нет статических маршрутов")                 
                {
                    cMS_Route_edit_menu(2);
                    class_Route_parameters.adress = lv_static_route.SelectedItems[0].SubItems[1].Text.ToString();
                    class_Route_parameters.mask = lv_static_route.SelectedItems[0].SubItems[2]?.Text.ToString();
                    class_Route_parameters.gateway = lv_static_route.SelectedItems[0].SubItems[3]?.Text.Replace("On-Line", "127.0.0.1").ToString();
                    class_Route_parameters.metric = lv_static_route.SelectedItems[0].SubItems[4]?.Text.ToString();
                }
                else
                {
                    cMS_Route_edit_menu(1);
                }
            }
        }

        private void cMS_Route_edit_menu(int ActiveMenu)
        {
            if (ActiveMenu == 1)
            {
                cMS_route_edit.Items[1].Enabled = false;
                cMS_route_edit.Items[2].Enabled = false;
                cMS_route_edit.Items[3].Enabled = false;
            }
            if (ActiveMenu == 2)
            {
                cMS_route_edit.Items[1].Enabled = true;
                cMS_route_edit.Items[2].Enabled = true;
                cMS_route_edit.Items[3].Enabled = true;
            }
            cMS_route_edit.Show(Cursor.Position);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            class_Route_parameters.cMS_string_select = "Add";
            class_Route_parameters.adress = null;
            class_Route_parameters.mask = null;
            class_Route_parameters.gateway = null;
            class_Route_parameters.metric = null;
            if (ActiveControl.Name == "lv_dynamic_route")
            {
                IPForm_Show();
            }

            if (ActiveControl.Name == "lv_static_route")
            {
                IPForm_Show();
            }

        }

        private void Change_Click(object sender, EventArgs e)
        {
            class_Route_parameters.cMS_string_select = "Change";
            IPForm_Show();
        }
        void IPForm_Show()
        {
            Form form4 = new IPForm(this);
//            form4.FormClosed += new FormClosedEventHandler(IPForm_Closed);
            form4.ShowDialog();
        }
        void IPForm_Closed(object sender, FormClosedEventArgs e)
        {
            Task.Run(() => { get_routes(); });
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            class_Route_parameters.cMS_string_select = "Add";
            string result = null;
            if (ActiveControl.Name == "lv_dynamic_route")
            {
                string adress = lv_dynamic_route.SelectedItems[0].SubItems[1].Text.ToString();
                string mask = "mask " + lv_dynamic_route.SelectedItems[0].SubItems[2].Text.ToString();
                string gateway = lv_dynamic_route.SelectedItems[0].SubItems[3].Text.Replace("On-Line", "127.0.0.1").ToString();
                string metric = "metric " + lv_dynamic_route.SelectedItems[0].SubItems[5].Text.ToString();
                result = adress + " " + mask + " " + gateway + " " + metric;
            }

            if (ActiveControl.Name == "lv_static_route")
            {
                string adress = lv_static_route.SelectedItems[0].SubItems[1].Text.ToString();
                string mask = "mask " + lv_static_route.SelectedItems[0].SubItems[2].Text.ToString();
                string gateway = lv_static_route.SelectedItems[0].SubItems[3].Text.Replace("On-Line", "127.0.0.1").ToString();
                string metric = "metric " + lv_static_route.SelectedItems[0].SubItems[4].Text.ToString();
                result = adress + " " + mask + " " + gateway + " " + metric;
            }
            Clipboard.Clear();
            Clipboard.SetText(result);

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить маршрут?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.Yes)
            {

                string ip = null;
                string mask = null;
                string gateway = null;

                if (ActiveControl.Name == "lv_dynamic_route")
                {
                    ip = lv_dynamic_route.SelectedItems[0].SubItems[1].Text.ToString();
                    mask = lv_dynamic_route.SelectedItems[0].SubItems[2].Text.ToString();
                    gateway = lv_dynamic_route.SelectedItems[0].SubItems[3].Text.Replace("On-Line", "127.0.0.1").ToString();
                }

                if (ActiveControl.Name == "lv_static_route")
                {
                    ip = lv_static_route.SelectedItems[0].SubItems[1].Text.ToString();
                    mask = lv_static_route.SelectedItems[0].SubItems[2].Text.ToString();
                    gateway = lv_static_route.SelectedItems[0].SubItems[3].Text.Replace("On-Line", "127.0.0.1").ToString();
                }

                var process = new ProcessStartInfo()
                {
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    CreateNoWindow = true,
                    Arguments = "cmd /C " + " route delete " + ip + " mask " + mask + " " + gateway,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(process);
                Task.Run(() => { get_routes(); });
            }
        }

        private void Refres_Click(object sender, EventArgs e)
        {
            Task.Run(() => { get_routes(); });
        }

        private void lv_adapters_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                    network_adapters();
            }
        }

        private void lv_dynamic_route_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyData == Keys.F5)
            {
                Task.Run(() => { get_routes(); });
            }
        }

        private void lv_static_route_KeyDown(object sender, KeyEventArgs e)
        {
            Task.Run(() => { get_routes(); });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form = new Form5(this);
            form.ShowDialog();

        }
        private void check_box_clear_clien_oik_settings_CheckedChanged(object sender, EventArgs e)
        {
            if(check_box_clear_clien_oik_settings.Checked == true)
            {
                check_box_clear_clien_oik_settings.ForeColor = Color.Black;
            }    
        }

        private void chbx_SystemFontsDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_SystemFontsDefault.Checked == true)
            {
                chbx_SystemFontsDefault.ForeColor = Color.Black;
            }
        }

        private void chbx_OIKFontsDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_OIKFontsDefault.Checked == true)
            {
                chbx_OIKFontsDefault.ForeColor = Color.Black;
            }
        }

        private void chbx_ModusFontsDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_ModusFontsDefault.Checked == true)
            {
                chbx_ModusFontsDefault.ForeColor = Color.Black;
            }
        }
    }

    public class class_Route_parameters
    {
        public static string adress, mask, gateway, outinterface, metric, cMS_string_select, IntefaceIndex;
    }


    public class class_NetworkAdapter_Settings
    {
        public static string number, ID, ConnectionName, Description, IP_adress, Gateway, MAC_Adress, Metric, Mask, State, DNS_1, DNS_2;
    }
}

