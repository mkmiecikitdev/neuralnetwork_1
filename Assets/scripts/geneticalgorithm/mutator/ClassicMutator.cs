using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicMutator : AbstractMutator, IMutator {

    override protected void Mutate(List<double> genotype) {
        for (int i = 0; i < genotype.Count; ++i)
        {
            if (RandomGenerator.Double() <= Config.MUTATION_PROBABILITY)
            {
                Debug.Log("MUTATE");
                genotype[i] *= RandomGenerator.Double(0.75, 1.25);
            }
        }

    }

}
