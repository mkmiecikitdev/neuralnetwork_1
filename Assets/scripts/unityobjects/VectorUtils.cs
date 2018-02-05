using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorUtils {

    public static Vector3 RotateToForward(Vector3 v, Vector3 dir) {
        float angle = Vector3.SignedAngle(dir, Vector3.forward, Vector3.down);
        Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * v;
        return rotatedVector.normalized;
    }
}
