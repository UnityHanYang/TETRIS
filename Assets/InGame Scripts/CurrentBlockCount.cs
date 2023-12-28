using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;

public class CurrentBlockCount : MonoBehaviour
{
    public static CurrentBlockCount Instance;
    public List<int> indexList = new List<int>();
    public int count = 0;
    public List<int> currentIndex = new List<int>();
    public List<int> continusList = new List<int>();
    public List<int> stuckList = new List<int>();
    public int stuck = 0;
    private int rowCount = 0;
    private bool isReturnFalse = false;
    private int num;
    public List<LineManager> lmrList = new List<LineManager>();
    private bool isEqual;
    private int continueNum;
    private bool isContinue;
    public bool isEnd;
    public bool isExit;
    private void Awake()
    {
        Instance = this;
    }

    void BlockPositionY(int n)
    {
        switch (n)
        {
            case 0:
                if (BlockManager.Instance.row1.Count > 0 && BlockManager.Instance.BlocksPositionY.ContainsKey(LineManager.instance.blockName[n]))
                {
                    BlockManager.Instance.BlocksPositionY[LineManager.instance.blockName[n]] = (float)BlockManager.Instance.row1[BlockManager.Instance.row1.Count - 1];
                }
                break;
            case 1:
                if (BlockManager.Instance.row2.Count > 0 && BlockManager.Instance.BlocksPositionY.ContainsKey(LineManager.instance.blockName[n]))
                {
                    BlockManager.Instance.BlocksPositionY[LineManager.instance.blockName[n]] = (float)BlockManager.Instance.row2[BlockManager.Instance.row2.Count - 1];
                }
                break;
            case 2:
                if (BlockManager.Instance.row3.Count > 0 && BlockManager.Instance.BlocksPositionY.ContainsKey(LineManager.instance.blockName[n]))
                {
                    BlockManager.Instance.BlocksPositionY[LineManager.instance.blockName[n]] = (float)BlockManager.Instance.row3[BlockManager.Instance.row3.Count - 1];
                }
                break;
            case 3:
                if (BlockManager.Instance.row4.Count > 0 && BlockManager.Instance.BlocksPositionY.ContainsKey(LineManager.instance.blockName[n]))
                {
                    BlockManager.Instance.BlocksPositionY[LineManager.instance.blockName[n]] = (float)BlockManager.Instance.row4[BlockManager.Instance.row4.Count - 1];
                }
                break;
            case 4:
                if (BlockManager.Instance.row5.Count > 0 && BlockManager.Instance.BlocksPositionY.ContainsKey(LineManager.instance.blockName[n]))
                {
                    BlockManager.Instance.BlocksPositionY[LineManager.instance.blockName[n]] = (float)BlockManager.Instance.row5[BlockManager.Instance.row5.Count - 1];
                }
                break;
            case 5:
                if (BlockManager.Instance.row6.Count > 0 && BlockManager.Instance.BlocksPositionY.ContainsKey(LineManager.instance.blockName[n]))
                {
                    BlockManager.Instance.BlocksPositionY[LineManager.instance.blockName[n]] = (float)BlockManager.Instance.row6[BlockManager.Instance.row6.Count - 1];
                }
                break;
            case 6:
                if (BlockManager.Instance.row7.Count > 0 && BlockManager.Instance.BlocksPositionY.ContainsKey(LineManager.instance.blockName[n]))
                {
                    BlockManager.Instance.BlocksPositionY[LineManager.instance.blockName[n]] = (float)BlockManager.Instance.row7[BlockManager.Instance.row7.Count - 1];
                }
                break;
            case 7:
                if (BlockManager.Instance.row8.Count > 0 && BlockManager.Instance.BlocksPositionY.ContainsKey(LineManager.instance.blockName[n]))
                {
                    BlockManager.Instance.BlocksPositionY[LineManager.instance.blockName[n]] = (float)BlockManager.Instance.row8[BlockManager.Instance.row8.Count - 1];
                }
                break;
            case 8:
                if (BlockManager.Instance.row9.Count > 0 && BlockManager.Instance.BlocksPositionY.ContainsKey(LineManager.instance.blockName[n]))
                {
                    BlockManager.Instance.BlocksPositionY[LineManager.instance.blockName[n]] = (float)BlockManager.Instance.row9[BlockManager.Instance.row9.Count - 1];
                }
                break;
            case 9:
                if (BlockManager.Instance.row10.Count > 0 && BlockManager.Instance.BlocksPositionY.ContainsKey(LineManager.instance.blockName[n]))
                {
                    BlockManager.Instance.BlocksPositionY[LineManager.instance.blockName[n]] = (float)BlockManager.Instance.row10[BlockManager.Instance.row10.Count - 1];
                }
                break;
        }
    }
    private void Update()
    {

        if (LineManager.instance.isDestroy)
        {
            count = 0;
            rowCount = 0;

            foreach (string key in LineManager.instance.key)
            {
                if (key.Length == 3)
                {
                    indexList.Add(int.Parse(key.Substring(1, 1).ToString()));
                }
                else if (key.Length == 4)
                {
                    indexList.Add(int.Parse(key.Substring(1, 2).ToString()));
                }
            }

            indexList.Sort();

            for (int i = indexList[0] + 1; i <= 20; i++)
            {
                if (!indexList.Contains(i))
                {
                    currentIndex.Add(i);
                }
            }

            if (indexList.Count > 0)
            {
                MoveBlocksDown(indexList);
                isExit = true;
            }

            if (isExit)
            {
                int k = 0;
                while (k < BlockManager.Instance.BlocksPositionY.Count)
                {
                    for (int j = 0; j < LineManager.instance.rowName.Count; j++)
                    {
                        if (LineManager.instance.rowName[j].Equals(LineManager.instance.blockName[k]))
                        {
                            if (LineManager.instance.rowBlockCount[LineManager.instance.rowName[j]] > 0)
                            {
                                int num = int.Parse(LineManager.instance.blockName[k].Substring(7, 1));
                                BlockPositionY(num);
                                if (BlockManager.Instance.BlocksPositionY[LineManager.instance.blockName[k]] < -4.6)
                                {
                                    LineManager.instance.removeRow.Add(LineManager.instance.blockName[k]);
                                }
                            }
                            else
                            {
                                LineManager.instance.removeRow.Add(LineManager.instance.blockName[k]);
                            }
                            break;
                        }
                    }
                    k++;
                }
                for (int i = 0; i < LineManager.instance.removeRow.Count; i++)
                {
                    BlockManager.Instance.BlocksPositionY.Remove(LineManager.instance.removeRow[i]);
                }

                LineManager.instance.blockName.Clear();
                LineManager.instance.removeRow.Clear();
                LineManager.instance.destoryGob.Clear();
                LineManager.instance.rowName.Clear();
                isExit = false;
            }

            indexList.Clear();
            currentIndex.Clear();
            count = 0;
            num = 0;
            rowCount = 0;
            isReturnFalse = false;
            lmrList.Clear();
            LineManager.instance.key.Clear();
            LineManager.instance.isDestroy = false;
        }



    }
    void MoveBlocksDown(List<int> clearLines)
    {
        int lastLine = clearLines[clearLines.Count - 1];
        isReturnFalse = IsConsecutive(clearLines);
        if (clearLines.Count == 1 || (clearLines.Count > 1 && isReturnFalse))
        {
            for (int i = lastLine + 1; i <= 20; i++)
            {
                isEnd = true;
                Debug.Log("1.  " + i);
                MoveBlocksDownSingleLine(i, i - clearLines.Count, 0.5525f * clearLines.Count);
            }
        }
        else
        {
            int i = 0;
            while (i < currentIndex.Count - 1)
            {
                if (continueNum != currentIndex[i])
                {
                    isEnd = false;
                    Debug.Log("2.  " + i);
                    MoveBlocksDownNonConsecutiveLines(currentIndex[i], currentIndex, i);
                }
                if (num > 0)
                {
                    i += num;
                }
                else
                {
                    i++;
                }
            }
        }
    }
    private void RowYDown(int currentValue, double downValue)
    {
        double db = 0f;
        double roundedResult = 0f;

        if (BlockManager.Instance.row1.Count > 0)
        {
            db = -4.2275 + (currentValue * 0.5525f);
            roundedResult = Math.Ceiling(db * 10000) / 10000;
            Debug.Log("db:  " + db + ",   " + roundedResult);
            for (int i = 0; i < BlockManager.Instance.row1.Count; i++)
            {
                float rowF = (float)BlockManager.Instance.row1[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    roundedResult -= downValue;
                    roundedResult = Math.Ceiling(roundedResult * 10000) / 10000;
                    BlockManager.Instance.row1[i] = roundedResult;
                    break;
                }
            }
        }
        if (BlockManager.Instance.row2.Count > 0)
        {
            db = -4.2275 + (currentValue * 0.5525f);
            roundedResult = Math.Ceiling(db * 10000) / 10000;
            for (int i = 0; i < BlockManager.Instance.row2.Count; i++)
            {
                double rowF = BlockManager.Instance.row2[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    roundedResult -= downValue;
                    roundedResult = Math.Ceiling(roundedResult * 10000) / 10000;
                    BlockManager.Instance.row2[i] = roundedResult;
                    break;
                }
            }
        }
        if (BlockManager.Instance.row3.Count > 0)
        {
            db = -4.2275 + (currentValue * 0.5525f);
            roundedResult = Math.Ceiling(db * 10000) / 10000;
            for (int i = 0; i < BlockManager.Instance.row3.Count; i++)
            {
                double rowF = BlockManager.Instance.row3[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    roundedResult -= downValue;
                    roundedResult = Math.Ceiling(roundedResult * 10000) / 10000;
                    BlockManager.Instance.row3[i] = roundedResult;
                    break;
                }
            }
        }
        if (BlockManager.Instance.row4.Count > 0)
        {
            db = -4.2275 + (currentValue * 0.5525f);
            roundedResult = Math.Ceiling(db * 10000) / 10000;
            for (int i = 0; i < BlockManager.Instance.row4.Count; i++)
            {
                double rowF = BlockManager.Instance.row4[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    roundedResult -= downValue;
                    roundedResult = Math.Ceiling(roundedResult * 10000) / 10000;
                    BlockManager.Instance.row4[i] = roundedResult;
                    break;
                }
            }
        }
        if (BlockManager.Instance.row5.Count > 0)
        {
            db = -4.2275 + (currentValue * 0.5525f);
            roundedResult = Math.Ceiling(db * 10000) / 10000;
            for (int i = 0; i < BlockManager.Instance.row5.Count; i++)
            {
                double rowF = BlockManager.Instance.row5[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    roundedResult -= downValue;
                    roundedResult = Math.Ceiling(roundedResult * 10000) / 10000;
                    BlockManager.Instance.row5[i] = roundedResult;
                    break;
                }
            }
        }
        if (BlockManager.Instance.row6.Count > 0)
        {
            db = -4.2275 + (currentValue * 0.5525f);
            roundedResult = Math.Ceiling(db * 10000) / 10000;
            for (int i = 0; i < BlockManager.Instance.row6.Count; i++)
            {
                double rowF = BlockManager.Instance.row6[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    roundedResult -= downValue;
                    roundedResult = Math.Ceiling(roundedResult * 10000) / 10000;
                    BlockManager.Instance.row6[i] = roundedResult;
                    break;
                }
            }
        }
        if (BlockManager.Instance.row7.Count > 0)
        {
            db = -4.2275 + (currentValue * 0.5525f);
            roundedResult = Math.Ceiling(db * 10000) / 10000;
            for (int i = 0; i < BlockManager.Instance.row7.Count; i++)
            {
                double rowF = BlockManager.Instance.row7[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    roundedResult -= downValue;
                    roundedResult = Math.Ceiling(roundedResult * 10000) / 10000;
                    BlockManager.Instance.row7[i] = roundedResult;
                    break;
                }
            }
        }
        if (BlockManager.Instance.row8.Count > 0)
        {
            db = -4.2275 + (currentValue * 0.5525f);
            roundedResult = Math.Ceiling(db * 10000) / 10000;
            for (int i = 0; i < BlockManager.Instance.row8.Count; i++)
            {
                double rowF = BlockManager.Instance.row8[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    roundedResult -= downValue;
                    roundedResult = Math.Ceiling(roundedResult * 10000) / 10000;
                    BlockManager.Instance.row8[i] = roundedResult;
                    break;
                }
            }
        }
        if (BlockManager.Instance.row9.Count > 0)
        {
            db = -4.2275 + (currentValue * 0.5525f);
            roundedResult = Math.Ceiling(db * 10000) / 10000;
            for (int i = 0; i < BlockManager.Instance.row9.Count; i++)
            {
                double rowF = BlockManager.Instance.row9[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    roundedResult -= downValue;
                    roundedResult = Math.Ceiling(roundedResult * 10000) / 10000;
                    BlockManager.Instance.row9[i] = roundedResult;
                    break;
                }
            }
        }
        if (BlockManager.Instance.row10.Count > 0)
        {
            db = -4.2275 + (currentValue * 0.5525f);
            roundedResult = Math.Ceiling(db * 10000) / 10000;
            for (int i = 0; i < BlockManager.Instance.row10.Count; i++)
            {
                double rowF = BlockManager.Instance.row10[i];
                if (Math.Abs(rowF - roundedResult) < 0.07)
                {
                    roundedResult -= downValue;
                    roundedResult = Math.Ceiling(roundedResult * 10000) / 10000;
                    BlockManager.Instance.row10[i] = roundedResult;
                    break;
                }
            }
        }
    }

