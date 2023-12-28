using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    public static BlockSpawn instance;
    public GameObject[] spawn;
    public GameObject[] spawnSimulationBlock;
    public GameObject go;
    public GameObject goSimulation;
    private List<int> index;
    public GameObject blocks;
    public GameObject simulationBlock;
    private Vector3 originalVec;
    private Vector3 originalVecSimulation;
    public List<int> nextIndex = new List<int>();
    int ran = 0;
    bool isLast = true;
    int cnt = 0;
    public Vector3 copyVec;
    public Transform pivot;
    private SpriteRenderer block;
    private bool isCreate;
    private void Awake()
    {
        instance = this;
        index = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
        originalVec = transform.position;
        originalVecSimulation = originalVec;
        originalVecSimulation.y -= 7f;
        copyVec = transform.position;
        while (cnt < 4)
        {
            ran = Random.Range(0, 7);
            if (index.Contains(ran))
            {
                nextIndex.Add(ran);
                index.Remove(ran);
                cnt++;
            }
        }
    }

    void Update()
    {
        if (GameStartCountDown.instance.isEnd)
        {
            go = Instantiate(spawn[nextIndex[0]], originalVec, Quaternion.identity);
            go.transform.SetParent(blocks.transform);
            go.SetActive(true);
            goSimulation = Instantiate(spawnSimulationBlock[nextIndex[0]], originalVecSimulation, Quaternion.identity);
            goSimulation.transform.SetParent(simulationBlock.transform);
            goSimulation.SetActive(true);
            BlockSimulation.instance.go = go;
            isCreate = true;
            GameStartCountDown.instance.isEnd = false;
        }
        if (BlockProperty.instance != null || isCreate)
        {
            if (!BlockProperty.instance.isGameEnd && LineTextManager.instance.cnt < 40 && !BlockProperty.instance.islive)
            {
                while (isLast)
                {
                    ran = Random.Range(0, 7);
                    if (index.Count == 0)
                    {
                        index = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
                    }
                    if (index.Contains(ran))
                    {
                        nextIndex.Add(ran);
                        index.Remove(ran);
                        isLast = false;
                    }
                }
                StaticBlockManager.Instance.istrue = true;
                StaticCurrentBlock.Instance.istrue = true;
                go = Instantiate(spawn[nextIndex[0]], originalVec, Quaternion.identity);
                LineManager.instance.isBlockLive = false;
                go.transform.SetParent(blocks.transform);
                go.SetActive(true);

                goSimulation = Instantiate(spawnSimulationBlock[nextIndex[0]], originalVecSimulation, Quaternion.identity);
                goSimulation.transform.SetParent(simulationBlock.transform);
                goSimulation.SetActive(true);
                goSimulation.GetComponent<BlockSimulation>().go = go;
                if (!HoldManager.instance.istrue)
                {
                    HoldManager.instance.istrue = true;
                }
                else
                {
                    HoldManager.instance.isHold = false;
                    if (pivot != null)
                    {
                        for (int i = 0; i < pivot.transform.childCount; i++)
                        {
                            block = pivot.GetChild(i).GetComponent<SpriteRenderer>();
                            block.color = HoldManager.instance.currentColor;
                        }
                    }
                }
                isLast = true;
                BlockProperty.instance.islive = true;
                OnTriggerBlock.instance.isAdd = false;
            }
        }
    }
}
