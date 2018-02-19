using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaNeuralNetwork
{
    class InputLayer
    {
        private (double[], double[])[]
        _trainset = new(double[], double[])[]
        {
            (new double[]{ 0.5, 1, 1}, new double[]{ 1, 0, 0 }),
            (new double[]{ 0.9, 1, 2}, new double[]{ 1, 0, 0 }),
            (new double[]{ 0.8, 0, 1}, new double[]{ 1, 0, 0 }),
            (new double[]{ 0.3, 1, 1}, new double[]{ 0, 1, 0 }),
            (new double[]{ 0.6, 1, 2}, new double[]{ 0, 1, 0 }),
            (new double[]{ 0.4, 0, 1}, new double[]{ 0, 1, 0 }),
            (new double[]{ 0.9, 1, 7}, new double[]{ 0, 0, 1 }),
            (new double[]{ 0.6, 1, 4}, new double[]{ 0, 0, 1 }),
            (new double[]{ 0.1, 0, 1}, new double[]{ 0, 0, 1 }),
            (new double[]{ 0.6, 1, 0}, new double[]{ 0, 0, 0 }),
            (new double[]{ 1.0, 1, 0}, new double[]{ 0, 0, 0 })

            //(new double[]{ 1.0, 0, 1}, new double[]{ 1, 0, 0 }),
            //(new double[]{ 0.9, 1, 3}, new double[]{ 1, 0, 0 }),
            //(new double[]{ 0.3, 0, 8}, new double[]{ 0, 1, 0 }),
            //(new double[]{ 1.0, 1, 8}, new double[]{ 0, 1, 0 }),
            //(new double[]{ 0.1, 0, 0}, new double[]{ 0, 1, 0 })

        };

        public (double[], double[])[]
        Trainset { get => _trainset; }

        public void GetTrainDataFromFile(int inputDataLngth, int resultLngth)
        {
            (double[], double[])[] data;
            string[] lines, input, result;
            char[] separator1 = { '\u0085' };
            char[] separator2 = { '\u0020' };
            try
            {   
                using (StreamReader sr = new StreamReader("DATA.txt"))
                {                  
                    String line = sr.ReadToEnd();
                    lines = line.Split(separator1, StringSplitOptions.RemoveEmptyEntries);
                    data = new(double[], double[])[lines.Length - 1];
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] temp = lines[i].Split(separator2, StringSplitOptions.RemoveEmptyEntries);
                        input = new string[inputDataLngth];
                        result = new string[resultLngth];
                        for (int j = 0; j < inputDataLngth; j++)
                        {
                            
                        }
                        Console.WriteLine(lines[i]);
                    }
                    
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
