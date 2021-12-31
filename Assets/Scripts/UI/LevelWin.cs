using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelWin : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;
    SoundManager SM;
    LevelManager LM;

    private void Start()
    {
        winCanvas.SetActive(false);
        SM = SoundManager.instance;
        if (SM == null)     Debug.LogError("Sm not found");
        LM = LevelManager.instance;
        if (LM == null)     Debug.LogError("Lm not found");
    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            winCanvas.SetActive(true);
            if (SM)     SM.PlaySfx(Sounds.TelePortUse);
            collision.gameObject.SetActive(false);

            if (LM)
            {
                Scene scene = SceneManager.GetActiveScene();
                if (PlayerPrefs.GetInt(LM.levelNames[scene.buildIndex]) != (int)LevelStatus.Completed)
                {
                    LM.SetLeveLStatus(scene.name, LevelStatus.Completed);
                }
                if (scene.buildIndex < LM.levelNames.Length - 1)
                {
                    if (PlayerPrefs.GetInt(LM.levelNames[scene.buildIndex+1]) != (int)LevelStatus.Unlocked)
                    {
                        LevelManager.instance.SetLeveLStatus(LM.levelNames[scene.buildIndex + 1], LevelStatus.Unlocked);
                    }
                }
            }
        }
    }
}
