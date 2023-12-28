using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationCancel : MonoBehaviour
{
    public GameObject canvas;

    public void ClickToCancel()
    {
        canvas.SetActive(false);
        OperationWindow.instance.isClick = false;
    }
}
