using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DiplomaNeuralNetwork
{
    abstract class Layer
    {
        /// <summary>
        /// Конструктор слоя
        /// </summary>
        /// <param name="non">Число нейронов в слое</param>
        /// <param name="nopn">Число нейронов в предыдущем слое</param>
        /// <param name="nt">Тип нейрона (Hiden или Output)</param>
        /// <param name="type"></param>
        protected Layer(int non, int nopn, NeuronType nt, string type)
        {
            numberOfNeurons = non;
            numerOfPreviousNeurons = nopn;
            Neurons = new Neuron[non];
            double[,] Weights = WeightInitialize(MemoryMode.GET, type);
            for (int i = 0; i < non; ++i)
            {
                double[] temp_weights = new double[nopn];
                for (int j = 0; j < nopn; ++j)
                    temp_weights[j] = Weights[i, j];
                Neurons[i] = new Neuron(null, temp_weights, nt);//про подачу null на входы ниже
            }
        }
        protected int numberOfNeurons; //Число нейронов текущего слоя
        protected int numerOfPreviousNeurons; //Число нейронов предыдущего слоя
        protected const double learningRate = 0.5d; //Шаг обучения (Скорость обучения)
        Neuron[] _neurons;
        public Neuron[] Neurons
        {
            get { return _neurons; }
            set { _neurons = value; }
        }

        public double[] Data
        {
            set
            {
                for (int i = 0; i < Neurons.Length; ++i)
                    Neurons[i].Inputs = value;
            }
        }

        /// <summary>
        /// Функция для сохранения или загрузки весов
        /// </summary>
        /// <param name="mm">Параметр для сохранения или загрузки</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public double[,] WeightInitialize(MemoryMode mm, string type)
        {
            double[,] _weights = new double[numberOfNeurons, numerOfPreviousNeurons];
            Console.WriteLine($"{type} weights are being initialized...");
            XmlDocument memory_doc = new XmlDocument();
            memory_doc.Load($"{type}_memory.xml");
            XmlElement memory_el = memory_doc.DocumentElement;
            switch (mm)
            {
                case MemoryMode.GET:
                    for (int l = 0; l < _weights.GetLength(0); ++l)
                        for (int k = 0; k < _weights.GetLength(1); ++k)
                            _weights[l, k] = double.Parse(memory_el.ChildNodes.Item(k + _weights.GetLength(1) * l).InnerText.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                    break;
                case MemoryMode.SET:
                    for (int l = 0; l < Neurons.Length; ++l)
                        for (int k = 0; k < numerOfPreviousNeurons; ++k)
                            memory_el.ChildNodes.Item(k + numerOfPreviousNeurons * l).InnerText = Neurons[l].Weights[k].ToString();
                    break;
                case MemoryMode.DROP:
                    for (int l = 0; l < Neurons.Length; ++l)
                        for (int k = 0; k < numerOfPreviousNeurons; ++k)
                            memory_el.ChildNodes.Item(k + numerOfPreviousNeurons * l).InnerText = "0";
                    break;
            }
            memory_doc.Save($"{type}_memory.xml");
            Console.WriteLine($"{type} weights have been initialized...");
            return _weights;
        }
        abstract public void StraightPass(Network net, Layer nextLayer);
        abstract public double[] BackwardPass(double[] stuff);

    }
}
