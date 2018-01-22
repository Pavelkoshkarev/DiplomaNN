using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaNeuralNetwork
{
    class OutputLayer : Layer
    {
        /// <summary>
        /// Конструктор слоя
        /// </summary>
        /// <param name="non">Число нейронов в слое</param>
        /// <param name="nopn">Число нейронов в предыдущем слое</param>
        /// <param name="nt">Тип нейрона (Hiden или Output)</param>
        /// <param name="type"></param>
        public OutputLayer(int non, int nopn, NeuronType nt, string type) : base(non, nopn, nt, type) { }
        public override void StraightPass(Network net, Layer nextLayer)
        {
            for (int i = 0; i < Neurons.Length; ++i)
                net.fact[i] = Neurons[i].Output;
        }
        public override double[] BackwardPass(double[] errors)
        {
            double[] gr_sum = new double[numerOfPreviousNeurons];
            for (int j = 0; j < gr_sum.Length; ++j)//вычисление градиентных сумм выходного слоя
            {
                double sum = 0;
                for (int k = 0; k < Neurons.Length; ++k)
                    sum += Neurons[k].Weights[j] * Neurons[k].Gradientor(errors[k], Neurons[k].Derivativator(Neurons[k].Output), 0);//через ошибку и производную
                gr_sum[j] = sum;
            }
            for (int i = 0; i < numberOfNeurons; ++i)
                for (int n = 0; n < numerOfPreviousNeurons; ++n)
                    Neurons[i].Weights[n] += learningRate * Neurons[i].Inputs[n] * Neurons[i].Gradientor(errors[i], Neurons[i].Derivativator(Neurons[i].Output), 0);//коррекция весов
            return gr_sum;
        }
    }
}
