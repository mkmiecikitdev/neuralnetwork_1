using UnityEngine;

public class ReturnCheckerController : MonoBehaviour {


    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && Config.NEURAL_NETWORK_LEARNING)
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.Dead();
        }
    }

}
