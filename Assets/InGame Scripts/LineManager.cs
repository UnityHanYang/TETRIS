using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public static LineManager instance;
    public Dictionary<GameObject, int> dicCount = new Dictionary<GameObject, int>();
    public GameObject[] gameArr;
    public List<GameObject> gameList = new List<GameObject>();
    public GameObject[] rowArr;
    private LineManager lineM;
    public List<GameObject> destoryGob;
    public bool isDestroy;
    public List<string> blockName = new List<string>();
    public List<string> rowName = new List<string>();
    public bool isWrite;
    public List<string> key = new List<string>();
    public bool isNull;
    public bool isBlockLive = true;
    private bool isAdd;
    public Animator animator;
    public Animator animatortext;
    public List<string> removeRow = new List<string>();
    public List<LineManager> lmList = new List<LineManager>();
    public Dictionary<string, int> rowBlockCount = new Dictionary<string, int>();
    private List<int> indexList = new List<int>();


    private void Awake()
    {
        instance = this;
        gameArr = new GameObject[10];
        destoryGob = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            gameArr[i] = transform.GetChild(i).gameObject;
        }
        rowArr = GameObject.FindGameObjectsWithTag("Row");
        rowArr = rowArr.OrderBy(go =>
        {
            var name = go.name;
            var start = name.IndexOf('(') + 1;
            var end = name.IndexOf(')');
            var number = int.Parse(name.Substring(start, end - start));
            return number;
        }).ToArray();
    }

    private void Update()
    {
        foreach (KeyValuePair<GameObject, int> kv in dicCount)
        {
            if (kv.Value == 10)
            {
                for (int i = 0; i < rowArr.Length; i++)
                {
                    if (kv.Key.ToString() == rowArr[i].ToString())
                    {
                        if (!key.Contains(kv.Key.ToString().Split(" ")[1]))
                        {
                            key.Add(kv.Key.ToString().Split(" ")[1]);
                        }
                        lineM = rowArr[i].GetComponent<LineManager>();
                        if (!lmList.Contains(lineM))
                        {
                            lmList.Add(lineM);
                        }
                        for (int j = 0; j < lineM.gameList.Count; j++)
                        {
                            if (!destoryGob.Contains(lineM.gameList[j]))
                            {
                                destoryGob.Add(lineM.gameList[j]);
                                isAdd = true;
                            }
                        }
                        break;
                    }

                }
            }
        }
        if (!isBlockLive)
        {
            RayCastBlock.Instance.isClear = true;
            if (isAdd)
            {
                if (LineManager.instance.destoryGob.Count >= 10)
                {
                    int n = destoryGob.Count;
                    for (int i = 0; i < n; i++)
                    {
                        Destroy(destoryGob[i]);
                    }
                    WarningBlock.Instance.isLineClear = true;
                    isNull = true;
                    LineTextManager.instance.lineValue = n / 10;
                    if (LineTextManager.instance.cnt + LineTextManager.instance.lineValue >= 40)
                    {
                        animator.SetBool("isClear", true);
                        animatortext.SetBool("isClear", true);
                    }
                    CurrentBlockCount.Instance.isEnd = false;
                    CurrentBlockCount.Instance.lmrList.AddRange(lmList);
                    isWrite = true;
                    foreach (KeyValuePair<string, float> pair in BlockManager.Instance.BlocksPositionY)
                    {
                        blockName.Add(pair.Key);
                    }
                    SortBlockNames(blockName);
                    foreach (KeyValuePair<string, int> pair in rowBlockCount)
                    {
                        rowName.Add(pair.Key);
                    }
                    foreach (string strKey in key)
                    {
                        if (strKey.Length == 3)
                        {
                            indexList.Add(int.Parse(strKey.Substring(1, 1).ToString()));
                        }
                        else if (strKey.Length == 4)
                        {
                            indexList.Add(int.Parse(strKey.Substring(1, 2).ToString()));
                        }
                    }

                    for (int i = 0; i < rowBlockCount.Count; i++)
                    {
                        rowBlockCount[rowName[i]] -= (n / 10);
                    }

                    indexList.Sort();
                    for (int i = 0; i < indexList.Count; i++)
                    {
                        rowNameEqualRemove(indexList[i]);
                    }
                    indexList.Clear();
                    isDestroy = true;
                }
                isAdd = false;
            }
            RayCastBlock.Instance.isClear = false;
            isBlockLive = true;
        }
    }
    public int GetNumberFromBlockName(string blockName)
    {
        int start = blockName.IndexOf('(') + 1;
        int end = blockName.IndexOf(')', start);
        string result = blockName.Substring(start, end - start);
        return int.Parse(result);
    }

    public void SortBlockNames(List<string> blockNames)
    {
        blockNames.Sort((a, b) => GetNumberFromBlockName(a).CompareTo(GetNumberFromBlockName(b)));
    }
    private void rowNameEqualRemove(int n)
    {
        double rowY = -4.2275 + ((n - 1) * 0.5525f);

        double roundedResult = Math.Ceiling(rowY * 10000) / 10000;

        if (BlockManager.Instance.row1.Count > 0)
        {
            for (int i = 0; i < BlockManager.Instance.row1.Count; i++)
            {
                double rowF = BlockManager.Instance.row1[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    BlockManager.Instance.row1.Remove(rowF);
                    if (BlockManager.Instance.row1.Count == 0)
                    {
                        BlockManager.Instance.row1.Clear();
                    }
                    break;
                }
            }
        }

        if (BlockManager.Instance.row2.Count > 0)
        {
            for (int i = 0; i < BlockManager.Instance.row2.Count; i++)
            {
                double rowF = BlockManager.Instance.row2[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    BlockManager.Instance.row2.Remove(rowF);
                    if (BlockManager.Instance.row2.Count == 0)
                    {
                        BlockManager.Instance.row2.Clear();
                    }
                    break;
                }
            }
        }

        if (BlockManager.Instance.row3.Count > 0)
        {
            for (int i = 0; i < BlockManager.Instance.row3.Count; i++)
            {
                double rowF = BlockManager.Instance.row3[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    BlockManager.Instance.row3.Remove(rowF);
                    if (BlockManager.Instance.row3.Count == 0)
                    {
                        BlockManager.Instance.row3.Clear();
                    }
                    break;
                }
            }
        }

        if (BlockManager.Instance.row4.Count > 0)
        {
            for (int i = 0; i < BlockManager.Instance.row4.Count; i++)
            {
                double rowF = BlockManager.Instance.row4[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    BlockManager.Instance.row4.Remove(rowF);
                    if (BlockManager.Instance.row4.Count == 0)
                    {
                        BlockManager.Instance.row4.Clear();
                    }
                    break;
                }
            }
        }

        if (BlockManager.Instance.row5.Count > 0)
        {
            for (int i = 0; i < BlockManager.Instance.row5.Count; i++)
            {
                double rowF = BlockManager.Instance.row5[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    BlockManager.Instance.row5.Remove(rowF);
                    if (BlockManager.Instance.row5.Count == 0)
                    {
                        BlockManager.Instance.row5.Clear();
                    }
                    break;
                }
            }
        }

        if (BlockManager.Instance.row6.Count > 0)
        {
            for (int i = 0; i < BlockManager.Instance.row6.Count; i++)
            {
                double rowF = BlockManager.Instance.row6[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    BlockManager.Instance.row6.Remove(rowF);
                    if (BlockManager.Instance.row6.Count == 0)
                    {
                        BlockManager.Instance.row6.Clear();
                    }
                    break;
                }
            }
        }

        if (BlockManager.Instance.row7.Count > 0)
        {
            for (int i = 0; i < BlockManager.Instance.row7.Count; i++)
            {
                double rowF = BlockManager.Instance.row7[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    BlockManager.Instance.row7.Remove(rowF);
                    if (BlockManager.Instance.row7.Count == 0)
                    {
                        BlockManager.Instance.row7.Clear();
                    }
                    break;
                }
            }
        }

        if (BlockManager.Instance.row8.Count > 0)
        {
            for (int i = 0; i < BlockManager.Instance.row8.Count; i++)
            {
                double rowF = BlockManager.Instance.row8[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    BlockManager.Instance.row8.Remove(rowF);
                    if (BlockManager.Instance.row8.Count == 0)
                    {
                        BlockManager.Instance.row8.Clear();
                    }
                    break;
                }
            }
        }

        if (BlockManager.Instance.row9.Count > 0)
        {
            for (int i = 0; i < BlockManager.Instance.row9.Count; i++)
            {
                double rowF = BlockManager.Instance.row9[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    BlockManager.Instance.row9.Remove(rowF);
                    if (BlockManager.Instance.row9.Count == 0)
                    {
                        BlockManager.Instance.row9.Clear();
                    }
                    break;
                }
            }
        }

        if (BlockManager.Instance.row10.Count > 0)
        {
            for (int i = 0; i < BlockManager.Instance.row10.Count; i++)
            {
                double rowF = BlockManager.Instance.row10[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    BlockManager.Instance.row10.Remove(rowF);
                    if (BlockManager.Instance.row10.Count == 0)
                    {
                        BlockManager.Instance.row10.Clear();
                    }
                    break;
                }
            }
        }
    }
}
