using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            KillPlayer(collision.gameObject);

        }
    }

    public void KillPlayer(GameObject player)
    {
        Debug.Log("Player is dead");
    }
}
