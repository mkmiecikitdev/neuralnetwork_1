using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Config.NEURAL_NETWORK_LEARNING)
        {
            collision.gameObject.GetComponent<PlayerController>().Dead();
        }
    }
}
