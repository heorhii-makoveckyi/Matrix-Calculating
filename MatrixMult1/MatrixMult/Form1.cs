using System;
using System.Data;
using System.Windows.Forms;
using MatrixReader;

namespace MatrixMult {
    public partial class Form1 : Form {
        public enum States {
            before,
            input,
            solved
        }

        States state;

        Matrix matrix1;
        Matrix matrix2;
        Matrix matrix3;

        TextBox[] textBoxes;
        TextBox[] roBoxes;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) /* Fill arrays */ {

            textBoxes = new TextBox[4];
            textBoxes[0] = MFirstCols;
            textBoxes[1] = MFirstStrs;
            textBoxes[2] = MSecCols;
            textBoxes[3] = MSecStrs;

            roBoxes = new TextBox[5];
            roBoxes[0] = textBox1;
            roBoxes[1] = textBox2;
            roBoxes[2] = textBox3;
            roBoxes[3] = textBox4;
            roBoxes[4] = OperText;

            state = States.before;
        }
        private void Button1_Click(object sender, EventArgs e) /* START */ {

            if (state == States.before) {

                if (Operation.SelectedIndex == 0) {

                    var error = "";
                    var willContinue = Extramethods.findingErrors(out error, textBoxes);

                    if (MFirstCols.Text != "" && MSecStrs.Text != "" && int.Parse(MFirstCols.Text) != int.Parse(MSecStrs.Text)) {
                        error = "Count of cols first matrix != count of rows second matrix";
                        willContinue = false;
                    }
                    if (willContinue == false) {
                        Debug.Text = error;
                    }
                    else {  

                        matrix1 = new Matrix(int.Parse(MFirstStrs.Text), int.Parse(MFirstCols.Text));
                        matrix2 = new Matrix(int.Parse(MSecStrs.Text), int.Parse(MSecCols.Text));
                        matrix3 = new Matrix(matrix1.Rows, matrix2.Cols);

                        Extramethods.changeScene(textBoxes, roBoxes, Coefficient, Operation, false);

                        DataTable table1;
                        DataTable table2;
                        DataTable table3;

                        Extramethods.addCols(out table1, out table2, out table3, matrix1.Cols, 
                            matrix1.Rows, matrix2.Cols, matrix2.Rows, matrix3.Cols, matrix3.Rows);

                        FMatrix.DataSource = table1;
                        SMatrix.DataSource = table2;
                        RMatrix.DataSource = table3;

                        state = States.input;
                    }
                }
                else if (Operation.SelectedIndex == 1) { // addition

                    var error = "";
                    var willContinue = Extramethods.findingErrors(out error, textBoxes);
                    if (willContinue == false) {
                        Debug.Text = error;
                        return;
                    }
                    if (int.Parse(MFirstCols.Text) != int.Parse(MSecCols.Text) || int.Parse(MFirstStrs.Text) != int.Parse(MSecStrs.Text)) {
                        Debug.Text = "Count of cols and rows in matrixes are different";
                        return;
                    }

                    var cols = int.Parse(MFirstCols.Text);
                    var rows = int.Parse(MFirstStrs.Text);

                    matrix1 = new Matrix(rows, cols);
                    matrix2 = new Matrix(rows, cols);
                    matrix3 = new Matrix(rows, cols);

                    Extramethods.changeScene(textBoxes, roBoxes, Coefficient, Operation, false);

                    DataTable table1;
                    DataTable table2;
                    DataTable table3;

                    Extramethods.addCols(out table1, out table2, out table3, cols, rows);

                    FMatrix.DataSource = table1;
                    SMatrix.DataSource = table2;
                    RMatrix.DataSource = table3;

                    state = States.input;

                }
                else if (Operation.SelectedIndex == 2) { // subtraction

                    var error = "";
                    var willContinue = Extramethods.findingErrors(out error, textBoxes);
                    if (willContinue == false) {
                        Debug.Text = error;
                        return;
                    }
                    if (int.Parse(MFirstCols.Text) != int.Parse(MSecCols.Text) || int.Parse(MFirstStrs.Text) != int.Parse(MSecStrs.Text)) {
                        Debug.Text = "Count of cols and rows in matrixes are different";
                        return;
                    }

 
                    var cols = int.Parse(MFirstCols.Text);
                    var rows = int.Parse(MFirstStrs.Text);

                    matrix1 = new Matrix(rows, cols);
                    matrix2 = new Matrix(rows, cols);
                    matrix3 = new Matrix(rows, cols);

                    Extramethods.changeScene(textBoxes, roBoxes, Coefficient, Operation, false);

                    DataTable table1;
                    DataTable table2;
                    DataTable table3;

                    Extramethods.addCols(out table1, out table2, out table3, cols, rows);

                    FMatrix.DataSource = table1;
                    SMatrix.DataSource = table2;
                    RMatrix.DataSource = table3;

                    state = States.input;
                }
                else if (Operation.SelectedIndex == -1)
                    Debug.Text = "Choose operator for resolving";
                else
                    Debug.Text = "Lol what";
            }
            else {
                Debug.Text = "You just started calculation matrixes";
            }
        }
        void Next_Click(object sender, EventArgs e) /* CALC */ {

            var doWeGo = false;

            switch (state) {

                case States.input:
                    // Taking values from 1-st matrix
                    for (var i = 0; i < matrix1.Rows; ++i) {
                        for (var j = 0; j < matrix1.Cols; ++j) {
                            var valuev = FMatrix.Rows[i].Cells[j].Value.ToString();
                            if (valuev == "") {
                                Debug.Text = "Empty fields cannot be existing. Input 0!";
                                return;
                            }
                            doWeGo = true;
                        }
                    }
                    if (doWeGo) {
                        for (var i = 0; i < matrix1.Rows; ++i) {
                            for (var j = 0; j < matrix1.Cols; ++j) {
                                matrix1.Values[i, j] = double.Parse(FMatrix.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                    }
                    doWeGo = false;
                    // Taking values from 2-nd matrix
                    for (var i = 0; i < matrix1.Rows; ++i) {
                        for (var j = 0; j < matrix2.Cols; ++j) {
                            var valuev = SMatrix.Rows[i].Cells[j].Value.ToString();
                            if (valuev == "") {
                                Debug.Text = "Empty fields cannot be existing. Input 0!";
                                return;
                            }
                            doWeGo = true;
                        }
                    }
                    if (doWeGo) {

                        for (var i = 0; i < matrix2.Rows; ++i) {
                            for (var j = 0; j < matrix2.Cols; ++j) {
                                matrix2.Values[i, j] = double.Parse(SMatrix.Rows[i].Cells[j].Value.ToString());
                            }
                        }

                        // Input results to 3-rd matrix

                        var oper = Operation.SelectedIndex;

                        var temp = Coefficient.Text;
                        var coeff = 0.0;

                        var rows = matrix3.Rows;
                        var cols = matrix3.Cols;

                        try {
                            coeff = double.Parse(temp);
                        }
                        catch { }
                        if (temp == "")
                            coeff = 1;

                        switch (oper) {

                            case 0:

                                matrix3 = matrix1 * matrix2;
                                for (var i = 0; i < rows; ++i) {
                                    for (var j = 0; j < cols; ++j)
                                        RMatrix.Rows[i].Cells[j].Value = matrix3.Values[i, j];
                                }
                                break;

                            case 1:

                                matrix3 = matrix1 + matrix2;
                                for (var i = 0; i < rows; ++i) {
                                    for (var j = 0; j < cols; ++j)
                                        RMatrix.Rows[i].Cells[j].Value = matrix3.Values[i, j];
                                }
                                break;

                            case 2:

                                matrix3 = matrix1 - matrix2;
                                for (var i = 0; i < rows; ++i) {
                                    for (var j = 0; j < cols; ++j)
                                        RMatrix.Rows[i].Cells[j].Value = matrix3.Values[i, j];
                                }
                                break;
                        }
                        state = States.solved;
                    }

                    break;
                    
                case States.before:
                    Debug.Text = "Not this button)";
                break;
                case States.solved:
                    Debug.Text = "No way xD. Press Clear)";

                break;
            }
        }

        private void Do_Clear_Click(object sender, EventArgs e) {

            for (var i = 0; i < textBoxes.Length; ++i)
                textBoxes[i].Text = "";
            Debug.Text = "";

            if (state != States.before) {
                Extramethods.changeScene(textBoxes, roBoxes, Coefficient, Operation, true);

                var j = FMatrix.Columns.Count - 1;
                for (; j >= 0; --j)
                    FMatrix.Columns.Remove(FMatrix.Columns[j]);

                var k = SMatrix.Columns.Count - 1;
                for (; k >= 0; --k)
                    SMatrix.Columns.Remove(SMatrix.Columns[k]);

                var l = RMatrix.Columns.Count - 1;
                for (; l >= 0; --l)
                    RMatrix.Columns.Remove(RMatrix.Columns[l]);
            }
            Coefficient.Text = "";

            state = States.before;
        }

        private void CopyF_Click(object sender, EventArgs e) {
            Extramethods.copyMatrix(Debug, FMatrix, SMatrix, RMatrix, 1, matrix1.Rows, matrix1.Cols,
                matrix2.Rows, matrix2.Cols, matrix3.Rows, matrix3.Cols);
        }
        private void SetF_Click(object sender, EventArgs e) {
            Extramethods.setMatrix(Debug, FMatrix, SMatrix, RMatrix, 1, matrix1.Rows, matrix1.Cols,
                matrix2.Rows, matrix2.Cols, matrix3.Rows, matrix3.Cols);
        }
        private void CopyS_Click(object sender, EventArgs e) {
            Extramethods.copyMatrix(Debug, FMatrix, SMatrix, RMatrix, 2, matrix1.Rows, matrix1.Cols,
                matrix2.Rows, matrix2.Cols, matrix3.Rows, matrix3.Cols);
        }
        private void SetS_Click(object sender, EventArgs e) {
            Extramethods.setMatrix(Debug, FMatrix, SMatrix, RMatrix, 2, matrix1.Rows, matrix1.Cols,
                matrix2.Rows, matrix2.Cols, matrix3.Rows, matrix3.Cols);
        }
        private void CopyT_Click(object sender, EventArgs e) {
            Extramethods.copyMatrix(Debug, FMatrix, SMatrix, RMatrix, 3, matrix1.Rows, matrix1.Cols,
                matrix2.Rows, matrix2.Cols, matrix3.Rows, matrix3.Cols);
        }

        private void RunCode_Click(object sender, EventArgs e) /* Read file with special markup and write to another one */ {
            Compiler.readMatrixFile(PathIN.Text, PathOUT.Text);
        }

        /*********************** HELP ***********************/
        private void TextBox5_TextChanged(object sender, EventArgs e) /* Cols in first matrix */ { 

        }
        private void TextBox6_TextChanged(object sender, EventArgs e) /* Rows in first matrix */ {

        }
        private void TextBox7_TextChanged(object sender, EventArgs e) /* Cols in second matrix */ {

        }
        private void TextBox8_TextChanged(object sender, EventArgs e) /* Rows in second matrix */ {

        }
        private void TextBox9_TextChanged(object sender, EventArgs e) /* Error output */ {

        }
        private void TextBox6_TextChanged_1(object sender, EventArgs e) {

        }
    }
}
