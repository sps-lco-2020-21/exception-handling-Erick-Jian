using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleExceptions.Lib;

namespace TriangleExceptionApp.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle t1 = new Triangle(3, 4, 5);    // t1 is an instatiation of the class Triangle
            Triangle t2 = new Triangle(2, 10, 10);

            Console.WriteLine("A triangle has {0} sides", t1);
            Debug.Assert(t2.Perimeter() == 22, "program error");
            Debug.Assert(t1.IsCongruent(t2) == false, "IsCongruent function error");

            // static functions are created on the class not the instances (variables)

            Debug.Assert(t1.Area() == 3.6, "Area method is wrong");

            if (t1.IsRightAngled())
            {
                Console.WriteLine("RT triangle");
            }

            while (Console.ReadKey().Key != ConsoleKey.End)
                Console.WriteLine("bruh");
        }
    }
}
