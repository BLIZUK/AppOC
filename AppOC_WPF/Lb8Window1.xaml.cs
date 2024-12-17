using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace AppOC_WPF
{
    public partial class Lb8Window1 : Window
    {
        public Lb8Window1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (RB1.IsChecked == true)
            {
                // Явная загрузка
                double result = CalculateUsingExplicitLoad();
                ResultLabel.Content = $"Результат: {result}";
            }
            else if (RB2.IsChecked == true)
            {
                // Неявная загрузка
                double result = CalculateUsingImplicitLoad();
                ResultLabel.Content = $"Результат: {result}";
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите метод загрузки.");
            }
        }

        // Неявная загрузка
        private double CalculateUsingImplicitLoad()
        {
            [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern double CalculateProduct(int n);

            if (int.TryParse(InputN.Text, out int n) && n > 0)
            {
                return CalculateProduct(n);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное положительное число.");
                return 0;
            }
        }

        // Явная загрузка
        private double CalculateUsingExplicitLoad()
        {
            IntPtr pDll = LoadLibrary("MathLibrary.dll");
            if (pDll == IntPtr.Zero)
            {
                MessageBox.Show("Не удалось загрузить библиотеку.");
                return 0;
            }

            IntPtr pAddressOfFunctionToCall = GetProcAddress(pDll, "CalculateProduct");
            if (pAddressOfFunctionToCall == IntPtr.Zero)
            {
                MessageBox.Show("Не удалось найти функцию.");
                FreeLibrary(pDll);
                return 0;
            }

            var calculateProduct = (CalculateProductDelegate)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(CalculateProductDelegate));

            if (int.TryParse(InputN.Text, out int n) && n > 0)
            {
                double result = calculateProduct(n);
                FreeLibrary(pDll);
                return result;
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное положительное число.");
                FreeLibrary(pDll);
                return 0;
            }
        }

        private delegate double CalculateProductDelegate(int n);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        private void RB1_Checked(object sender, RoutedEventArgs e)
        {
            // Дополнительная логика при выборе RB1 (если требуется)
        }
    }
}
