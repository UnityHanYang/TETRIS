using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    float duration = 0.8f;
    float smoothness = 0.02f;
    float progress = 0f;
    public Image currentColor;
    Color firstColor = new Color(99 / 255f, 22 / 255f, 78 / 255f);
    Color secondColor = new Color(22 / 255f, 51 / 255f, 99 / 255f);

    void Start()
    {
        StartCoroutine("LerpColor");
    }

    IEnumerator LerpColor()
    {
        while (true)
        {
            progress += smoothness / duration;
            currentColor.color = Color.Lerp(secondColor, firstColor, progress);
            yield return new WaitForSeconds(smoothness);
            if (progress >= 1.0f)
            {
                Color temp = firstColor;
                firstColor = secondColor;
                secondColor = temp;
                progress = 0.0f;
            }

            yield return null;
        }
    }
}
