using System.Collections;
using System.Collections.Generic;
using ExtensionList;

public class ClassicMixer : AbstractMixer, IMixer {

    public List<List<double>> Cross(List<List<double>> genotypes, int offspringsCount) {
        genotypes.Shuffle();

        if (genotypes.Count != offspringsCount)
            throw new System.ArgumentException("offspringsCount argument is not correct");
        
        List<List<double>> afterCrossGenotypes = new List<List<double>>(genotypes.Count);
        int half = genotypes.Count / 2;
        for (int i = 0; i < half; ++i)
        {
            afterCrossGenotypes.AddRange(this.Cross(genotypes[i], genotypes[i + half] ) );
        }

        return afterCrossGenotypes;
    }

}
