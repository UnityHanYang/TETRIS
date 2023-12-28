using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTimeManager : MonoBehaviour
{
    public Text decimalText;
    public Text integerText;

    private void Awake()
    {
        decimalText.text = "." + TimeManager.roundedDecimalPart.ToString();
        if (TimeManager.integerSecondPart < 10)
        {
            integerText.text = TimeManager.integerMinutePart.ToString() + ":0" + TimeManager.integerSecondPart.ToString();
        }
        else
        {
            integerText.text = TimeManager.integerMinutePart.ToString() + ":" + TimeManager.integerSecondPart.ToString();
        }
    }
}
