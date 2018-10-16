using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBush : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player.isDead = true;
            GameController.instance.PlayerDied();
        }
    }
}
