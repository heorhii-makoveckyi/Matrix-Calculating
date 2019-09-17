using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MatrixMult {
    public partial class Form1 : Form {

        void copyMatrix(short whichOne) {

            string matrix = "#_";

            switch (whichOne) {
                case 1:
                    matrix += fMatStr + "_" + fMatCol + "_";

                    for (int i = 0; i < fMatStr; ++i) {
                        for (int j = 0; j < fMatCol; ++j) {

                            if (FMatrix.Rows[i].Cells[j].Value.ToString() == "") {
                                Debug.Text = "Fill matrix!";
                                return;
                            }

                            matrix += FMatrix.Rows[i].Cells[j].Value.ToString() + "_";
                        }
                    }
                    Clipboard.SetText(matrix);
                    break;

                case 2:
                    matrix += sMatStr + "_" + sMatCol + "_";

                    for (int i = 0; i < sMatStr; ++i) {
                        for (int j = 0; j < sMatCol; ++j) {
                            if (SMatrix.Rows[i].Cells[j].Value.ToString() == "") {
                                Debug.Text = "Fill matrix!";
                                return;
                            }

                            matrix += SMatrix.Rows[i].Cells[j].Value.ToString() + "_";
                        }
                    }
                    Clipboard.SetText(matrix);
                    break;

                case 3:
                    matrix += tMatStr + "_" + tMatCol + "_";

                    for (int i = 0; i < tMatStr; ++i) {
                        for (int j = 0; j < tMatCol; ++j) {
                            if (RMatrix.Rows[i].Cells[j].Value.ToString() == "") {
                                Debug.Text = "Fill matrix!";
                                return;
                            }

                            matrix += RMatrix.Rows[i].Cells[j].Value.ToString() + "_";
                        }
                    }
                    Clipboard.SetText(matrix);
                    break;
            }
        }
        void setMatrix(short whichOne) {

            string matrixClip = Clipboard.GetText();
            MessageBox.Show(matrixClip);

            if (matrixClip[0] != '#' && matrixClip[1] != '_') {
                Debug.Text = "Does not match pattern:\t #_rows_cols_value1_value2_..._";
            }
            string[] matrix = matrixClip.Split('_'); //matrix[0] - help elem
            int str = int.Parse(matrix[1]);
            int col = int.Parse(matrix[2]);

            int step = 0;

            switch (whichOne) {

                case 1:
                    if (fMatStr != str || fMatCol != col) {
                        Debug.Text = "Copied matrix does not fit";
                        return;
                    }
                    for (int i = 0; i < fMatStr; ++i) {
                        for (int j = 0; j < fMatCol; ++j) {
                            FMatrix.Rows[i].Cells[j].Value = matrix[3 + step];
                            ++step;
                        }
                    }
                    break;

                case 2:
                    if (sMatStr != str || sMatCol != col) {
                        Debug.Text = "Copied matrix does not fit";
                        return;
                    }
                    for (int i = 0; i < sMatStr; ++i) {
                        for (int j = 0; j < sMatCol; ++j) {
                            SMatrix.Rows[i].Cells[j].Value = matrix[3 + step];
                            ++step;
                        }
                    }
                    break;

                case 3:
                    if (tMatStr != str || tMatCol != col) {
                        Debug.Text = "Copied matrix does not fit";
                        return;
                    }
                    for (int i = 0; i < tMatStr; ++i) {
                        for (int j = 0; j < tMatCol; ++j) {
                            RMatrix.Rows[i].Cells[j].Value = matrix[3 + step];
                            ++step;
                        }
                    }
                    break;
            }
        }

        bool findingErrors(out string error) {

            bool willContinue = true;
            error = "";
            for (int i = 0; i < 4; ++i) {
                if (textBoxes[i].Text == "") {
                    willContinue = false;
                    error += "Wasnt inputed value in " + (i + 1) + " row. \t";
                }
            }
            for (int i = 0; i < 4; ++i) {
                for (int j = 0; j < textBoxes[i].Text.Length; ++j) {
                    if (textBoxes[i].Text[j] < 48 || textBoxes[i].Text[j] > 57) {
                        error += "In field " + (i + 1) + " you havent inputed num value! \t";
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
        private void Do_Clear_Click(object sender, EventArgs e) {

            for (int i = 0; i < textBoxes.Length; ++i)
                textBoxes[i].Text = "";
            Debug.Text = "";

            if (state != States.before) {
                changeScene(true);

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
            Coefficient.Text = "";

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
        private void TextBox6_TextChanged_1(object sender, EventArgs e) {

        }
    }
}
