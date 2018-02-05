using System;

public class ActivationFunctions {

    public delegate double Func(double arg);

    public static Func Linear {
        get {
            return ((arg) => arg * 1);
        }
    }

    public static Func Tanh {
        get {
            return ((arg) => Math.Tanh(arg));
        }
    }

    public static Func Sigmoidal {
        get {
            return ((arg) => 1.0 / (1.0 + Math.Exp(-1.0 * arg)));
        }
    }

    public static Func Unipolar {
        get {
            return ((arg) => arg > 0 ? 1 : 0);
        }
    }

    public static Func Bipolar {
        get {
            return ((arg) => arg > 0 ? 1 : -1);
        }
    }

    public static Func ReLU
    {
        get {
            return ((arg) => arg > 0 ? arg : arg/20 );
        }

    }

}
