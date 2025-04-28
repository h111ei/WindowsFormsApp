using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        double[] array;
        double left = 0;
        double right = 2;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N = int.Parse(textBox1.Text);
            int K = int.Parse(textBox2.Text);

            double min = 99999999;
            double max = -1;
            double k = 0;



            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            double difference = (max - min) / K;
            double right = min + difference;
            double left = min;
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < K; i++)
            {
                int count = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] >= left && array[j] < right)
                    {
                        count++;
                    }
                }
                chart1.Series[0].Points.AddXY(left, (Convert.ToDouble(count) / N) / difference);
                left += difference;
                right += difference;
            }
        }


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (i != checkedListBox1.SelectedIndex)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }

            if (checkedListBox1.SelectedIndex == 2)
            {
                textBox2.Enabled = false;
                label3.Enabled = false;
            }
            else
            {
                label3.Enabled = true;
                textBox2.Enabled= true;
            }

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int N = int.Parse(textBox1.Text);


            array = new double[N];
            Random r = new Random();




            if (checkedListBox1.SelectedIndex == 0)
            {

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = r.NextDouble();
                }

            }
            if (checkedListBox1.SelectedIndex == 1)
            {
                for (int i = 0; i < array.Length; i++)
                {

                    for (int j = 0; j < 40; j++)
                    {
                        array[i] += r.NextDouble();

                    }

                }


            }
            if (checkedListBox1.SelectedIndex == 2)
            {
                
                int M = int.Parse(textBox3.Text);
                double[] possarray = new double[M];
                double differece = (right - left) / M;

                double smallleft = 0;
                double smallright = smallleft + differece;

                double[] y = new double[M];
                double sum = 0;

                double[] midX = new double[M];
                double mathWait = 0;
                for (int i = 0; i < M; i++)
                {
                    double x = (smallleft + smallright) / 2;
                    y[i] = 0.5 * x;
                    sum += y[i];
                    smallleft += differece;
                    smallright += differece;
                    midX[i] = x;
                }



                for (int i = 0; i < M; i++)
                {
                    possarray[i] = y[i] / sum;
                    mathWait += midX[i] * possarray[i];
                }





                double tempormidsum = 0;


                for (int i = 0; i < N; i++)
                {
                    double rrr = r.NextDouble();
                    int indexes = 1;
                    while (rrr >= possarray[indexes - 1])
                    {
                        rrr -= possarray[indexes - 1];
                        indexes++;
                    }

                    smallleft = (indexes - 1) * differece;
                    smallright = smallleft + differece;
                    double c = r.NextDouble() * (smallright - smallleft) + smallleft;
                    array[i] = c;
                    tempormidsum += c;
                }

                tempormidsum /= N;


            }




            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите тип распределения!");
            }
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click_2(object sender, EventArgs e)
        {

        }
    }
}
