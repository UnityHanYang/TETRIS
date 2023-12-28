using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RePlaySelect : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("RePlay");
    }
}
