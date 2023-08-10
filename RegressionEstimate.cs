using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovia_Mat_Stat
{
    public partial class RegressionEstimate : Form
    {
        public RegressionEstimate(double[] yCount, double[] regression, double[,] matrix)
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = yCount.Length;

            CreateTable(yCount, matrix, regression);
        }

        private void CreateTable(double[] yCount, double[,] matrix, double[] regression)
        {
            dataGridView1.Columns[0].HeaderText = "Действительные значения";
            dataGridView1.Columns[1].HeaderText = "Значение модели";
            dataGridView1.Columns[2].HeaderText = "Погрешность";
            for (int i = 0; i < yCount.Length; i++)
            {
                dataGridView1[0, i].Value = yCount[i];
            }

            //значение модели
            double buf;
            double[] model = new double[yCount.Length];
            for (int i = 0; i < yCount.Length; i++)
            {
                buf = 0.0;
                double[] some = GetDataRow(matrix, i);
                for (int j = 0; j < regression.Length; j++)
                {
                    if (j == 0)
                    {
                        buf += regression[j];
                    }
                    else
                    {
                        buf += regression[j] * some[j];
                    }
                }
                model[i] = buf;
                dataGridView1[1, i].Value = buf;
            }

            double something = 0;
            double[] someArr = new double[yCount.Length];

            for (int i = 0; i < yCount.Length; i++)
            {
                something = Convert.ToDouble(dataGridView1[0, i].Value) - Convert.ToDouble(dataGridView1[1, i].Value);
                someArr[i] = Math.Abs(something);
                dataGridView1[2, i].Value = Math.Abs(something);
            }
            label1.Text += $"\n Средняя погрешность = {Data.Average(someArr)}";
                       

            //занесение значений в chart
            //chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            //chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            chart1.Series[0].BorderWidth = 3; //толщина линии
            chart1.Series[1].BorderWidth = 3;

            for (int i = 0; i < yCount.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i, yCount[i]);
                chart1.Series[1].Points.AddXY(i, model[i]);
            }
        }

        private double[] GetDataRow(double[,] matrix, int numberCount)
        {
            double[] result = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result[i] = matrix[i, numberCount];
            }
            return result;
        }
    }
}
