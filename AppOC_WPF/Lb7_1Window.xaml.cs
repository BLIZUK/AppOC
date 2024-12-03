using System;
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
using System.Threading;

namespace AppOC_WPF
{
    /// <summary>
    /// Логика взаимодействия для Lb7_1Window.xaml
    /// </summary>
    public partial class Lb7_1Window : Window
    {
        private EventWaitHandle _eventWaitHandle;
        public Lb7_1Window()
        {
            InitializeComponent();
            _eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, "InputEvent");
            Thread controllerThread = new Thread(ControllerThread);
            controllerThread.IsBackground = true;
            controllerThread.Start();
        }
        private void ControllerThread()
        {
            while (true)
            {
                _eventWaitHandle.WaitOne(); // Ожидание сигнала от второго приложения
                Dispatcher.Invoke(() => OutputTextBlock.Text += "*"); // Обновление UI
            }
        }

    }
}