    void MoveBlocksDownSingleLine(int currentLine, int targetLine, float yOffset)
    {
        Debug.Log("bb: " + yOffset);
        Debug.Log("z: " + (currentLine - 1) + ",  " + (targetLine - 1));
        GameObject obj = LineManager.instance.rowArr[currentLine - 1];
        GameObject objDownRow = LineManager.instance.rowArr[targetLine - 1];
        RowYDown(currentLine - 1, yOffset);
        if (obj != null && objDownRow != null)
        {
            LineManager lm = obj.GetComponent<LineManager>();
            LineManager lmDownRow = objDownRow.GetComponent<LineManager>();

            if (lm != null && lmDownRow != null && lm.gameList.Count > 0)
            {
                foreach (var block in lm.gameList)
                {
                    if (block != null)
                    {
                        Vector3 currentPosition = block.transform.position;
                        currentPosition.y -= yOffset;
                        block.transform.position = currentPosition;
                    }
                }
                if (!isEnd)
                {
                    for (int i = 0; i < LineManager.instance.lmList.Count; i++)
                    {
                        LineManager.instance.lmList[i].gameList.Clear();
                    }
                    LineManager.instance.lmList.Clear();
                    isEnd = true;
                }
                LineManager.instance.dicCount[objDownRow] = 0;
                LineManager.instance.dicCount[obj] = 0;
                lmDownRow.gameList.Clear();
                lmDownRow.gameList.AddRange(lm.gameList);
                LineManager.instance.dicCount[objDownRow] = lm.gameList.Count;
                lm.gameList.Clear();
            }
        }
    }

