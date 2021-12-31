using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MainMenuLoader : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] TextMeshProUGUI[] buttonTexts;
    LevelManager LM;

    private void Start()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
        LM = LevelManager.instance;
        if (LM == null) Debug.LogError("Lm not found");
    }
    public void loadLevelMenu()
    {
        for(int i=0;i<buttonTexts.Length;i++)
        {
            if (LM)
            {
                LevelStatus levelStat = (LevelStatus)PlayerPrefs.GetInt(LM.levelNames[i + 1]);

                if (levelStat == LevelStatus.Locked) buttonTexts[i].color = new Color(1f, 1f, 1f, .25f);

                else if (levelStat == LevelStatus.Unlocked) buttonTexts[i].color = new Color(1f, 1f, 1f, 1f);

                else if (levelStat == LevelStatus.Completed) buttonTexts[i].color = new Color(0f, 1f, 0f, 1f);
            }
        }
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);

    }
}
