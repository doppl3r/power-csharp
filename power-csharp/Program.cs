using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace power_csharp
{
    class Program
    {
        //declare variables
        static double[,] a; //matrix #1
        static double[,] x; //matrix #2
        static double tol; //tolerance z^x
        static int n; //iterations

        static void Main(string[] args)
        {
            //These stay the same per test
            Power power = new Power();
            x = new double[,]{ //row, column
                {500},
                {300},
                {150},
                { 50}
            };
            tol = Math.Pow(10, -5);
            n = 100;

            //Test1
            a = new double[,]{
                { 0, 0.75, 2.4, 0.3},
                { 0.4, 0, 0, 0},
                { 0, 0.7, 0, 0},
                { 0, 0, 0.8, 0}
            };
            power.calculate(a, x, tol, n);

            //Test2
            a = new double[,]{
                { 0, 0.75, 2.4, 0.3},
                { 0.2, 0, 0, 0},
                { 0, 0.1, 0, 0},
                { 0, 0, 0.1, 0}
            };
            power.calculate(a, x, tol, n);

            //Test3
            a = new double[,]{
                { 0, 1.2, 2.8, 0.7},
                { 0.6, 0, 0, 0},
                { 0, 0.9, 0, 0},
                { 0, 0, 0.8, 0}
            };
            power.calculate(a, x, tol, n);

            //Test4
            a = new double[,]{
                { 0, 1.8, 3, 1},
                { 0.8, 0, 0, 0},
                { 0, 0.95, 0, 0},
                { 0, 0, 0.9, 0}
            };
            power.calculate(a, x, tol, n);

            Console.ReadKey();
        }
    }
}
