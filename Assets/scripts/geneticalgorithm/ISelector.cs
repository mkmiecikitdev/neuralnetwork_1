using System.Collections;
using System.Collections.Generic;

public interface ISelector {

    List<NeuralNetwork> Select(List<NeuralNetwork> currentPopulation);

}
