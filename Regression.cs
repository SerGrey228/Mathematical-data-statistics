using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovia_Mat_Stat
{
    public partial class Regression : Form
    {
        private double tableStudent = 2.51; //табличное значение критерия Стьюдента
        private double tableFisher = 2.76; //табличное значение критерия Фишера (k1 = 7 и k2 = n - m - 1 = 22 - 7 - 1 = 14)
        //private double determinant = 0.9851; //детерминант R^2
        private double determinant = 0.8421; //детерминант R^2

        private double[] result2; //содержит уравнение регрессии
        private double[] yCount; // массив содержащий Y столбец
        private double[,] cloneMatrix;
        public Regression(double[,] matrix)
        {
            InitializeComponent();
            result2 = new double[matrix.GetLength(0)];
            yCount = new double[matrix.GetLength(1)];
            cloneMatrix = matrix;

            dataGridView1.ColumnCount = matrix.GetLength(0) + 1;
            dataGridView1.RowCount = 4;

            dataGridView2.ColumnCount = 2;
            dataGridView2.RowCount = 3;

            CreateTable();
            RegressionCalculation(matrix);
        }

        private void CreateTable()
        {
            //первая таблица
            dataGridView1.Columns[0].HeaderText = "Коэффициент";
            dataGridView1.Columns[1].HeaderText = "Y";
            for (int i = 2; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = $"X{i - 1}";
            }
            dataGridView1[0, 0].Value = "Значение коэффициента";
            dataGridView1[0, 1].Value = "Расчетный t-критерий";
            dataGridView1[0, 2].Value = "Табличный t-критерий";
            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1[i, 2].Value = tableStudent;
            }
            dataGridView1[0, 3].Value = "Значимость";

            // вторая таблица
            dataGridView2.Columns[0].HeaderText = "R-квадрат";
            dataGridView2.Columns[1].HeaderText = Convert.ToString(determinant);
            dataGridView2[0, 0].Value = "F-критерий";
            dataGridView2[0, 1].Value = "F-табличное";
            dataGridView2[0, 2].Value = "Кол-во наблюдейний";
        }

        private void RegressionCalculation(double[,] matrix)
        {   // формула уравнения регрессии - Y(X) = (X^T * X)^1 * (X^T * Y)
            double[,] matrixWithOneColumn = matrix.Clone() as double[,]; // матрица с единичным столбцом Y
            double[,] transponMatrix = new double[matrix.GetLength(1), matrix.GetLength(0)];
            double[,] result = new double[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                yCount[i] = matrixWithOneColumn[0, i];
                matrixWithOneColumn[0, i] = 1;
            }

            transponMatrix = Data.TranspositionMatrix(matrixWithOneColumn); // X^T
            result = Data.MultiplicationMatrix(matrixWithOneColumn, transponMatrix); // X^T * X
            result2 = Data.MultiplicationMatrixOnColumn(transponMatrix, yCount); // X^T * Y
            result = Data.InverseMatrix(result, result.GetLength(0)); // (X^T * X)^1
            result2 = Data.MultiplicationMatrixOnColumn(result, result2); // (X^T * X)^1 * (X^T * Y)

            CreateRegressionEquation(result2);

            List<double> significantOptions = new List<double>();
            for (int i = 0; i < dataGridView1.ColumnCount - 1; i++) // запись критериев в таблицу
            {
                dataGridView1[i + 1, 0].Value = result2[i];
            }

            // t-критерий Стьюдента
            double[] calculatedTStudent = new double[result2.Length]; 
            for (int i = 0; i < result2.Length; i++)
            {
                calculatedTStudent[i] = result2[i] / Data.AvarageDeviation(getDataList(matrix, i));
                dataGridView1[i + 1, 1].Value = calculatedTStudent[i];

                if (calculatedTStudent[i] > tableStudent)
                {
                    dataGridView1[i + 1, 3].Style.BackColor = Color.Green;
                    dataGridView1[i + 1, 3].Value = "+++";
                }
                else
                {
                    dataGridView1[i + 1, 3].Style.BackColor = Color.Red;
                    dataGridView1[i + 1, 3].Value = "---";
                }
            }
            dataGridView1[1, 3].Style.BackColor = Color.Green;
            dataGridView1[1, 3].Value = "+++";


            // критерий Фишера
            double fisher = (determinant * (22 - 7 - 1)) / ((1 - determinant) * 7);
            dataGridView2[1, 0].Value = Math.Round(fisher, 4, MidpointRounding.AwayFromZero); // запись рассчитанного Фишера
            dataGridView2[1, 1].Value = tableFisher; //табличный Фишер
            dataGridView2[1, 2].Value = matrix.GetLength(1); //кол-во наблюдений
        }

        private void CreateRegressionEquation(double[] equation)
        {
            // откругление до 4 знака после запятой
            for (int i = 0; i < equation.Length; i++)
            {
                equation[i] = Math.Round(equation[i], 4, MidpointRounding.AwayFromZero);
            }

            // запись регрессионного уравнения
            label1.Text = $"Уравнение регрессии: Y = {equation[0]}";
            for (int i = 1; i < equation.Length; i++)
            {
                if (equation[i] >= 0)
                {
                    label1.Text += $" + {Math.Abs(equation[i])}*X{i}";
                }
                else
                {
                    label1.Text += $" - {Math.Abs(equation[i])}*X{i}";
                }
            }
            label1.Text += $"\n Уравнение (только значимые коэффициенты): Y = {equation[0]} + {equation[5]}*X5";
        }

        private double[] getDataList(double[,]matrix, int numberColumn) //формирует одномерную матрицу из данных определенного столбца
        {
            double[] resultList = new double[matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                resultList[i] = matrix[numberColumn, i];
            }
            return resultList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegressionEstimate estimate = new RegressionEstimate(yCount, result2, cloneMatrix);
            estimate.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(result2);
            form2.Show();
        }
    }
}
