using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorController : MonoBehaviour {

    public PlayerController Player { set; get; }
    private int layerMask = 1 << 9;

    private const float TANG_22_5 = 0.414f;
     

    private readonly Vector3[] DIRERCTIONS = new Vector3[]
        {
            Vector3.left,
            new Vector3(-1, 0, TANG_22_5),
            new Vector3(-1, 0, 1),
            new Vector3(-TANG_22_5, 0, 1),
            Vector3.forward,
            new Vector3(TANG_22_5, 0, 1),
            new Vector3(1, 0, 1),
            new Vector3(1, 0, TANG_22_5),
            Vector3.right,
            Vector3.back
        };

    private float[] inputs;

    public double[] Inputs {
        get {
            double[] inpts = new double[this.inputs.Length];
            for (int i = 0; i < inpts.Length; ++i)
            {
                inpts[i] = (double)this.inputs[i];
            }
            return inpts;
        }
    }

    void Awake() {
        inputs = new float[DIRERCTIONS.Length];
        for (int i = 0; i < this.inputs.Length; ++i)
        {
            this.inputs[i] = Config.SENSOR_LIMIT;
        }
    }

	void FixedUpdate () {
        if (Player == null)
            return;

        UpdateInputs();

	}

    public void UpdateInputs() {
        transform.position = Player.transform.position;

        Vector3 vRot = Player.Dir;
        if(vRot.magnitude != 0)
            transform.rotation = Quaternion.LookRotation(vRot);

        RaycastHit hit;

        for (int i = 0; i < DIRERCTIONS.Length; ++i)
        {
            this.inputs[i] = Config.SENSOR_LIMIT;
            Vector3 dir = VectorUtils.RotateToForward(DIRERCTIONS[i], Player.Dir);

            if (Physics.Raycast(transform.position, dir, out hit, Config.SENSOR_LIMIT, layerMask))
                this.inputs[i] = hit.distance;

            Debug.DrawRay (transform.position, Config.SENSOR_LIMIT * dir, i == 4 ? Color.blue : Color.red);

        }
        
    }

    public string ToString() {
        string s = Player.GetComponent<PlayerController>().ID + ": ";

        foreach (double f in Inputs)
        {
            s += (f + ", "); 
        }

        return s;
    }

}
