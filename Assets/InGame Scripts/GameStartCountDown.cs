using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartCountDown : MonoBehaviour
{
    public static GameStartCountDown instance;
    public Animator animator;
    public bool isStart;
    public bool isEnd;
    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(isStart)
        {
            animator.SetTrigger("isStart");
            isStart = false;
        }
    }

    public void GameStart()
    {
        isEnd = true;
        TimeManager.instance.isStart = true;
    }
}
