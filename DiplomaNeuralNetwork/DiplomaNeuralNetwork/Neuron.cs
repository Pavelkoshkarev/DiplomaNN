using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaNeuralNetwork
{
    class Neuron
    {
        public Neuron(double[] inputs, double[] weights, NeuronType type)
        {
            _type = type;
            _weights = weights;
            _inputs = inputs;
        }
        private NeuronType _type;
        private double[] _weights;
        private double[] _inputs;
        public double[] Weights
        {
            get { return _weights; }
            set { _weights = value; }
        }
        public double[] Inputs
        {
            get { return _inputs; }
            set { _inputs = value; }
        }
        public double Output
        {
            get { return Activator(_inputs, _weights); }
        }
        private double Activator(double[] i, double[] w)//преобразования
        {
            double sum = 0;
            for (int l = 0; l < i.Length; ++l)
                sum += i[l] * w[l];//Линейная комбинация весов и входов
            return Math.Pow(1 + Math.Exp(-sum), -1);//функция активации
        }
        public double Derivativator(double outsignal) => outsignal * (1 - outsignal);//dE/dw для сигмоиды
        public double Gradientor(double error, double dif, double g_sum) => (_type == NeuronType.Output) ? error * dif : g_sum * dif;//g_sum - это сумма градиентов следующего слоя

    }
}
