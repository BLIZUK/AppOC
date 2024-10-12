using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Management;
using System.Runtime.InteropServices;

namespace AppOC_WPF
{
    /// <summary>
    /// Логика взаимодействия для Lb2Window.xaml
    /// </summary>
    public partial class Lb2Window : Window
    {
        public Lb2Window()
        {
            InitializeComponent();
        }

        private void SysInfo_Click(object sender, RoutedEventArgs e)
        {
            MainListBox.Items.Clear();
            try
            {
                var sercher = new ManagementObjectSearcher("SELECT Architecture FROM Win32_Processor");
                var cpuInfo = sercher.Get().OfType<ManagementObject>().FirstOrDefault();

                if (cpuInfo != null)
                {
                    int architecture = Convert.ToInt32(cpuInfo["Architecture"]);
                    string architectureDescription = architecture switch
                    {
                        0 => "x86",
                        1 => "MIPS",
                        2 => "Alpha",
                        3 => "PowerPC",
                        6 => "Itanium-based",
                        9 => "x64",
                        _ => "Неизвестная архитектура"
                    };
                    MainListBox.Items.Add($"Архитектура процессора: {architectureDescription}");
                }
                else
                {
                    MainListBox.Items.Add($"Архитектура процессора: Не удалось получить информацию о процессоре.");
                }
            }

            catch(Exception ex) 
            { 
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
