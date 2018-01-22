using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaNeuralNetwork
{
    class HiddenLayer: Layer
    {
        /// <summary>
        /// Конструктор слоя
        /// </summary>
        /// <param name="non">Число нейронов в слое</param>
        /// <param name="nopn">Число нейронов в предыдущем слое</param>
        /// <param name="nt">Тип нейрона (Hiden или Output)</param>
        /// <param name="type"></param>
        public HiddenLayer(int non, int nopn, NeuronType nt, string type) : base(non, nopn, nt, type) { }
        public override void StraightPass(Network net, Layer nextLayer)
        {
            double[] hidden_out = new double[Neurons.Length];
            for (int i = 0; i < Neurons.Length; ++i)
                hidden_out[i] = Neurons[i].Output;
            nextLayer.Data = hidden_out;
        }
        public override double[] BackwardPass(double[] gr_sums)
        {
            double[] gr_sum = null;
            for (int i = 0; i < numberOfNeurons; ++i)
                for (int n = 0; n < numerOfPreviousNeurons; ++n)
                    Neurons[i].Weights[n] += learningRate * Neurons[i].Inputs[n] * Neurons[i].Gradientor(0, Neurons[i].Derivativator(Neurons[i].Output), gr_sums[i]);//коррекция весов
            return gr_sum;
        }
    }
}
