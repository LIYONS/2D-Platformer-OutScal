using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            ScoreControler scoreController = collision.gameObject.GetComponent<ScoreControler>();
            scoreController.increaseScore();
            Destroy(gameObject);
        }
    }
}
