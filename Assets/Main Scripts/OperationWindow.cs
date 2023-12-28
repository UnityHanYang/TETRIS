using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationWindow : MonoBehaviour
{
    public static OperationWindow instance;
    public GameObject canvas;
    public bool isClick;

    private void Awake()
    {
        instance = this;
    }
    public void OperClick()
    {
        if (!isClick)
        {
            isClick = true;
            canvas.SetActive(true);
        }
    }
}
