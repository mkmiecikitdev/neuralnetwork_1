using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestOffspringsSelector : ISelector {

    public List<NeuralNetwork> Select(List<NeuralNetwork> currentPopulation) {

        currentPopulation.Sort((x, y) => y.Points - x.Points);

        int bestCount = (int) (0.4 * currentPopulation.Count);
        List<NeuralNetwork> newPopulation = new List<NeuralNetwork>(bestCount);

        for (int i = 0; i < bestCount; ++i)
        {
            newPopulation.Add(currentPopulation[i]);
        }

        return newPopulation;
    }
	
}
