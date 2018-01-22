using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum MemoryMode { GET, SET }
enum NeuronType { Hidden, Output }


namespace DiplomaNeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Network net = new Network();
            Network.Train(net);
            Network.TestWords(net);
            Console.ReadKey();
        }

        

    }
}
