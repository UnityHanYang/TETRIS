using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    [SerializeField] private float currentTime = 0f;
    public TextMesh decimalText;
    public TextMesh integerText;
    [SerializeField] private float decimalPart = 0f;
    static public int integerSecondPart = 0;
    static public int integerMinutePart = 0;
    static public int roundedDecimalPart = 0;
    private bool isAdd = true;
    public bool isStart;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (isStart && !BlockManager.Instance.isEnd && LineTextManager.instance.cnt < 40)
        {
            currentTime += Time.deltaTime;
            integerSecondPart = (int)currentTime;
            decimalPart = currentTime - integerSecondPart;

            if (integerSecondPart < 10)
            {
                integerText.text = integerMinutePart.ToString() + ":0" + integerSecondPart.ToString();
            }
            else
            {
                integerText.text = integerMinutePart.ToString() + ":" + integerSecondPart.ToString();
            }
            if ((int)(currentTime % 60) == 0 && !isAdd)
            {
                integerMinutePart++;
                currentTime %= 60;
                isAdd = true;
            }
            else if (isAdd)
            {
                if ((int)(currentTime % 60) != 0)
                {
                    isAdd = false;
                }
            }
            roundedDecimalPart = Mathf.FloorToInt(decimalPart * 1000);
            decimalText.text = "." + roundedDecimalPart.ToString();
        }
    }
}
