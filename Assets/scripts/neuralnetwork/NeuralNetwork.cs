
public class NeuralNetwork {
   
    private NetLayer[] layers;
    private int[] topology;

    public int Points { set; get; }

    public NeuralNetwork(NetLayer[] layers) : this(null, layers, 0) {
        int[] t = new int[layers.Length + 1];

        t[0] = layers[0].Neurons[0].WeightsVector.Values.Length - 1;

        for (int i = 0; i < layers.Length; ++i)
        {
            t[i + 1] = layers[i].Neurons.Length;
        }

        this.topology = t;
    }

    public NeuralNetwork(int[] topology) {
        this.layers = new NetLayer[topology.Length - 1];
        this.topology = topology;

        Points = 0;

        for (int i = 1; i < topology.Length; ++i)
        {
            this.layers[i-1] = new NetLayer(topology[i], topology[i-1], Config.WEIGHT_MIN, Config.WEIGHT_MAX, Config.ACTIVATION_FUNC);
        }
    }

    private NeuralNetwork(int[] topology, NetLayer[] layers, int points) {
        this.layers = layers;
        this.topology = topology;
        Points = points;
    }

    public NetLayer[] Layers {
        get {
            NetLayer[] copied = new NetLayer[this.layers.Length];
            for (int i = 0; i < copied.Length; ++i) {
                copied[i] = this.layers[i].Clone;
            }
            return copied;
        }
    }

    public int[] Topology {
        get {
            return (int[])this.topology.Clone();
        }
    }



    public NeuralNetwork Clone {
        get {
            return new NeuralNetwork(Topology, Layers, Points);
        }
    }

    public double[] Response(NetVector input) {
        return this.Response(input.Values);
    }

    public double[] Response(double[] inputValues) {
        if (inputValues.Length != topology[0]) {
            throw new System.ArgumentException("Input vector size is not correct");
        }

        NetVector response = NetVector.FromValues(inputValues).Normalize;

        foreach (NetLayer hidden in layers) {
            response = hidden.Response(response);
        }
       
        return response.Values;
    }
}
