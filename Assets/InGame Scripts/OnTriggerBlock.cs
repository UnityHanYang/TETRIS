using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OnTriggerBlock : MonoBehaviour
{
    public static OnTriggerBlock instance;
    //public GameObject go;
    public List<GameObject> colliderList = new List<GameObject>();
    public bool isAdd = false;
    private Vector2 transVec;
    private Vector2 mylayerTransVec;
    public bool isLive = true;
    public GameObject currentBlock;
    public GameObject go;
    public bool isHit = false;
    private string remainCollider;

    private void Awake()
    {
        instance = this;
        isLive = true;
    }


    private void Update()
    {
        for (int i = 0; i < RayCastBlock.Instance.temporary.Count; i++)
        {
            Vector2 start = RayCastBlock.Instance.temporary[i].position + Vector3.down * 0.3f;
            int blockLayerMask = (1 << LayerMask.NameToLayer("Block1")) | (1 << LayerMask.NameToLayer("Block2")) | (1 << LayerMask.NameToLayer("Block3")) | (1 << LayerMask.NameToLayer("Block4")) | (1 << LayerMask.NameToLayer("Block5")) | (1 << LayerMask.NameToLayer("Block6")) | (1 << LayerMask.NameToLayer("Block7"));
            blockLayerMask = ~blockLayerMask;
            RaycastHit2D hit2 = Physics2D.Raycast(start, Vector2.down, 0.5f, blockLayerMask);
            if (hit2.collider != null)
            {
                isHit = true;
            }
            else
            {
                isHit = false;
            }
        }
        int layerMask = (1 << LayerMask.NameToLayer("Block1")) | (1 << LayerMask.NameToLayer("Block2")) | (1 << LayerMask.NameToLayer("Block3")) | (1 << LayerMask.NameToLayer("Block4")) | (1 << LayerMask.NameToLayer("Block5")) | (1 << LayerMask.NameToLayer("Block6")) | (1 << LayerMask.NameToLayer("Block7"));
        layerMask = ~layerMask;
        transVec = new Vector2(transform.position.x, transform.position.y+0.11f);
        RaycastHit2D hit = Physics2D.Raycast(transVec, Vector2.down, 0.3f, layerMask);
        if (hit.collider != null)
        {   
            currentBlock = this.gameObject;
            go = hit.collider.transform.parent.gameObject;
            remainCollider = hit.collider.ToString();
        }
        if (!isLive)
        {
            if (go != null)
            {
                LineManager lineManager = go.GetComponent<LineManager>();
                colliderList.Add(currentBlock);
                lineManager.gameList.Add(currentBlock);
                string str = remainCollider.Substring(7, 1);
                BlockProperty.instance.RowListAdd(str, remainCollider, go.ToString().Split(" ")[1]);
                BlockProperty.instance.TopRayCast();

            }
            if (go != null)
            {
                if (!LineManager.instance.dicCount.ContainsKey(go))
                {
                    LineManager.instance.dicCount.Add(go, 1);
                }
                else
                {
                    LineManager.instance.dicCount[go] += 1;
                }
            }
            if (remainCollider != null)
            {
                if (!LineManager.instance.rowBlockCount.ContainsKey(remainCollider))
                {
                    LineManager.instance.rowBlockCount.Add(remainCollider, 1);
                }
                else
                {
                    LineManager.instance.rowBlockCount[remainCollider] += 1;
                }
            }
            GetComponent<OnTriggerBlock>().enabled = false;
            isLive = true;
        }
        int myLayerIgnoreMask =  (1 << LayerMask.NameToLayer("Rows")) | (1 << gameObject.layer);
        myLayerIgnoreMask = ~myLayerIgnoreMask;
        mylayerTransVec = new Vector2(transform.position.x, transform.position.y + 0.11f);
        RaycastHit2D myLayerIgnoreHit = Physics2D.Raycast(mylayerTransVec, Vector2.down, 0.3f, myLayerIgnoreMask);
        //Debug.DrawRay(mylayerTransVec, Vector2.down * 0.3f, Color.blue);
        if (myLayerIgnoreHit.collider != null)
        {
            //Debug.Log(myLayerIgnoreHit.collider.name);
        }
    }
}
