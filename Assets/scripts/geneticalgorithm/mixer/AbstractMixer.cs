using System.Collections;
using System.Collections.Generic;

public class AbstractMixer {

    protected List<double>[] Cross(List<double> g1, List<double> g2) {
        if (g1.Count != g2.Count)
            throw new System.ArgumentException("Genotypes have different count");
        
        List<double>[] genotypes = new List<double>[2];
        genotypes[0] = new List<double>();
        genotypes[1] = new List<double>();

        int crossIndex = RandomGenerator.Next(1, g1.Count - 1); 
        int length = g1.Count;

        genotypes[0].AddRange(g1.GetRange(0, crossIndex)); 
        genotypes[1].AddRange(g2.GetRange(0, crossIndex));

        genotypes[0].AddRange(g2.GetRange(crossIndex, length - crossIndex));
        genotypes[1].AddRange(g1.GetRange(crossIndex, length - crossIndex));

        return genotypes;
    }

}
