using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//уровень значимости = 0.05
//число степеней свободы = n(кол-во эл. выборки) - 2 = 21 - 2 = 19
//теоретическое значение = 30,147

namespace Kursovia_Mat_Stat
{
    public partial class Pirson : Form
    {
        private int sampleCount = 22; //размер выборки
        int[] intervalCount = new int[5]; //количество элементов вошедших в интервал
        int[,] intervals = new int[8, 5];
        public Pirson()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = Data.DGV.ColumnCount;
            dataGridView1.RowCount = 5;
            dataGridView1[0, 0].Value = "X табличное";
            dataGridView1[0, 1].Value = "X расчетное";
            //dataGridView1[0, 2].Value = "Эмпирические частоты";
            dataGridView1[0, 2].Value = "Соответствие распределению";
            dataGridView1[0, 3].Value = "Частоты";
            dataGridView1[0, 4].Value = "Интервалы";
            //dataGridView1[0, 5].Value = "Теоритические частоты";

            CreateTable();
            Intervals();
        }

        private void CreateTable()
        {
            //инициализация dataGridView1
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = Data.DGV.Columns[i].HeaderText;
            }

            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1[i, 0].Value = "30,147"; // запись в таблицу X критических
                //dataGridView1[i, 2].Value = Data.Average(getDataList(i)); // запись в таблицу эмпиричесикх частот
                //dataGridView1[i, 5].Value = TeorFrequencies(i);
                dataGridView1[i, 1].Value = ObservedValues(TeorFrequencies(i), i);
            }

            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                if (Convert.ToDouble(dataGridView1[i, 0].Value) > Convert.ToDouble(dataGridView1[i, 1].Value))
                {
                    dataGridView1[i, 2].Value = "ДА";
                    dataGridView1[i, 2].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    dataGridView1[i, 2].Value = "НЕТ";
                    dataGridView1[i, 2].Style.BackColor = Color.OrangeRed;
                }
            }

            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                comboBox1.Items.Add(dataGridView1.Columns[i].HeaderText);
            }
        }

        private double SampleСorrectedVariance (int numberSample) //выборочная исправленная дисперсия
        {
            double sampleMean = 0; //выборочное среднее
            double avarageSample = sampleCount; //объем выборки (эмпирические частоты)
            double sampleСorrectedVariance = 0;

            //avarageSample = Data.Average(getDataList(numberSample));

            for (int j = 0; j < Data.DGV.RowCount; j++)
            {
                sampleMean += getDataList(numberSample)[j] * avarageSample;
            }
            sampleMean /= sampleCount;

            for (int j = 0; j < Data.DGV.RowCount; j++)
            {
                sampleСorrectedVariance += avarageSample * Math.Pow(getDataList(numberSample)[j] - sampleMean, 2);
            }
            sampleСorrectedVariance /= sampleCount - 1;

            return Math.Sqrt(Math.Abs(sampleСorrectedVariance));
        }

        private double TeorFrequencies(int numberSample) //теоретические частоты
        {
            double teorFrequencies = 0;
            double avarageSample = sampleCount;
            double sampleMean = 0; //выборочное среднее

            //avarageSample = Data.Average(getDataList(numberSample)); //среднее арифметические выборки (эмпирические частоты)

            double step = (Data.MaxElem(getDataList(numberSample)) - Data.MinElem(getDataList(numberSample))) / 5;
            for (int j = 0; j < Data.DGV.RowCount; j++) //выборочное среднее
            {
                sampleMean += getDataList(numberSample)[j] * avarageSample;
            }
            sampleMean /= sampleCount;

            for (int i = 0; i < Data.DGV.RowCount; i++)
            {
                teorFrequencies = getDataList(numberSample)[i] - sampleMean / SampleСorrectedVariance(numberSample);
            }

            teorFrequencies = 1 / (Math.Sqrt(2 * Math.PI)) * Math.Exp(-Math.Pow(teorFrequencies, 2) / 2);

            teorFrequencies = teorFrequencies * sampleCount * step / SampleСorrectedVariance(numberSample);

            return teorFrequencies;
        }

        private void Intervals()
        {
            double[] sample = new double[sampleCount];

            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                ZeroingArray(intervalCount);
                for (int j = 0; j < sampleCount; j++)
                {
                    sample[j] = getDataList(i)[j];
                }
                
                double stepConstant = 0;
                double step = 0;
                int count = 0;

                stepConstant = (sample.Max() - sample.Min()) / 5;
                step = stepConstant;
                Array.Sort(sample);

                for (int j = 0; j < sample.Length; j++)
                {
                    if (sample[j] <= step)
                    {
                        intervalCount[count]++;
                    }
                    else
                    {
                        intervals[i - 1, count] = intervalCount[count];
                        count++;
                        intervalCount[count]++;
                        step = step + stepConstant;
                    }
                }

                intervals[i - 1, count] = intervalCount[count];

                dataGridView1[i, 4].Value = $"{stepConstant}; {stepConstant * 2}; {stepConstant * 3};" +
                    $" {stepConstant * 4}; {stepConstant * 5}";

                dataGridView1[i, 3].Value = $"{intervalCount[0]}, {intervalCount[1]}, {intervalCount[2]}," +
                    $" {intervalCount[3]}, {intervalCount[4]}";
            }
        }

        private void ZeroingArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
        }

        private double ObservedValues(double teorFrequencies, int numberSample)
        {
            double avarageSample = Data.Average(getDataList(numberSample)); //среднее арифметические выборки (эмпирические частоты)

            return Math.Pow(avarageSample - teorFrequencies, 2) / teorFrequencies;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            for (int i = 0; i < intervalCount.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i + 1, intervals[comboBox1.SelectedIndex, i]);
                chart1.Series[1].Points.AddXY(i + 1, intervals[comboBox1.SelectedIndex, i]);
            }
        }
    }
}

