using ProcessViewer;
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
            TextInfo.Items.Add($"\t\t\t    Лабораторная работа 1:");
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
            TextInfo.Items.Add($"\t\t\t    Лабораторная работа 2:");
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
            TextInfo.Items.Add($"\t\t\t    Лабораторная работа 3:");
            TextInfo.Items.Add($"Цель работы:");
        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb4_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 4;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\t    Лабораторная работа 4:");
            TextInfo.Items.Add($"Цель работы:");
            TextInfo.Items.Add($"  Цель работы заключается в  освоении методов работы с файлами");
            TextInfo.Items.Add($"    проецируемыми в память. ");
            TextInfo.Items.Add($"  Задания для самостоятельной работы:");
            TextInfo.Items.Add($"    С помощью механизма проецирования в память  замените в текстовом файле все");
            TextInfo.Items.Add($"    строчные буквы на прописные и удвойте вхождение каждой цифры. ");


        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb5_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 5;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\t    Лабораторная работа 5:");
            TextInfo.Items.Add($"Цель работы:");
            TextInfo.Items.Add($"  Целью работы является изучение основных принципов организации");
            TextInfo.Items.Add($"    многозадачных операционных систем. Все многозадачные операционные");
            TextInfo.Items.Add($"    системы используют концепцию процесса и потока.");
            TextInfo.Items.Add($"    В данной работе рассматриваются  следующие вопросы:");
            TextInfo.Items.Add($"\t•  Чередование выполнения нескольких процессов с целью повышения");
            TextInfo.Items.Add($"\t   степени использования процессора;");
            TextInfo.Items.Add($"\t•  Разделение ресурсов между процессами;");
            TextInfo.Items.Add($"\t•  Организация обмена данными между процессами и потоками;");
            TextInfo.Items.Add($"\t•  Изменение класса приоритета процесса и уровня приоритета потока.");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"Задание для выполнения:");
            TextInfo.Items.Add($"\t2. Программа, выполняющая запуск любого процесса и завершение");
            TextInfo.Items.Add($"\t   данного процесса по команде пользователя.");

        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb6_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 6;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\t    Лабораторная работа 6:");
            TextInfo.Items.Add($"Цель работы:");
            TextInfo.Items.Add($"  Целью работы является получение навыков работы  с функциями ");
            TextInfo.Items.Add($"    библиотеки ToolHelp API для получения системной информации. В данной ");
            TextInfo.Items.Add($"    работе рассматриваются следующие вопросы:");
            TextInfo.Items.Add($"\t•  Получение списка всех  процессов в системе;");
            TextInfo.Items.Add($"\t•  Получение списка всех  модулей в системе;");
            TextInfo.Items.Add($"\t•  Получение списка всех  потоков выбранного процесса;");
            TextInfo.Items.Add($"\t•  Получение карты памяти выбранного процесса.");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"Задания для самостоятельной работы");
            TextInfo.Items.Add($"\t2. Программа, формирующая список всех процессов, выполняющихся");
            TextInfo.Items.Add($"\t   на данном компьютере и позволяющая просматривать  список");
            TextInfo.Items.Add($"\t   потоков данного процесса.");
        }

        //кнопка ---------------------------------------------------------------------------------------
        private void Lb7_Click(object sender, RoutedEventArgs e)
        {
            flagChoseLb = 7;
            TextInfo.Items.Clear();
            TextInfo.Items.Add($" ");
            TextInfo.Items.Add($"\t\t\t    Лабораторная работа 7:");
            TextInfo.Items.Add($"Цель работы:");
            TextInfo.Items.Add($"  Целью данной работы является  исследование объектов синхронизации,");
            TextInfo.Items.Add($"    с помощью которых в многозадачной среде обеспечивается ");
            TextInfo.Items.Add($"    последовательный доступ к совместно используемым ресурсам. В данной");
            TextInfo.Items.Add($"    работе рассматриваются следующие вопросы:");
            TextInfo.Items.Add($"\t•Синхронизация потоков с помощью объектов пользовательского режима");
            TextInfo.Items.Add($"\t (критические секции);");
            TextInfo.Items.Add($"\t•Синхронизация потоков с помощью объектов ядра (объекты Mutex, ");
            TextInfo.Items.Add($"\t события, семафоры, процессы и потоки);");
            TextInfo.Items.Add($"\t•Работа Wait- функций в различных режимах.");
            TextInfo.Items.Add($"");
            TextInfo.Items.Add($"Задания для самостоятельной работы");
            TextInfo.Items.Add($"    2.Исследование возможности синхронизации потоков с помощью событий. ");
            TextInfo.Items.Add($"    Создание двух приложений. Первое приложение следит  за вторым ");
            TextInfo.Items.Add($"    приложением. Второе приложение позволяет пользователю вводить с ");
            TextInfo.Items.Add($"    помощью клавиатуры и отображать в своем окне произвольные символы.");
            TextInfo.Items.Add($"    Первое, контролирующее приложение при вводе  в окне второго приложения");
            TextInfo.Items.Add($"    символа отображает в своем окне символ \"*\".");
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
                case 5:
                    Lb5Window lb5win = new Lb5Window();
                    lb5win.Owner = this;
                    lb5win.Show();
                    break;
                case 6:
                    Lb6Window lb6win = new Lb6Window();
                    lb6win.Owner = this;
                    lb6win.Show();
                    break;
                case 7:
                    Lb7_1Window lb7_1win = new Lb7_1Window();
                    lb7_1win.Owner = this;
                    lb7_1win.Show();
                    Lb7_2Window lb7_2win = new Lb7_2Window();
                    lb7_2win.Owner = this;
                    lb7_2win.Show();
                    break;

            }
        }
    }
}