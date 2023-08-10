using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Kursovia_Mat_Stat
{
    public partial class Correlation : Form
    {
        bool doubleCorelationState = true; //true - если отрисована таблица парных коррел., иначе false
        List<double> SaveNumbers = new List<double>(); //список для сохранения элементов при приведении таблицы в треугольный вид

        public double[,] doubleCorrelArray = new double[Data.DGV.ColumnCount - 1, Data.DGV.ColumnCount - 1];//матрица парых коэф корреляции
        public double[,] privateCorrelArray = new double[Data.DGV.ColumnCount - 1, Data.DGV.ColumnCount - 1]; //матрица частных коэф корреляции
        public double[,] studentDoubleCorrelArray = new double[Data.DGV.ColumnCount - 1, Data.DGV.ColumnCount - 1];
        public double[,] studentPrivateCorrelArray = new double[Data.DGV.ColumnCount - 1, Data.DGV.ColumnCount - 1];

        public Point[] points = new Point[8]
                {
                new Point(24, 153),
                new Point(54, 56),
                new Point(154, 23),
                new Point(251, 55),
                new Point(283, 153),
                new Point(251, 249),
                new Point(153, 284),
                new Point(54, 251)
                };
        public Point[] numbersPoints = new Point[8]
                {
                new Point(10, 141),
                new Point(40, 42),
                new Point(147, 7),
                new Point(252, 40),
                new Point(285, 147),
                new Point(250, 249),
                new Point(147, 284),
                new Point(44, 249)
                };
        public Correlation()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = Data.DGV.ColumnCount;
            dataGridView1.RowCount = Data.DGV.ColumnCount;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView2.ColumnCount = Data.DGV.ColumnCount;
            dataGridView2.RowCount = Data.DGV.ColumnCount;
            dataGridView2.AllowUserToAddRows = false;

            CreateTable();
            СorrelationСalculation();
            PictureDoubleCorrelationTable();
            PictureStudentDoubleCorrelTable();
            PictureCorrelationPleads(true);
        }

        private void CreateTable() // первоначальная отрисовка формы при запуске
        {
            //инициализация dataGridView1
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = Data.DGV.Columns[i].HeaderText;
            }
            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1[0, i - 1].Value = Data.DGV.Columns[i].HeaderText;
            }

            //инициализация dataGridView2
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2.Columns[i].HeaderText = Data.DGV.Columns[i].HeaderText;
            }
            for (int i = 1; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2[0, i - 1].Value = Data.DGV.Columns[i].HeaderText;
            }
        }

        private void СorrelationСalculation() // Расчет парной и частной корреляции, с последующим занесением их в массивы
        {
            int n = 21; // количество элементов в выборке
            int l = 6; // количество фиксированных переменных

            //парная
            double correlationValue = 0;

            for (int i = 0; i < doubleCorrelArray.GetLength(0); i++)
            {
                for (int j = 0; j < doubleCorrelArray.GetLength(1); j++)
                {
                    correlationValue = Data.Сorrelation(getDataList(i + 1), getDataList(j + 1));
                    doubleCorrelArray[i, j] = correlationValue;
                }
            }

            //Стьюдент для парной
            correlationValue = 0;
            for (int i = 0; i < studentDoubleCorrelArray.GetLength(0); i++)
            {
                for (int j = 0; j < studentDoubleCorrelArray.GetLength(1); j++)
                {
                    //correlationValue = Math.Sqrt(n - l - 2) / Math.Sqrt(1 - doubleCorrelArray[i, j]);
                    correlationValue = (doubleCorrelArray[i, j] / Math.Sqrt(1 - Math.Pow(doubleCorrelArray[i, j], 2)) * Math.Sqrt(n - l - 2));
                    studentDoubleCorrelArray[i, j] = correlationValue;
                }
            }

            //частная 
            double[,] algebraicAddMatrix = new double[doubleCorrelArray.GetLength(0), doubleCorrelArray.GetLength(1)];

            for (int i = 0; i < doubleCorrelArray.GetLength(0); i++)
            {
                for (int j = 0; j < doubleCorrelArray.GetLength(1); j++)
                {
                    algebraicAddMatrix[i, j] = Math.Pow(-1, (i + j)) * Data.Determinant(Data.Minor(doubleCorrelArray, i, j));
                }
            }

            correlationValue = 0;
            for (int i = 0; i < doubleCorrelArray.GetLength(0); i++)
            {
                for (int j = 0; j < doubleCorrelArray.GetLength(1); j++)
                {
                    correlationValue = algebraicAddMatrix[i, j] /
                        Math.Sqrt(algebraicAddMatrix[i, i] * algebraicAddMatrix[j, j]);

                    privateCorrelArray[i, j] = correlationValue;
                }
            }
            
            //Стьюдент для частной
            correlationValue = 0;
            for (int i = 0; i < studentPrivateCorrelArray.GetLength(0); i++)
            {
                for (int j = 0; j < studentPrivateCorrelArray.GetLength(1); j++)
                {
                    correlationValue = (privateCorrelArray[i, j] / Math.Sqrt(1 - Math.Pow(privateCorrelArray[i, j], 2)) * Math.Sqrt(n - l - 2));
                    //correlationValue = Math.Sqrt(n - l - 2) / Math.Sqrt(1 - privateCorrelArray[i, j]);
                    studentPrivateCorrelArray[i, j] = correlationValue;
                }
            }
        }

        private double[] getDataList(int numberColumn) //формирует одномерную матрицу из данных определенного столбца
        {
            double[] resultList = new double[Data.DGV.RowCount];

            for (int i = 0; i < Data.DGV.RowCount; i++)
            {
                resultList[i] = (Convert.ToDouble(Data.DGV[numberColumn, i].Value));
            }
            return resultList;
        }

        private void ClearColorTable2()
        {
            for (int i = 1; i < dataGridView2.ColumnCount; i++)
            {
                for (int j = 1; j < dataGridView2.ColumnCount; j++)
                {
                    dataGridView2[j, i - 1].Style.BackColor = Color.White;
                }
            }
        }

        private void PictureStudentDoubleCorrelTable() // отрисовка данных критерев Стьюдента(парная корреляция) в таблицу
        {
            ClearColorTable2();
            for (int i = 1; i < dataGridView2.ColumnCount; i++)
            {
                for (int j = 1; j < dataGridView2.ColumnCount; j++)
                {
                    dataGridView2[j, i - 1].Value = studentDoubleCorrelArray[i - 1, j - 1];

                    if (Math.Abs(studentDoubleCorrelArray[i - 1, j - 1]) > 2.1604)
                    {
                        dataGridView2[j, i - 1].Style.BackColor = Color.LimeGreen;
                    }
                }
            }

            for (int i = 1; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2[i, i - 1].Style.BackColor = Color.White;
                dataGridView2[i, i - 1].Value = "-";
            }
        }

        private void PictureStudentPrivateCorrelTable() // отрисовка данных критерев Стьюдента(частная корреляция) в таблицу
        {
            ClearColorTable2();
            for (int i = 1; i < dataGridView2.ColumnCount; i++)
            {
                for (int j = 1; j < dataGridView2.ColumnCount; j++)
                {
                    dataGridView2[j, i - 1].Value = studentPrivateCorrelArray[i - 1, j - 1];

                    if (Math.Abs(studentPrivateCorrelArray[i - 1, j - 1]) > 2.1604)
                    {
                        dataGridView2[j, i - 1].Style.BackColor = Color.LimeGreen;
                    }
                }
            }

            for (int i = 1; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2[i, i - 1].Style.BackColor = Color.White;
                dataGridView2[i, i - 1].Value = "-";
            }
        }

        private void PictureDoubleCorrelationTable() //отрисовка данных парной корреляции в таблицу
        {
            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 1; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1[j, i - 1].Value = doubleCorrelArray[i - 1, j - 1];
                    dataGridView1[j, i - 1].Style.BackColor = Data.GetColor(doubleCorrelArray[i - 1, j - 1]);
                }
            }
        }

        private void PicturePrivateCorrelationTable() //отрисовка данных частной корреляции в таблицу
        {
            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 1; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1[j, i - 1].Value = privateCorrelArray[i - 1, j - 1];
                    dataGridView1[j, i - 1].Style.BackColor = Data.GetColor(privateCorrelArray[i - 1, j - 1]);
                }
            }
        }

        private void PictureCorrelationPleads(bool visibleWeakLines) //отрисовка плеяд
        {
            Graphics g = pictureBox1.CreateGraphics();
            //g.Clear(Color.Black);
            g.Clear(Color.FromArgb(64, 64, 64));

            Pen pen = new Pen(Color.Black, 2);
            Font font = new Font("Courier New", 12.0F);
            SolidBrush brush = new SolidBrush(Color.White);

            for (int i = 0; i < numbersPoints.Length; i++)
                g.DrawString(Convert.ToString(i + 1), font, brush, numbersPoints[i]);

            //покраска и отрисовка линий
            if (doubleCorelationState == true)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    for (int j = 0; j < points.Length; j++)
                    {
                        if (visibleWeakLines == true)
                        {
                            pen.Color = Data.GetColor(doubleCorrelArray[i, j]);
                            g.DrawLine(pen, points[i], points[j]);
                        }
                        else
                        {
                            if (Math.Abs(doubleCorrelArray[i, j]) > 0.5)
                            {
                                pen.Color = Data.GetColor(doubleCorrelArray[i, j]);
                                g.DrawLine(pen, points[i], points[j]);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < points.Length; i++)
                {
                    for (int j = 0; j < points.Length; j++)
                    {
                        if (visibleWeakLines == true)
                        {
                            pen.Color = Data.GetColor(privateCorrelArray[i, j]);
                            g.DrawLine(pen, points[i], points[j]);
                        }
                        else
                        {
                            if (Math.Abs(privateCorrelArray[i, j]) > 0.5)
                            {
                                pen.Color = Data.GetColor(privateCorrelArray[i, j]);
                                g.DrawLine(pen, points[i], points[j]);
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) //начальная отрисовка плеяды при загрузке формы
        {
            Pen pen = new Pen(Color.Black, 2);

            Font font = new Font("Courier New", 12.0F);
            SolidBrush brush = new SolidBrush(Color.White);

            for (int i = 0; i < numbersPoints.Length; i++)
            {
                e.Graphics.DrawString(Convert.ToString(i + 1), font, brush, numbersPoints[i]);
            }

            //покраска и отрисовка линий
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    pen.Color = Data.GetColor(doubleCorrelArray[i, j]);
                    e.Graphics.DrawLine(pen, points[i], points[j]);
                }
            }
        }

        private void DoubleCorrelButton_Click(object sender, EventArgs e)
        {
            label1.Text = "Матрица парных коэффициентов корреляции";
            doubleCorelationState = true;
            PictureDoubleCorrelationTable();
            PictureStudentDoubleCorrelTable();
            PictureCorrelationPleads(true);
            TriangleViewTableСheckBox.Checked = false;
            HidingWeakLinesCheckBox.Checked = false;
        }

        private void PrivateCorrelButton_Click(object sender, EventArgs e)
        {
            label1.Text = "Матрица частных коэффициентов корреляции";
            doubleCorelationState = false;
            PicturePrivateCorrelationTable();
            PictureStudentPrivateCorrelTable();
            PictureCorrelationPleads(true);
            TriangleViewTableСheckBox.Checked = false;
            HidingWeakLinesCheckBox.Checked = false;
        }

        private void TriangleViewTableСheckBox_CheckedChanged(object sender, EventArgs e) // приведение таблицы к триугольному виду
        {
            if (TriangleViewTableСheckBox.Checked == true)
            {
                SaveNumbers.Clear();
                int zeroCount = 2;

                for (int i = 1; i < dataGridView1.ColumnCount; i++)
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        if (zeroCount <= j)
                        {
                            SaveNumbers.Add(Convert.ToDouble(dataGridView1[j, i - 1].Value));
                            dataGridView1[j, i - 1].Style.BackColor = Color.White;
                            dataGridView1[j, i - 1].Value = "";
                        }
                    }
                    zeroCount++;
                }
            }
            else
            {
                int zeroCount = 2;
                int column = 0;

                for (int i = 1; i < dataGridView1.ColumnCount; i++)
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        if (zeroCount <= j)
                        {
                            dataGridView1[j, i - 1].Value = SaveNumbers[column];
                            dataGridView1[j, i - 1].Style.BackColor = Data.GetColor(SaveNumbers[column]);
                            column++;
                        }
                    }
                    zeroCount++;
                }
            }
        }

        private void HidingWeakLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (HidingWeakLinesCheckBox.Checked == true)
            {
                PictureCorrelationPleads(false);
            }
            else
            {
                PictureCorrelationPleads(true);
            }
        }

        private void MultipleCorrelationButton_Click(object sender, EventArgs e)
        {
            MultipleCorrelation multipleCorrelation = new MultipleCorrelation(doubleCorrelArray);
            multipleCorrelation.Show();
        }
    }
}