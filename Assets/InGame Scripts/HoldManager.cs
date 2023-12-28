using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldManager : MonoBehaviour
{
    public static HoldManager instance;
    public Transform go;
    public GameObject holdGo;
    public GameObject[] indexGo;
    public GameObject holdBlock;
    Transform transGo;
    public int index;
    public bool isHold;
    public bool istrue = true;
    public GameObject blocks;
    public GameObject blocksSimulation;
    private Transform pivot;
    private SpriteRenderer block;
    public Color currentColor;
    private GameObject simulationBlock;
    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (BlockProperty.instance != null)
        {
            if (!BlockProperty.instance.isGameEnd && LineTextManager.instance.cnt < 40 && BlockProperty.instance.islive && !isHold && Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.C))
            {

            }
            else if (!BlockProperty.instance.isGameEnd && LineTextManager.instance.cnt < 40 && BlockProperty.instance.islive && !isHold && Input.GetKeyDown(KeyCode.LeftShift) || !BlockProperty.instance.isGameEnd && LineTextManager.instance.cnt < 40 && BlockProperty.instance.islive && !isHold && Input.GetKeyDown(KeyCode.C))
            {
                if (holdBlock.transform.childCount > 0)
                {
                    Transform HoldenGo = GameObject.FindGameObjectWithTag("Hold").transform.GetChild(0);
                    Destroy(HoldenGo.gameObject);
                    transGo = GameObject.FindGameObjectWithTag("BlockSpace").transform.GetChild(GameObject.FindGameObjectWithTag("BlockSpace").transform.childCount - 1);
                    GameObject newObject = Instantiate(indexGo[BlockSpawn.instance.nextIndex[0]]);
                    pivot = newObject.transform.GetChild(0);
                    BlockSpawn.instance.pivot = pivot;
                    currentColor = pivot.GetChild(0).GetComponent<SpriteRenderer>().color;
                    for (int i = 0; i < pivot.transform.childCount; i++)
                    {
                        block = pivot.GetChild(i).GetComponent<SpriteRenderer>();
                        block.color = new Color(111 / 255f, 111 / 255f, 111 / 255f);
                    }
                    newObject.transform.SetParent(holdBlock.transform);
                    newObject.transform.position = holdGo.transform.position;
                    newObject.gameObject.SetActive(true);
                    Destroy(transGo.gameObject);
                    simulationBlock = GameObject.FindGameObjectWithTag("Simulation");
                    Destroy(simulationBlock);
                    LineManager.instance.isBlockLive = false;
                    GameObject yetObject = Instantiate(BlockSpawn.instance.spawn[index]);
                    yetObject.transform.SetParent(blocks.transform);
                    yetObject.transform.position = BlockSpawn.instance.copyVec;
                    yetObject.gameObject.SetActive(true);
                    StaticCurrentBlock.Instance.isHold = true;
                    StaticCurrentBlock.Instance.index = index;
                    GameObject yetSimulation = Instantiate(BlockSpawn.instance.spawnSimulationBlock[index]);
                    yetSimulation.transform.SetParent(blocksSimulation.transform);
                    yetSimulation.gameObject.SetActive(true);
                    yetSimulation.GetComponent<BlockSimulation>().go = yetObject;
                    index = BlockSpawn.instance.nextIndex[0];
                    block = null;
                }
                else
                {
                    go = GameObject.FindGameObjectWithTag("BlockSpace").transform.GetChild(GameObject.FindGameObjectWithTag("BlockSpace").transform.childCount - 1);
                    GameObject newObject = Instantiate(indexGo[BlockSpawn.instance.nextIndex[0]]);
                    pivot = newObject.transform.GetChild(0);
                    BlockSpawn.instance.pivot = pivot;
                    currentColor = pivot.GetChild(0).GetComponent<SpriteRenderer>().color;
                    for (int i = 0; i < pivot.transform.childCount; i++)
                    {
                        block = pivot.GetChild(i).GetComponent<SpriteRenderer>();
                        block.color = new Color(111 / 255f, 111 / 255f, 111 / 255f);
                    }
                    index = BlockSpawn.instance.nextIndex[0];
                    newObject.transform.SetParent(holdBlock.transform);
                    newObject.transform.position = holdGo.transform.position;
                    newObject.gameObject.SetActive(true);
                    Destroy(go.gameObject);
                    simulationBlock = GameObject.FindGameObjectWithTag("Simulation");
                    Destroy(simulationBlock);
                    istrue = false;
                    BlockProperty.instance.islive = false;
                    BlockSpawn.instance.nextIndex.RemoveAt(0);
                }
                isHold = true;
            }
        }
    }
}
