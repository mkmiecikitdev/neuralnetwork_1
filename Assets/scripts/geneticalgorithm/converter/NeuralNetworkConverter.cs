using System.Collections;
using System.Collections.Generic;

public class NeuralNetworkConverter : INeuralNetworkConverter  {

    public List<List<double>> ToGenotypes(List<NeuralNetwork> networks) {
        List<List<double>> genotypes = new List<List<double>>();

        foreach (NeuralNetwork n in networks)
        {
            genotypes.Add(this.ToGenotype(n));
        }

        return genotypes;
    }

    public List<NeuralNetwork> ToNetworks(List<List<double>> genotypes, int[] topology) {
        List<NeuralNetwork> networks = new List<NeuralNetwork>(genotypes.Count);

        foreach (List<double> g in genotypes)
        {
            networks.Add(this.ToNetwork(g, topology));
        }

        return networks;
    }


    private List<double> ToGenotype(NeuralNetwork network) {
        List<double> genotype = new List<double>();

        NetLayer[] layers = network.Layers;
        foreach (NetLayer layer in layers)
        {
            Neuron[] neurons = layer.Neurons;
            foreach (Neuron neuron in neurons)
            {
                genotype.AddRange(neuron.WeightsVector.Values);
            }
        }

        return genotype;
    }

    private NeuralNetwork ToNetwork(List<double> genotype, int[] topology) {
        int index = 0;

        NetLayer[] layers = new NetLayer[topology.Length - 1];

        for (int i = 1; i < topology.Length; ++i)
        {
            Neuron[] neurons = new Neuron[topology[i]];
            for (int j = 0; j < neurons.Length; ++j)
            {
                double[] weight = new double[topology[i - 1] + 1];
                for (int k = 0; k < weight.Length; ++k)
                {
                    weight[k] = genotype[index++];
                }

                neurons[j] = new Neuron(NetVector.FromValues(weight), Config.ACTIVATION_FUNC);
            }

            layers[i - 1] = new NetLayer(neurons);
        }

        return new NeuralNetwork(layers);

    }
	
}
