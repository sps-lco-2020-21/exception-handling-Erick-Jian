using Exceptions.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.App
{
    class Program
    {
        /// <summary>
        /// Problems with ToDouble
        ///     Before we have seen that the static methods in the built in static class System.Convert are able to 
        ///         convert values of one type to values of another type.
        ///     Read the official docs for System.Convert.ToDouble.There are several overloads of the ToDouble method. 
        ///         Which exceptions can occur by converting a string to a double?
        ///     Write a Console.App which triggers these exceptions.
        ///     Finally, supply handlers of the exceptions. The handlers should report the problem on the Console 
        ///         and then continue. 
        /// Extend Triangle
        ///     Revisit your Triangle class from way back when. 
        ///     Create a TriangleException class and, instead of having a IsValid property return false, 
        ///         validate the data in the constructor and the setters to forbid illegal triangles being generated.
        /// </summary>

        static void Main(string[] args)
        {
            Trigger_Exceptions();
            
            //Division(25, 5);
            //Division(25, 0);

            //SetExamScore(-2, 72);
            //SetExamScore(5, 0);

            Console.ReadKey();
        }

        static double Trigger_Exceptions()
        {
            /// Exceptions includes: 
            ///     FormatException
            ///         value is not in an appropriate format for a Double type.
            ///     InvalidCastException
            ///         value does not implement the IConvertible interface.
            ///     OverflowException
            ///         value represents a number that is less than MinValue or greater than MaxValue.

            int testvalue1 = 1;
            char testvalue2 = '2';
            int supermegalargenumber = (int)Math.Pow(11, 308);

            Console.WriteLine("Which type of Exception? [ Format | Casting | Overflow ]:  ");
            string ExceptionType = Console.ReadLine();

            switch (ExceptionType)
            {
                case "Format":
                    try
                    { return Convert.ToDouble(testvalue1); }
                    catch (FormatException FE)
                    { Console.WriteLine($"Exception is known as {FE}"); }
                    finally
                    { Console.WriteLine("I will convert it into a double for you"); }
                    break;
                case "Casting":
                    try
                    { Convert.ToDouble(testvalue2); }
                    catch (InvalidCastException ICE)
                    { Console.WriteLine($"Exception is known as {ICE}"); }
                    finally
                    { Console.WriteLine("I will convert into a double for you"); }
                    break;
                case "Overflow":
                    // double MaxValue = 1.7976931348623157E+308
                    try
                    { Convert.ToDouble(supermegalargenumber); }
                    catch (OverflowException OE)
                    //value represents a number that is less than MinValue or greater than MaxValue.
                    {
                        Console.WriteLine($" Exception is known as {OE}: i.e. double can't be larger than {0}", double.MaxValue);
                        Console.WriteLine(" viz. {0} > {1:E}", supermegalargenumber, double.MaxValue);
                    }
                    finally
                    { Console.WriteLine("Try it again !!!"); }
                    break;
            }
            return Convert.ToDouble(testvalue1);
        }

        static void Division(int num1, int num2)
        {
            int result = 0;
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }
            finally
            {
                Console.WriteLine("Result: {0}", result);
            }
        }

        static void SetExamScore(int score, int total)
        {
            try
            {
                Console.WriteLine("{0}/{1} = {2}%", new ExamScore(score, total).Percentage);
            }
            catch (ExamScoreException ese)
            {
                Console.WriteLine("Invalid score: {0}", ese.Message);
            }

        }
    }
}
