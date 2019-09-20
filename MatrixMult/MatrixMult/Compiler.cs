using System.Windows.Forms;
using System.IO;
using System;
using System.Collections.Generic;
using MatrixMult;

namespace MatrixReader {
    public static class Compiler {

        public static void readMatrixFile(string pathIN, string pathOUT) {

            var comments = new List<int>();

            var reader = new StreamReader(pathIN);
            var writer = new StreamWriter(pathOUT);

            var matrixReader = "";
            while (matrixReader != "Start;") {
                matrixReader = reader.ReadLine();
            }
            var temp = "";
            var str = 1;
            while (temp != "End;") {
                temp = reader.ReadLine();
                if (temp.Length == 0 || temp[0] == '!') {
                    comments.Add(str);
                    ++str;
                    continue;
                }
                matrixReader += temp;
            }

            var code = matrixReader.Split(';');

            var oper = ' ';

            var matrix1 = new Matrix(0, 0, 1);
            var matrix2 = new Matrix(0, 0, 1);
            var matrix3 = new Matrix(0, 0, 1);

            var isFirst = true;
            var isReady = false;

            for (var i = 1; i < code.Length - 1; ++i) {
                if (code[i][0] == '#') /* Matrixes */  { 
                    if (isFirst) {
                        try {
                            matrix1.coeff = double.Parse(code[i - 1]);
                        }
                        catch {
                            var plusStrs = 0;
                            foreach (var strs in comments) {
                                if (strs < i)
                                    ++plusStrs;
                            }
                            MessageBox.Show("You lost coeff here: " + (i + plusStrs) + "str");
                            return;
                        }
                        var help = code[i].Split('_');

                        matrix1.rows = int.Parse(help[1]);
                        matrix1.cols = int.Parse(help[2]);

                        matrix1.values = new double[matrix1.rows, matrix1.cols];
                        var cycle = 3;

                        for (var j = 0; j < matrix1.rows; ++j) {
                            for (var k = 0; k < matrix1.cols; ++k) {
                                matrix1.values[j, k] = int.Parse(help[cycle]) * matrix1.coeff;
                                ++cycle;
                            }
                        }
                        isFirst = false;
                    }
                    else {
                        var help = code[i].Split('_');
                        try {
                            matrix2.coeff = double.Parse(code[i - 1]);
                        }
                        catch {
                            var plusStrs = 0;
                            foreach (var strs in comments) {
                                if (strs < i)
                                    ++plusStrs;
                            }
                            MessageBox.Show("You lost coeff here: " + (i + plusStrs) + "str");
                            return;
                        }
                        matrix2.rows = int.Parse(help[1]);
                        matrix2.cols = int.Parse(help[2]);

                        matrix2.values = new double[matrix2.rows, matrix2.cols];
                        var cycle = 3;

                        for (var j = 0; j < matrix2.rows; ++j) {
                            for (var k = 0; k < matrix2.cols; ++k) {
                                matrix2.values[j, k] = int.Parse(help[cycle]) * matrix2.coeff;
                                ++cycle;
                            }
                        }
                        isFirst = true;
                    }
                } // Matrixes
                else if (code[i][0] == '@') /* Operators */ {
                    if (code[i].Length > 1) {
                        if (code[i][1] == '*') {

                            matrix3.rows = matrix1.rows;
                            matrix3.cols = matrix2.cols;

                            oper = '*';

                            if (matrix1.cols != matrix2.rows) {
                                var plusStrs = 0;
                                foreach (var strs in comments) {
                                    if (strs < i)
                                        ++plusStrs;
                                }
                                MessageBox.Show("Cant mult on: " + (i + plusStrs) + "str");
                                return;
                            }

                            try {
                                matrix3.coeff = double.Parse(code[i - 1]);
                            }
                            catch {
                                var plusStrs = 0;
                                foreach (var strs in comments) {
                                    if (strs < i)
                                        ++plusStrs;
                                }
                                MessageBox.Show("You lost coeff here: " + (i + plusStrs) + "str");
                                return;
                            }
                            matrix3.values = new double[matrix1.rows, matrix2.cols];
                            matrix3.values = matrix3.multipliying(matrix1, matrix2);
                            
                            isReady = true;
                        }
                        else if (code[i][1] == '+') {

                            matrix3.cols = matrix2.cols;
                            matrix3.rows = matrix2.rows;

                            oper = '+';

                            if (matrix1.cols != matrix2.cols && matrix1.rows != matrix2.rows) {
                                var plusStrs = 0;
                                foreach (var strs in comments) {
                                    if (strs < i)
                                        ++plusStrs;
                                }
                                MessageBox.Show("Cant multipie on: " + (i + 1 + plusStrs) + "str");
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
                                var plusStrs = 0;
                                foreach (var strs in comments) {
                                    if (strs < i)
                                        ++plusStrs;
                                }
                                MessageBox.Show("Cant sub on: " + (i + 1 + plusStrs) + "str");
                                return;
                            }

                            matrix3.coeff = double.Parse(code[i - 1]);

                            matrix3.values = new double[matrix1.rows, matrix1.cols];
                            matrix3.values = matrix3.subtraction(matrix1, matrix2);

                            isReady = true;
                        }
                        else {
                            var plusStrs = 0;
                            foreach (var strs in comments) {
                                if (strs < i)
                                    ++plusStrs;
                            }
                            MessageBox.Show("Unknown operato on: " + (i + 1 + plusStrs) + "str") ;
                            return;
                        }
                    }
                    else {
                        var plusStrs = 0;
                        foreach (var strNum in comments) {
                            if (strNum < i)
                                ++plusStrs;
                        }
                        MessageBox.Show("You lost operator here: " + (i + 1 + plusStrs) + "str");
                        return;
                    }
                } // Operators
                if (isReady) /* Writing to the file */ {

                    writer.WriteLine("Coeff: " + matrix1.coeff);
                    for (var y = 0; y < matrix1.rows; ++y) {
                        for (var r = 0; r < matrix1.cols; ++r) {
                            writer.Write(matrix1.values[y, r] + "\t"); 
                        }
                        writer.WriteLine();
                    }

                    writer.WriteLine(oper);
                    writer.WriteLine("\nCoeff: " + matrix2.coeff);
                    for (var y = 0; y < matrix2.rows; ++y) {
                        for (var r = 0; r < matrix2.cols; ++r) {
                            writer.Write(matrix2.values[y, r] + "\t");
                        }
                        writer.WriteLine();
                    }

                    writer.WriteLine("-->");
                    writer.WriteLine("Coeff: " + matrix3.coeff);
                    for (var y = 0; y < matrix3.rows; ++y) {
                        for (var r = 0; r < matrix3.cols; ++r) {
                            writer.Write(matrix3.values[y, r] + "\t");
                        }
                        writer.WriteLine();
                    }
                    writer.WriteLine();
                    isReady = false;

                } // Writing to the file
            }
            reader.Close();
            writer.Close();
        }
    }
}
