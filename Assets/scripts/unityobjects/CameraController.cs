using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private const float FAST_RATE = 20f;
    private const float SLOW_RATE = 5f;
    private float rate = FAST_RATE;

    private const float TIME_OFFSET = 0.2f;

    private float lastPlayerUpdate;

    private Transform player;
    public Transform Player { 
        get {
            return this.player;
        } 

        set {
            int id = this.player == null ? -1 : this.player.GetComponent<PlayerController>().ID;
            int id2 = value.GetComponent<PlayerController>().ID;
            if (id != id2)
            {
                this.lastPlayerUpdate = Time.time;
            }
            this.player = value;
        }
    }

    void Start() {
        this.lastPlayerUpdate = Time.time;
    }
	
	void LateUpdate () {
        if (Player != null)
            this.UpdateRate();
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, Player.position.y + 40f, Player.position.z), Time.deltaTime * rate);
    }

    private void UpdateRate() {
        if (Time.time - this.lastPlayerUpdate >= TIME_OFFSET)
        {
            this.rate = FAST_RATE;
        }
        else
        {
            this.rate = SLOW_RATE;
        }
    }


}
