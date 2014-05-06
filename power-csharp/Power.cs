using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace power_csharp
{
    class Power
    {
        public Power()
        {

        }
        public void calculate(double[,] a, double[,] x, double tol, int n){
        //declare and initialize variables
        int k = 1;
        double yp;
        double err;
        double mu = 0;
        double[,] y;
        //mutate vars
        x = divideMatrix(x,getHighestValue(x));

        //loop through
        while (k <= n){
            y  = multiplyMatrix(a, x);
            mu = getHighestValue(y);
            yp = getHighestValue(y);
            if (yp == 0){
                Console.WriteLine("A");
                Console.WriteLine("A has a zero eigenvalue with corresponding e_vect");
                break;
            }
            err = norm(subtractMatrix(x, divideMatrix(y, getHighestValue(y))));
            x = divideMatrix(y, getHighestValue(y));
            if (err < tol){
                Console.WriteLine("err: " + err + ", tol: " + tol);
                break;
            }
            k++;
        }
        Console.WriteLine("Coverages to mu=" + mu);
    }
        public double getHighestValue(double[,] matrix) { return matrix[getHighestValueIndex(matrix),0]; }
        public int getHighestValueIndex(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int index = 0;
            double p = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (p < matrix[row,col])
                    {
                        p = matrix[row,col];
                        index = row;
                    }
                }
            }
            return index;
        }
        public double[,] divideMatrix(double[,] matrix, double denominator)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row,col] = matrix[row,col] / denominator;
                }
            }
            return matrix;
        }
        public double norm(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double total = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    total += Math.Pow(matrix[row,col], 2);
                }
            }
            return Math.Sqrt(total);
        }
        public double[,] subtractMatrix(double[,] A, double[,] B){
            int aRows = A.GetLength(0);
            int aCols = A.GetLength(1);
            int bRows = B.GetLength(0);
            int bCols = B.GetLength(1);

            double[,] matrix = new double[aRows,bCols];
            for (int row = 0; row < aRows; row++) {
                for (int col = 0; col < bCols; col++) {
                    matrix[row,col] = A[row,col]-B[row,col];
                }
            }
            return matrix;
        }
        public double[,] multiplyMatrix(double[,] A, double[,] B) {
            int aRows = A.GetLength(0);
            int aCols = A.GetLength(1);
            int bRows = B.GetLength(0);
            int bCols = B.GetLength(1);

            if (aCols != bRows) {
                //throw new IllegalArgumentException("A:Rows: " + aCols + " did not match B:Columns " + bRows + ".");
            }

            double[,] matrix = new double[aRows,bCols];
            for (int i = 0; i < aRows; i++) {
                for (int j = 0; j < bCols; j++) {
                    matrix[i,j] = 0;
                }
            }

            for (int i = 0; i < aRows; i++) { // aRow
                for (int j = 0; j < bCols; j++) { // bColumn
                    for (int k = 0; k < aCols; k++) { // aColumn
                        matrix[i,j] += A[i,k] * B[k,j];
                    }
                }
            }

            return matrix;
        }
        public void matrixToString(double[,] matrix){
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++){
                for (int col = 0; col < cols; col++){
                    Console.Write(matrix[row,col]);
                    if (col != cols && row != rows) Console.Write(",");
                }
                Console.WriteLine("");
            }
        }
    }
}
