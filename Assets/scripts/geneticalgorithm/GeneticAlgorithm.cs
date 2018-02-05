using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm {

    private INeuralNetworkConverter converter;
    private IMutator mutator;
    private IMixer mixer;
    private ISelector selector;

    public GeneticAlgorithm(INeuralNetworkConverter converter, IMutator mutator, IMixer mixer, ISelector selector) {
        this.converter = converter;
        this.mutator = mutator;
        this.mixer = mixer;
        this.selector = selector;
    }

    public List<NeuralNetwork> NextPopulation(List<NeuralNetwork> currentPopulation) {
        List<List<double>> genotypes = converter.ToGenotypes(selector.Select(currentPopulation));

        List<List<double>> afterCrossGenotypes = mixer.Cross(genotypes, currentPopulation.Count);
        mutator.Mutate(afterCrossGenotypes);

        return converter.ToNetworks(afterCrossGenotypes, currentPopulation[0].Topology);
    }

}