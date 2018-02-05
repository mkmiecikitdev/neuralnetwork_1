using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class TestUtils {

    public static void AssertEqualDoubleList(List<double> l1, List<double> l2) {
        Assert.AreEqual(l1.Count, l2.Count);
        for (int i = 0; i < l1.Count; ++i)
        {
            Assert.AreEqual(l1[i], l2[i]);
        }
    }

}
