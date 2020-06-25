using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        int[] mas = new int[24];
        public Form1()
        {
            InitializeComponent();

        }


                                      //Кнопка "Добавить график"
        private void grafik(object sender, EventArgs e)
        {
            int[] x = mas;
            int[] y = new int[24];
            for (int i = 0; i < 24; i++)
            {
                y[i] = mas[i];
                x[i] = i;
                chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 1;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 2;
                chart1.Series[0].Points.DataBindXY(x, y);
            }
        }



                                             //Кнопка "Завершие работы"

        private void Zaverchit(object sender, EventArgs e) 
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Подтверждение действия", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.Close();
        }



                                    //Кнопка "Вычисление массива" (Задание)

        private void Zadanie(object sender, EventArgs e)  
        int temp = 0;
            for (int i = 0; i < 24; i++)// Нахождение среднего арифметического отрицательных элементов массива
            {

                if (array[i] < 0)
                {
                    sr += array[i];
                    count++;
                }

            for (int j = 0; j < 24; j++)// Нахождение среднего арифметического положительных элементов массива
             {

                if (array[
                {
                    sr += array[i];
                    temp++;
                }
             label1.Text = "Среднее арифметическое положительных элементов:" + Math.Round(sr * count, 3);
            label2.Text = "Среднее арифметическое отрицательных элементов :" + Math.Round(sr / count, 3);
        }

                                       //Кнопка "Рандомное заполнение массива"

        private void RandZapolnenie(object sender, EventArgs e)     
        {
            dataGridView1.ColumnCount = 24;
            Random rnd = new Random();
            for (int i = 0; i < mas.Length; i++)
                 {
                     mas[i] = rnd.Next(-100, 100);
                     dataGridView1.Rows[0].Cells[i].Value = mas[i];
                 } 
        }




                                                //Переход на Form2 с скрытием Form1

        private void Perehod(object sender, EventArgs e)    
        {
            Genesis frm = new Genesis();
            this.Hide();// При переходе на Form2, Form1 скрывается и остаётся только form2
            frm.Show();

        }


                                                //Кнопка "Очистить"

        private void Ochistka_Click(object sender, EventArgs e)   
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Rows[0].Cells[i].Value = "";
            label2.Text = "";
        }


                                     // Кнопка "ввод из файла" 

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader f = new StreamReader(@"C:\\massiv.txt"); // Объявление StreamReader

                string[] a = f.ReadToEnd().Split('\n');// Чтение данных из файла
                for (int i = 0; i < 24; i++)
                {
                    dataGridView1.Rows[0].Cells[i].Value = a[i]; // Заполнение ячеек
                    mas[i] = Convert.ToInt32(a[i]); // Заполнение массива 
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Ошибка! Не удалось найти файл.!"); // Исключение при отсутствии файла
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();// При переходе на Form2, Form1 скрывается и остаётся только form2
            frm.Show();
        }
    }
}
