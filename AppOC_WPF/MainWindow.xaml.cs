using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppOC_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int flagChoseLb = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Lb1_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 1;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\tЛабораторная работа 1:");
            TextInfo.Items.Add($"Цель работы:");
            TextInfo.Items.Add($"  Целью данной работы является изучение процедур и функций Win32");
            TextInfo.Items.Add($"    позволяющих получить общую информации о характеристиках компьютера  ");
            TextInfo.Items.Add($"    u операционной системы.");

            TextInfo.Items.Add($"  В данной лабораторной работе рассматриваются функции Win32, с  ");
            TextInfo.Items.Add($"    помощью которых можно получить перечисленную информацию:");
            TextInfo.Items.Add(" ");
            TextInfo.Items.Add($"\t•  тип ПК и версия операционной системы;");
            TextInfo.Items.Add($"\t•  состав аппаратных средств;");
            TextInfo.Items.Add($"\t•  физическое положение файлов на дисковом носителе;");
            TextInfo.Items.Add($"\t•  наличие скрытых частей программы;");
            TextInfo.Items.Add($"\t•  физические особенности (в том числе дефекты) носителя.");

        }

        private void Lb2_Click(object sender, RoutedEventArgs e)
        {
            TextInfo.Items.Clear();
        }

        private void Lb3_Click(object sender, RoutedEventArgs e)
        {
            TextInfo.Items.Clear();
        }

        private void Lb4_Click(object sender, RoutedEventArgs e)
        {
            TextInfo.Items.Clear();
        }

        private void Lb5_Click(object sender, RoutedEventArgs e)
        {
            TextInfo.Items.Clear();
        }

        private void Lb6_Click(object sender, RoutedEventArgs e)
        {
            TextInfo.Items.Clear();
        }

        private void Lb7_Click(object sender, RoutedEventArgs e)
        {
            TextInfo.Items.Clear();
        }

        private void Lb8_Click(object sender, RoutedEventArgs e)
        {
            TextInfo.Items.Clear();
        }

        private void Lb9_Click(object sender, RoutedEventArgs e)
        {
            TextInfo.Items.Clear();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            switch (flagChoseLb)
            {
                case 0:
                    MessageBox.Show("Не выбрана лабораторная работа!");
                    break;
                case 1:
                    Lb1Window Lb1win = new Lb1Window();
                    Lb1win.Owner = this;
                    Lb1win.Show();
                    break;

            }
        }
    }
}