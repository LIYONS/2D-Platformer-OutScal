using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    SoundManager SM;
    LevelManager LM;
    GameManager GM;
    private void Start()
    {
        SM = SoundManager.instance;
        if (SM == null) Debug.LogError("Sm not found");
        LM = LevelManager.instance;
        if (LM == null) Debug.LogError("Lm not found");
        GM = GameManager.instance;
        if (GM == null) Debug.LogError("Gm not found");

    }
    public void LoadLevel(int buildIndex)
    {
        if (SM)
        {
            SM.PlaySfx(Sounds.ButtonClick);
            if (GM)
            {
                GM.LoadLevel(buildIndex);
                SM.ResetSounds();
            }
        }
    }

    public void LoadNextLevel()
    {
        if (SM)
        {
            SM.PlaySfx(Sounds.ButtonClick);
            if (GM)
            {
                SM.ResetSounds();
                GM.LoadNextLevel();
            }
        }
    }

    public void Quit()
    {
        if (SM) SM.PlaySfx(Sounds.ButtonClick);
        Application.Quit();
    }

    public void ReStart()
    {
        if (SM)
        {
            SM.PlaySfx(Sounds.ButtonClick);
            if (GM)
            {
                GM.Restart();
                SM.ResetSounds();
            }
        }
    }
}
