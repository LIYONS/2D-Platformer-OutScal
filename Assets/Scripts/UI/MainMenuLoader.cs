using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MainMenuLoader : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] TextMeshProUGUI[] buttonTexts;

    private void Start()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }
    public void loadLevelMenu()
    {
        for(int i=0;i<buttonTexts.Length;i++)
        {
            LevelStatus levelStat = (LevelStatus)PlayerPrefs.GetInt(LevelManager.instance.levelNames[i + 1]);

            if (levelStat == LevelStatus.Locked) buttonTexts[i].color = new Color(1f, 1f, 1f, .25f);

            else if(levelStat==LevelStatus.Unlocked) buttonTexts[i ].color = new Color(1f, 1f, 1f, 1f);

            else if(levelStat== LevelStatus.Completed) buttonTexts[i].color = new Color(0f, 1f, 0f, 1f);
        }
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);

    }
}
