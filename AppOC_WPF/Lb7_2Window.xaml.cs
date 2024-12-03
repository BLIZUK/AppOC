using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppOC_WPF
{
    /// <summary>
    /// Логика взаимодействия для Lb7_2Window.xaml
    /// </summary>
    public partial class Lb7_2Window : Window
    {
        private EventWaitHandle _eventWaitHandle;
        public Lb7_2Window()
        {
            InitializeComponent();
            _eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, "InputEvent");
        }
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) // Игнорируем нажатие Enter
            {
                _eventWaitHandle.Set(); // Сигнализируем контроллеру о вводе символа
            }
        }
    }
}
