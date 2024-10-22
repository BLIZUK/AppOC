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
        // Флаг выбора программы
        private int flagChoseLb = 0;

        public MainWindow()
        {
            InitializeComponent();
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"\t\t\tВыберите лабораторную задачу.");
            TextInfo.Items.Add(" ");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");

        }

        //кнопка ---------------------------------------------------------------------------------------
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
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($" ");

        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb2_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 2;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\tЛабораторная работа 2:");
            TextInfo.Items.Add($"Цель работы:");
            TextInfo.Items.Add($"  Целью работы является изучение основных функций ядра Kernel32.dll ");
            TextInfo.Items.Add($"    для работы с виртуальной  памятью. Рассматриваемые в данной ");
            TextInfo.Items.Add($"    лабораторной работе функции позволяют:");
            TextInfo.Items.Add($"\t•  получить информацию о состоянии системной памяти и виртуального ");
            TextInfo.Items.Add($"\t   адресного пространства любого процесса;");
            TextInfo.Items.Add($"\t•  напрямую резервировать регион адресного пространства;");
            TextInfo.Items.Add($"\t•  передавать зарезервированному региону физическую память;");
            TextInfo.Items.Add($"\t•  освобождать регионы адресного пространства;");
            TextInfo.Items.Add($"\t•  изменять атрибуты защиты страниц виртуальной памяти.");
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($" ");


        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb3_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 3;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\tЛабораторная работа 3:");
            TextInfo.Items.Add($"Цель работы:");
        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb4_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 4;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\tЛабораторная работа 4:");
            TextInfo.Items.Add($"Цель работы:");
            TextInfo.Items.Add($"  Цель работы заключается в  освоении методов работы с файлами");
            TextInfo.Items.Add($"    проецируемыми в память. ");
            TextInfo.Items.Add($"  Задания для самостоятельной работы:");
            TextInfo.Items.Add($"    2.С помощью механизма проецирования в память  замените в текстовом файле все");
            TextInfo.Items.Add($"    строчные буквы на прописные и удвойте вхождение каждой цифры. ");


        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb5_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 5;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\tЛабораторная работа 5:");
            TextInfo.Items.Add($"Цель работы:");
        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb6_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 6;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\tЛабораторная работа 6:");
            TextInfo.Items.Add($"Цель работы:");
        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb7_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 7;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\tЛабораторная работа 7:");
            TextInfo.Items.Add($"Цель работы:");
        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb8_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 8;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\tЛабораторная работа 8:");
            TextInfo.Items.Add($"Цель работы:");
        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb9_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 9;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\tЛабораторная работа 9:");
            TextInfo.Items.Add($"Цель работы:");
        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 0;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"\t\t               AppOC Windows System Analyzer");
            TextInfo.Items.Add($"\t\t\t\t     0.0.8");
            TextInfo.Items.Add($"\t\t   Разработана Близученко Андреем ИВТ2-23");
            TextInfo.Items.Add($"\t\t\t\t 10.10.2024");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"");
        }

        //кнопка ---------------------------------------------------------------------------------------
        //Для запуска дополнительных окон 
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
                case 2:
                    Lb2Window Lb2win = new Lb2Window();
                    Lb2win.Owner = this;
                    Lb2win.Show();
                    break;
                case 3:
                    break;
                case 4:
                    Lb4Window lb4win = new Lb4Window();
                    lb4win.Owner = this;
                    lb4win.Show();
                    break;

            }
        }
    }
}