    void MoveBlocksDownNonConsecutiveLines(int currentLine, List<int> currentBlockList, int n)
    {
        int stuck = 0;
        Debug.Log("aa: " + currentLine + ",  " + n);
        for (int i = n; i < currentBlockList.Count - 1; i++)
        {
            if (currentBlockList[i] + 1 == currentBlockList[i + 1])
            {
                if (!continusList.Contains(currentBlockList[i]) && !continusList.Contains(currentBlockList[i + 1]))
                {
                    continusList.Add(currentBlockList[i]);
                    continusList.Add(currentBlockList[i + 1]);
                    isContinue = true;
                    num = i + 1;
                }
                else if (!continusList.Contains(currentBlockList[i]))
                {
                    continusList.Add(currentBlockList[i]);
                    num = i + 1;
                    isContinue = true;
                }
                else if (!continusList.Contains(currentBlockList[i + 1]))
                {
                    continusList.Add(currentBlockList[i + 1]);
                    num = i + 1;
                    isContinue = true;
                }
            }
            else
            {
                rowCount++;
                stuck = currentLine;
                num = i + 1;
                isContinue = false;
                break;
            }
        }
        foreach (var currentBlock in continusList)
        {
            Debug.Log("var:  " + currentBlock);
        }
        Debug.Log("bool:   " + isContinue);
        if (isContinue)
        {
            for (int i = currentLine - 1; i >= 0; i--)
            {
                if (currentLine > 1)
                {
                    GameObject obj = LineManager.instance.rowArr[i - 1];
                    if (obj != null)
                    {
                        LineManager lm = obj.GetComponent<LineManager>();
                        if (lm != null)
                        {
                            for (int j = 0; j < lmrList.Count; j++)
                            {
                                if (lm == lmrList[j])
                                {
                                    count++;
                                    isEqual = true;
                                    break;
                                }
                            }
                            if (!isEqual)
                            {
                                break;
                            }
                        }
                    }
                    isEqual = false;
                }
            }
        }
        if (!isContinue)
        {
            count++;
        }
        Debug.Log("count:  " + count);
        MoveStuckBlocks(continusList, stuck, count);
        continusList.Clear();
    }

