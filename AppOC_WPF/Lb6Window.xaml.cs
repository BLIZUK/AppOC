using System;
using System.Diagnostics;
using System.Windows;

namespace ProcessViewer
{
    public partial class Lb6Window : Window
    {
        public Lb6Window()
        {
            InitializeComponent();
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            processList.ItemsSource = Process.GetProcesses();
        }

        private void processList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (processList.SelectedItem is Process selectedProcess)
            {
                threadList.ItemsSource = selectedProcess.Threads;
            }
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadProcesses();
        }
    }
}