using System.Collections;
using System.Collections.Generic;
using ExtensionList;
using UnityEngine;

public class ShuffleMutator : AbstractMutator, IMutator {

    private const float RATE = 0.5f;

    override protected void Mutate(List<double> genotype) {
        if (RandomGenerator.Double() <= Config.MUTATION_PROBABILITY)
        {
            Debug.Log("MUTATE");
            int K = (int) (RATE * genotype.Count);
            int index = RandomGenerator.Next(0, K - 1);
            List<double> subset = genotype.GetRange(index, K);

            subset.Shuffle();

            int j = 0;
            for (int i = index; i < K + index; ++i)
            {
                genotype[i] = subset[j++];
            }
        }
    }

}
