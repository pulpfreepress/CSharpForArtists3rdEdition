using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MergeSort
{
    /// <summary>
    /// Sorts integers using the Merge Sort algorithm
    /// </summary>
    class MergeSort
    {

        #region PrivateFields

        private static int[] _mainArray;
        private static FileInfo _inputFile;
        private static FileInfo _outputFile;
        private static int _callCount = 0;

        #endregion





        static public void Split(int[] numbers, int left, int right)
        {
            Console.WriteLine("Split()...");
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                Split(numbers, left, mid);
                Split(numbers, (mid + 1), right);

                Merge(numbers, left, (mid + 1), right);
            }
        }


        static public void Merge(int[] numbers, int left, int mid, int right)
        {
            Console.WriteLine("Merge()...");
            int[] temp = new int[numbers.Length];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }





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
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }


        /// <summary>
        /// Takes the name of a file containing comma-delimited integers
        /// </summary>
        /// <param name="args">Filename</param>
        static void Main(string[] args)
        {
            if (args.Length < 1) throw new ArgumentException("Must supply filename argument!");
            _inputFile = new FileInfo(args[0]);
            ParseInputFile(_inputFile);

            foreach (int i in _mainArray)
            {
                Console.Write(i + ",");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Split(_mainArray, 0, _mainArray.Length-1);

            stopwatch.Stop();
      
            Console.WriteLine("\n-------------------------------------------------");
            

            foreach (int i in _mainArray)
            {
                Console.Write(i + ",");
            }

            Console.WriteLine("Sort Time in miliseconds: " + stopwatch.ElapsedMilliseconds);

            Console.ReadKey();
        }

    }
}
