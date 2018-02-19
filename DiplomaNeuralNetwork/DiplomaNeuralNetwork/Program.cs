using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum MemoryMode { GET, SET, DROP }
enum NeuronType { Hidden, Output }


namespace DiplomaNeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Network net = new Network();
            net.input_layer.GetTrainDataFromFile(6,1);
            //Network.Train(net);
            Network.TestWords(net);
            Console.ReadKey();
        }

        

    }
}
