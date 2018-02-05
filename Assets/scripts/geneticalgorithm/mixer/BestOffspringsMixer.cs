using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestOffspringsMixer : AbstractMixer, IMixer {

    public List<List<double>> Cross(List<List<double>> genotypes, int offspringsCount) {
        int genotypesCount = genotypes.Count;
        if(genotypesCount > offspringsCount)
            throw new System.ArgumentException("offspringsCount argument is not correct");

        List<List<double>> afterCrossGenotypes = new List<List<double>>(offspringsCount);
        afterCrossGenotypes.AddRange(genotypes);

        while(afterCrossGenotypes.Count < offspringsCount)
        {
            afterCrossGenotypes.AddRange(Cross(genotypes[RandomGenerator.Next(0, genotypesCount -1)], genotypes[RandomGenerator.Next(0, genotypesCount - 1)] ) );
        }

        return afterCrossGenotypes;
    }

}
