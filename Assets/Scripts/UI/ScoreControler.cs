using UnityEngine;
using TMPro;

public class ScoreControler : MonoBehaviour
{
    int score ;
    [SerializeField] int scoreForKey;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;
    }
    public void increaseScore()
    {
        SoundManager SM = SoundManager.instance;
        if (SM) SM.PlaySfx(Sounds.KeyCollect);
        score += scoreForKey;
        scoreText.text = "Score:" + score;
    }
  
}
