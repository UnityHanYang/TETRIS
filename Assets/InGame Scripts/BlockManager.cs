using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager Instance;
    public Dictionary<string, float> BlocksPositionY = new Dictionary<string, float>();
    public List<double> row1 = new List<double>();
    public List<double> row2 = new List<double>();
    public List<double> row3 = new List<double>();
    public List<double> row4 = new List<double>();
    public List<double> row5 = new List<double>();
    public List<double> row6 = new List<double>();
    public List<double> row7 = new List<double>();
    public List<double> row8 = new List<double>();
    public List<double> row9 = new List<double>();
    public List<double> row10 = new List<double>();
    public bool isEnd;
    private void Awake()
    {
        Instance = this;
    }

}
