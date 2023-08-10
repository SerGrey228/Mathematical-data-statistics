namespace Kursovia_Mat_Stat
{
    partial class Correlation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DoubleCorrelButton = new System.Windows.Forms.Button();
            this.PrivateCorrelButton = new System.Windows.Forms.Button();
            this.TriangleViewTableСheckBox = new System.Windows.Forms.CheckBox();
            this.HidingWeakLinesCheckBox = new System.Windows.Forms.CheckBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MultipleCorrelationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(937, 253);
            this.dataGridView1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(944, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 311);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Матрица парных коэффициентов корреляции";
            // 
            // DoubleCorrelButton
            // 
            this.DoubleCorrelButton.Location = new System.Drawing.Point(947, 34);
            this.DoubleCorrelButton.Name = "DoubleCorrelButton";
            this.DoubleCorrelButton.Size = new System.Drawing.Size(149, 44);
            this.DoubleCorrelButton.TabIndex = 5;
            this.DoubleCorrelButton.Text = "Парная корреляция";
            this.DoubleCorrelButton.UseVisualStyleBackColor = true;
            this.DoubleCorrelButton.Click += new System.EventHandler(this.DoubleCorrelButton_Click);
            // 
            // PrivateCorrelButton
            // 
            this.PrivateCorrelButton.Location = new System.Drawing.Point(1106, 34);
            this.PrivateCorrelButton.Name = "PrivateCorrelButton";
            this.PrivateCorrelButton.Size = new System.Drawing.Size(149, 44);
            this.PrivateCorrelButton.TabIndex = 6;
            this.PrivateCorrelButton.Text = "Частная корреляция";
            this.PrivateCorrelButton.UseVisualStyleBackColor = true;
            this.PrivateCorrelButton.Click += new System.EventHandler(this.PrivateCorrelButton_Click);
            // 
            // TriangleViewTableСheckBox
            // 
            this.TriangleViewTableСheckBox.AutoSize = true;
            this.TriangleViewTableСheckBox.Location = new System.Drawing.Point(944, 84);
            this.TriangleViewTableСheckBox.Name = "TriangleViewTableСheckBox";
            this.TriangleViewTableСheckBox.Size = new System.Drawing.Size(156, 30);
            this.TriangleViewTableСheckBox.TabIndex = 7;
            this.TriangleViewTableСheckBox.Text = "треугольный вид\r\nкорреляционной таблицы\r\n";
            this.TriangleViewTableСheckBox.UseVisualStyleBackColor = true;
            this.TriangleViewTableСheckBox.CheckedChanged += new System.EventHandler(this.TriangleViewTableСheckBox_CheckedChanged);
            // 
            // HidingWeakLinesCheckBox
            // 
            this.HidingWeakLinesCheckBox.AutoSize = true;
            this.HidingWeakLinesCheckBox.Location = new System.Drawing.Point(944, 120);
            this.HidingWeakLinesCheckBox.Name = "HidingWeakLinesCheckBox";
            this.HidingWeakLinesCheckBox.Size = new System.Drawing.Size(151, 30);
            this.HidingWeakLinesCheckBox.TabIndex = 8;
            this.HidingWeakLinesCheckBox.Text = "скрыть слабую связь на\r\nдиаграмме\r\n";
            this.HidingWeakLinesCheckBox.UseVisualStyleBackColor = true;
            this.HidingWeakLinesCheckBox.CheckedChanged += new System.EventHandler(this.HidingWeakLinesCheckBox_CheckedChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1, 321);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(937, 249);
            this.dataGridView2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(973, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Диаграмма корреляционных плеяд";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Критерий Стьюдента";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(944, 488);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 80);
            this.label4.TabIndex = 12;
            this.label4.Text = "Данные:\r\n- кол-во элементов в выборке = 21\r\n- уровень значимости = 0,05\r\n- число " +
    "степеней свободы = 13\r\n- кр. знач. критерия Стьюдента = 2,1604\r\n";
            // 
            // MultipleCorrelationButton
            // 
            this.MultipleCorrelationButton.Location = new System.Drawing.Point(1106, 84);
            this.MultipleCorrelationButton.Name = "MultipleCorrelationButton";
            this.MultipleCorrelationButton.Size = new System.Drawing.Size(149, 44);
            this.MultipleCorrelationButton.TabIndex = 13;
            this.MultipleCorrelationButton.Text = "Множественная корреляция";
            this.MultipleCorrelationButton.UseVisualStyleBackColor = true;
            this.MultipleCorrelationButton.Click += new System.EventHandler(this.MultipleCorrelationButton_Click);
            // 
            // Correlation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1267, 571);
            this.Controls.Add(this.MultipleCorrelationButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.HidingWeakLinesCheckBox);
            this.Controls.Add(this.TriangleViewTableСheckBox);
            this.Controls.Add(this.PrivateCorrelButton);
            this.Controls.Add(this.DoubleCorrelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Correlation";
            this.Text = "Correlation";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DoubleCorrelButton;
        private System.Windows.Forms.Button PrivateCorrelButton;
        private System.Windows.Forms.CheckBox TriangleViewTableСheckBox;
        private System.Windows.Forms.CheckBox HidingWeakLinesCheckBox;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button MultipleCorrelationButton;
    }
}