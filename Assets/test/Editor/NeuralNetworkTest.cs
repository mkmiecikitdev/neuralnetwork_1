using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NeuralNetworkTest {

    [Test]
    public void ShouldReturnCorrectSizeAndInputs() {
        NeuralNetwork n = new NeuralNetwork(new int[] { 2, 3, 4 });

        Assert.AreEqual(2, n.Layers.Length);

        Assert.AreEqual(3, n.Layers[0].Neurons.Length);
        Assert.AreEqual(4, n.Layers[1].Neurons.Length);

        Assert.AreEqual(3, n.Layers[0].Neurons[0].WeightsVector.Values.Length);
        Assert.AreEqual(4, n.Layers[1].Neurons[0].WeightsVector.Values.Length);
    }
	
    [Test]
    public void ShouldReturnException() {
        NeuralNetwork n = new NeuralNetwork(new int[] { 2, 3, 4 });

        Assert.Throws<System.ArgumentException>(delegate()
            {
                n.Response(new double[] { 1, 2, 3 });
            });



    }

}
