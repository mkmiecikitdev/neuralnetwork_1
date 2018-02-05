using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NetVestorTest {

	[Test]
	public void ShouldReturnCorrectWithoutBias() {
        NetVector v1 = NetVector.FromValues(new double[] {5, 1.5, 2.4});
        NetVector v2 = NetVector.FromValues(new double[] {0.23, 3.4, 9.9});

        double result = v1.Scalar(v2);
        Assert.AreEqual(30.01, result, 0.01);
	}

    [Test]
    public void ShouldReturnCorrectWithBias() {
        NetVector v1 = NetVector.FromValues(new double[] {1, 3, 2});
        NetVector v2 = NetVector.FromValues(new double[] {1, 4});

        double result = v1.Scalar(v2, -1);
        Assert.AreEqual(10, result);
    }

    [Test]
    public void ShouldReturnCorrectSizeWhenRandomize() {
        NetVector v1 = NetVector.Randomize(10, -5, 5);
        Assert.AreEqual(10, v1.Values.Length);
    }

    [Test]
    public void ShouldReturnException() {
        NetVector v1 = NetVector.FromValues(new double[] {5, 1.5, 2.4, 6.6});
        NetVector v2 = NetVector.FromValues(new double[] {0.23, 3.4, 9.9});

        Assert.Throws<System.ArgumentException>(delegate()
            {
                v1.Scalar(v2);
            });
    }
}
