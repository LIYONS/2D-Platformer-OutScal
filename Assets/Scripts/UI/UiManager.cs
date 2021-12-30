using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public void LoadLevel(int buildIndex)
    {
        if (GameManager.instance) GameManager.instance.LoadLevel(buildIndex);
        else Debug.LogError("Gm Instance not found");
    }

    public void LoadNextLevel()
    {
        if (GameManager.instance) GameManager.instance.LoadNextLevel();
        else Debug.LogError("Gm Instance not found");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ReStart()
    {
        if (GameManager.instance) GameManager.instance.Restart();
        else Debug.LogError("Gm Instance not found");
    }
}
