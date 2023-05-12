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
        private int id; //고유남바
        private double outputSignal; //최종 출력 신호

        List<Neuron> connectedNeuronList; //입력으로 들어오는 연결된 뉴런들

        Dictionary<Neuron, double> inputSignalTable; //연결강도
        Dictionary<Neuron, double> inputWeightTable; //연결강도
        Dictionary<Neuron, int> routingTable; //현재 연결 정책 1이면 강화, -1이면 약화, 0이면 유지

        Random random;

        double learningRate = 0.03; //학습률
        double bias = 1;

        public Neuron(List<Neuron> connectedNeuronList, double learningRate) 
        {
            this.learningRate = learningRate;
            this.connectedNeuronList = connectedNeuronList;
            random = new Random();
        }

        public int GetId() { return id; }   
        public double GetOutputSignal() {  return outputSignal; }

        public void InitConnecttion()
        {
            inputWeightTable.Clear();
            routingTable.Clear();
        }

        public void AddConnection(Neuron neuron)
        {

            if(!connectedNeuronList.Contains(neuron))
            {
                double weight = random.NextDouble();

                connectedNeuronList.Add(neuron);
                inputWeightTable.Add(neuron, weight);
                inputSignalTable.Add(neuron, 0);   
                routingTable.Add(neuron, 0);
            }

           
        }

        public void InitWeight()
        {
            foreach(Neuron key in inputWeightTable.Keys)
            {
                inputWeightTable[key] = random.NextDouble();
            }

            bias = random.NextDouble();
        }

        public double Processing()
        {
            double sum = 0;
            foreach (Neuron key in inputWeightTable.Keys)
            {
                sum = sum + inputWeightTable[key] * inputSignalTable[key];
            }
            sum = sum + bias;

            this.outputSignal = Sigmoid(sum);

            return this.outputSignal;   
        }

        public void UpdateWeight()
        {
            foreach (Neuron key in inputWeightTable.Keys)
            {
                double w = inputWeightTable[key];
                int r = routingTable[key];

                w = w + (learningRate * r);


                inputWeightTable[key] = w;
            }
        }

        public double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}
