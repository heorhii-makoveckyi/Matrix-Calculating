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
            reader.Close();

            var oper = ' ';

            Matrix matrix1 = new Matrix();
            Matrix matrix2 = new Matrix();
            Matrix matrix3 = new Matrix();

            double coeff1 = 0.0;
            double coeff2 = 0.0;
            double coeff3 = 0.0;

            var isFirst = true;
            var isReady = false;

            for (var i = 1; i < code.Length - 1; ++i) {
                if (code[i][0] == '#') /* Matrixes */  { 
                    if (isFirst) {
                        try {
                            coeff1 = double.Parse(code[i - 1]);
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

                        matrix1 = new Matrix(int.Parse(help[1]), int.Parse(help[2]));

                        var cycle = 3;

                        for (var j = 0; j < matrix1.Rows; ++j) {
                            for (var k = 0; k < matrix1.Cols; ++k) {
                                matrix1.Values[j, k] = int.Parse(help[cycle]) * coeff1;
                                ++cycle;
                            }
                        }
                        isFirst = false;
                    }
                    else {
                        var help = code[i].Split('_');
                        try {
                            coeff2 = double.Parse(code[i - 1]);
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
                        matrix2 = new Matrix(int.Parse(help[1]), int.Parse(help[2]));
                        var cycle = 3;

                        for (var j = 0; j < matrix2.Rows; ++j) {
                            for (var k = 0; k < matrix2.Cols; ++k) {
                                matrix2.Values[j, k] = int.Parse(help[cycle]) * coeff2;
                                ++cycle;
                            }
                        }
                        isFirst = true;
                    }
                } // Matrixes
                else if (code[i][0] == '@') /* Operators */ {
                    if (code[i].Length > 1) {
                        if (code[i][1] == '*') {

                            matrix3 = new Matrix(matrix1.Rows, matrix2.Cols);
                            
                            oper = '*';

                            if (matrix1.Cols != matrix2.Rows) {
                                var plusStrs = 0;
                                foreach (var strs in comments) {
                                    if (strs < i)
                                        ++plusStrs;
                                }
                                MessageBox.Show("Cant mult on: " + (i + plusStrs) + "str");
                                return;
                            }
                            try {
                                coeff3 = double.Parse(code[i - 1]);
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
                            matrix3 = coeff3 * matrix1 * matrix2;                            
                            isReady = true;
                        }
                        else if (code[i][1] == '+') {

                            matrix3 = new Matrix(matrix2.Cols, matrix2.Rows);

                            oper = '+';

                            if (matrix1.Cols != matrix2.Cols && matrix1.Rows != matrix2.Rows) {
                                var plusStrs = 0;
                                foreach (var strs in comments) {
                                    if (strs < i)
                                        ++plusStrs;
                                }
                                MessageBox.Show("Cant multipie on: " + (i + 1 + plusStrs) + "str");
                                return;
                            }

                            coeff3 = double.Parse(code[i - 1]);
                            matrix3 = coeff3 * (matrix1 + matrix2);

                            isReady = true;
                        }
                        else if (code[i][1] == '-') {

                            matrix3 = new Matrix(matrix2.Cols, matrix2.Rows);
                            oper = '-';

                            if (matrix1.Cols != matrix2.Cols && matrix1.Rows != matrix2.Rows) {
                                var plusStrs = 0;
                                foreach (var strs in comments) {
                                    if (strs < i)
                                        ++plusStrs;
                                }
                                MessageBox.Show("Cant sub on: " + (i + 1 + plusStrs) + "str");
                                return;
                            }

                            coeff3 = double.Parse(code[i - 1]);

                            matrix3 = coeff3 * (matrix1 - matrix2);
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

                    var writer = new StreamWriter(pathOUT);

                    writer.WriteLine("Coeff: " + coeff1);
                    writer.Write(matrix1.ToString());

                    writer.WriteLine(oper);
                    writer.WriteLine("\nCoeff: " + coeff2);
                    writer.Write(matrix2.ToString());
                        
                    writer.WriteLine("-->");
                    writer.WriteLine("Coeff: " + coeff3);
                    writer.Write(matrix3.ToString());
                    writer.WriteLine();

                    writer.Close();

                    isReady = false;

                } // Writing to the file
            }
        }
    }
}
