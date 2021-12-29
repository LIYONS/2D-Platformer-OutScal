using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelWin : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;

    private void Start()
    {
        winCanvas.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            winCanvas.SetActive(true);
            collision.gameObject.SetActive(false);
            

            //Level Completed
            LevelManager.instance.SetLeveLStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
            //NextLevel
            LevelManager.instance.SetLeveLStatus(LevelManager.instance.levelNames[SceneManager.GetActiveScene().buildIndex+1],LevelStatus.Unlocked);
        }
    }
}
