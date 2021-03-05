using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleExceptions.Lib
{
    // properties don't take arguments: wrap return with "get()"
    
    // interface: abstract classes: abstract & public
    interface IShapes
    {
        /// <summary>
        /// QUESTION:  ↓↓↓ where should this be to enlist different shapes ?
        /// </summary>
        List<IShapes> shapes = new List<IShapes>();
        double PERIMETER { get;  }
        double AREA { get;  }
        List<int> SIDES { get;  }
    }

    // reason for writing a class is encapsulation -- hiding
    public class Triangle : IShapes, IEquatable<Triangle>, IComparable<Triangle>
    {
        const int NUMBEROFSIDES = 3;    // you can't change the number of sides of a triangle

        int sideA, sideB, sideC;        // they are privates
        double angleA, angleB, angleC;

        // get from interface:

        public double PERIMETER     {   get {   return sideA + sideB + sideC; } }

        public double AREA      {   get {   return 0.5 * sideA * sideB * Math.Sin(angleC); }    }

        public List<int> SIDES
        {
            get {
                List<int> SIDES = new List<int> { sideA, sideB, sideC };
                return SIDES;
            }
        }

        public bool Equals(Triangle other){
            return (PERIMETER.Equals(other.PERIMETER));
        }

        public bool AreaEquals(Triangle other){
            return (AREA == other.AREA);
        }

        public int AreaCompareTo(Triangle other){
            return AREA.CompareTo(other.AREA);
        }
        public int PeriCompareTo(Triangle other)
        {
            return PERIMETER.CompareTo(other.PERIMETER);
        }


        // constructors: Triangle Types

        public Triangle(int a, int b, int c)           // Normal Triangle: takes in 3 values
        {
            sideA = a;
            sideB = b;
            sideC = c;
            angleA = Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c));
            angleB = Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c));
            angleC = Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b));
            if (sideA <= 0 || sideB <= 0 || sideC <= 0 || angleA <= 0 || angleB <= 0 || angleC <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (a + b < c || c + a < b || c + b < a){
                throw new ArithmeticException();
            }

            Debug.Assert((Math.Sin(angleA) / sideA - Math.Sin(angleB) / sideB) < double.Epsilon && (Math.Sin(angleB) / sideB - Math.Sin(angleC) / sideC) < double.Epsilon, "parameters error");
                    // sine rule check
        }
            
        public Triangle(int e) : this(e, e, e)          // Equilateral: duplicates "e" × 3
        // this: refers to the current object that the values function are taken in
        {                                                   // only takes in ONE value
            if (e <= 0)
                throw new ArgumentOutOfRangeException();

            Console.WriteLine("This triangle is equilateral");
        }

        public Triangle(int i, int o) : this(i, i, o)  // Isoceles: ducplicates "i" × 2, "o" × 1
        {                                                   // only takes in TWO values
            if (i <= 0 || o <= 0)
                throw new ArgumentOutOfRangeException("Come on, sides are always positive");

            Console.WriteLine("This triangle is isoceles");
        }

        // Parameters

        public int Perimeter()      {   return (sideA + sideB + sideC); }
        // it's already in the instance of triangle no need to take in triangle

        public double Area()    {   return (Math.Sin(angleA) * sideB * sideC);  }

        public List<double> ThreeSides()
        {
            List<double> listofAngles = new List<double>();

            listofAngles.Add(angleA * Math.PI / 180);
            listofAngles.Add(angleB * Math.PI / 180);
            listofAngles.Add(angleC * Math.PI / 180);
            return listofAngles;
        }

        public List<double> ThreeAngles()
        {
            List<double> listofAngles = new List<double>();

            Console.WriteLine("In RAD[1] or DEG[2] ?");
            string option = Console.ReadLine();

            if (option == "1")
            {
                listofAngles.Add(angleA * Math.PI / 180);
                listofAngles.Add(angleB * Math.PI / 180);
                listofAngles.Add(angleC * Math.PI / 180);
            }
            else if (option == "2")
            {
                listofAngles.Add(angleA);
                listofAngles.Add(angleB);
                listofAngles.Add(angleC);
            }
            return listofAngles;
        }

        // Features

        public bool IsRightAngled(){
            return (sideA * sideA == sideB * sideB + sideC * sideC || sideB * sideB == sideA * sideA + sideC * sideC || sideC * sideC == sideA * sideA + sideB * sideB);
        }

        public bool IsIsoceles(){
            return (sideA == sideB || sideB == sideC || sideC == sideA);
        }

        public bool IsEquilateral(){
            return (sideA == sideB && sideB == sideC);
        }

        public bool IsCongruent(Triangle two){
            return (sideA == two.sideA && sideB == two.sideB && sideC == two.sideC);
        }

        public int CompareTo(Triangle other)
        {
            throw new NotImplementedException();
        }
    }

    public class Circle: IShapes, IEquatable<Circle>
    {
        double x_CO, y_CO, RADIUS;

        public double PERIMETER {   get { return CircleCircum(); } }

        public double AREA  {   get { return CircleArea(); }  }

        public List<int> SIDES => throw new NotImplementedException();

        public bool Equals(Circle other){
            return (AREA == other.AREA);
        }

        public Circle(double x_co, double y_co, double r)   // Question: is this part called a constructor
        {
            x_CO = x_co;        // of centre
            y_CO = y_co;        // of centre
            RADIUS = r;

            if (RADIUS <= 0)
                throw new ArgumentOutOfRangeException();
        }

        public double CircleArea()  {   return (Math.Pow(RADIUS, 2) * Math.PI);    }

        public double CircleCircum()  {   return (2 * RADIUS * Math.PI);   }

        public bool PointIsIn(double point_x, double point_y)
        {
            return (Math.Pow(Math.Abs(point_x - x_CO), 2) + Math.Pow(Math.Abs(point_y - y_CO), 2) < RADIUS);
        }

        public bool PassThrough(double m, double c) // takes in gradient and y intercept
        {
            bool meets;
            for (double x = x_CO - RADIUS; x <= x_CO + RADIUS; ++x)
            {
                meets = (Math.Pow(m * x + c - y_CO, 2) + Math.Pow(x - x_CO, 2) - Math.Pow(RADIUS, 2) >= 0);
                if (meets != true)
                    return false;
            }
            return true;
        }
    }

    public class Square : IShapes, IEquatable<Square>
    {
        double EDGE, DIAG;
        const int angle_Interior = 90;
        const int angel_In_Sum = 360;

        public bool Equals(Square other){
            return (AREA == other.AREA);
        }

        public Square(double edge)
        {
            EDGE = edge;
            DIAG = edge * Math.Sqrt(2); // diagnal

            if (EDGE <= 0)
                throw new ArgumentOutOfRangeException();

            Debug.Assert(DIAG * DIAG / 2 == EDGE * EDGE, "edge * edge ≡ diagnal * diagnal / 2");
        }

        public double PERIMETER     {   get { return EDGE * 4; }    }

        public double AREA      {   get { return EDGE * EDGE; }    }

        public List<int> SIDES
        {
            get 
            {
                List<int> FourSameSides = new List<int> {};
                int EDGE_int = Convert.ToInt32(EDGE);
                for (int t = 0; t<4; t++)
                {
                    FourSameSides.Add(EDGE_int);
                }
                return FourSameSides;       //  "offer a getter Sides which returns an int"
                                            // what should I return as an int ?
            }
        }
    }

    public class Point
    {
        double X, Y;

        public Point (double x_coor, double y_coor)
        {
            X = x_coor;
            Y = y_coor;
        }

        public bool IsOrigin () {   return (X == 0 && Y == 0);  }
        
        public bool IsOnAxis() 
        {
            if (Y == 0)
                Console.WriteLine("On x axis");
            else if (X == 0)
                Console.WriteLine("On y axis");
            return (X == 0 || Y == 0);
        }
    }
}
