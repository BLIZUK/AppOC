using Microsoft.Win32;
using System;
using System.Diagnostics;
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

namespace AppOC_WPF
{
    /// <summary>
    /// Логика взаимодействия для Lb5Window.xaml
    /// </summary>
    public partial class Lb5Window : Window
    {
        string pathfile;
        public Lb5Window()
        {
            InitializeComponent();
        }

        private void FIndPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                pathfile = openFileDialog.FileName;
                PathText.Text = pathfile;
            }
        }


        void start_proc(string pathName)
        {
            try
            {

                ProcessStartInfo startInfo = new ProcessStartInfo(pathName)
                {
                    UseShellExecute = true, // Использовать оболочку для открытия окна
                    CreateNoWindow = false // Не скрывать окно
                };
                //Process.Start(pathName);
                status.Text = $"Запущен";


                Process process = new Process();
                process.StartInfo.FileName = pathName;

                process.Start();



                System.Threading.Thread.Sleep(5000);
                process.Kill();
                status.Text = $"Не активен";




                /*
                Process process = new Process();  
                process.StartInfo.FileName = pathfile;
                process.Start();

                status.Text = $"Запущен";
                */
                //process.Kill();
                //process.WaitForExit();

                // status.Text = $"Не активен";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                status.Text = $"Не активен";
            }
        }


        private void start_Click(object sender, RoutedEventArgs e)
        {
            status.Text = $"Запущен";
            string pathName = PathText.Text; 
            start_proc(pathName);
            
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
           // process.Kill();
        }
    }
}
