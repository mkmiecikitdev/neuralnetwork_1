using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    private HashSet<int> IDs = new HashSet<int>();

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (IDs.Contains(player.ID))
            {
                player.Dead();
            }
            else
            {
                IDs.Add(player.ID);
                player.CheckpointDone();
            }
        }
    }

    public void Reset() {
        this.IDs.Clear();
    }

}
