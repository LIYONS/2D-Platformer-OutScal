using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    //Game-Over
    [SerializeField] GameObject GUI;
    [SerializeField] GameObject gameOvercanvas;

    private void Start()
    {
        gameOvercanvas.SetActive(false);

    }
    public void GameOver()
    {
        GUI.SetActive(false);
        gameOvercanvas.SetActive(true);
    }
}
