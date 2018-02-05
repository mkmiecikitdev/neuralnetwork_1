using System.Collections;
using System.Collections.Generic;

abstract public class AbstractMutator {

    public void Mutate(List<List<double>> genotypes) {
        foreach (List<double> g in genotypes)
        {
            this.Mutate(g);
        }
    }

    protected abstract void Mutate(List<double> genotype);
}
