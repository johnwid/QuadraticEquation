using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class QuadraticEquation
    {
        public double a, b, c;
        public double D;
        public double x1, x2;
        public QuadraticEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.D = 0;
            this.x1 = 0;
            this.x2 = 0;
        }
        public void Show()
        {
            Console.WriteLine("\n"+this.a + "x^2 + " + this.b + "x + " + this.c + " = 0");
        }
        public void Calculate()
        {
            this.D = Math.Pow(this.b, 2) - 4 * this.a * this.c;
            switch (Check(this.D))
            {
                case eCompare.LessThan:
                    Console.WriteLine("D = " + D + " < 0. There are no roots.");
                    break;
                case eCompare.Equal:
                    Console.WriteLine("D = " + D + " = 0. There is ONE root.");
                    this.x1 = (-this.b + Math.Sqrt(D)) / 2 * this.a;
                    Console.WriteLine("X = " + Math.Round(this.x1, 2));
                    break;
                case eCompare.MoreThan:
                    Console.WriteLine("D = " + D + " > 0. There are TWO roots.");
                    this.x1 = (-this.b + Math.Sqrt(D)) / 2 * this.a;
                    this.x2 = (-this.b - Math.Sqrt(D)) / 2 * this.a;
                    Console.WriteLine("X1 = {0}; X2 = {1}", Math.Round(this.x1, 2), Math.Round(this.x2, 2));
                    break;
                default:
                    break;
            }
        }

        public enum eCompare
        {
            MoreThan,
            Equal,
            LessThan,
            NotRecognized
        }
        eCompare Check(double oneItem)
        {
            if (D < 0) return eCompare.LessThan;
            if (D == 0) return eCompare.Equal;
            if (D > 0) return eCompare.MoreThan;
            return eCompare.NotRecognized;
        }
    };
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ax^2 + Bx + C = 0. Set arguments (A, B, C):");
            try
            {
                double[] arguments = Console.ReadLine().Split().Select(double.Parse).ToArray();
                QuadraticEquation qe = new QuadraticEquation(arguments[0], arguments[1], arguments[2]);
                qe.Show();
                qe.Calculate();
                Console.ReadKey();
            }
            catch (SystemException e)
            {
                Console.WriteLine("Input arguments error.");
                Console.ReadKey();
            }
        }
    }
}
