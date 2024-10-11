﻿using System;
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
using System.IO;


namespace AppOC_WPF

{
    /// <summary>
    /// Логика взаимодействия для Lb1Window.xaml
    /// </summary>
    public partial class Lb1Window : Window
    {

        public Lb1Window()
        {
            // Инициализация окна
            InitializeComponent();
            // Получение данных о систем
            string version = Environment.OSVersion.Version.Major.ToString();
            string numVersion = Environment.OSVersion.Version.Build.ToString();
            string platform = Environment.OSVersion.Platform.ToString();
            string ServPk = Environment.OSVersion.ServicePack;
            
            // Вставка в блоки
            Platform.Text = " " + platform;
            Version.Text = " " + version;
            NumOC.Text = " " + numVersion;

            // Проверка на наличие Данных в ServicePack
            // В поздних версиях Windows ServicePack отсутствует
            if (ServPk.Length > 1) ServicePack.Text = " " + ServPk;
            else ServicePack.Text = " Недоступно!";

            // Получение системного каталога и каталога Windows 
            string pathWindows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string pathSystem = Environment.GetFolderPath(Environment.SpecialFolder.System);

            // Вставка в блоки
            WinCat.Text = pathWindows;
            SisCat.Text = pathSystem;
            // В моей системе есть нарушения WMI, возможности найти каталог инициализатор Windows утерян
            WinCatInst.Text = " H:\\" ;
        }

        // Кнопка получение информации о диске
        private void Info_take_Click(object sender, RoutedEventArgs e)
        {
            // Получение пути из TextBox
            string directoryPath = path.Text.Trim();

            // Проверка на наличие данных
            if (string.IsNullOrEmpty(directoryPath))
            {
                directoryPath = @"C:\"; // Путь по умолчанию
            }

            try
            {
                // Получение серийного номера и имени тома
                var searcher = new ManagementObjectSearcher("SELECT SerialNumber, Name FROM Win32_LogicalDisk WHERE DriveType=3");
                var diskInfo = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                if (diskInfo != null)
                {
                    string serialNumber = diskInfo["SerialNumber"]?.ToString() ?? "Не найдено";
                    string volumeName = diskInfo["Name"]?.ToString() ?? "Не найдено";

                    // Получение максимального количества символов в имени файла
                    DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);

                    // Проверка на существование директории
                    if (dirInfo.Exists)
                    {
                        // Получение числа равного максимальной длинне имени файла в системе
                        int maxFileNameLength = dirInfo.GetFiles().Select(f => f.Name.Length).DefaultIfEmpty(0).Max();
                        string maxFileNameLen = $"{maxFileNameLength}";

                        // Вставка в блоки
                        SerNum.Text = " " + serialNumber;
                        NameTom.Text = " " + volumeName;
                        maxSymb.Text = " " + maxFileNameLen;
                    }
                    else
                    {
                        // Всплывающее окно
                        MessageBox.Show("Указанный каталог не существует.");
                    }
                }
                else
                {
                    // Всплывающее окно
                    MessageBox.Show("Не удалось получить информацию о дисках.");
                }
            }
            // Перехват ошибки связанной с WMI системой
            catch (ManagementException ex)
            {
                // Всплывающее окно
                MessageBox.Show($"Ошибка WMI: {ex.Message}");
            }
            // Перехват ошибки
            catch (Exception ex)
            {
                // Всплывающее окно
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Кнопка получения информации о тактовой частоте процессора 
        private void UnfoCpu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение информации о частоте процессора 
                var searcher = new ManagementObjectSearcher("SELECT CurrentClockSpeed FROM Win32_Processor");
                var cpuinfo = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                // Проверка на наличие данных
                if (cpuinfo != null)
                {
                    CPU.Text = $"Тактовая частота: {cpuinfo["CurrentClockSpeed"]} МГц";
                }

                else
                {
                    CPU.Text = "Не удалось получить информацию о процессоре";
                }
            }

            // Перехват ошибки
            catch (Exception ex) 
            {
                CPU.Text = $"Ошибка: {ex.Message}";
            }
        }
    }
}