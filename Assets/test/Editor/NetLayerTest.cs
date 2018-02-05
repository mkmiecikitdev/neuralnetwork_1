using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NetLayerTest {

    [Test]
    public void ShouldReturnCorrectSizeAndInputsLength() {
        NetLayer netLayer = new NetLayer(10, 8, -5, 5, Config.ACTIVATION_FUNC);
        Assert.AreEqual(10, netLayer.Neurons.Length);

        for (int i = 0; i < netLayer.Neurons.Length; ++i)
        {
            Assert.AreEqual(9, netLayer.Neurons[i].WeightsVector.Values.Length);
        }
    }

    [Test]
    public void ShouldReturnCorrectResponse() {
        NetVector v1 = NetVector.FromValues(new double[] {1, 2 ,3});
        Neuron n1 = new Neuron(v1, ActivationFunctions.Linear);

        NetVector v2 = NetVector.FromValues(new double[] {4, 5 ,6});
        Neuron n2 = new Neuron(v2, ActivationFunctions.Linear);

        NetLayer layer = new NetLayer(new Neuron[] { n1, n2 });

        NetVector v3 = NetVector.FromValues(new double[] {7, 8}); // -1 + 14 + 24 ; -4 + 35 + 48

        double[] r = layer.Response(v3).Values;

        Assert.AreEqual(2, r.Length);
        Assert.AreEqual(37, r[0], 0.01);
        Assert.AreEqual(79, r[1], 0.01);
    }
	
}
