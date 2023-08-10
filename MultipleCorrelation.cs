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
    public partial class MultipleCorrelation : Form
    {
        public MultipleCorrelation(double[,] doubleCorrelation)
        {
            InitializeComponent();

            //dataGridView1.ColumnCount = Data.DGV.ColumnCount;
            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = Data.DGV.ColumnCount;
            dataGridView1.AllowUserToAddRows = false;

            CreateTable();
            CreateMultipleCorreltion(doubleCorrelation);
        }

        private void CreateTable()
        {
            dataGridView1.Columns[1].HeaderText = "R";
            dataGridView1.Columns[2].HeaderText = "R^2";
            dataGridView1.Columns[3].HeaderText = "F-критерий";

            for (int i = 1; i < dataGridView1.RowCount + 1; i++)
            {
                dataGridView1[0, i - 1].Value = Data.DGV.Columns[i].HeaderText;
            }
        }

        private void CreateMultipleCorreltion(double[,] doubleCorrelation)
        {
            double determinant = Data.Determinant(doubleCorrelation); //определитель матрицы
            double minor = 0.0;
            double determination = 0; // коэфф детерминации

            for (int i = 0; i < doubleCorrelation.GetLength(0); i++)
            {
                minor = Data.Determinant(Data.Minor(doubleCorrelation, i, i)); // алгебраическое дополнение
                determination = 1.0 - (determinant / minor);
                dataGridView1[1, i].Value = Math.Sqrt(determination);
                dataGridView1[2, i].Value = determination;
                dataGridView1[3, i].Value = determination * (21 - 8 - 1) / (8 * (1 - determination)); //Фишер
            }
        }
    }
}
