using System.Collections;
using System.Collections.Generic;

public interface IMixer {

    List<List<double>> Cross(List<List<double>> genotypes, int offspringsCount);

}
