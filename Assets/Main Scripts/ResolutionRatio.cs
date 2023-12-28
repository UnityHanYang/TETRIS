using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionRatio : MonoBehaviour
{
    private void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scalaheight = ((float)Screen.width / Screen.height) / ((float)9 / 16);
        float scalawidth = 1f/ scalaheight;
        if(scalawidth < 1)
        {
            rect.height = scalaheight;
            rect.y = (1f - scalaheight) / 2f;
        }
        else
        {
            rect.width = scalawidth;
            rect.x = (1f - scalawidth) / 2f;

        }
        camera.rect = rect;
    }
}
