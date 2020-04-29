using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DumbSort
{
    public class DumbSort
    {

        private static int[] _mainArray;
        private static FileInfo _inputFile;



        private static void ParseInputFile(FileInfo file)
        {
            try
            {
                StreamReader streamReader = new StreamReader(file.OpenRead());
                string inputString = streamReader.ReadToEnd();
                string[] integerStringArray = inputString.Split(',');
                _mainArray = new int[integerStringArray.Length];
                for (int i = 0; i < integerStringArray.Length; i++)
                {
                    _mainArray[i] = Int32.Parse(integerStringArray[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public static void Sort()
        {
            int innerloop = 0;
            int outerloop = 0;
            int swaps = 0;

            for (int i = 0; i < _mainArray.Length; i++)
            {
                Console.Write(_mainArray[i] + " ");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < _mainArray.Length; i++)
            {
                outerloop++;
                for (int j = 1; j < _mainArray.Length; j++)
                {
                    innerloop++;
                    if (_mainArray[j - 1] > _mainArray[j])
                    {
                        int temp = _mainArray[j - 1];
                        _mainArray[j - 1] = _mainArray[j];
                        _mainArray[j] = temp;
                        swaps++;
                    }
                }
            }

            stopwatch.Stop();

            Console.WriteLine("\n-----------------------------------------------------------------");

            for (int i = 0; i < _mainArray.Length; i++)
            {
                Console.Write(_mainArray[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Sort time in milliseconds: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Outer loop executed " + outerloop + " times.");
            Console.WriteLine("Inner loop executed " + innerloop + " times.");
            Console.WriteLine(swaps + " swaps completed.");

        }


        public static void Main(String[] args)
        {

            if (args.Length < 1) throw new ArgumentException("Must supply filename argument!");
            _inputFile = new FileInfo(args[0]);
            ParseInputFile(_inputFile);
            Sort();
            
        }
    }
}
