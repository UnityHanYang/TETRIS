using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCurrentBlock : MonoBehaviour
{
    public static StaticCurrentBlock Instance;
    private GameObject gameBlock;
    public GameObject parentGameBlock;
    public GameObject removeGameBlock;
    public bool istrue;
    public bool isHold;
    public int index;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        gameBlock = Instantiate(StaticBlockManager.Instance.list[BlockSpawn.instance.nextIndex[0]]);
        gameBlock.transform.SetParent(parentGameBlock.transform);
        gameBlock.transform.position = parentGameBlock.transform.position;
        gameBlock.SetActive(true);
        removeGameBlock = gameBlock;
    }
    void Update()
    {
        if (istrue)
        {
            Destroy(removeGameBlock);
            gameBlock = Instantiate(StaticBlockManager.Instance.list[BlockSpawn.instance.nextIndex[0]]);
            gameBlock.transform.SetParent(parentGameBlock.transform);
            gameBlock.transform.position = parentGameBlock.transform.position;
            gameBlock.SetActive(true);
            removeGameBlock = gameBlock;
            istrue = false;
        }
        else if (isHold)
        {
            Destroy(removeGameBlock);
            gameBlock = Instantiate(StaticBlockManager.Instance.list[index]);
            gameBlock.transform.SetParent(parentGameBlock.transform);
            gameBlock.transform.position = parentGameBlock.transform.position;
            gameBlock.SetActive(true);
            removeGameBlock = gameBlock;
            isHold = false;
        }
    }
}
