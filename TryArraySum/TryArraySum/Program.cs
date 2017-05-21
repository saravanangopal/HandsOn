using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize different categories of array with value
            Object[] values = new Object[4] { 2, 5, "X", 3 };
            Object[][] jaggedValues = new Object[4][]
            {
                    new Object[3] {5,2,2},
                    new Object[3] {5,"X",4},
                    new Object[3] {8,4,3},
                    new Object[3] {2,5,4},
            };

            Object[][] rectangularArray = new Object[6][]
           {
                    new Object[1] {1},
                    new Object[4] {1,2,5,3},
                    new Object[3] {"X",8,9},
                    new Object[2] {2,8},
                    new Object[3] {2,4,7},
                    new Object[1] {9}
           };

           SumArray(values, jaggedValues, rectangularArray);

        }

        public static void SumArray(object[] singleArray = null, object[][] jaggedArray = null, object[][] rectangularArray = null)
        {
            Int32 singleArraySum = 0;
            Int32 jaggedArraySum = 0;
            Int32 rectangularArraySum = 0;

            singleArraySum = GetSingleArraySum(singleArray, singleArraySum);
            jaggedArraySum = GetJaggedArraySum(jaggedArray, jaggedArraySum);
            rectangularArraySum = GetRectangularSumArray(rectangularArray, rectangularArraySum);

            Console.WriteLine("Single Array Sum = " + singleArraySum);
            Console.WriteLine("Jagged Array Sum = " + jaggedArraySum);
            Console.WriteLine("Rectangular Array Sum = " + rectangularArraySum);
        }

        private static int GetRectangularSumArray(object[][] rectangularArray, int rectangularArrayResult)
        {
            if (rectangularArray != null)
            {
                for (int i = 0; i < rectangularArray.Length; i++)
                {
                    for (int j = 0; j < rectangularArray[i].Length; j++)
                    {
                        //Use try catch to skip the conversion issue for non numeric value
                        try
                        {
                            rectangularArrayResult = rectangularArrayResult + Convert.ToInt32(rectangularArray[i][j]);
                        }
                        catch
                        {

                        }
                    }
                }
            }

            return rectangularArrayResult;
        }

        private static int GetJaggedArraySum(object[][] jaggedArray, int jaggedArrayResult)
        {
            if (jaggedArray != null)
            {
                for (int i = 0; i < jaggedArray.Length; i++)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        //Use try catch to skip the conversion issue for non numeric value
                        try
                        {
                            jaggedArrayResult = jaggedArrayResult + Convert.ToInt32(jaggedArray[i][j]);
                        }
                        catch
                        {

                        }
                    }
                }
            }

            return jaggedArrayResult;
        }

        private static int GetSingleArraySum(object[] singleArray, int result)
        {
            if (singleArray != null)
            {
                foreach (object item in singleArray)
                {
                    //Use try catch to skip the conversion issue for non numeric value
                    try
                    {
                        result = result + Convert.ToInt32(item);
                    }
                    catch
                    {

                    }

                }
            }

            return result;
        }
    }
}
