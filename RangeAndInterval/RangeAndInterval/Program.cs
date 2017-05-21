using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Starting number for a range between 1 to 1000");
                int minimum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Ending number for a range between 1 to 1000");
                int maximum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Provide an interval for cumulative calculation");
                int interval = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Choose an arithmetic operation");
                Console.WriteLine("1 for Addtion");
                Console.WriteLine("2 for Substraction");
                Console.WriteLine("3 for Multiplication");
                Console.WriteLine("4 for Division");
                ArithmeticOperators arithmeticOperator = (ArithmeticOperators)(Convert.ToInt32(Console.ReadLine()));
                IntervalCalc(minimum, maximum, interval, arithmeticOperator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
        public static void IntervalCalc(int minimum, int maximum, int interval, ArithmeticOperators operators)
        {
            //Check Starting and Ending Number are with in range
            IsWithinRange(minimum, true);
            IsWithinRange(maximum, false);

            //Other mandatory validations
            Validations(minimum, maximum, interval);

            //Build the list of numbers to perform arithmetic operations
            List<double> numbers = GetNumbersToCalculate(minimum, maximum, interval);

            //Perform arithemetic operation
            double result = GetComputedValue(operators, numbers);

            Console.WriteLine("The result is " + result);
            Console.ReadLine();
        }
        private static void Validations(int minimum, int maximum, int interval)
        {
            //Starting and Ending number should not be same
            if (minimum == maximum)
            {
                throw new ArgumentOutOfRangeException("Starting and Ending number can not be same");
            }

            if (interval < minimum || interval > maximum)
            {
                throw new ArgumentOutOfRangeException("Interva should be bewtween Starting and Ending number");
            }

            //The Ending should be greater than sum of starting and interval Value
            if ((minimum + interval) > maximum)
            {
                throw new ArgumentOutOfRangeException("Sum of Starting number and Interval should not exceed ending number");
            }
        }
        private static double GetComputedValue(ArithmeticOperators operators, List<double> numbers)
        {
            Double result = 0;
            switch (operators)
            {
                case ArithmeticOperators.Addition:
                    result = numbers.Aggregate((a, x) => a + x);
                    break;
                case ArithmeticOperators.Substraction:
                    result = numbers.Aggregate((a, x) => a - x);
                    break;
                case ArithmeticOperators.Multiplication:
                    result = numbers.Aggregate((a, x) => a * x);
                    break;
                case ArithmeticOperators.Division:
                    result = numbers.Aggregate((a, x) => a / x);
                    break;
                default:
                    break;
            }

            return result;
        }
        private static List<double> GetNumbersToCalculate(int minimum, int maximum, int interval)
        {
            List<Double> numbers = new List<Double>();
            Double iterationValue = minimum;
            for (Double i = iterationValue; iterationValue < maximum; iterationValue++)
            {
                Double valueToCalculate = iterationValue + interval - 1;
                numbers.Add(valueToCalculate);
                iterationValue = valueToCalculate;
            }

            return numbers;
        }
        public static void IsWithinRange(int value, bool IsMinimum)
        {
            if (value < 1 || value > 1000)
            {
                if (IsMinimum)
                {
                    throw new ArgumentOutOfRangeException("Minimum value should be between 1 and 1000");
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Maximum value should be between 1 and 1000");
                }
            }
        }
        public enum ArithmeticOperators
        {
            Addition = 1,
            Substraction = 2,
            Multiplication = 3,
            Division = 4
        }
    }
}
