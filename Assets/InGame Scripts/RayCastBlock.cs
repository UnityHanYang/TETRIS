using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastBlock : MonoBehaviour
{
    public static RayCastBlock Instance;
    public Transform[] blocks;
    public Transform pivot;
    public List<Transform> temporary = new List<Transform>();
    public List<int> index = new List<int>();
    public List<Transform> xEquals = new List<Transform>();
    public bool isAdd = true;
    private Transform trans;
    private int count;
    public List<float> targetMaxY = new List<float>();
    public List<GameObject> strings = new List<GameObject>();
    public bool isClear = true;

    private void Awake()
    {
        Instance = this;
        blocks = new Transform[4];
        pivot = transform.GetChild(0);
        for (int i = 0; i < pivot.transform.childCount; i++)
        {
            blocks[i] = pivot.transform.GetChild(i);
        }
        for (int i = 0; i < blocks.Length; i++)
        {
            if (!index.Contains(i))
            {
                xEquals.Add(blocks[i]);
                for (int j = i + 1; j < blocks.Length; j++)
                {
                    if (j < blocks.Length)
                    {
                        if (Mathf.Approximately(blocks[i].position.x, blocks[j].position.x))
                        {
                            xEquals.Add(blocks[j]);
                            index.Add(j);
                        }
                    }
                }
                if (xEquals.Count == 1)
                {
                    temporary.Add(xEquals[0]);
                    xEquals.RemoveAt(0);
                }
                else if (xEquals.Count > 1)
                {
                    trans = xEquals[0];
                    for (int k = 1; k < xEquals.Count; k++)
                    {
                        if (trans.position.y > xEquals[k].position.y)
                        {
                            trans = xEquals[k];
                        }
                    }
                    temporary.Add(trans);
                }
            }
            xEquals.Clear();
            trans = null;
        }
        for (int i = 0; i < temporary.Count; i++)
        {
            Vector2 start = temporary[i].position + Vector3.down * 0.3f;
            RaycastHit2D hit2 = Physics2D.Raycast(start, Vector2.down, 16f);
            if (hit2.collider != null)
            {
                foreach (KeyValuePair<string, float> pair in BlockManager.Instance.BlocksPositionY)
                {
                    if (pair.Key == hit2.collider.ToString())
                    {
                        strings.Add(temporary[i].gameObject);
                        targetMaxY.Add(pair.Value);
                        count++;
                        break;
                    }
                }
            }
        }
        if (count > 0)
        {
            BlockProperty.instance.isContain = true;
        }
        else
        {
            BlockProperty.instance.isContain = false;
        }
    }

    void Update()
    {
        if (BlockProperty.instance.islive)
        {
            if (!isAdd)
            {
                temporary.Clear();
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
                                if (Mathf.Abs(blocks[i].position.x - blocks[j].position.x) < 0.00001)
                                {
                                    xEquals.Add(blocks[j]);
                                    index.Add(j);
                                }
                            }
                        }
                        if (xEquals.Count == 1)
                        {
                            temporary.Add(xEquals[0]);
                        }
                        else if (xEquals.Count > 1)
                        {
                            trans = xEquals[0];
                            for (int k = 1; k < xEquals.Count; k++)
                            {
                                if (trans.position.y > xEquals[k].position.y)
                                {
                                    trans = xEquals[k];
                                }
                            }
                            temporary.Add(trans);
                        }
                    }
                    xEquals.Clear();
                    trans = null;
                }
                count = 0;
                targetMaxY.Clear();
                strings.Clear();
                if (!isClear)
                {
                    for (int i = 0; i < temporary.Count; i++)
                    {
                        Vector2 start = temporary[i].position + Vector3.down * 0.3f;
                        RaycastHit2D hit2 = Physics2D.Raycast(start, Vector2.down, 16f);
                        Debug.DrawRay(start, Vector2.down * 16f, Color.red);
                        if (hit2.collider != null)
                        {
                            foreach (KeyValuePair<string, float> pair in BlockManager.Instance.BlocksPositionY)
                            {
                                //Debug.Log(pair.Key+",  "+ hit2.collider.ToString());
                                if (pair.Key == hit2.collider.ToString())
                                {
                                    strings.Add(temporary[i].gameObject);
                                    targetMaxY.Add(pair.Value);
                                    count++;
                                    break;
                                }
                            }
                        }
                    }
                    if (count > 0)
                    {
                        BlockProperty.instance.isContain = true;
                    }
                    else
                    {
                        BlockProperty.instance.isContain = false;
                    }
                    isAdd = true;
                }
            }
        }
    }
}
