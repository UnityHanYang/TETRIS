using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class SceneAnimation : MonoBehaviour
{
    public Animator animator;
    public GameObject game;
    public static SceneAnimation instance;
    private void Awake()
    {
        instance = this;
    }
    public void ClickToGame()
    {
        if (!OperationWindow.instance.isClick)
        {
            FadeOut();
        }
    }

    public void ClickToInGame()
    {
        MoveInGame();
    }
    public void ClickToMain()
    {
        MoveMain();
    }

    public void MoveInGame()
    {
        game.SetActive(true);
        animator.SetTrigger("InGame");
    }

    public void MoveMain()
    {
        game.SetActive(true);
        animator.SetTrigger("Main");
    }

    public void FadeOut()
    {
        game.SetActive(true);
        animator.SetTrigger("FadeOut");
    }
    public void CanvasInvi()
    {
        if(GameStartCountDown.instance != null)
        {
            GameStartCountDown.instance.isStart = true;
        }
        game.SetActive(false);
    }
    public void ClickToRetry()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ClickToFirstScene()
    {
        SceneManager.LoadScene("Main");
    }
}
