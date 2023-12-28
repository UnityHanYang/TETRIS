using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;
using UnityEngine;

public class BlockProperty : MonoBehaviour
{
    public static BlockProperty instance;
    Vector3 downVec = new Vector3();
    Vector3 rightVec = new Vector3();
    Vector3 leftVec = new Vector3();
    bool istrue = false;
    bool istrue2 = false;
    bool isRight = false;
    bool isLeft = false;
    public bool islive = true;
    bool ischange = false;
    public Transform pivot;
    public Quaternion qua;
    Rigidbody2D rigid;
    public Transform[] blocks;
    public Transform leftGame;
    public Transform rightGame;
    public Transform bottomGame;
    public bool isSpace = false;
    public bool isDie = false;
    public Collider2D[] collArr;
    Vector2 sizeVec;
    private Vector3 currentRotation;
    public List<Transform> topBlocks = new List<Transform>();
    private List<int> index = new List<int>();
    private List<Transform> xEquals = new List<Transform>();
    public bool isReturn;
    private Transform trans;
    public bool isContain;
    public RayCastBlock rcb;
    private bool isDieLive2;
    public int oneCount = 0;
    public bool isCtrl;
    public bool isCtrlSimulation;
    public bool isPutRight;
    public bool isPutLeft;
    public string str;
    public bool isGameEnd;
    private GameObject firstTarget;
    private float firstValue;
    private bool isDown;
    public Vector2 newPosition = new Vector2();
    private bool isStart;
    public bool isBlockNum;
    public GameObject currentSimulation;
    private bool isOver;
    private float currentTime = 0;
    private float targetTime = 0.08f;
    private void Awake()
    {
        instance = this;
        pivot = transform.GetChild(0);
        blocks = new Transform[4];
        collArr = new Collider2D[pivot.transform.childCount];
        for (int i = 0; i < pivot.transform.childCount; i++)
        {
            blocks[i] = pivot.transform.GetChild(i);
        }
        leftGame = blocks[0].transform;
        rightGame = blocks[0].transform;
        bottomGame = blocks[0].transform;
        rigid = GetComponent<Rigidbody2D>();
        for (int i = 0; i < pivot.transform.childCount; i++)
        {
            collArr[i] = pivot.transform.GetChild(i).GetComponent<Collider2D>();
        }
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].GetComponent<BoxCollider2D>().size = new Vector2(0.912f, 0.99f);
        }
        rcb = GetComponent<RayCastBlock>();
    }
    void Start()
    {
        qua.eulerAngles = new Vector3(0f, 0f, 90f);
        downVec = transform.position;
        downVec.y = transform.position.y - 0.545f;
        currentSimulation = GameObject.FindGameObjectWithTag("Simulation");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isSpace = false;
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Update()
    {
        if (bottomGame != null)
        {
            // Debug.Log(bottomGame.transform.position.y);
        }
        if (LineTextManager.instance.cnt >= 40)
        {
            Destroy(this.gameObject);
        }
        if (!isGameEnd)
        {
            downVec = transform.position;
            if (!isReturn)
            {
                topBlocks.Clear();
                index.Clear();
                for (int i = 0; i < blocks.Length; i++)
                {
                    if (!index.Contains(i))
                    {
                        xEquals.Add(blocks[i]);
                        for (int j = i + 1; j < blocks.Length; j++)
                        {
                            if (j < blocks.Length)
                            {
                                if (blocks[j] != null)
                                {
                                    if (Mathf.Approximately(blocks[i].position.x, blocks[j].position.x))
                                    {
                                        xEquals.Add(blocks[j]);
                                        index.Add(j);
                                    }
                                }
                            }
                        }
                        if (xEquals.Count == 1)
                        {
                            topBlocks.Add(xEquals[0]);
                            xEquals.RemoveAt(0);
                        }
                        else if (xEquals.Count > 1)
                        {
                            trans = xEquals[0];
                            for (int k = 1; k < xEquals.Count; k++)
                            {
                                if (trans.position.y < xEquals[k].position.y)
                                {
                                    trans = xEquals[k];
                                }
                            }
                            topBlocks.Add(trans);
                        }
                    }
                    xEquals.Clear();
                    trans = null;
                }
                isReturn = true;
            }
            for (int i = 0; i < blocks.Length; i++)
            {
                if (leftGame != null && blocks[i] != null)
                {
                    if (leftGame.position.x > blocks[i].position.x)
                    {
                        leftGame = blocks[i].transform;
                    }
                }
                if (rightGame != null && blocks[i] != null)
                {
                    if (rightGame.position.x < blocks[i].position.x)
                    {
                        rightGame = blocks[i].transform;
                    }
                }
                if (bottomGame != null && blocks[i] != null)
                {
                    if (bottomGame.position.y > blocks[i].position.y)
                    {
                        bottomGame = blocks[i].transform;
                    }
                }
            }
            currentRotation = pivot.transform.rotation.eulerAngles;
            str = this.gameObject.name.Substring(7, 1);
            if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.UpArrow) && !isSpace && islive)
            {
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && !isSpace && islive || Input.GetKeyDown(KeyCode.LeftControl) && !isSpace && islive)
            {
                if (!str.Equals("0"))
                {
                    if (!ischange)
                    {
                        isCtrl = true;
                        isCtrlSimulation = true;
                        isReturn = false;
                        BlockSimulation.instance.isReturn = false;
                        for (int i = 0; i < blocks.Length; i++)
                        {
                            if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 270) || Mathf.Approximately(currentRotation.z, 90.00001f))
                            {
                                sizeVec = new Vector2(0.912f, 0.99f);
                            }
                            else
                            {
                                sizeVec = new Vector2(0.99f, 0.912f);
                            }
                            blocks[i].GetComponent<BoxCollider2D>().size = sizeVec;
                        }
                    }
                    ischange = true;
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.UpArrow) && !isSpace && islive)
            {

            }
            else if (Input.GetKeyUp(KeyCode.LeftControl) && !isSpace && islive || Input.GetKeyUp(KeyCode.UpArrow) && !isSpace && islive)
            {
                qua.eulerAngles += new Vector3(0f, 0f, 90f);
                ischange = false;
            }
            if (!isSpace && Input.GetKeyDown(KeyCode.Space))
            {
                RayCastBlock rcb = this.GetComponent<RayCastBlock>();
                for (int i = 0; i < rcb.targetMaxY.Count; i++)
                {
                    if (rcb.targetMaxY[i] > 5.6)
                    {
                        isOver = true;
                    }
                }
                if (!isOver && !RightLeftArrowMove.instance.isbottomCollider)
                {
                    rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
                    StopAllCoroutines();
                    isSpace = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                isDown = true;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                isDown = false;
            }
            else if (!isSpace && !isDie && isDown && Input.GetKey(KeyCode.DownArrow) && islive)
            {
                StartCoroutine("Fastdownmove");
            }
            else if (!isSpace && !isDie && !Input.GetKey(KeyCode.DownArrow) && islive || !isDown && !isSpace && islive && !isDie)
            {
                StartCoroutine("downmove");
            }
            if (isSpace)
            {
                transform.position += new Vector3(0f, -0.9f, 0f);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && islive)
            {
                isPutLeft = true;
                BlockSimulation.instance.isEnter = false;
                BlockSimulation.instance.isReturn = false;
                StartCoroutine("LeftMove");
            }
            else if (Input.GetKey(KeyCode.RightArrow) && islive)
            {
                isPutRight = true;
                BlockSimulation.instance.isEnter = false;
                BlockSimulation.instance.isReturn = false;
                StartCoroutine("RightMove");
            }
            if (!RightLeftArrowMove.instance.isleftCollider && Input.GetKeyUp(KeyCode.LeftArrow) && islive)
            {
                isPutLeft = false;
            }
            else if (!RightLeftArrowMove.instance.isrightCollider && Input.GetKeyUp(KeyCode.RightArrow) && islive)
            {
                isPutRight = false;
            }
            if (isDie && !isStart)
            {
                DelayDie();
            }
            if (RayCastBlock.Instance.targetMaxY.Count > 0)
            {
                firstValue = RayCastBlock.Instance.targetMaxY[0];
                firstTarget = RayCastBlock.Instance.strings[0];
                if (RayCastBlock.Instance.targetMaxY.Count > 1)
                {
                    for (int i = 1; i < RayCastBlock.Instance.strings.Count; i++)
                    {
                        if (firstValue < RayCastBlock.Instance.targetMaxY[i])
                        {
                            firstValue = RayCastBlock.Instance.targetMaxY[i];
                            firstTarget = RayCastBlock.Instance.strings[i];
                        }
                    }
                }
            }
        }

    }

    void DelayDie()
    {
        if (!isDieLive2 && !isStart)
        {
            for (int i = 0; i < BlockProperty.instance.blocks.Length; i++)
            {
                OnTriggerBlock onTriggerBlock = BlockProperty.instance.blocks[i].GetComponent<OnTriggerBlock>();
                onTriggerBlock.isLive = false;
            }
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;

            for (int i = 0; i < pivot.childCount; i++)
            {
                if (pivot.GetChild(i).position.y >= 6.7)
                {
                    isGameEnd = true;
                    BlockManager.Instance.isEnd = true;
                    break;
                }
            }
            if (!isGameEnd)
            {
                if (BlockSpawn.instance.nextIndex.Count > 0)
                {
                    BlockSpawn.instance.nextIndex.RemoveAt(0);
                }
                for (int i = 0; i < blocks.Length; i++)
                {
                    if (blocks[i].position.y >= 5.12)
                    {
                        WarningBlock.Instance.lastBlockPivot.Add(blocks[i]);
                    }
                    else
                    {
                        continue;
                    }
                }
                PicecManager.instance.picecValue++;
                PicecManager.instance.isWrite = true;
                this.GetComponent<RightLeftArrowMove>().enabled = false;
                this.GetComponent<BlockSpeedDown>().enabled = false;
                this.GetComponent<BlockFastDown>().enabled = false;
                this.GetComponent<BlockRotation>().enabled = false;
                if (currentSimulation != null)
                {
                    if (currentSimulation.GetComponent<BlockSimulation>() != null)
                    {
                        currentSimulation.GetComponent<BlockSimulation>().enabled = false;
                    }
                }
                Destroy(currentSimulation);
                WarningBlock.Instance.bigF = topBlocks[0].transform.position.y;
                for (int i = 1; i < topBlocks.Count; i++)
                {
                    if (WarningBlock.Instance.bigF < topBlocks[i].transform.position.y)
                    {
                        WarningBlock.Instance.bigF = topBlocks[i].transform.position.y;
                    }
                }
                islive = false;
                isDie = false;
                isDieLive2 = true;
            }
            GetComponent<BlockProperty>().enabled = false;
            isSpace = false;
        }
    }
    public void TopRayCast()
    {
        for (int i = 0; i < topBlocks.Count; i++)
        {
            int layerMask = (1 << LayerMask.NameToLayer("Block1")) | (1 << LayerMask.NameToLayer("Block2")) | (1 << LayerMask.NameToLayer("Block3")) | (1 << LayerMask.NameToLayer("Block4")) | (1 << LayerMask.NameToLayer("Block5")) | (1 << LayerMask.NameToLayer("Block6")) | (1 << LayerMask.NameToLayer("Block7"));
            layerMask = ~layerMask;
            Vector2 start = topBlocks[i].position + Vector3.up * 0.4f;
            RaycastHit2D hit2 = Physics2D.Raycast(start, Vector2.up, 7f, layerMask);
            if (hit2.collider != null)
            {
                string str = hit2.collider.ToString().Substring(7, 1);
                if (!BlockManager.Instance.BlocksPositionY.ContainsKey(hit2.collider.ToString()))
                {

                    BlockManager.Instance.BlocksPositionY.Add(hit2.collider.ToString(), TopBlockY(str));
                }
                else
                {
                    BlockManager.Instance.BlocksPositionY[hit2.collider.ToString()] = TopBlockY(str);
                }
            }
        }
        rcb.enabled = false;
    }

    private float TopBlockY(string hitNum)
    {
        float topBlockY = 0f;
        switch (hitNum)
        {
            case "0":
                if (BlockManager.Instance.row1.Count > 0)
                {
                    topBlockY = (float)BlockManager.Instance.row1[BlockManager.Instance.row1.Count - 1];
                }
                break;
            case "1":
                if (BlockManager.Instance.row2.Count > 0)
                {
                    topBlockY = (float)BlockManager.Instance.row2[BlockManager.Instance.row2.Count - 1];
                }
                break;
            case "2":
                if (BlockManager.Instance.row3.Count > 0)
                {
                    topBlockY = (float)BlockManager.Instance.row3[BlockManager.Instance.row3.Count - 1];
                }
                break;
            case "3":
                if (BlockManager.Instance.row4.Count > 0)
                {
                    topBlockY = (float)BlockManager.Instance.row4[BlockManager.Instance.row4.Count - 1];
                }
                break;
            case "4":
                if (BlockManager.Instance.row5.Count > 0)
                {
                    topBlockY = (float)BlockManager.Instance.row5[BlockManager.Instance.row5.Count - 1];
                }
                break;
            case "5":
                if (BlockManager.Instance.row6.Count > 0)
                {
                    topBlockY = (float)BlockManager.Instance.row6[BlockManager.Instance.row6.Count - 1];
                }
                break;
            case "6":
                if (BlockManager.Instance.row7.Count > 0)
                {
                    topBlockY = (float)BlockManager.Instance.row7[BlockManager.Instance.row7.Count - 1];
                }
                break;
            case "7":
                if (BlockManager.Instance.row8.Count > 0)
                {
                    topBlockY = (float)BlockManager.Instance.row8[BlockManager.Instance.row8.Count - 1];
                }
                break;
            case "8":
                if (BlockManager.Instance.row9.Count > 0)
                {
                    topBlockY = (float)BlockManager.Instance.row9[BlockManager.Instance.row9.Count - 1];
                }
                break;
            case "9":
                if (BlockManager.Instance.row10.Count > 0)
                {
                    topBlockY = (float)BlockManager.Instance.row10[BlockManager.Instance.row10.Count - 1];
                }
                break;
        }
        return topBlockY;
    }

    public void RowListAdd(string s, string fullStr, string rowName)
    {
        double f = 0f;
        double roundedResult = 0f;
        switch (s)
        {
            case "0":
                if (rowName.Length == 3)
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 1).ToString()) - 1) * 0.5525f);
                }
                else
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 2).ToString()) - 1) * 0.5525f);
                }
                roundedResult = Math.Ceiling(f * 10000) / 10000;
                BlockManager.Instance.row1.Add(roundedResult);
                break;
            case "1":
                if (rowName.Length == 3)
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 1).ToString()) - 1) * 0.5525f);
                }
                else
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 2).ToString()) - 1) * 0.5525f);
                }
                roundedResult = Math.Ceiling(f * 10000) / 10000;
                BlockManager.Instance.row2.Add(roundedResult);
                break;
            case "2":
                if (rowName.Length == 3)
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 1).ToString()) - 1) * 0.5525f);
                }
                else
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 2).ToString()) - 1) * 0.5525f);
                }
                roundedResult = Math.Ceiling(f * 10000) / 10000;
                BlockManager.Instance.row3.Add(roundedResult);
                break;
            case "3":
                if (rowName.Length == 3)
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 1).ToString()) - 1) * 0.5525f);
                }
                else
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 2).ToString()) - 1) * 0.5525f);
                }
                roundedResult = Math.Ceiling(f * 10000) / 10000;
                BlockManager.Instance.row4.Add(roundedResult);
                break;
            case "4":
                if (rowName.Length == 3)
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 1).ToString()) - 1) * 0.5525f);
                }
                else
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 2).ToString()) - 1) * 0.5525f);
                }
                roundedResult = Math.Ceiling(f * 10000) / 10000;
                BlockManager.Instance.row5.Add(roundedResult);
                break;
            case "5":
                if (rowName.Length == 3)
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 1).ToString()) - 1) * 0.5525f);
                }
                else
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 2).ToString()) - 1) * 0.5525f);
                }
                roundedResult = Math.Ceiling(f * 10000) / 10000;
                BlockManager.Instance.row6.Add(roundedResult);
                break;
            case "6":
                if (rowName.Length == 3)
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 1).ToString()) - 1) * 0.5525f);
                }
                else
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 2).ToString()) - 1) * 0.5525f);
                }
                roundedResult = Math.Ceiling(f * 10000) / 10000;
                BlockManager.Instance.row7.Add(roundedResult);
                break;
            case "7":
                roundedResult = Math.Ceiling(f * 10000) / 10000;
                if (rowName.Length == 3)
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 1).ToString()) - 1) * 0.5525f);
                }
                else
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 2).ToString()) - 1) * 0.5525f);
                }
                roundedResult = Math.Ceiling(f * 10000) / 10000;
                BlockManager.Instance.row8.Add(roundedResult);
                break;
            case "8":
                if (rowName.Length == 3)
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 1).ToString()) - 1) * 0.5525f);
                }
                else
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 2).ToString()) - 1) * 0.5525f);
                }
                roundedResult = Math.Ceiling(f * 10000) / 10000;
                BlockManager.Instance.row9.Add(roundedResult);
                break;
            case "9":
                if (rowName.Length == 3)
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 1).ToString()) - 1) * 0.5525f);
                }
                else
                {
                    f = -4.2275 + ((int.Parse(rowName.Substring(1, 2).ToString()) - 1) * 0.5525f);
                }
                roundedResult = Math.Ceiling(f * 10000) / 10000;
                BlockManager.Instance.row10.Add(roundedResult);
                break;
        }

        BlockManager.Instance.row1.Sort();
        BlockManager.Instance.row2.Sort();
        BlockManager.Instance.row3.Sort();
        BlockManager.Instance.row4.Sort();
        BlockManager.Instance.row5.Sort();
        BlockManager.Instance.row6.Sort();
        BlockManager.Instance.row7.Sort();
        BlockManager.Instance.row8.Sort();
        BlockManager.Instance.row9.Sort();
        BlockManager.Instance.row10.Sort();
    }

    IEnumerator LeftMove()
    {
        if (!isLeft && !RightLeftArrowMove.instance.isleftCollider)
        {
            if (leftGame != null)
            {
                if (leftGame.position.x - 0.5518 >= -2.355)
                {
                    isLeft = true;
                    RayCastBlock.Instance.isAdd = false;
                    leftVec = transform.position;
                    leftVec.x = leftVec.x - 0.5518f;
                    transform.position = leftVec;
                    yield return new WaitForSeconds(0.1f);
                    downVec = transform.position;
                    isLeft = false;
                }
            }
        }
    }
    IEnumerator RightMove()
    {
        if (!isRight && !RightLeftArrowMove.instance.isrightCollider)
        {
            if (rightGame != null)
            {
                if (rightGame.position.x + 0.5518 <= 2.63)
                {
                    isRight = true;
                    RayCastBlock.Instance.isAdd = false;
                    rightVec = transform.position;
                    rightVec.x = rightVec.x + 0.5518f;
                    transform.position = rightVec;
                    yield return new WaitForSeconds(0.1f);
                    downVec = transform.position;
                    isRight = false;
                }
            }
        }
    }
    IEnumerator Fastdownmove()
    {
        if (!istrue2)
        {
            if (bottomGame != null)
            {
                if (RayCastBlock.Instance.targetMaxY.Count > 0)
                {
                    newPosition = firstTarget.transform.position;

                    newPosition.y -= 1.105f;
                    if ((newPosition.y + BlockSpeedDown.instance.remainV) > firstValue && !RightLeftArrowMove.instance.isbottomCollider && !isDie)
                    {
                        isBlockNum = true;
                        istrue2 = true;
                        transform.position = downVec;
                        BlockRotation.instance.time = 0.0f;
                        downVec.y = downVec.y - 0.5525f;
                        transform.position = downVec;
                        yield return new WaitForSeconds(0.1f);
                        istrue2 = false;
                    }
                    else
                    {
                        isDie = true;
                    }
                }
                else
                {
                    if (bottomGame != null)
                    {
                        if (bottomGame.position.y - 0.5525 >= -4.234)
                        {
                            istrue2 = true;
                            transform.position = downVec;
                            BlockRotation.instance.time = 0.0f;
                            downVec.y = downVec.y - 0.5525f;
                            transform.position = downVec;
                            yield return new WaitForSeconds(0.1f);
                            istrue2 = false;
                        }
                        else
                        {
                            isDie = true;
                        }
                    }
                }
            }
        }
    }
    IEnumerator downmove()
    {
        if (!istrue)
        {
            if (bottomGame != null)
            {
                if (bottomGame.position.y - 0.5525 >= -4.234 && !RightLeftArrowMove.instance.isbottomCollider && !isDie)
                {
                    istrue = true;
                    downVec.y = downVec.y - 0.5525f;
                    transform.position = downVec;
                    yield return new WaitForSeconds(0.9f);
                    downVec = transform.position;
                    istrue = false;
                }
                else
                {
                    currentTime += Time.deltaTime;
                    if (currentTime >= targetTime)
                    {
                        isDie = true;
                        currentTime = 0.0f;
                    }
                    else
                    {
                        if (isCtrl)
                        {
                            currentTime = 0.0f;
                        }
                    }
                }
            }
        }
    }
}
