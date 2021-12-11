using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    int heartCount;

    Animator animator;

    private void Start()
    {
        heartCount = hearts.Length;
        animator = GetComponent<Animator>();
    }
    public void damagePlayer()
    {
        if (heartCount > 1)
        {
            hearts[heartCount - 1].color = Color.white;
            heartCount--;
            animator.Play("PlayerHurt");
            animator.SetTrigger("Hurt");
        }
        else
        {
            KillPlayer();

        }      
    }
    public void KillPlayer()
    {
        animator.Play("PlayerDeath");
        Invoke("RestartLevel", .5f);

    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
