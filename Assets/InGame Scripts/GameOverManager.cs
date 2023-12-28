using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public Animator animator;
    public GameObject simulationBlock;

    private void Update()
    {
        if (BlockProperty.instance != null)
        {
            if (BlockProperty.instance.isGameEnd)
            {
                simulationBlock = GameObject.FindGameObjectWithTag("Simulation");
                Destroy(simulationBlock);
                animator.SetBool("isEnd", true);
            }
        }
    }
}
