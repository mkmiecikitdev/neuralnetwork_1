using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NeuronTest {

    [Test]
    public void ShouldReturnSizePlusOne() {
        Neuron n = new Neuron(5, -5, 5, Config.ACTIVATION_FUNC);
        Assert.AreEqual(6, n.WeightsVector.Values.Length);
    }

    [Test]
    public void ShouldReturnCorrectResponse() {
        NetVector v = NetVector.FromValues(new double[]{1.1, 2.2, 3.3, 4.4, 5.5});
        Neuron n = new Neuron(v, ActivationFunctions.Linear);
        NetVector v2 = NetVector.FromValues(new double[]{2.2, 3.3, 4.4, 5.5});
        double result = n.Response(v2);
        Assert.AreEqual(64.24, result, 0.01);
    }
}
