using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron {

    private const double BIAS = -1.0;

    private NetVector weightsVector;
    private ActivationFunctions.Func activationFunc;

    public NetVector WeightsVector {
        get {
            return this.weightsVector.Clone;
        }
    }

    public Neuron(NetVector weightsVector, ActivationFunctions.Func activationFunc) {
        this.weightsVector = weightsVector;
        this.activationFunc = activationFunc;
    }

    public Neuron(int size, double weightMin, double weightMax, ActivationFunctions.Func activationFunc) {
        this.weightsVector = NetVector.Randomize(size + 1, weightMin, weightMax);
        this.activationFunc = activationFunc;
    }

    public Neuron Clone {
        get {
            return new Neuron(WeightsVector, this.activationFunc);
        }
    }

    public double Response(NetVector inputVector) {
        return this.activationFunc(this.weightsVector.Scalar(inputVector, BIAS));
    }
}




