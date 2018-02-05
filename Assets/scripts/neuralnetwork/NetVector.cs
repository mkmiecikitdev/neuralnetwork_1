using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NetVector {

    private readonly double[] values;

    private NetVector(double[] values) {
        this.values = values;
    }

    public double[] Values {
        get {
            return (double[]) this.values.Clone();
        }
    }

    public static NetVector Randomize(int size, double min, double max) {
        double[] values = new double[size];

        for (int i = 0; i < size; ++i) {
            values[i] = RandomGenerator.Double(min, max);
        }

        return new NetVector(values);
    }

    public static NetVector FromValues(double[] values) {
        return new NetVector(values);
    }

    public double EuclideanStrength {
        get {
            double strength = 0;

            foreach(double v in this.values) {
                strength += v * v;
            }

            return Math.Sqrt(strength);
        }
    }

    public NetVector Normalize {
        get {
            double strength = EuclideanStrength;
            double[] normalizeValues = new double[values.Length];
            for (int i = 0; i < values.Length; i++) {
                normalizeValues[i] = values[i] / strength;
            }

            return new NetVector(normalizeValues);
        }
    }

    public NetVector Clone {
        get {
            return new NetVector(Values);
        }
    }

    public double Scalar(NetVector other, double bias) {
        double[] withBias = new double[other.values.Length + 1];
        withBias[0] = bias;
        for (int i = 1; i < withBias.Length; ++i) {
            withBias[i] = other.values[i - 1];
        }

        return this.Scalar(new NetVector(withBias));
    }

    public double Scalar(NetVector other) {
        if (!HasEqualSize(other)) {
            throw new ArgumentException("Size of both vectors are not equal or are null");
        }

        double result = 0;

        for (int i = 0; i < values.Length; ++i) {
            result += values[i] * other.values[i];
        }

        return result;

    }

    public string ToString() {
        string text = "[";

        foreach (double v in this.values)
        {
            text += v;
            text += ", ";
        }

        text += "]";

        return text;

    }

    private bool HasEqualSize(NetVector other) {
        return other != null && other.values != null && values.Length == other.values.Length;
    }

}
