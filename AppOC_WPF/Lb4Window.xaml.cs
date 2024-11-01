using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace AppOC_WPF
{
    public partial class Lb4Window : Window
    {
        string pathFileStn = @"D:\example.txt", pathFileChos;
        int flagchose = 0, flagactive = 0;

        public Lb4Window()
        {
            InitializeComponent();
            stdrb.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flagchose == 0)
            {
                ProcessFile(pathFileStn);
                EndText.Text = File.ReadAllText(pathFileStn);
            }
            else if (flagchose == 1)
            {
                ProcessFile(pathFileChos);
                EndText.Text = File.ReadAllText(pathFileChos);
            }
        }

        private void ProcessFile(string filename)
        {
            try
            {
                // Открыть файл
                using (var file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    var fileSize = (int)file.Length;

                    // Если файл пуст, установить минимальную емкость
                    var capacity = fileSize > 0 ? fileSize : 1;

                    MemoryMappedFile mmf = null;

                    MemoryMappedViewAccessor accessor = null;


                    try
                    {
                        mmf = MemoryMappedFile.CreateFromFile(file, null, capacity, MemoryMappedFileAccess.ReadWrite, HandleInheritability.None, false);
                        accessor = mmf.CreateViewAccessor(0, capacity, MemoryMappedFileAccess.ReadWrite);

                        // Пройтись по проецированному файлу
                        for (int i = 0; i < fileSize; i++)
                        {
                            byte b;
                            accessor.Read(i, out b);

                            // Замена строчной буквы на прописную
                            if (b >= 'a' && b <= 'z')
                            {
                                b = (byte)(b - 'a' + 'A');
                                accessor.Write(i, ref b);
                            }
                            // Удвоение цифры
                            if (b >= '0' && b <= '9')
                            {
                                // Сдвинуть содержимое файла вправо, чтобы освободить место для дублирования цифры
                                var newFileSize = fileSize + 1;
                                var newBuffer = new byte[newFileSize];

                                // Читать данные из проецированного файла в буфер
                                accessor.ReadArray(0, newBuffer, 0, fileSize);

                                // Сдвигать данные вправо, начиная с индекса i+1
                                Array.Copy(newBuffer, i, newBuffer, i + 1, fileSize - i - 1);
                                newBuffer[i] = b; // Дублировать цифру

                                // Обновить размер файла
                                file.SetLength(newFileSize);

                                // Закрыть текущее проецированное представление
                                accessor.Dispose();
                                accessor = null;

                                // Создать новое проецированное представление с обновленной емкостью
                                mmf.Dispose();
                                mmf = MemoryMappedFile.CreateFromFile(file, null, newFileSize, MemoryMappedFileAccess.ReadWrite, HandleInheritability.None, false);
                                accessor = mmf.CreateViewAccessor(0, newFileSize, MemoryMappedFileAccess.ReadWrite);

                                // Записать обновленный буфер обратно в файл
                                accessor.WriteArray(0, newBuffer, 0, newFileSize);

                                // Увеличить индекс, поскольку мы добавили новый символ
                                i++;
                                fileSize = newFileSize;
                            } // Ошибка в дублирование цифр - не работает!!!
                        }
                    }
                    finally
                    {
                        // Закрыть проецированное представление файла
                        if (accessor != null)
                        {
                            accessor.Dispose();
                        }
                        if (mmf != null)
                        {
                            mmf.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (flagactive == 0)
            {
                MessageBox.Show("Файл не выбран");
            }
            else
            {
                if (flagchose == 0)
                {
                    File.WriteAllText(pathFileStn, startText.Text);
                }
                else
                {
                    File.WriteAllText(pathFileChos, startText.Text);
                }
            }
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            flagactive = 1;
            if (flagchose == 0)
            {
                try
                {
                    string filecontent = File.ReadAllText(pathFileStn);
                    startText.Text = filecontent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (flagchose == 1)
            {
                try
                {
                    string filecontent = File.ReadAllText(pathFileChos);
                    startText.Text = filecontent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            flagactive = 0;
            flagchose = 1;

            // Интересная конструкция 
            // <-----------------------------------------------------------
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                pathFileChos = openFileDialog.FileName;
                PathText.Text = pathFileChos;
                flagactive = 1;
            }   
            // <-----------------------------------------------------------
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            PathText.Text = pathFileStn;
            flagchose = 0;
            flagactive = 0;
        }
    }
}