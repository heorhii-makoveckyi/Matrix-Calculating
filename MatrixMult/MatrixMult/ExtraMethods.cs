using System.Windows.Forms;
using System.Data;

namespace MatrixMult {
    public static class Extramethods {
        public static void copyMatrix(TextBox Debug, DataGridView FMatrix, DataGridView SMatrix, DataGridView RMatrix, short whichOne,
            int fStr, int fCol, int sCol, int sStr, int tCol, int tStr) {

            var matrix = "#_";

            switch (whichOne) {
                case 1:
                    matrix += fStr + "_" + fCol + "_";

                    for (int i = 0; i < fStr; ++i) {
                        for (int j = 0; j < fCol; ++j) {

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
                    matrix += sStr + "_" + sCol + "_";

                    for (int i = 0; i < sStr; ++i) {
                        for (int j = 0; j < sCol; ++j) {
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
                    matrix += tStr + "_" + tCol + "_";

                    for (int i = 0; i < tStr; ++i) {
                        for (int j = 0; j < tCol; ++j) {
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
        public static void setMatrix(TextBox Debug, DataGridView FMatrix, DataGridView SMatrix, DataGridView RMatrix, short whichOne,
            int fStr, int fCol, int sCol, int sStr, int tCol, int tStr) {

            var matrixClip = Clipboard.GetText();
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
                    if (fStr != str || fCol != col) {
                        Debug.Text = "Copied matrix does not fit";
                        return;
                    }
                    for (int i = 0; i < fStr; ++i) {
                        for (int j = 0; j < fCol; ++j) {
                            FMatrix.Rows[i].Cells[j].Value = matrix[3 + step];
                            ++step;
                        }
                    }
                    break;

                case 2:
                    if (sStr != str || sCol != col) {
                        Debug.Text = "Copied matrix does not fit";
                        return;
                    }
                    for (int i = 0; i < sStr; ++i) {
                        for (int j = 0; j < sCol; ++j) {
                            SMatrix.Rows[i].Cells[j].Value = matrix[3 + step];
                            ++step;
                        }
                    }
                    break;

                case 3:
                    if (tStr != str || tCol != col) {
                        Debug.Text = "Copied matrix does not fit";
                        return;
                    }
                    for (int i = 0; i < tStr; ++i) {
                        for (int j = 0; j < tCol; ++j) {
                            RMatrix.Rows[i].Cells[j].Value = matrix[3 + step];
                            ++step;
                        }
                    }
                    break;
            }
        }
        public static bool findingErrors(out string error, TextBox[] textBoxes) {

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
        public static void addCols(out DataTable table1, out DataTable table2, out DataTable table3, 
            int fCol, int fStr, int sCol, int sStr, int tCol, int tStr) {

            table1 = new DataTable();
            for (int i = 0; i < fCol; ++i)
                table1.Columns.Add("Col_" + (i + 1));
            for (int i = 0; i < fStr; ++i) {
                DataRow r = table1.NewRow();
                table1.Rows.Add(r);
            }

            table2 = new DataTable();
            for (int i = 0; i < sCol; ++i)
                table2.Columns.Add("Col_" + (i + 1));
            for (int i = 0; i < sStr; ++i) {
                DataRow r = table2.NewRow();
                table2.Rows.Add(r);
            }

            table3 = new DataTable();
            for (int i = 0; i < tCol; ++i)
                table3.Columns.Add("Col_" + (i + 1));
            for (int i = 0; i < tStr; ++i) {
                DataRow r = table3.NewRow();
                table3.Rows.Add(r);
            }
        }
        public static void addCols(out DataTable table1, out DataTable table2, out DataTable table3, int col, int str) {
            table1 = new DataTable();
            for (int i = 0; i < col; ++i)
                table1.Columns.Add("Col_" + (i + 1));
            for (int i = 0; i < str; ++i) {
                DataRow r = table1.NewRow();
                table1.Rows.Add(r);
            }
            table2 = new DataTable();
            for (int i = 0; i < col; ++i)
                table2.Columns.Add("Col_" + (i + 1));
            for (int i = 0; i < str; ++i) {
                DataRow r = table2.NewRow();
                table2.Rows.Add(r);
            }
            table3 = new DataTable();
            for (int i = 0; i < col; ++i)
                table3.Columns.Add("Col_" + (i + 1));
            for (int i = 0; i < str; ++i) {
                DataRow r = table3.NewRow();
                table3.Rows.Add(r);
            }
        }
        public static void changeScene(TextBox[] textBoxes, TextBox[] roBoxes, TextBox coeff, ComboBox operation, bool isVisible) {

            for (var i = 0; i < textBoxes.Length; ++i)
                textBoxes[i].Visible = isVisible;
            for (var i = 0; i < roBoxes.Length; ++i)
                roBoxes[i].Visible = isVisible;

            if (coeff.Text == "")
                coeff.Text = "1";

            coeff.Enabled = isVisible;
            operation.Enabled = isVisible;

        }
    }
}
