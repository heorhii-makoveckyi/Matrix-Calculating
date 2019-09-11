namespace MatrixMult
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
            this.Start = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.MFirstCols = new System.Windows.Forms.TextBox();
            this.MFirstStrs = new System.Windows.Forms.TextBox();
            this.MSecCols = new System.Windows.Forms.TextBox();
            this.MSecStrs = new System.Windows.Forms.TextBox();
            this.Debug = new System.Windows.Forms.TextBox();
            this.FMatrix = new System.Windows.Forms.DataGridView();
            this.Next = new System.Windows.Forms.Button();
            this.Do_Clear = new System.Windows.Forms.Button();
            this.SMatrix = new System.Windows.Forms.DataGridView();
            this.RMatrix = new System.Windows.Forms.DataGridView();
            this.Operation = new System.Windows.Forms.ComboBox();
            this.OperText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(465, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(180, 162);
            this.Start.TabIndex = 0;
            this.Start.Text = "Старт";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Столбцов в первой матрице";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(152, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Строк в первой матрице";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 84);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(152, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Столбцов во второй матрице";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 110);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(152, 20);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "Строк во второй матрице";
            // 
            // MFirstCols
            // 
            this.MFirstCols.Location = new System.Drawing.Point(181, 12);
            this.MFirstCols.Name = "MFirstCols";
            this.MFirstCols.Size = new System.Drawing.Size(83, 20);
            this.MFirstCols.TabIndex = 5;
            this.MFirstCols.TextChanged += new System.EventHandler(this.TextBox5_TextChanged);
            // 
            // MFirstStrs
            // 
            this.MFirstStrs.Location = new System.Drawing.Point(181, 38);
            this.MFirstStrs.Name = "MFirstStrs";
            this.MFirstStrs.Size = new System.Drawing.Size(83, 20);
            this.MFirstStrs.TabIndex = 6;
            this.MFirstStrs.TextChanged += new System.EventHandler(this.TextBox6_TextChanged);
            // 
            // MSecCols
            // 
            this.MSecCols.Location = new System.Drawing.Point(181, 84);
            this.MSecCols.Name = "MSecCols";
            this.MSecCols.Size = new System.Drawing.Size(83, 20);
            this.MSecCols.TabIndex = 7;
            this.MSecCols.TextChanged += new System.EventHandler(this.TextBox7_TextChanged);
            // 
            // MSecStrs
            // 
            this.MSecStrs.Location = new System.Drawing.Point(181, 110);
            this.MSecStrs.Name = "MSecStrs";
            this.MSecStrs.Size = new System.Drawing.Size(83, 20);
            this.MSecStrs.TabIndex = 8;
            this.MSecStrs.TextChanged += new System.EventHandler(this.TextBox8_TextChanged);
            // 
            // Debug
            // 
            this.Debug.Location = new System.Drawing.Point(279, 297);
            this.Debug.Multiline = true;
            this.Debug.Name = "Debug";
            this.Debug.ReadOnly = true;
            this.Debug.Size = new System.Drawing.Size(366, 135);
            this.Debug.TabIndex = 9;
            this.Debug.TextChanged += new System.EventHandler(this.TextBox9_TextChanged);
            // 
            // FMatrix
            // 
            this.FMatrix.AllowUserToAddRows = false;
            this.FMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FMatrix.Location = new System.Drawing.Point(651, 12);
            this.FMatrix.Name = "FMatrix";
            this.FMatrix.Size = new System.Drawing.Size(606, 207);
            this.FMatrix.TabIndex = 10;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(279, 193);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(366, 98);
            this.Next.TabIndex = 11;
            this.Next.Text = "Посчитать";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Do_Clear
            // 
            this.Do_Clear.Location = new System.Drawing.Point(279, 12);
            this.Do_Clear.Name = "Do_Clear";
            this.Do_Clear.Size = new System.Drawing.Size(180, 162);
            this.Do_Clear.TabIndex = 12;
            this.Do_Clear.Text = "Очистить";
            this.Do_Clear.UseVisualStyleBackColor = true;
            this.Do_Clear.Click += new System.EventHandler(this.Do_Clear_Click);
            // 
            // SMatrix
            // 
            this.SMatrix.AllowUserToAddRows = false;
            this.SMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SMatrix.Location = new System.Drawing.Point(651, 225);
            this.SMatrix.Name = "SMatrix";
            this.SMatrix.Size = new System.Drawing.Size(606, 207);
            this.SMatrix.TabIndex = 13;
            // 
            // RMatrix
            // 
            this.RMatrix.AllowUserToAddRows = false;
            this.RMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RMatrix.Location = new System.Drawing.Point(651, 438);
            this.RMatrix.Name = "RMatrix";
            this.RMatrix.Size = new System.Drawing.Size(606, 207);
            this.RMatrix.TabIndex = 14;
            // 
            // Operation
            // 
            this.Operation.FormattingEnabled = true;
            this.Operation.Items.AddRange(new object[] {
            "Умножение",
            "Сложение",
            "Вычитание"});
            this.Operation.Location = new System.Drawing.Point(181, 154);
            this.Operation.Name = "Operation";
            this.Operation.Size = new System.Drawing.Size(83, 21);
            this.Operation.TabIndex = 15;
            // 
            // OperText
            // 
            this.OperText.Location = new System.Drawing.Point(12, 154);
            this.OperText.Name = "OperText";
            this.OperText.ReadOnly = true;
            this.OperText.Size = new System.Drawing.Size(152, 20);
            this.OperText.TabIndex = 16;
            this.OperText.Text = "Выберите операцию";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1269, 786);
            this.Controls.Add(this.OperText);
            this.Controls.Add(this.Operation);
            this.Controls.Add(this.RMatrix);
            this.Controls.Add(this.SMatrix);
            this.Controls.Add(this.Do_Clear);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.FMatrix);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.MSecStrs);
            this.Controls.Add(this.MSecCols);
            this.Controls.Add(this.MFirstStrs);
            this.Controls.Add(this.MFirstCols);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox MFirstCols;
        private System.Windows.Forms.TextBox MFirstStrs;
        private System.Windows.Forms.TextBox MSecCols;
        private System.Windows.Forms.TextBox MSecStrs;
        private System.Windows.Forms.TextBox Debug;
        private System.Windows.Forms.DataGridView FMatrix;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Do_Clear;
        private System.Windows.Forms.DataGridView SMatrix;
        private System.Windows.Forms.DataGridView RMatrix;
        private System.Windows.Forms.ComboBox Operation;
        private System.Windows.Forms.TextBox OperText;
    }
}

