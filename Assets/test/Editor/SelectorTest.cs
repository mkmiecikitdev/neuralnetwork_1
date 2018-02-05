using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using ExtensionList;

public class SelectorTest {

    [Test]
    public void ShouldReturnCorrectGenotype() {

        NetVector v1 = NetVector.FromValues(new double[] {1, 2, 3} );
        NetVector v2 = NetVector.FromValues(new double[] {4, 5, 6} );
        NetVector v3 = NetVector.FromValues(new double[] {7, 8, 9} );
        NetVector v4 = NetVector.FromValues(new double[] {10, 11, 12} );

        NetVector v5 = NetVector.FromValues(new double[] {13, 14, 15, 16, 17} );
        NetVector v6 = NetVector.FromValues(new double[] {18, 19, 20, 21, 22} );

        Neuron n1 = new Neuron(v1, Config.ACTIVATION_FUNC);
        Neuron n2 = new Neuron(v2, Config.ACTIVATION_FUNC);
        Neuron n3 = new Neuron(v3, Config.ACTIVATION_FUNC);
        Neuron n4 = new Neuron(v4, Config.ACTIVATION_FUNC);

        Neuron n5 = new Neuron(v5, Config.ACTIVATION_FUNC);
        Neuron n6 = new Neuron(v6, Config.ACTIVATION_FUNC);

        NetLayer l1 = new NetLayer(new Neuron[]{ n1, n2, n3, n4 });
        NetLayer l2 = new NetLayer(new Neuron[]{ n5, n6 });

        NeuralNetwork n = new NeuralNetwork(new NetLayer[]{ l1, l2 });
        List<NeuralNetwork> ln = new List<NeuralNetwork>();
        ln.Add(n);
        List<List<double>> genotypes = new NeuralNetworkConverter().ToGenotypes(ln);

        Assert.AreEqual(genotypes.Count, 1);

        TestUtils.AssertEqualDoubleList(
            new List<double>(new double[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22}),
            genotypes[0]
        );
    }

    [Test]
    public void ShouldReturnCorrectSize() {
        NeuralNetwork n = new NeuralNetwork(new int[] { 2, 3, 4 });
        List<NeuralNetwork> ln = new List<NeuralNetwork>();
        ln.Add(n);
        List<List<double>> genotypes = new NeuralNetworkConverter().ToGenotypes(ln);

        Assert.AreEqual(genotypes[0].Count, 25);
    }

    [Test]
    public void ShouldReturnSameGenotypes() {
        List<double> genotype = new List<double>(new double[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22});
        int[] topology = new int[] { 2, 4, 2 };
        NeuralNetworkConverter converter = new NeuralNetworkConverter();

        List<List<double>> genotypes = new List<List<double>>();
        genotypes.Add(genotype);

        List<NeuralNetwork> networks = converter.ToNetworks(genotypes, topology);
        Assert.AreEqual(1, networks.Count);

        List<List<double>> newGenotypes = converter.ToGenotypes(networks);

        TestUtils.AssertEqualDoubleList(
            new List<double>(new double[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22}),
            newGenotypes[0]
        );
    }
	
}
