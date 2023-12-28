using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitleClick : MonoBehaviour
{
    private RectTransform originalVec;
    private bool isEnter;

    private void Awake()
    {
        originalVec = gameObject.GetComponent<RectTransform>();
    }
    public void BtnMouseEnter()
    {
        isEnter = true;
        originalVec.pivot = new Vector2(0.55f, 0.5f);
    }

    public void BtnMouseExit()
    {
        isEnter = false;
        originalVec.pivot = new Vector2(0.5f, 0.5f);
    }

    public void ClickToTitle()
    {
        if (isEnter)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
