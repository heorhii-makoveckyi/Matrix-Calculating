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
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.Coefficient = new System.Windows.Forms.TextBox();
            this.SetF = new System.Windows.Forms.Button();
            this.CopyF = new System.Windows.Forms.Button();
            this.CopyS = new System.Windows.Forms.Button();
            this.SetS = new System.Windows.Forms.Button();
            this.CopyT = new System.Windows.Forms.Button();
            this.SetT = new System.Windows.Forms.Button();
            this.runCode = new System.Windows.Forms.Button();
            this.PathIN = new System.Windows.Forms.TextBox();
            this.PathOUT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(497, 2);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(229, 77);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Cols in first matrix";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(27, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(152, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Rows in first matrix";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(27, 79);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(152, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Cols in second matrix";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(27, 105);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(152, 20);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "Rows in second matrix";
            // 
            // MFirstCols
            // 
            this.MFirstCols.Location = new System.Drawing.Point(186, 2);
            this.MFirstCols.Name = "MFirstCols";
            this.MFirstCols.Size = new System.Drawing.Size(82, 20);
            this.MFirstCols.TabIndex = 5;
            this.MFirstCols.TextChanged += new System.EventHandler(this.TextBox5_TextChanged);
            // 
            // MFirstStrs
            // 
            this.MFirstStrs.Location = new System.Drawing.Point(186, 28);
            this.MFirstStrs.Name = "MFirstStrs";
            this.MFirstStrs.Size = new System.Drawing.Size(82, 20);
            this.MFirstStrs.TabIndex = 6;
            this.MFirstStrs.TextChanged += new System.EventHandler(this.TextBox6_TextChanged);
            // 
            // MSecCols
            // 
            this.MSecCols.Location = new System.Drawing.Point(185, 79);
            this.MSecCols.Name = "MSecCols";
            this.MSecCols.Size = new System.Drawing.Size(83, 20);
            this.MSecCols.TabIndex = 7;
            this.MSecCols.TextChanged += new System.EventHandler(this.TextBox7_TextChanged);
            // 
            // MSecStrs
            // 
            this.MSecStrs.Location = new System.Drawing.Point(185, 105);
            this.MSecStrs.Name = "MSecStrs";
            this.MSecStrs.Size = new System.Drawing.Size(83, 20);
            this.MSecStrs.TabIndex = 8;
            this.MSecStrs.TextChanged += new System.EventHandler(this.TextBox8_TextChanged);
            // 
            // Debug
            // 
            this.Debug.Location = new System.Drawing.Point(29, 567);
            this.Debug.Multiline = true;
            this.Debug.Name = "Debug";
            this.Debug.ReadOnly = true;
            this.Debug.Size = new System.Drawing.Size(605, 207);
            this.Debug.TabIndex = 9;
            this.Debug.TextChanged += new System.EventHandler(this.TextBox9_TextChanged);
            // 
            // FMatrix
            // 
            this.FMatrix.AllowUserToAddRows = false;
            this.FMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FMatrix.Location = new System.Drawing.Point(28, 297);
            this.FMatrix.Name = "FMatrix";
            this.FMatrix.Size = new System.Drawing.Size(606, 207);
            this.FMatrix.TabIndex = 10;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(732, 2);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(229, 77);
            this.Next.TabIndex = 11;
            this.Next.Text = "Calculate";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Do_Clear
            // 
            this.Do_Clear.Location = new System.Drawing.Point(275, 2);
            this.Do_Clear.Name = "Do_Clear";
            this.Do_Clear.Size = new System.Drawing.Size(220, 77);
            this.Do_Clear.TabIndex = 12;
            this.Do_Clear.Text = "Clear";
            this.Do_Clear.UseVisualStyleBackColor = true;
            this.Do_Clear.Click += new System.EventHandler(this.Do_Clear_Click);
            // 
            // SMatrix
            // 
            this.SMatrix.AllowUserToAddRows = false;
            this.SMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SMatrix.Location = new System.Drawing.Point(635, 297);
            this.SMatrix.Name = "SMatrix";
            this.SMatrix.Size = new System.Drawing.Size(606, 207);
            this.SMatrix.TabIndex = 13;
            // 
            // RMatrix
            // 
            this.RMatrix.AllowUserToAddRows = false;
            this.RMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RMatrix.Location = new System.Drawing.Point(639, 567);
            this.RMatrix.Name = "RMatrix";
            this.RMatrix.Size = new System.Drawing.Size(606, 207);
            this.RMatrix.TabIndex = 14;
            // 
            // Operation
            // 
            this.Operation.FormattingEnabled = true;
            this.Operation.Items.AddRange(new object[] {
            "*",
            "+",
            "-"});
            this.Operation.Location = new System.Drawing.Point(186, 181);
            this.Operation.Name = "Operation";
            this.Operation.Size = new System.Drawing.Size(83, 21);
            this.Operation.TabIndex = 15;
            // 
            // OperText
            // 
            this.OperText.Location = new System.Drawing.Point(26, 182);
            this.OperText.Name = "OperText";
            this.OperText.ReadOnly = true;
            this.OperText.Size = new System.Drawing.Size(152, 20);
            this.OperText.TabIndex = 16;
            this.OperText.Text = "Choose operation";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(29, 271);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(605, 20);
            this.textBox5.TabIndex = 17;
            this.textBox5.Text = "First matrix";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(636, 271);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(605, 20);
            this.textBox6.TabIndex = 18;
            this.textBox6.Text = "Second matrix";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox6.TextChanged += new System.EventHandler(this.TextBox6_TextChanged_1);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(640, 541);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(606, 20);
            this.textBox7.TabIndex = 19;
            this.textBox7.Text = "Resolting matrix";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(29, 541);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(605, 20);
            this.textBox8.TabIndex = 20;
            this.textBox8.Text = "Helper";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.23F);
            this.textBox9.Location = new System.Drawing.Point(26, 156);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(152, 20);
            this.textBox9.TabIndex = 21;
            this.textBox9.Text = "Multiplie res. matrix";
            // 
            // Coefficient
            // 
            this.Coefficient.Location = new System.Drawing.Point(186, 156);
            this.Coefficient.Name = "Coefficient";
            this.Coefficient.Size = new System.Drawing.Size(83, 20);
            this.Coefficient.TabIndex = 22;
            // 
            // SetF
            // 
            this.SetF.Location = new System.Drawing.Point(156, 239);
            this.SetF.Name = "SetF";
            this.SetF.Size = new System.Drawing.Size(121, 23);
            this.SetF.TabIndex = 23;
            this.SetF.Text = "Paste";
            this.SetF.UseVisualStyleBackColor = true;
            this.SetF.Click += new System.EventHandler(this.SetF_Click);
            // 
            // CopyF
            // 
            this.CopyF.Location = new System.Drawing.Point(29, 239);
            this.CopyF.Name = "CopyF";
            this.CopyF.Size = new System.Drawing.Size(121, 23);
            this.CopyF.TabIndex = 24;
            this.CopyF.Text = "Copy";
            this.CopyF.UseVisualStyleBackColor = true;
            this.CopyF.Click += new System.EventHandler(this.CopyF_Click);
            // 
            // CopyS
            // 
            this.CopyS.Location = new System.Drawing.Point(635, 242);
            this.CopyS.Name = "CopyS";
            this.CopyS.Size = new System.Drawing.Size(121, 23);
            this.CopyS.TabIndex = 25;
            this.CopyS.Text = "Copy";
            this.CopyS.UseVisualStyleBackColor = true;
            this.CopyS.Click += new System.EventHandler(this.CopyS_Click);
            // 
            // SetS
            // 
            this.SetS.Location = new System.Drawing.Point(761, 242);
            this.SetS.Name = "SetS";
            this.SetS.Size = new System.Drawing.Size(121, 23);
            this.SetS.TabIndex = 26;
            this.SetS.Text = "Paste";
            this.SetS.UseVisualStyleBackColor = true;
            this.SetS.Click += new System.EventHandler(this.SetS_Click);
            // 
            // CopyT
            // 
            this.CopyT.Location = new System.Drawing.Point(639, 512);
            this.CopyT.Name = "CopyT";
            this.CopyT.Size = new System.Drawing.Size(117, 23);
            this.CopyT.TabIndex = 29;
            this.CopyT.Text = "Copy";
            this.CopyT.UseVisualStyleBackColor = true;
            this.CopyT.Click += new System.EventHandler(this.CopyT_Click);
            // 
            // SetT
            // 
            this.SetT.Location = new System.Drawing.Point(762, 512);
            this.SetT.Name = "SetT";
            this.SetT.Size = new System.Drawing.Size(120, 23);
            this.SetT.TabIndex = 31;
            this.SetT.Text = "Paste";
            this.SetT.UseVisualStyleBackColor = true;
            this.SetT.Click += new System.EventHandler(this.SetT_Click);
            // 
            // runCode
            // 
            this.runCode.Location = new System.Drawing.Point(275, 130);
            this.runCode.Name = "runCode";
            this.runCode.Size = new System.Drawing.Size(118, 46);
            this.runCode.TabIndex = 32;
            this.runCode.Text = "Run";
            this.runCode.UseVisualStyleBackColor = true;
            this.runCode.Click += new System.EventHandler(this.RunCode_Click);
            // 
            // PathIN
            // 
            this.PathIN.Location = new System.Drawing.Point(399, 130);
            this.PathIN.Name = "PathIN";
            this.PathIN.Size = new System.Drawing.Size(562, 20);
            this.PathIN.TabIndex = 33;
            this.PathIN.Text = "Way to input file";
            // 
            // PathOUT
            // 
            this.PathOUT.Location = new System.Drawing.Point(399, 156);
            this.PathOUT.Name = "PathOUT";
            this.PathOUT.Size = new System.Drawing.Size(562, 20);
            this.PathOUT.TabIndex = 34;
            this.PathOUT.Text = "Way to output file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1253, 782);
            this.Controls.Add(this.PathOUT);
            this.Controls.Add(this.PathIN);
            this.Controls.Add(this.runCode);
            this.Controls.Add(this.SetT);
            this.Controls.Add(this.CopyT);
            this.Controls.Add(this.SetS);
            this.Controls.Add(this.CopyS);
            this.Controls.Add(this.CopyF);
            this.Controls.Add(this.SetF);
            this.Controls.Add(this.Coefficient);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
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
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox Coefficient;
        private System.Windows.Forms.Button SetF;
        private System.Windows.Forms.Button CopyF;
        private System.Windows.Forms.Button CopyS;
        private System.Windows.Forms.Button SetS;
        private System.Windows.Forms.Button CopyT;
        private System.Windows.Forms.Button SetT;
        private System.Windows.Forms.Button runCode;
        private System.Windows.Forms.TextBox PathIN;
        private System.Windows.Forms.TextBox PathOUT;
    }
}

