using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MatrixMult {
    public partial class Form1 : Form {

        void readMatrixFile(string pathIN, string pathOUT, bool isSTDView) {

            StreamReader reader = new StreamReader(pathIN);
            StreamWriter writer = new StreamWriter(pathOUT);

            string matrixReader = "";
            while (matrixReader != "Start;") {
                matrixReader = reader.ReadLine();
            }
            string temp = "";
            while (temp != "End;") {
                temp = reader.ReadLine();
                if (temp[0] == '!')
                    continue;
                matrixReader += temp;
            }

            string[] matrix = matrixReader.Split(';');

            char oper = ' ';

            double coeff1 = 1;
            double coeff2 = 1;
            double coeff3 = 1;

            int mStr1 = 0;
            int mCol1 = 0;
            int mStr2 = 0;
            int mCol2 = 0;
            int mStr3 = 0;
            int mCol3 = 0;

            double[,] matrix1 = new double[0, 0];
            double[,] matrix2 = new double[0, 0];
            double[,] matrix3 = new double[0, 0];

            bool isFirst = true;
            bool isReady = false;

            for (int i = 1; i < matrix.Length - 1; ++i) {
                if (matrix[i][0] == '#') { 
                    if (isFirst) {

                        coeff1 = double.Parse(matrix[i - 1]);

                        string[] help = matrix[i].Split('_');

                        mStr1 = int.Parse(help[1]);
                        mCol1 = int.Parse(help[2]);

                        matrix1 = new double[mStr1, mCol1];
                        int cycle = 3;

                        for (int j = 0; j < mStr1; ++j) {
                            for (int k = 0; k < mCol1; ++k) {
                                matrix1[j, k] = int.Parse(help[cycle]) * coeff1;
                                ++cycle;
                            }
                        }
                        isFirst = false;
                    }
                    else {
                        string[] help = matrix[i].Split('_');

                        coeff2 = double.Parse(matrix[i - 1]);

                        mStr2 = int.Parse(help[1]);
                        mCol2 = int.Parse(help[2]);

                        matrix2 = new double[mStr2, mCol2];
                        int cycle = 3;

                        for (int j = 0; j < mStr2; ++j) {
                            for (int k = 0; k < mCol2; ++k) {
                                matrix2[j, k] = int.Parse(help[cycle]) * coeff2;
                                ++cycle;
                            }
                        }
                        isFirst = true;
                    }
                } // Матрицы
                else if (matrix[i][0] == '@') {
                    if (matrix[i][1] == '*') {

                        mStr3 = mStr1;
                        mCol3 = mCol2;

                        oper = '*';

                        if (mCol1 != mStr2) {
                            MessageBox.Show("Не получается умножить на: " + i);
                            return;
                        }

                        coeff3 = double.Parse(matrix[i - 1]);

                        matrix3 = new double[mStr1, mCol2];
                        matrix3 = multipliying(matrix1, matrix2, coeff3, mStr1, mCol2, mCol1);

                        isReady = true;
                    }
                    else if (matrix[i][1] == '+') {

                        mCol3 = mCol2;
                        mStr3 = mStr2;

                        oper = '+';

                        if (mCol1 != mCol2 && mStr1 != mStr2) {
                            MessageBox.Show("Не получается сложить на: " + i);
                            return;
                        }

                        coeff3 = double.Parse(matrix[i - 1]);

                        matrix3 = new double[mStr1, mCol1];
                        matrix3 = addition(matrix1, matrix2, coeff3, mStr1, mCol1);

                        isReady = true;
                    }
                    else if (matrix[i][1] == '-') {

                        mCol3 = mCol2;
                        mStr3 = mStr2;

                        oper = '-';

                        if (mCol1 != mCol2 && mStr1 != mStr2) {
                            MessageBox.Show("Не получается вычесть на: " + i);
                            return;
                        }

                        coeff3 = double.Parse(matrix[i - 1]);

                        matrix3 = new double[mStr1, mCol1];
                        matrix3 = subtraction(matrix1, matrix2, coeff3, mStr1, mCol1);

                        isReady = true;
                    }
                    else {
                        MessageBox.Show("Неверный оператор на: " + i);
                        return;
                    }
                } // Операторы
                if (isReady) {

                    for (int y = 0; y < mStr1; ++y) {
                        for (int r = 0; r < mCol1; ++r) {
                            writer.Write(matrix1[y, r] + "\t"); 
                        }
                        writer.WriteLine();
                    }

                    writer.WriteLine(oper);
                    for (int y = 0; y < mStr2; ++y) {
                        for (int r = 0; r < mCol2; ++r) {
                            writer.Write(matrix2[y, r] + "\t");
                        }
                        writer.WriteLine();
                    }

                    writer.WriteLine("-->");
                    for (int y = 0; y < mStr3; ++y) {
                        for (int r = 0; r < mCol3; ++r) {
                            writer.Write(matrix3[y, r] + "\t");
                        }
                        writer.WriteLine();
                    }
                    writer.WriteLine();
                    isReady = false;

                } // Вывод в файл
            }
            reader.Close();
            writer.Close();
        }
        double[,] multipliying(double[,] matrix1, double[,] matrix2, double ratio, int fMatrixStr, int sMatrixCol, int fMatrixCol) {

            double[,] resMatrix = new double[fMatrixStr, sMatrixCol];

            for (int i = 0; i < fMatrixStr; ++i) {
                for (int j = 0; j < sMatrixCol; ++j) {
                    for (int t = 0; t < fMatrixCol; ++t) {
                        resMatrix[i, j] += matrix1[i, t] * matrix2[t, j];
                    }
                    resMatrix[i, j] *= ratio;
                }
            }
            return resMatrix;
        }
        double[,] addition(double[,] matrix1, double[,] matrix2, double ratio, int str, int col) {

            double[,] resMatrix = new double[str, col];

            for (int i = 0; i < str; ++i) {
                for (int j = 0; j < col; ++j) {
                    resMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                    resMatrix[i, j] *= ratio;
                }
            }
            return resMatrix;
        }
        double[,] subtraction(double[,] matrix1, double[,] matrix2, double ratio, int str, int col) {

            double[,] resMatrix = new double[str, col];

            for (int i = 0; i < str; ++i) {
                for (int j = 0; j < col; ++j) {
                    resMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                    resMatrix[i, j] *= ratio;
                }
            }
            return resMatrix;
        }

    }
}
