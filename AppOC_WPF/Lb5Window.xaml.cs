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


        private Process _process;
        private int flagActiv = 0;
        private string pathfile;


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


        private void start_Click(object sender, RoutedEventArgs e)
        {
            status.Text = $"Запущено";
            flagActiv = 1;
            string pathName = PathText.Text;
            try
            {
                _process = new Process();
                _process.StartInfo.FileName = pathName;
                _process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                status.Text = $"Ошибка!";
                flagActiv = 0;
            }

        }


        private void end_Click(object sender, RoutedEventArgs e)
        {
            if (flagActiv == 1)
            {
                _process.Kill();
                status.Text = $"Не запущено";
                flagActiv = 0;
            }
            else {
                MessageBox.Show($"Процесс не запущен!");
            }
        }
    }
}
