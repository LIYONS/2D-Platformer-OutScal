using UnityEngine;

public class MainMenuLoader : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelMenu;

    private void Start()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }
    public void loadLevelMenu()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }
}
