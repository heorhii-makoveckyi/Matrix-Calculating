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
        // START
        private void Button1_Click(object sender, EventArgs e) {

            if (state == States.before) {

                if (Operation.SelectedIndex == 0) {

                    string error = "";
                    bool willContinue = findingErrors(out error);

                    if (MFirstCols.Text != "" && MSecStrs.Text != "" && int.Parse(MFirstCols.Text) != int.Parse(MSecStrs.Text)) {
                        error = "Количество столбцов первой матрицы != количеству строк второй матрицы";
                        willContinue = false;
                    }
                    if (willContinue == false) {
                        Debug.Text = error;
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
                    string error = "";
                    bool willContinue = findingErrors(out error);
                    if (willContinue == false) {
                        Debug.Text = error;
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

                    string error = "";
                    bool willContinue = findingErrors(out error);
                    if (willContinue == false) {
                        Debug.Text = error;
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
                else if (Operation.SelectedIndex == -1)
                    Debug.Text = "Выберите операцию над матрицами";
                else
                    Debug.Text = "Бред какой-то xD";
            }
            else {
                Debug.Text = "Вы уже начали вычисление умножения матриц!";
            }
        }
        // CALC
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

                        string temp = Coefficient.Text;
                        double coeff = 0;

                        if (temp == "")
                            coeff = 1;

                        coeff = double.Parse(temp);

                        switch (oper) {

                            case 0:

                            for (int i = 0; i < tMatStr; ++i) {
                                for (int j = 0; j < tMatCol; ++j) {
                                    for (int t = 0; t < fMatCol; ++t) {
                                        MatrixResult[i, j] += (MatrixOne[i, t] * MatrixTwo[t, j]);
                                    }
                                    MatrixResult[i, j] *= coeff;
                                }
                            }

                            for (int i = 0; i < tMatStr; ++i) {
                                for (int j = 0; j < tMatCol; ++j)
                                    RMatrix.Rows[i].Cells[j].Value = MatrixResult[i, j];
                            }
                                break;

                            case 1:

                                for (int i = 0; i < fMatStr; ++i) {
                                    for (int j = 0; j < fMatCol; ++j) {
                                        MatrixResult[i, j] = MatrixOne[i, j] + MatrixTwo[i, j];
                                        MatrixResult[i, j] *= coeff;
                                    }
                                }

                                for (int i = 0; i < tMatStr; ++i) {
                                    for (int j = 0; j < tMatCol; ++j)
                                        RMatrix.Rows[i].Cells[j].Value = MatrixResult[i, j];
                                }

                                break;

                            case 2:

                                for (int i = 0; i < fMatStr; ++i) {
                                    for (int j = 0; j < fMatCol; ++j) {
                                        MatrixResult[i, j] = MatrixOne[i, j] - MatrixTwo[i, j];
                                        MatrixResult[i, j] *= coeff;
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

        private void CopyF_Click(object sender, EventArgs e) {
            copyMatrix(1);
        }
        private void SetF_Click(object sender, EventArgs e) {
            setMatrix(1);
        }

        private void CopyS_Click(object sender, EventArgs e) {
            copyMatrix(2);
        }
        private void SetS_Click(object sender, EventArgs e) {
            setMatrix(2);
        }

        private void CopyT_Click(object sender, EventArgs e) {
            copyMatrix(3);
        }
        private void SetT_Click(object sender, EventArgs e) {
            setMatrix(3);
        }

        private void RunCode_Click(object sender, EventArgs e) {
            readMatrixFile(PathIN.Text, PathOUT.Text, false);
        }
    }
}