    void MoveStuckBlocks(List<int> stuckList, int stuck, int cnt)
    {
        if (stuckList.Count > 0)
        {
            Debug.Log(stuckList.Count);
            for (int j = 0; j < stuckList.Count; j++)
            {
                Debug.Log(j);
                if (stuckList[j] != 1)
                {
                    int targetIndex = stuckList[j] - count;

                    if (targetIndex >= 1 && targetIndex <= 20)
                    {
                        Debug.Log("obj:  " + (stuckList[j] - 1) + ",  " + (targetIndex - 1));
                        GameObject obj = LineManager.instance.rowArr[stuckList[j] - 1];
                        GameObject objDownRow = LineManager.instance.rowArr[targetIndex - 1];

                        RowYDown(stuckList[j] - 1, (count * 0.5525));
                        if (obj != null && objDownRow != null)
                        {
                            LineManager lm = obj.GetComponent<LineManager>();
                            LineManager lmDownRow = objDownRow.GetComponent<LineManager>();

                            if (lm != null && lmDownRow != null && lm.gameList.Count > 0)
                            {
                                foreach (var block in lm.gameList)
                                {
                                    if (block != null)
                                    {
                                        Vector3 currentPosition = block.transform.position;
                                        currentPosition.y -= 0.5525f * count;
                                        block.transform.position = currentPosition;
                                    }
                                }
                                if (!isEnd)
                                {
                                    for (int i = 0; i < LineManager.instance.lmList.Count; i++)
                                    {
                                        LineManager.instance.lmList[i].gameList.Clear();
                                    }
                                    LineManager.instance.lmList.Clear();
                                    isEnd = true;
                                }
                                LineManager.instance.dicCount[objDownRow] = 0;
                                LineManager.instance.dicCount[obj] = 0;
                                lmDownRow.gameList.Clear();
                                lmDownRow.gameList.AddRange(lm.gameList);
                                LineManager.instance.dicCount[objDownRow] = lm.gameList.Count;
                                lm.gameList.Clear();
                            }
                        }
                    }
                }
            }
            stuckList.Clear();
        }
        else
        {
            if (stuck != 1)
            {
                Debug.Log("xx:  " + (stuck - 1) + ",  " + (rowCount + 1));
                GameObject obj = LineManager.instance.rowArr[stuck - 1];
                GameObject objDownRow = LineManager.instance.rowArr[stuck - (rowCount + 1)];
                Debug.Log("row:  " + rowCount);
                RowYDown(stuck - 1, (rowCount * 0.5525f));
                if (obj != null && objDownRow != null)
                {
                    LineManager lm = obj.GetComponent<LineManager>();
                    LineManager lmDownRow = objDownRow.GetComponent<LineManager>();

                    if (lm != null && lmDownRow != null && lm.gameList.Count > 0)
                    {
                        if (lm.gameList.Count > 0)
                        {
                            foreach (var block in lm.gameList)
                            {
                                if (block != null)
                                {
                                    Vector3 currentPosition = block.transform.position;
                                    currentPosition.y -= 0.5525f * rowCount;
                                    block.transform.position = currentPosition;
                                }
                            }
                        }
                        if (!isEnd)
                        {
                            for (int i = 0; i < LineManager.instance.lmList.Count; i++)
                            {
                                LineManager.instance.lmList[i].gameList.Clear();
                            }
                            LineManager.instance.lmList.Clear();
                            isEnd = true;
                        }
                        LineManager.instance.dicCount[objDownRow] = 0;
                        LineManager.instance.dicCount[obj] = 0;
                        lmDownRow.gameList.Clear();
                        lmDownRow.gameList.AddRange(lm.gameList);
                        LineManager.instance.dicCount[objDownRow] = lm.gameList.Count;
                        lm.gameList.Clear();
                    }
                }
            }
        }
    }


    bool IsConsecutive(List<int> lines)
    {
        for (int i = 0; i < lines.Count - 1; i++)
        {
            if (lines[i] + 1 != lines[i + 1])
            {
                return false;
            }
        }
        return true;
    }

}
