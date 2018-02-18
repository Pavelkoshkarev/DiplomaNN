using System;
using System.Collections.Generic;
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

        
    }
}
