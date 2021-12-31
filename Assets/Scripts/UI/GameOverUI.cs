using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    //Game-Over
    [SerializeField] GameObject GUI;
    [SerializeField] GameObject gameOvercanvas;
    [SerializeField] GameObject bloodPS;

    private void Start()
    {
        gameOvercanvas.SetActive(false);
    }
    public void GameOver()
    {
        Instantiate(bloodPS,transform);
        SoundManager SM = SoundManager.instance;
        if (SM)
        {
            SM.PlaySfx(Sounds.Death);
            SM.StopMusic();
        }
        GUI.SetActive(false);
        gameOvercanvas.SetActive(true);
    }
}
