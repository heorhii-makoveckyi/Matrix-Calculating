using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixMult {
    public partial class Form1 : Form {

        public enum States {
            before,
            input,
            solved
        }

        States state;

        int fMatStr;
        int fMatCol;
        int sMatStr;
        int sMatCol;
        int tMatStr;
        int tMatCol;
        TextBox[] textBoxes;
        double[,] MatrixOne;
        double[,] MatrixTwo;
        double[,] MatrixResult;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            textBoxes = new TextBox[4];
            textBoxes[0] = MFirstCols;
            textBoxes[1] = MFirstStrs;
            textBoxes[2] = MSecCols;
            textBoxes[3] = MSecStrs;
            state = States.before;
        }
        private void Button1_Click(object sender, EventArgs e) {

            if (state == States.before) {

                if (Operation.SelectedIndex == 0) {

                    string eror = "";
                    bool willContinue = findingErrors(out eror);

                    if (MFirstCols.Text != "" && MSecStrs.Text != "" && int.Parse(MFirstCols.Text) != int.Parse(MSecStrs.Text)) {
                        eror = "Количество столбцов первой матрицы != количеству строк второй матрицы";
                        willContinue = false;
                    }
                    if (willContinue == false) {
                        Debug.Text = eror;
                    }
                    else {

                        fMatCol = int.Parse(MFirstCols.Text);
                        fMatStr = int.Parse(MFirstStrs.Text);
                        sMatCol = int.Parse(MSecCols.Text);
                        sMatStr = int.Parse(MSecStrs.Text);

                        tMatStr = fMatStr;
                        tMatCol = sMatCol;

                        MatrixOne = new double[fMatStr, fMatCol];
                        MatrixTwo = new double[sMatStr, sMatCol];

                        MatrixResult = new double[tMatStr, tMatCol];

                        changeScene(false);

                        DataTable table = new DataTable();
                        for (int i = 0; i < fMatCol; ++i)
                            table.Columns.Add("Col_" + (i + 1));
                        for (int i = 0; i < fMatStr; ++i) {
                            DataRow r = table.NewRow();
                            table.Rows.Add(r);
                        }
                        FMatrix.DataSource = table;

                        DataTable table2 = new DataTable();
                        for (int i = 0; i < sMatCol; ++i)
                            table2.Columns.Add("Col_" + (i + 1));
                        for (int i = 0; i < sMatStr; ++i) {
                            DataRow r = table2.NewRow();
                            table2.Rows.Add(r);
                        }
                        SMatrix.DataSource = table2;

                        DataTable table3 = new DataTable();
                        for (int i = 0; i < tMatCol; ++i)
                            table3.Columns.Add("Col_" + (i + 1));
                        for (int i = 0; i < tMatStr; ++i) {
                            DataRow r = table3.NewRow();
                            table3.Rows.Add(r);
                        }
                        RMatrix.DataSource = table3;

                        state = States.input;
                    }
                }
                else if (Operation.SelectedIndex == 1) { // Сложение
                    string eror = "";
                    bool willContinue = findingErrors(out eror);
                    if (willContinue == false) {
                        Debug.Text = eror;
                        return;
                    }
                    if (int.Parse(MFirstCols.Text) != int.Parse(MSecCols.Text) || int.Parse(MFirstStrs.Text) != int.Parse(MSecStrs.Text)) {
                        Debug.Text = "Количество столбцов или строк в матрицах разное";
                        return;
                    }

                    fMatCol = int.Parse(MFirstCols.Text);
                    fMatStr = int.Parse(MFirstStrs.Text);
                    sMatCol = fMatCol;
                    sMatStr = fMatStr;
                    tMatCol = fMatCol;
                    tMatStr = fMatStr;

                    MatrixOne = new double[fMatStr, fMatCol];
                    MatrixTwo = new double[fMatStr, fMatCol];
                    MatrixResult = new double[fMatStr, fMatCol];

                    changeScene(false);

                    DataTable table = new DataTable();
                    for (int i = 0; i < fMatCol; ++i)
                        table.Columns.Add("Col_" + (i + 1));
                    for (int i = 0; i < fMatStr; ++i) {
                        DataRow r = table.NewRow();
                        table.Rows.Add(r);
                    }

                    DataTable table2 = new DataTable();
                    for (int i = 0; i < fMatCol; ++i)
                        table2.Columns.Add("Col_" + (i + 1));
                    for (int i = 0; i < fMatStr; ++i) {
                        DataRow r = table2.NewRow();
                        table2.Rows.Add(r);
                    }

                    DataTable table3 = new DataTable();
                    for (int i = 0; i < fMatCol; ++i)
                        table3.Columns.Add("Col_" + (i + 1));
                    for (int i = 0; i < fMatStr; ++i) {
                        DataRow r = table3.NewRow();
                        table3.Rows.Add(r);
                    }
                    FMatrix.DataSource = table;
                    SMatrix.DataSource = table2;
                    RMatrix.DataSource = table3;

                    state = States.input;

                }
                else if (Operation.SelectedIndex == 2) { // Вычитание

                    string eror = "";
                    bool willContinue = findingErrors(out eror);
                    if (willContinue == false) {
                        Debug.Text = eror;
                        return;
                    }
                    if (int.Parse(MFirstCols.Text) != int.Parse(MSecCols.Text) || int.Parse(MFirstStrs.Text) != int.Parse(MSecStrs.Text)) {
                        Debug.Text = "Количество столбцов или строк в матрицах разное";
                        return;
                    }

                    fMatCol = int.Parse(MFirstCols.Text);
                    fMatStr = int.Parse(MFirstStrs.Text);
                    sMatCol = fMatCol;
                    sMatStr = fMatStr;
                    tMatCol = fMatCol;
                    tMatStr = fMatStr;

                    MatrixOne = new double[fMatStr, fMatCol];
                    MatrixTwo = new double[fMatStr, fMatCol];
                    MatrixResult = new double[fMatStr, fMatCol];

                    changeScene(false);

                    DataTable table = new DataTable();
                    for (int i = 0; i < fMatCol; ++i)
                        table.Columns.Add("Col_" + (i + 1));
                    for (int i = 0; i < fMatStr; ++i) {
                        DataRow r = table.NewRow();
                        table.Rows.Add(r);
                    }

                    DataTable table2 = new DataTable();
                    for (int i = 0; i < fMatCol; ++i)
                        table2.Columns.Add("Col_" + (i + 1));
                    for (int i = 0; i < fMatStr; ++i) {
                        DataRow r = table2.NewRow();
                        table2.Rows.Add(r);
                    }

                    DataTable table3 = new DataTable();
                    for (int i = 0; i < fMatCol; ++i)
                        table3.Columns.Add("Col_" + (i + 1));
                    for (int i = 0; i < fMatStr; ++i) {
                        DataRow r = table3.NewRow();
                        table3.Rows.Add(r);
                    }
                    FMatrix.DataSource = table;
                    SMatrix.DataSource = table2;
                    RMatrix.DataSource = table3;

                    state = States.input;
                }
                else
                    Debug.Text = "Бред какой-то xD";
            }
            else {
                Debug.Text = "Вы уже начали вычисление умножения матриц!";
            }
        }

        bool findingErrors(out string eror) {

            bool willContinue = true;
            eror = "";
            for (int i = 0; i < 4; ++i) {
                if (textBoxes[i].Text == "") {
                    willContinue = false;
                    eror += "Не введен параметр в " + (i + 1) + " строке. \t";
                }
            }
            for (int i = 0; i < 4; ++i) {
                for (int j = 0; j < textBoxes[i].Text.Length; ++j) {
                    if (textBoxes[i].Text[j] < 48 || textBoxes[i].Text[j] > 57) {
                        eror += "В поле " + (i + 1) + " вы ввели не числовое значение! \t";
                        willContinue = false;
                        break;
                    }
                }
            }
            return willContinue;
        }



        void changeScene(bool isVisible) {

            for (int i = 0; i < textBoxes.Length; ++i)
                textBoxes[i].Visible = isVisible;

            textBox1.Visible = isVisible;
            textBox2.Visible = isVisible;
            textBox3.Visible = isVisible;
            textBox4.Visible = isVisible;
            Operation.Visible = isVisible;
            OperText.Visible = isVisible;

        }
        void Next_Click(object sender, EventArgs e) {

            bool doWeGo = false;

            switch (state) {

                case States.input:
                    // Взятие значений из первой матрицы
                    for (int i = 0; i < fMatStr; ++i) {
                        for (int j = 0; j < fMatCol; ++j) {
                            string valuev = FMatrix.Rows[i].Cells[j].Value.ToString();
                            if (valuev == "") {
                                Debug.Text = "Пустые поля недопустимы, введите 0!";
                                return;
                            }
                            doWeGo = true;
                        }
                    }
                    if (doWeGo) {
                        for (int i = 0; i < fMatStr; ++i) {
                            for (int j = 0; j < fMatCol; ++j) {
                                MatrixOne[i, j] = double.Parse(FMatrix.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                    }
                    doWeGo = false;
                    // Взятие значений из второй матрицы
                    for (int i = 0; i < sMatStr; ++i) {
                        for (int j = 0; j < sMatCol; ++j) {
                            string valuev = SMatrix.Rows[i].Cells[j].Value.ToString();
                            if (valuev == "") {
                                Debug.Text = "Пустые поля недопустимы, введите 0!";
                                return;
                            }
                            doWeGo = true;
                        }
                    }
                    if (doWeGo) {

                        for (int i = 0; i < sMatStr; ++i) {
                            for (int j = 0; j < sMatCol; ++j) {
                                MatrixTwo[i, j] = double.Parse(SMatrix.Rows[i].Cells[j].Value.ToString());
                            }
                        }

                        // Вывод результата в 3-ью матрицу

                        int oper = Operation.SelectedIndex;

                        switch (oper) {

                            case 0:

                            for (int i = 0; i < tMatStr; ++i) {
                                for (int j = 0; j < tMatCol; ++j) {
                                    for (int t = 0; t < fMatCol; ++t) {
                                        MatrixResult[i, j] += (MatrixOne[i, t] * MatrixTwo[t, j]);
                                    }
                                }
                            }

                            for (int i = 0; i < tMatStr; ++i) {
                                for (int j = 0; j < tMatCol; ++j)
                                    RMatrix.Rows[i].Cells[j].Value = MatrixResult[i, j];
                            }
                                break;

                            case 1:

                                Debug.Text = "2";

                                for (int i = 0; i < fMatStr; ++i) {
                                    for (int j = 0; j < fMatCol; ++j) {
                                        MatrixResult[i, j] = MatrixOne[i, j] + MatrixTwo[i, j];
                                    }
                                }

                                for (int i = 0; i < tMatStr; ++i) {
                                    for (int j = 0; j < tMatCol; ++j)
                                        RMatrix.Rows[i].Cells[j].Value = MatrixResult[i, j];
                                }

                                break;

                            case 2:

                                Debug.Text = "3";

                                for (int i = 0; i < fMatStr; ++i) {
                                    for (int j = 0; j < fMatCol; ++j) {
                                        MatrixResult[i, j] = MatrixOne[i, j] - MatrixTwo[i, j];
                                    }
                                }

                                for (int i = 0; i < tMatStr; ++i) {
                                    for (int j = 0; j < tMatCol; ++j)
                                        RMatrix.Rows[i].Cells[j].Value = MatrixResult[i, j];
                                }

                                break;
                        }
                        state = States.solved;
                    }

                    break;
                    
                case States.before:
                    Debug.Text = "Не та кнопка)";
                break;
                case States.solved:
                    Debug.Text = "Дальше некуда. Теперь можно только очистить всё и начать заново)";

                break;
            }
        }
        private void Do_Clear_Click(object sender, EventArgs e) {
            changeScene(true);
            for (int i = 0; i < textBoxes.Length; ++i)
                textBoxes[i].Text = "";
            Debug.Text = "";
            
            if (state != States.before) {
                int j = FMatrix.Columns.Count - 1;
                for (; j >= 0; --j)
                    FMatrix.Columns.Remove(FMatrix.Columns[j]);

                int k = SMatrix.Columns.Count - 1;
                for (; k >= 0; --k)
                    SMatrix.Columns.Remove(SMatrix.Columns[k]);

                int l = RMatrix.Columns.Count - 1;
                for (; l >= 0; --l)
                    RMatrix.Columns.Remove(RMatrix.Columns[l]);
            }

            state = States.before;
        }

        /*********************** HELP ***********************/
        private void TextBox5_TextChanged(object sender, EventArgs e) { // Столбцов в первой матрице

        }
        private void TextBox6_TextChanged(object sender, EventArgs e) { // Строк в первой матрице

        }
        private void TextBox7_TextChanged(object sender, EventArgs e) { // Столбцов во второй матрице

        }
        private void TextBox8_TextChanged(object sender, EventArgs e) { // Строк во второй матрице

        }
        private void TextBox9_TextChanged(object sender, EventArgs e) { // Выводы ошибок

        }
    }
}
