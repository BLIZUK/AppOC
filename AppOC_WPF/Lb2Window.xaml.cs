using System;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace AppOC_WPF
{
    public partial class Lb2Window : Window
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO
        {
            public ushort wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public uint dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType; // Устаревшее поле
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        }

        [DllImport("kernel32.dll")]
        public static extern void GetSystemInfo(ref SYSTEM_INFO lpSystemInfo);

        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORYSTATUSEX
        {
            public uint dwLength; // Размер структуры
            public uint dwMemoryLoad; // Процент использования памяти
            public ulong ullTotalPhys; // Общая физическая память
            public ulong ullAvailPhys; // Доступная физическая память
            public ulong ullTotalPageFile; // Общий объем файла подкачки
            public ulong ullAvailPageFile; // Доступный объем файла подкачки
            public ulong ullTotalVirtual; // Общая виртуальная память
            public ulong ullAvailVirtual; // Доступная виртуальная память
            public ulong ullAvailExtendedVirtual; // Резервировано, всегда 0
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public uint AllocationProtect;
            public IntPtr RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }

        [DllImport("kernel32.dll")]
        public static extern uint VirtualQuery(IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

        // Инициализация окна---------------------------------------------------------------------------------------
        public Lb2Window()
        {
            InitializeComponent();
        }


        // Кнопка SysInfo_Click-------------------------------------------------------------------------------------
        private void SysInfo_Click(object sender, RoutedEventArgs e)
        {
            MainListBox.Items.Clear();

            try
            {
                var searcher = new ManagementObjectSearcher("SELECT Architecture FROM Win32_Processor");
                var cpuInfo = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

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
                    MainListBox.Items.Add("Архитектура процессора: Не удалось получить информацию о процессоре.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return; // Выход из метода в случае ошибки
            }

            try
            {
                SYSTEM_INFO sysInfo = new SYSTEM_INFO();
                GetSystemInfo(ref sysInfo);
                MainListBox.Items.Add($"Уровень процессора: {sysInfo.wProcessorLevel} ");
                MainListBox.Items.Add($"Ревизия процессора: {sysInfo.wProcessorRevision} ");
                MainListBox.Items.Add($"Размер страницы: {sysInfo.dwPageSize} байт");
                MainListBox.Items.Add($"Минимальный адрес памяти доступного адресного пространства: {sysInfo.lpMinimumApplicationAddress}");
                MainListBox.Items.Add($"Максимальный адрес памяти доступного адресного пространства: {sysInfo.lpMaximumApplicationAddress}");
                MainListBox.Items.Add($"Битовая маска: {sysInfo.dwActiveProcessorMask}");
                MainListBox.Items.Add($"Число логических процессоров: {sysInfo.dwNumberOfProcessors}");
                MainListBox.Items.Add($"Гранулярность резервирования регионов адресного пространства: {sysInfo.dwAllocationGranularity}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении системной информации: {ex.Message}");
            }

        }

        // Кнопка GlobalMemoryStatus--------------------------------------------------------------------------------
        private void GlobalMemoryStatus_Click(object sender, RoutedEventArgs e)
        {
            MainListBox.Items.Clear();
            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            memStatus.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));

            if (GlobalMemoryStatusEx(ref memStatus))
            {
                MainListBox.Items.Add($"Использование памяти: {memStatus.dwMemoryLoad}%");
                MainListBox.Items.Add($"Общая физическая память: {memStatus.ullTotalPhys} байт");
                MainListBox.Items.Add($"Доступная физическая память: {memStatus.ullAvailPhys} байт");
                MainListBox.Items.Add($"Общий объем файла подкачки: {memStatus.ullTotalPageFile} байт");
                MainListBox.Items.Add($"Доступный объем файла подкачки: {memStatus.ullAvailPageFile} байт");
                MainListBox.Items.Add($"Общая виртуальная память: {memStatus.ullTotalVirtual} байт");
                MainListBox.Items.Add($"Доступная виртуальная память: {memStatus.ullAvailVirtual} байт");
            }
            else
            {
                MessageBox.Show("Ошибка при получении состояния памяти.");
            }
        }

        private void VirtualQuery_Click(object sender, RoutedEventArgs e)
        {
            SYSTEM_INFO sysInfo = new SYSTEM_INFO();
            GetSystemInfo(ref sysInfo); // Получаем информацию о системе

            MEMORY_BASIC_INFORMATION mbi = new MEMORY_BASIC_INFORMATION();

            // Проверяем текстовое поле на наличие введенного адреса.
            IntPtr address;

            try
            {
                if (string.IsNullOrWhiteSpace(TextBox1.Text))
                {
                    address = 4096; // Начальный адрес по умолчанию.
                }
                else
                {
                    // Преобразуем введенный адрес из строки в IntPtr.
                    address = (IntPtr)Convert.ToInt64(TextBox1.Text, 10); // Предполагаем, что ввод в шестнадцатеричном формате.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка - {ex}\nНедопустимый адрес.VirtualQuery запущена со значением по умолчанию - {4096}");
                address = 4096; // Начальный адрес по умолчанию.
            }

            // Запрос информации о памяти.
            uint result = VirtualQuery(address, out mbi, (uint)Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));

            MainListBox.Items.Clear(); // Очистка перед выводом новой информации.

            if (result != 0)
            {
                MainListBox.Items.Add($"Минимальный адрес: 4096");
                MainListBox.Items.Add($"Рассматриваемое значение: {mbi.BaseAddress}");
                MainListBox.Items.Add($"Базовый адрес региона :{mbi.AllocationBase}");
                MainListBox.Items.Add($"Размер региона: {mbi.RegionSize}");
                MainListBox.Items.Add($"Состояние: {mbi.State}");
                MainListBox.Items.Add($"Защита региона: {mbi.Protect}");
                MainListBox.Items.Add($"Тип физической памяти: {mbi.Type}");
            }
            else
            {
                uint errorCode = (uint)Marshal.GetLastWin32Error();
                MessageBox.Show($"Ошибка при вызове VirtualQuery. Код ошибки: {errorCode}");
            }
        }
    }
}
