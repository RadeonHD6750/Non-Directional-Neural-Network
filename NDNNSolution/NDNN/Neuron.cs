using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NDNN
{
    public class Neuron
    {
        private int id;
        private double outputSignal;

        Dictionary<int, double> inputSignalTable;
        Dictionary<int, double> inputWeightTable;

        public Neuron(List<int> connectedNeuronList) 
        {
            
        }
    }
}
