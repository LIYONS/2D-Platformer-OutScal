using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    //Game-Over
    [SerializeField] GameObject GUI;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void GameOver()
    {
        GUI.SetActive(false);
        gameObject.SetActive(true);
    }
}
