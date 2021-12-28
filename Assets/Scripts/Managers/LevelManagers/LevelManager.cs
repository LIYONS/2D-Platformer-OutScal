using UnityEngine;
using UnityEngine.SceneManagement;

public enum LevelStatus
{
    Locked,
    Unlocked,
    Completed
}
public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;

    public static LevelManager instance { get { return _instance; } }

    public string[] levelNames;
    [SerializeField] int firstLvlBuildIndex;

    private void Awake()
    {
        if(_instance==null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        for(int i=0; i<levelNames.Length;i++)
        {
            if (i > firstLvlBuildIndex) SetLeveLStatus(levelNames[i], LevelStatus.Locked);

            else SetLeveLStatus(levelNames[i], LevelStatus.Unlocked);
        }
    }
    public void SetLeveLStatus(string sceneName,LevelStatus status)
    {
        PlayerPrefs.SetInt(sceneName, (int)status);
        Debug.Log("set" + status);
    }
    public LevelStatus GetLevelStatus(string sceneName)
    {
        int status=PlayerPrefs.GetInt(sceneName);
        Debug.Log("get" + status);
        return (LevelStatus)status;
    }

}
