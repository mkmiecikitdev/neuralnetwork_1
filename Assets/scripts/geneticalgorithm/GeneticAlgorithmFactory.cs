

public class GeneticAlgorithmFactory {

    public static GeneticAlgorithm ClassicStrategy() {
        return new GeneticAlgorithm(
            new NeuralNetworkConverter(),
            new ClassicMutator(),
            new ClassicMixer(),
            new ClassicSelector()
        );
    }

    public static GeneticAlgorithm BestOffspringsStrategy() {
        return new GeneticAlgorithm(
            new NeuralNetworkConverter(),
            new ClassicMutator(),
            new BestOffspringsMixer(),
            new BestOffspringsSelector()
        );
    }

    public static GeneticAlgorithm HybridStrategy() {
        return new GeneticAlgorithm(
            new NeuralNetworkConverter(),
            new ShuffleMutator(),
            new ClassicMixer(),
            new ClassicSelector()
        );
    }
}
