

public class Config  {

    public const bool NEURAL_NETWORK_LEARNING = true;

    public static readonly ActivationFunctions.Func ACTIVATION_FUNC = ActivationFunctions.Sigmoidal;

    public const float WEIGHT_MAX = 8f;
    public const float WEIGHT_MIN = -WEIGHT_MAX;

    public const float MUTATION_PROBABILITY = 0.1f;
    public const int OFFSPRINGS_COUNT = NEURAL_NETWORK_LEARNING ? 40 : 2;

    public static readonly int[] TOPOLOGY = new int[] { 11, 15, 12, 2 };

    public const float SENSOR_LIMIT = 40f;

    public static readonly GeneticAlgorithm GENETIC_ALGORITHM = GeneticAlgorithmFactory.HybridStrategy();

    private Config() {}

}
