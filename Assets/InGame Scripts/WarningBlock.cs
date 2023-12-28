using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class WarningBlock : MonoBehaviour
{
    public static WarningBlock Instance;
    public List<Transform> lastBlockPivot = new List<Transform>();
    private SpriteRenderer blockSprite;
    private TextMesh textColor;
    public GameObject[] blockSpriteArr;
    public GameObject[] textFrame;
    float duration = 0.3f;
    float smoothness = 0.01f;
    float progress = 0f;
    Color firstColor = Color.red;
    Color secondColor = new Color(1f, 1f, 1f);
    public bool isLineClear;
    private bool isOver;
    private bool isZero;
    public float bigF;
    private bool isEnter;
    private void Awake()
    {
        Instance = this;
        blockSpriteArr = GameObject.FindGameObjectsWithTag("FrameBlock");
        textFrame = GameObject.FindGameObjectsWithTag("TextFrame");
    }

    IEnumerator LerpColor(Color original, Color red)
    {
        progress += smoothness / duration;
        for (int j = 0; j < blockSpriteArr.Length; j++)
        {
            blockSprite = blockSpriteArr[j].GetComponent<SpriteRenderer>();
            blockSprite.color = Color.Lerp(original, red, progress);
            yield return new WaitForSeconds(smoothness);
            if (progress >= 1.0f)
            {
                continue;
            }
        }
        for (int j = 0; j < textFrame.Length; j++)
        {
            textColor = textFrame[j].GetComponent<TextMesh>();
            textColor.color = Color.Lerp(original, red, progress);
            yield return new WaitForSeconds(smoothness);
            if (progress >= 1.0f)
            {
                continue;
            }
        }
        yield break;
    }
    void Update()
    {
        if (lastBlockPivot.Count > 0)
        {
            for (int i = 0; i < lastBlockPivot.Count; i++)
            {
                if (lastBlockPivot[i] != null)
                {
                    if (lastBlockPivot[i].position.y >= 5.12)
                    {
                        isEnter = true;
                    }
                    else
                    {
                        lastBlockPivot.RemoveAt(i);
                        isOver = false;
                    }
                }
            }
            if(isEnter)
            {
                isOver = true;
                isEnter = false;
            }
            if (isOver)
            {
                isZero = false;
                StartCoroutine(LerpColor(firstColor, secondColor));
                if (!isZero)
                {
                    progress = 0.0f;
                    isZero = true;
                }
            }
            else
            {
                if (!BlockProperty.instance.isGameEnd)
                {
                    isZero = false;
                    StartCoroutine(LerpColor(secondColor, firstColor));
                    if (!isZero)
                    {
                        progress = 0.0f;
                        isZero = true;
                    }
                }
            }
        }
    }

}
