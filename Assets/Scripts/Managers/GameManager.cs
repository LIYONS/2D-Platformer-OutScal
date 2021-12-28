using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(_instance);
            _instance = this;
        }

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel(int buildIndex)
    {
        LevelStatus levelStat = (LevelStatus)PlayerPrefs.GetInt(LevelManager.instance.levelNames[buildIndex]);

        if (levelStat == LevelStatus.Unlocked || levelStat==LevelStatus.Completed)
        {
            SceneManager.LoadScene(buildIndex);
        }
        else Debug.Log("Not unlocked"+levelStat);
    }
    public void LoadNextLevel()
    {
        int targetBuildIndex = SceneManager.GetActiveScene().buildIndex;

        LevelStatus levelStat = (LevelStatus) PlayerPrefs.GetInt(LevelManager.instance.levelNames[targetBuildIndex]);

        if ( levelStat== LevelStatus.Unlocked || levelStat== LevelStatus.Completed)     SceneManager.LoadScene(targetBuildIndex);

        else Debug.Log("Not unlocked"+levelStat);
    }
}

