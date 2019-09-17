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

            string[] code = matrixReader.Split(';');

            char oper = ' ';

            Matrix matrix1 = new Matrix(0, 0, 1);
            Matrix matrix2 = new Matrix(0, 0, 1);
            Matrix matrix3 = new Matrix(0, 0, 1);

            bool isFirst = true;
            bool isReady = false;

            for (int i = 1; i < code.Length - 1; ++i) {
                if (code[i][0] == '#') { 
                    if (isFirst) {

                        matrix1.coeff = double.Parse(code[i - 1]);

                        string[] help = code[i].Split('_');

                        matrix1.rows = int.Parse(help[1]);
                        matrix1.cols = int.Parse(help[2]);

                        matrix1.values = new double[matrix1.rows, matrix1.cols];
                        int cycle = 3;

                        for (int j = 0; j < matrix1.rows; ++j) {
                            for (int k = 0; k < matrix1.cols; ++k) {
                                matrix1.values[j, k] = int.Parse(help[cycle]) * matrix1.coeff;
                                ++cycle;
                            }
                        }
                        isFirst = false;
                    }
                    else {
                        string[] help = code[i].Split('_');

                        matrix2.coeff = double.Parse(code[i - 1]);

                        matrix2.rows = int.Parse(help[1]);
                        matrix2.cols = int.Parse(help[2]);

                        matrix2.values = new double[matrix2.rows, matrix2.cols];
                        int cycle = 3;

                        for (int j = 0; j < matrix2.rows; ++j) {
                            for (int k = 0; k < matrix2.cols; ++k) {
                                matrix2.values[j, k] = int.Parse(help[cycle]) * matrix2.coeff;
                                ++cycle;
                            }
                        }
                        isFirst = true;
                    }
                } // Matrixes
                else if (code[i][0] == '@') {
                    if (code[i][1] == '*') {

                        matrix3.rows = matrix1.rows;
                        matrix3.cols = matrix2.cols;

                        oper = '*';

                        if (matrix1.cols != matrix2.rows) {
                            MessageBox.Show("Cant mult on: " + i);
                            return;
                        }

                        matrix3.coeff = double.Parse(code[i - 1]);

                        matrix3.values = new double[matrix1.rows, matrix2.cols];
                        matrix3.values = matrix3.multipliying(matrix1, matrix2);

                        isReady = true;
                    }
                    else if (code[i][1] == '+') {

                        matrix3.cols = matrix2.cols;
                        matrix3.rows = matrix2.rows;

                        oper = '+';

                        if (matrix1.cols != matrix2.cols && matrix1.rows != matrix2.rows) {
                            MessageBox.Show("Cant multipie on: " + i);
                            return;
                        }

                        matrix3.coeff = double.Parse(code[i - 1]);

                        matrix3.values = new double[matrix1.rows, matrix1.cols];
                        matrix3.values = matrix3.addition(matrix1, matrix2);

                        isReady = true;
                    }
                    else if (code[i][1] == '-') {

                        matrix3.cols = matrix2.cols;
                        matrix3.rows = matrix2.rows;

                        oper = '-';

                        if (matrix1.cols != matrix2.cols && matrix1.rows != matrix2.rows) {
                            MessageBox.Show("Cant sub on: " + i);
                            return;
                        }

                        matrix3.coeff = double.Parse(code[i - 1]);

                        matrix3.values = new double[matrix1.rows, matrix1.cols];
                        matrix3.values = matrix3.subtraction(matrix1, matrix2);

                        isReady = true;
                    }
                    else {
                        MessageBox.Show("Unknown operato on: " + i);
                        return;
                    }
                } // Operators
                if (isReady) {

                    writer.WriteLine("Coeff: " + matrix1.coeff);
                    for (int y = 0; y < matrix1.rows; ++y) {
                        for (int r = 0; r < matrix1.cols; ++r) {
                            writer.Write(matrix1.values[y, r] + "\t"); 
                        }
                        writer.WriteLine();
                    }

                    writer.WriteLine(oper);
                    writer.WriteLine("\nCoeff: " + matrix2.coeff);
                    for (int y = 0; y < matrix2.rows; ++y) {
                        for (int r = 0; r < matrix2.cols; ++r) {
                            writer.Write(matrix2.values[y, r] + "\t");
                        }
                        writer.WriteLine();
                    }

                    writer.WriteLine("-->");
                    writer.WriteLine("Coeff: " + matrix3.coeff);
                    for (int y = 0; y < matrix3.rows; ++y) {
                        for (int r = 0; r < matrix3.cols; ++r) {
                            writer.Write(matrix3.values[y, r] + "\t");
                        }
                        writer.WriteLine();
                    }
                    writer.WriteLine();
                    isReady = false;

                } // Output to the file
            }
            reader.Close();
            writer.Close();
        }
    }
}
