using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaNeuralNetwork
{
    class Network
    {
        //Все слои сети
        public InputLayer input_layer = new InputLayer();
        public HiddenLayer hidden_layer = new HiddenLayer(4, 3, NeuronType.Hidden, nameof(hidden_layer));
        public OutputLayer output_layer = new OutputLayer(3, 4, NeuronType.Output, nameof(output_layer));
        //массив для хранения выхода сети
        public double[] fact = new double[3];
        //ошибка одной итерации обучения
        double GetMSE(double[] errors)
        {
            double sum = 0;
            for (int i = 0; i < errors.Length; ++i)
                sum += Math.Pow(errors[i], 2);
            return 0.5d * sum;
        }
        //ошибка эпохи
        double GetCost(double[] mses)
        {
            double sum = 0;
            for (int i = 0; i < mses.Length; ++i)
                sum += mses[i];
            return (sum / mses.Length);
        }

        /// <summary>
        /// Обучение сети
        /// </summary>
        /// <param name="net"></param>
        public static void Train(Network net)
        {
            const double threshold = 0.001d;//Порог ошибки
            double[] temp_mses = new double[net.input_layer.Trainset.Length];//Массив для хранения ошибок итераций
            double temp_cost = 0;//Текущее значение ошибки по эпохе
            do
            {
                for (int i = 0; i < net.input_layer.Trainset.Length; ++i)
                {
                    //Прямой проход
                    net.hidden_layer.Data = net.input_layer.Trainset[i].Item1;
                    net.hidden_layer.StraightPass(null, net.output_layer);
                    net.output_layer.StraightPass(net, null);
                    //Вычисление ошибки по итерации
                    double[] errors = new double[net.input_layer.Trainset[i].Item2.Length];
                    for (int x = 0; x < errors.Length; ++x)
                        errors[x] = net.input_layer.Trainset[i].Item2[x] - net.fact[x];
                    temp_mses[i] = net.GetMSE(errors);
                    //Обратный проход и коррекция весов
                    double[] temp_gsums = net.output_layer.BackwardPass(errors);
                    net.hidden_layer.BackwardPass(temp_gsums);
                }
                temp_cost = net.GetCost(temp_mses);//вычисление ошибки по эпохе
                Console.WriteLine($"{temp_cost}");
            } while (temp_cost > threshold);
            //загрузка скорректированных весов в "память"
            net.hidden_layer.WeightInitialize(MemoryMode.SET, nameof(hidden_layer));
            net.output_layer.WeightInitialize(MemoryMode.SET, nameof(output_layer));
        }
        /// <summary>
        /// Тестирование сети
        /// </summary>
        /// <param name="net"></param>
        public static void Test(Network net)
        {
            for (int i = 0; i < net.input_layer.Trainset.Length; ++i)
            {
                net.hidden_layer.Data = net.input_layer.Trainset[i].Item1;
                net.hidden_layer.StraightPass(null, net.output_layer);
                net.output_layer.StraightPass(net, null);
                for (int j = 0; j < net.fact.Length; ++j)
                    Console.WriteLine($"{net.fact[j]}");
                Console.WriteLine();
            }
        }

        public static void TestWords(Network net)
        {
            for (int i = 0; i < net.input_layer.Trainset.Length; ++i)
            {
                net.hidden_layer.Data = net.input_layer.Trainset[i].Item1;
                net.hidden_layer.StraightPass(null, net.output_layer);
                net.output_layer.StraightPass(net, null);
                for (int j = 0; j < net.fact.Length; ++j) 
                    Console.WriteLine($"{net.fact[j]}");
                Decision(net);
                Console.WriteLine();
            }
        }

        public static void Decision(Network net)
        {
            int c = 0;
            for (int j = 0; j < net.fact.Length - 1; ++j)
            {
                if (net.fact[j + 1] > net.fact[j]) c = j + 1;
            }
            if (net.fact.Max() < 0.1) c = -1;
            switch(c)
            {
                case 0:
                    Console.WriteLine("Attack");
                    break;
                case 1:
                    Console.WriteLine("Hide");
                    break;
                case 2:
                    Console.WriteLine("Run");
                    break;
                case -1:
                    Console.WriteLine("Nothing");
                    break;

            }
        }
        

    }
}

