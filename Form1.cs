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

namespace Kursovia_Mat_Stat
{
    public partial class Form1 : Form
    {
        private bool savePath = false;
        private string fileName = string.Empty;
        private DataTableCollection tableCollection = null; //хранит листы excel

        private double[,] defaultDataTable; //хранит первоначальные значения таблицы, полученные из excel
        private int defaultColumnCount = 0;
        private int defaultRowCount = 0;
        private bool NormViewData = false; //указывает, приведены данные в нормированный вид или нет

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            OpenSaveFile();
            SafeDefaultDataTable();
            //PaintCells();
        }

        //private void PaintCells()
        //{
        //    for (int i = 0; i < dataGridView1.ColumnCount; i++)
        //    {
        //        dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Gray;
        //    }
        //}

        private void OpenSaveFile()
        {
            string line;
            StreamReader reader = new StreamReader("SaveExcelPath.txt");
            line = reader.ReadLine();
            reader.Close();
            if (line != null)
            {
                OpenExcelFile(line);
            }
            else
            {
                savePath = true;
            }
        }

        private double[] getDataList(int numberColumn) //формирует одномерную матрицу из данных определенного столбца
        {
            double[] resultList = new double[defaultColumnCount];

            for (int i = 0; i < defaultColumnCount; i++)
            {
                resultList[i] = (Convert.ToDouble(defaultDataTable[numberColumn, i]));
            }
            return resultList;
        }

        //////////////////// ОТКРЫТИЕ EXCEL ФАЙЛА ////////////////////
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = openFileDialog1.ShowDialog();

                if (res == DialogResult.OK)
                {
                    fileName = openFileDialog1.FileName;
                    Text = fileName;
                    if (savePath == true)
                    {
                        StreamWriter writer = new StreamWriter("SaveExcelPath.txt");
                        writer.WriteLine(fileName);
                        writer.Close();
                    }
                    OpenExcelFile(fileName);

                    
                    SafeDefaultDataTable();
                    defaultColumnCount = dataGridView1.ColumnCount;
                    defaultRowCount = dataGridView1.RowCount;

                }
                else
                {
                    throw new Exception("Файл не выбран!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenExcelFile(string path)
        {
            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
            DataSet db = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            tableCollection = db.Tables;
            toolStripComboBox1.Items.Clear();

            foreach (DataTable table in tableCollection)
            {
                toolStripComboBox1.Items.Add(table.TableName);
            }
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = tableCollection[Convert.ToString(toolStripComboBox1.SelectedItem)];

            dataGridView1.DataSource = table;
        }

        ////////////////////////////////////////////////////////////

        private double[,] SafeDefaultDataTable()
        {
            defaultDataTable = new double[dataGridView1.ColumnCount, dataGridView1.RowCount];

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    double something = Convert.ToDouble(dataGridView1[i, j].Value);
                    defaultDataTable[i, j] = something;
                }
            }
            defaultColumnCount = defaultDataTable.GetLength(1);
            defaultRowCount = defaultDataTable.GetLength(0);

            return defaultDataTable;
        }

        private void NormButton_Click(object sender, EventArgs e) // нормализация данных
        {
            try
            {
                if (dataGridView1 != null)
                {
                    for (int i = 1; i < dataGridView1.ColumnCount; i++)
                    {
                        double max = Data.MaxElem(getDataList(i));
                        double min = Data.MinElem(getDataList(i));

                        for (int j = 0; j < dataGridView1.RowCount; j++)
                        {
                            double value = Convert.ToDouble(defaultDataTable[i, j]);
                            dataGridView1[i, j].Value = (value - min) / (max - min);
                            defaultDataTable[i, j] = value;
                        }
                    }
                    NormViewData = true;
                }
                else
                {
                    throw new Exception("Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Файл не открыт!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void DefaultDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1 != null)
                {
                    for (int i = 1; i < dataGridView1.ColumnCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.RowCount; j++)
                        {
                            double some = Convert.ToDouble(defaultDataTable[i, j]);
                            dataGridView1[i, j].Value = some;
                        }
                    }
                    NormViewData = false;
                }

                else
                {
                    throw new Exception("Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Файл не открыт!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void числовыеХарактеристикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1 != null)
                {
                    if (NormViewData == true)
                    {
                        Data.DGV = dataGridView1;
                        Charasteristiks charasteristiks = new Charasteristiks();
                        charasteristiks.Show();
                    }
                    else
                        MessageBox.Show("Для расчета числовых характеристик данные должны быть нормированы!");
                }

                else
                {
                    throw new Exception("Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Файл не открыт!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void критерийПирсонахиквадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1 != null)
                {
                    if (NormViewData == true)
                    {
                        Data.DGV = dataGridView1;
                        Pirson pirson = new Pirson();
                        pirson.Show();
                    }
                    else
                        MessageBox.Show("Для расчета критерия Пирсона данные должны быть нормированы!");
                }
                else
                {
                    throw new Exception("Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Файл не открыт!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void корреляцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1 != null)
                {
                    if (NormViewData == false)
                    {
                        Data.DGV = dataGridView1;
                        Correlation corr = new Correlation();
                        corr.Show();
                    }
                    else
                        MessageBox.Show("Для расчета корреляции данные должны быть ненормированы!");
                }
                else
                {
                    throw new Exception("Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Файл не открыт!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void регрессионныйАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1 != null)
                {
                    if (NormViewData == false)
                    {
                        double[,] matrix = new double[dataGridView1.ColumnCount - 1, dataGridView1.RowCount];

                        for (int i = 1; i < dataGridView1.ColumnCount; i++)
                        {
                            for (int j = 0; j < dataGridView1.RowCount; j++)
                            {
                                matrix[i - 1, j] = Convert.ToInt32(dataGridView1[i, j].Value);
                            }
                        }

                        Data.DGV = dataGridView1;
                        Regression regression = new Regression(matrix);
                        regression.Show();
                    }
                    else
                        MessageBox.Show("Для расчета регресии данные должны быть ненормированы!");
                }
                else
                {
                    throw new Exception("Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Файл не открыт!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
