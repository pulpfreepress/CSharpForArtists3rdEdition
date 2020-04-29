using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace IntFileGenerator
{
    public class IntFileGenerator
    {
        




        static void Main(string[] args)
        {

            if(args.Length < 1)
            {
                throw new ArgumentException("Must supply two arguments: 1) a file name, and 2) number of integers to generate!");
            }
            else
            {
                IntFileGenerator.GenerateIntFile(args[0], Int32.Parse(args[1]));
            }

        }


        public static void GenerateIntFile(string fileName, int numberOfIntsToGenerate)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);

            try
            {
                Random random = new Random(DateTime.Now.Millisecond);
                int[] intArray = new int[numberOfIntsToGenerate];
                for (int i = 0; i < intArray.Length; i++)
                {
                    intArray[i] = random.Next();
                }

                StreamWriter writer = new StreamWriter(fs);
                for(int i = 0; i < intArray.Length; i++)
                {
                    writer.Write(intArray[i]);
                    if(i < intArray.Length - 1)
                    {
                        writer.Write(",");
                    }
                }

                writer.Flush();

            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if(fs != null)
                {
                    fs.Close();
                }
            }
      

        }
    }
}
