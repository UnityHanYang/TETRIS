using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicecManager : MonoBehaviour
{
    public static PicecManager instance;
    public TextMesh picecText;
    public bool isWrite;
    public int picecValue { get; set; }

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (isWrite)
        {
            picecText.text = picecValue.ToString();
            isWrite = false;
        }
    }
}
