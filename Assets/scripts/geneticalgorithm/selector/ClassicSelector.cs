using System.Collections;
using System.Collections.Generic;

public class ClassicSelector : ISelector {

    public List<NeuralNetwork> Select(List<NeuralNetwork> currentPopulation) {

        double sum = 0;
        foreach (NeuralNetwork n in currentPopulation)
        {
            sum += n.Points;
        }

        if (sum == 0)
            return currentPopulation;

        List<double> rulette = new List<double>(currentPopulation.Count);
        double tmp = 0;
        for (int i = 0; i < currentPopulation.Count; ++i)
        {
            tmp +=  currentPopulation[i].Points /  sum;
            rulette.Add(tmp);
        }

        List<NeuralNetwork> newPopulation = new List<NeuralNetwork>(currentPopulation.Count);
        for (int i = 0; i < currentPopulation.Count; ++i)
        {
            double rand = RandomGenerator.Double();
            for (int j = 0; j < rulette.Count; ++j)
            {
                if(rand <= rulette[j]) {
                    newPopulation.Add(currentPopulation[j]);
                    break;
                }
            }
        }

        return newPopulation;
    }
}
