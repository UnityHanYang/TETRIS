using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineTextManager : MonoBehaviour
{
    public static LineTextManager instance;
    public TextMesh lineText;
    public int cnt = 0;
    public int lineValue { get; set; }

    private void Awake()
    {
        instance = this;
        cnt = 0;
    }
    private void Update()
    {
        if (LineManager.instance.isWrite)
        {
            if (cnt + lineValue > 40)
            {
                cnt = 40;
            }
            else
            {
                cnt += lineValue;
            }
            lineText.text = cnt.ToString();
            LineManager.instance.isWrite = false;
        }
    }
}
