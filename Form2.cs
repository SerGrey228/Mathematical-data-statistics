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
    public partial class Form2 : Form
    {
        private double[] massiv;
        public Form2(double[] massiv32) 
        {
            InitializeComponent();
            massiv = massiv32;

            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = 8;

            for (int i = 0; i < 8; i++)
            {
                dataGridView1[i, 0].Value = Data.DGV.Columns[i].HeaderText;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double res = massiv[0];
            for (int i = 0; i < 7; i++)
            {
                res += massiv[i+1] * Convert.ToDouble(dataGridView1[i, 1].Value);
                
            }
            textBox1.Text = res.ToString();
        }
    }
}
