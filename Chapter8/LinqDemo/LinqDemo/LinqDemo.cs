using System;
using System.Collections.Generic;
using System.Linq;


namespace LinqDemo
{
    public class LinqDemo
    {

        static void Main(string[] args)
        {
            // Declare and initialize an array of 100 doubles
            double[] double_array = new double[100];
            Random random = new Random();

            // Initialize each array element with a random double value
            for (int i = 0; i < double_array.GetLength(0); i++)
            {
                double_array[i] = random.NextDouble() * 100;
            }

            // Print the array of doubles as a nicely formatted grid
            for (int i = 1; i <= double_array.GetLength(0); i++)
            {
                Console.Write(double_array[i - 1].ToString("00.00") + " ");

                if ((i % 10) == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine("--------------------------------------------------------------");

            // Create the query using LINQ. Sort results in ascending order
            IEnumerable<double> query = double_array.AsQueryable().Where(n => n <= 10).OrderByDescending(n => n);
                                        
            // Write the results of the query to the console
            foreach (double d in query)
            {
                Console.Write(d.ToString("00.00") + " ");
            }

            Console.WriteLine("\n");

        } // end Main
    } // end class
} // end namespace
