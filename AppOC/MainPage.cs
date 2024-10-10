using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppOC
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Lb1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add($" ");
            listBox1.Items.Add($"\t\t\tЛабораторная работа 1:");
            listBox1.Items.Add($"Цель работы:");
            listBox1.Items.Add($"  Целью данной работы является изучение процедур и функций Win32"  );
            listBox1.Items.Add($"  позволяющих получить общую информации о характеристиках компьютера  ");
            listBox1.Items.Add($"  u операционной системы.");

            listBox1.Items.Add($"  В данной лабораторной работе рассматриваются функции Win32, с  ");
            listBox1.Items.Add($"  помощью которых можно получить перечисленную информацию:");
            listBox1.Items.Add(" ");
            listBox1.Items.Add($"•\tтип ПК и версия операционной системы;");
            listBox1.Items.Add($"•\tсостав аппаратных средств;");
            listBox1.Items.Add($"•\tфизическое положение файлов на дисковом носителе;");
            listBox1.Items.Add($"•\tналичие скрытых частей программы;");
            listBox1.Items.Add($"•\tфизические особенности (в том числе дефекты) носителя.");

        }

        private void Lb2_Click(object sender, EventArgs e)
        {

        }

        private void Lb3_Click(object sender, EventArgs e)
        {

        }

        private void Lb4_Click(object sender, EventArgs e)
        {

        }

        private void Lb7_Click(object sender, EventArgs e)
        {

        }

        private void info_Click(object sender, EventArgs e)
        {

        }

        

    }
}
