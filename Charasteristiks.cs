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
    public partial class Charasteristiks : Form
    {
        private string[] NameNumCharacteristics = { "мода", "медиана", "дисперсия", "сред. арифметическая",
            "сред. арифм. отклонение", "Эксцесс", "коэфф. ассиметрии", "средняя ошибка", "предельная ошибка",
        "доверительный интервал", "необходимая выборка"};
        public Charasteristiks()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = Data.DGV.ColumnCount;
            dataGridView1.RowCount = NameNumCharacteristics.Length;
            CreateTable();
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

        private void CreateTable()
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = Data.DGV.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1[0, i].Value = NameNumCharacteristics[i];
            }

            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1[i, 0].Value = Data.Mode(getDataList(i));
                dataGridView1[i, 1].Value = Data.Median(getDataList(i));
                dataGridView1[i, 2].Value = Data.Dispersion(getDataList(i));
                dataGridView1[i, 3].Value = Data.Average(getDataList(i));
                dataGridView1[i, 4].Value = Data.AvarageDeviation(getDataList(i));
                dataGridView1[i, 5].Value = Data.Excess(getDataList(i));
                dataGridView1[i, 6].Value = Data.assymetry(getDataList(i));
                dataGridView1[i, 7].Value = Data.MeanError(getDataList(i));
                dataGridView1[i, 8].Value = Data.MarginalError(getDataList(i));
                dataGridView1[i, 9].Value = Data.ConfidenceInterval(getDataList(i));
                dataGridView1[i, 10].Value = Data.RequiredSample(getDataList(i));
            }
        }

    }
}
