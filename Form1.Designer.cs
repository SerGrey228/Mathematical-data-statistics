namespace Kursovia_Mat_Stat
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дейстияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.числовыеХарактеристикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.критерийПирсонахиквадратToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.корреляцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.NormButton = new System.Windows.Forms.Button();
            this.DefaultDataButton = new System.Windows.Forms.Button();
            this.регрессионныйАнализToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.дейстияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // дейстияToolStripMenuItem
            // 
            this.дейстияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.числовыеХарактеристикиToolStripMenuItem,
            this.критерийПирсонахиквадратToolStripMenuItem,
            this.корреляцияToolStripMenuItem,
            this.регрессионныйАнализToolStripMenuItem});
            this.дейстияToolStripMenuItem.Name = "дейстияToolStripMenuItem";
            this.дейстияToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.дейстияToolStripMenuItem.Text = "дейстия";
            // 
            // числовыеХарактеристикиToolStripMenuItem
            // 
            this.числовыеХарактеристикиToolStripMenuItem.Name = "числовыеХарактеристикиToolStripMenuItem";
            this.числовыеХарактеристикиToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.числовыеХарактеристикиToolStripMenuItem.Text = "числовые характеристики";
            this.числовыеХарактеристикиToolStripMenuItem.Click += new System.EventHandler(this.числовыеХарактеристикиToolStripMenuItem_Click);
            // 
            // критерийПирсонахиквадратToolStripMenuItem
            // 
            this.критерийПирсонахиквадратToolStripMenuItem.Name = "критерийПирсонахиквадратToolStripMenuItem";
            this.критерийПирсонахиквадратToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.критерийПирсонахиквадратToolStripMenuItem.Text = "критерий Пирсона(хи-квадрат)";
            this.критерийПирсонахиквадратToolStripMenuItem.Click += new System.EventHandler(this.критерийПирсонахиквадратToolStripMenuItem_Click);
            // 
            // корреляцияToolStripMenuItem
            // 
            this.корреляцияToolStripMenuItem.Name = "корреляцияToolStripMenuItem";
            this.корреляцияToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.корреляцияToolStripMenuItem.Text = "корреляция";
            this.корреляцияToolStripMenuItem.Click += new System.EventHandler(this.корреляцияToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(924, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel1.Text = "Лист";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(924, 474);
            this.dataGridView1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel|*.xlsx";
            // 
            // NormButton
            // 
            this.NormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NormButton.Location = new System.Drawing.Point(283, 24);
            this.NormButton.Name = "NormButton";
            this.NormButton.Size = new System.Drawing.Size(107, 25);
            this.NormButton.TabIndex = 3;
            this.NormButton.Text = "Нормировать";
            this.NormButton.UseVisualStyleBackColor = true;
            this.NormButton.Click += new System.EventHandler(this.NormButton_Click);
            // 
            // DefaultDataButton
            // 
            this.DefaultDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DefaultDataButton.Location = new System.Drawing.Point(166, 24);
            this.DefaultDataButton.Name = "DefaultDataButton";
            this.DefaultDataButton.Size = new System.Drawing.Size(111, 25);
            this.DefaultDataButton.TabIndex = 4;
            this.DefaultDataButton.Text = "Исходные данные";
            this.DefaultDataButton.UseVisualStyleBackColor = true;
            this.DefaultDataButton.Click += new System.EventHandler(this.DefaultDataButton_Click);
            // 
            // регрессионныйАнализToolStripMenuItem
            // 
            this.регрессионныйАнализToolStripMenuItem.Name = "регрессионныйАнализToolStripMenuItem";
            this.регрессионныйАнализToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.регрессионныйАнализToolStripMenuItem.Text = "регрессионный анализ";
            this.регрессионныйАнализToolStripMenuItem.Click += new System.EventHandler(this.регрессионныйАнализToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(924, 525);
            this.Controls.Add(this.DefaultDataButton);
            this.Controls.Add(this.NormButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button NormButton;
        private System.Windows.Forms.Button DefaultDataButton;
        private System.Windows.Forms.ToolStripMenuItem дейстияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem числовыеХарактеристикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem критерийПирсонахиквадратToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem корреляцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem регрессионныйАнализToolStripMenuItem;
    }
}

