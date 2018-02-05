using System.Collections.Generic;
using System.Collections;

public interface INeuralNetworkConverter  {
    
    List<List<double>> ToGenotypes(List<NeuralNetwork> networks);

    List<NeuralNetwork> ToNetworks(List<List<double>> genotypes, int[] topology);

}
