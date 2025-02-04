using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
// using DLL;

namespace AppOC_WPF
{
    /// <summary>
    /// Логика взаимодействия для Lb8_Window.xaml
    /// </summary>
    public partial class Lb8Window : Window
    {
        public Lb8Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Lb8Window1 lb8win1 = new Lb8Window1();
            lb8win1.Owner = this;
            lb8win1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Lb8Window2 lb8win2 = new Lb8Window2();
            lb8win2.Owner = this;
            lb8win2.Show();
        }
    }
}
