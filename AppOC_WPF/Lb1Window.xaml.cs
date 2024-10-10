using System;
using System.Management;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;


namespace AppOC_WPF


{
    /// <summary>
    /// Логика взаимодействия для Lb1Window.xaml
    /// </summary>
    public partial class Lb1Window : Window
    {



        public Lb1Window()
        {
            InitializeComponent();

            string version = Environment.OSVersion.Version.Major.ToString();
            string numVersion = Environment.OSVersion.Version.Build.ToString();
            string platform = Environment.OSVersion.Platform.ToString();
            string ServPk = Environment.OSVersion.ServicePack;
             
            Platform.Text = " " + platform;
            Version.Text = " " + version;
            if (ServPk.Length > 1) ServisPack.Text = " " + ServPk;
            else ServisPack.Text = " Недоступно!";
            NumOC.Text = " " + numVersion;

            string pathWindows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string pathSystem = Environment.GetFolderPath(Environment.SpecialFolder.System);

            WinCat.Text = pathWindows;
            SisCat.Text = pathSystem;
            WinCatInst.Text = " H:\\" ;
        }



        private void Info_take_Click(object sender, RoutedEventArgs e)
        {

        }


        private void UnfoCpu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
