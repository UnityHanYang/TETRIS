using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBlockManager : MonoBehaviour
{
    public static StaticBlockManager Instance;
    public List<GameObject> list = new List<GameObject>();
    public List<GameObject> staticBlockList = new List<GameObject>();
    private GameObject gameBlock;
    public bool istrue = false;
    public List<GameObject> remainBlock = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        for (int i = 0; i < staticBlockList.Count; i++)
        {
            gameBlock = Instantiate(list[BlockSpawn.instance.nextIndex[i+1]]);
            gameBlock.transform.SetParent(staticBlockList[i].transform);
            gameBlock.transform.position = staticBlockList[i].transform.position;
            gameBlock.SetActive(true);
            remainBlock.Add(gameBlock);
        }
    }
    void Update()
    {
        if (istrue)
        {
            for (int i = 0; i < remainBlock.Count; i++)
            {
                Destroy(remainBlock[i]);
            }
            for (int i = 0; i < staticBlockList.Count; i++)
            {
                gameBlock = Instantiate(list[BlockSpawn.instance.nextIndex[i + 1]]);
                gameBlock.transform.SetParent(staticBlockList[i].transform);
                gameBlock.transform.position = staticBlockList[i].transform.position;
                gameBlock.SetActive(true);
                remainBlock[i] = gameBlock;
            }
            istrue = false;
        }
    }
}
