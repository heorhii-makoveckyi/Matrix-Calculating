namespace MatrixMult {
    public class Matrix {

        public Matrix() {}
        public Matrix(int rows, int cols, double coeff) {
            this.coeff = coeff;
            this.rows = rows;
            this.cols = cols;
        }
        public double[,] values { get; set; }
        public double coeff { get; set; }
        public int rows { get; set; }
        public int cols { get; set; }

        public double[,] multipliying(Matrix matrix1, Matrix matrix2) {

            var resValues = new double[matrix1.rows, matrix2.cols];

            for (var i = 0; i < matrix1.rows; ++i) {
                for (var j = 0; j < matrix2.cols; ++j) {
                    for (var t = 0; t < matrix1.cols; ++t) {
                        resValues[i, j] += matrix1.values[i, t] * matrix2.values[t, j];
                    }
                    resValues[i, j] *= coeff;
                }
            }
            return resValues;
        }
        public double[,] addition(Matrix matrix1, Matrix matrix2) {

            var resValues = new double[rows, cols];

            for (var i = 0; i < rows; ++i) {
                for (var j = 0; j < cols; ++j) {
                    resValues[i, j] = matrix1.values[i, j] + matrix2.values[i, j];
                    resValues[i, j] *= coeff;
                }
            }
            return resValues;
        }
        public double[,] subtraction(Matrix matrix1, Matrix matrix2) {

            var resValues = new double[rows, cols];

            for (var i = 0; i < rows; ++i) {
                for (var j = 0; j < cols; ++j) {
                    resValues[i, j] = matrix1.values[i, j] - matrix2.values[i, j];
                    resValues[i, j] *= coeff;
                }
            }
            return resValues;
        }

    }
}
