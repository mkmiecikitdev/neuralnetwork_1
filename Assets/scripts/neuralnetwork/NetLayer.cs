using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetLayer {

    private Neuron[] neurons;

    public NetLayer(int size, int inputsCount, double randMin, double randMax, ActivationFunctions.Func activationFunc) {
        this.neurons = new Neuron[size];
        for (int i = 0; i < size; ++i) {
            neurons[i] = new Neuron(inputsCount, randMin, randMax, activationFunc);
        }
    }

    public NetLayer(Neuron[] neurons) {
        this.neurons = neurons;
    }

    public Neuron[] Neurons {
        get {
            Neuron[] copied = new Neuron[this.neurons.Length];
            for (int i = 0; i < copied.Length; ++i) {
                copied[i] = this.neurons[i].Clone;
            }
            return copied;
        }
    }

    public NetLayer Clone{
        get {
            return new NetLayer(Neurons);
        }
    }

    public NetVector Response(NetVector inputVector) {
        int layerSize = this.neurons.Length;

        double[] outputs = new double[layerSize];

        for (int i = 0; i < layerSize; ++i) {
            outputs[i] = neurons[i].Response(inputVector);
        }

        return NetVector.FromValues(outputs);      
    }

}
