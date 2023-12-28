using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RightLeftArrowMove : MonoBehaviour
{
    public static RightLeftArrowMove instance;
    private List<Transform> leftTemporary = new List<Transform>();
    private List<int> leftIndex = new List<int>();
    private List<Transform> leftYEquals = new List<Transform>();
    private Transform leftTrans;
    private List<Transform> rightTemporary = new List<Transform>();
    private List<int> rightIndex = new List<int>();
    private List<Transform> rightYEquals = new List<Transform>();
    private Transform rightTrans;
    public List<Transform> bottomTemporary = new List<Transform>();
    private List<int> bottomIndex = new List<int>();
    private List<Transform> bottomXEquals = new List<Transform>();
    private Transform bottomTrans;
    private Vector2 leftVec;
    private Vector2 bottomVec;
    private Vector2 rightVec;
    public bool isleftCollider;
    public bool isbottomCollider;
    public bool isrightCollider;
    public bool istopCollider;
    private int count;
    private int count2;
    private int count3;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (BlockProperty.instance.islive && !BlockProperty.instance.isGameEnd)
        {
            leftTemporary.Clear();
            leftIndex.Clear();
            for (int i = 0; i < RayCastBlock.Instance.blocks.Length; i++)
            {
                if (!leftIndex.Contains(i))
                {
                    leftYEquals.Add(RayCastBlock.Instance.blocks[i]);
                    for (int j = i + 1; j < RayCastBlock.Instance.blocks.Length; j++)
                    {
                        if (j < RayCastBlock.Instance.blocks.Length)
                        {
                            if (RayCastBlock.Instance.blocks[i] != null && RayCastBlock.Instance.blocks[j] != null)
                            {
                                if (Mathf.Abs(RayCastBlock.Instance.blocks[i].position.y - RayCastBlock.Instance.blocks[j].position.y) < 0.00001)
                                {
                                    leftYEquals.Add(RayCastBlock.Instance.blocks[j]);
                                    leftIndex.Add(j);
                                }
                            }
                        }
                    }
                    if (leftYEquals.Count == 1)
                    {
                        leftTemporary.Add(leftYEquals[0]);
                    }
                    else if (leftYEquals.Count > 1)
                    {
                        leftTrans = leftYEquals[0];
                        for (int k = 1; k < leftYEquals.Count; k++)
                        {
                            if (leftTrans.position.x > leftYEquals[k].position.x)
                            {
                                leftTrans = leftYEquals[k];
                            }
                        }
                        leftTemporary.Add(leftTrans);
                    }
                }
                leftYEquals.Clear();
                leftTrans = null;
            }
            rightTemporary.Clear();
            rightIndex.Clear();
            for (int i = 0; i < RayCastBlock.Instance.blocks.Length; i++)
            {
                if (!rightIndex.Contains(i))
                {
                    rightYEquals.Add(RayCastBlock.Instance.blocks[i]);
                    for (int j = i + 1; j < RayCastBlock.Instance.blocks.Length; j++)
                    {
                        if (j < RayCastBlock.Instance.blocks.Length)
                        {
                            if (RayCastBlock.Instance.blocks[i] != null && RayCastBlock.Instance.blocks[j] != null)
                            {
                                if (Mathf.Abs(RayCastBlock.Instance.blocks[i].position.y - RayCastBlock.Instance.blocks[j].position.y) < 0.00001)
                                {
                                    rightYEquals.Add(RayCastBlock.Instance.blocks[j]);
                                    rightIndex.Add(j);
                                }
                            }
                        }
                    }
                    if (rightYEquals.Count == 1)
                    {
                        rightTemporary.Add(rightYEquals[0]);
                    }
                    else if (rightYEquals.Count > 1)
                    {
                        rightTrans = rightYEquals[0];
                        for (int k = 1; k < rightYEquals.Count; k++)
                        {
                            if (rightTrans.position.x < rightYEquals[k].position.x)
                            {
                                rightTrans = rightYEquals[k];
                            }
                        }
                        rightTemporary.Add(rightTrans);
                    }
                }
                rightYEquals.Clear();
                rightTrans = null;
            }
            bottomTemporary.Clear();
            bottomIndex.Clear();
            for (int i = 0; i < RayCastBlock.Instance.blocks.Length; i++)
            {
                if (!bottomIndex.Contains(i))
                {
                    bottomXEquals.Add(RayCastBlock.Instance.blocks[i]);
                    for (int j = i + 1; j < RayCastBlock.Instance.blocks.Length; j++)
                    {
                        if (j < RayCastBlock.Instance.blocks.Length)
                        {
                            if (RayCastBlock.Instance.blocks[i] != null && RayCastBlock.Instance.blocks[j] != null)
                            {
                                if (Mathf.Abs(RayCastBlock.Instance.blocks[i].position.x - RayCastBlock.Instance.blocks[j].position.x) < 0.00001)
                                {
                                    bottomXEquals.Add(RayCastBlock.Instance.blocks[j]);
                                    bottomIndex.Add(j);
                                }
                            }
                        }
                    }
                    if (bottomXEquals.Count == 1)
                    {
                        bottomTemporary.Add(bottomXEquals[0]);
                    }
                    else if (bottomXEquals.Count > 1)
                    {
                        bottomTrans = bottomXEquals[0];
                        for (int k = 1; k < bottomXEquals.Count; k++)
                        {
                            if (bottomTrans.position.y > bottomXEquals[k].position.y)
                            {
                                bottomTrans = bottomXEquals[k];
                            }
                        }
                        bottomTemporary.Add(bottomTrans);
                    }
                }
                bottomXEquals.Clear();
                bottomTrans = null;
            }
            for (int i = 0; i < leftTemporary.Count; i++)
            {
                if (leftTemporary[i] != null)
                {
                    int layerMask = (1 << LayerMask.NameToLayer("Rows"));
                    layerMask = ~layerMask;
                    leftVec = leftTemporary[i].position + Vector3.left * 0.3f;
                    RaycastHit2D leftCast = Physics2D.Raycast(leftVec, Vector2.left, 0.3f, layerMask);
                    if (leftCast.collider != null)
                    {
                        isleftCollider = true;
                        count = 0;
                    }
                    else
                    {
                        count++;
                    }
                    if (count == leftTemporary.Count)
                    {
                        isleftCollider = false;
                        count = leftTemporary.Count;
                    }
                }
            }
            for (int i = 0; i < rightTemporary.Count; i++)
            {
                if (rightTemporary[i] != null)
                {
                    int layerMask = (1 << LayerMask.NameToLayer("Rows"));
                    layerMask = ~layerMask;
                    rightVec = rightTemporary[i].position + Vector3.right * 0.3f;
                    RaycastHit2D rightCast = Physics2D.Raycast(rightVec, Vector2.right, 0.3f, layerMask);

                    if (rightCast.collider != null)
                    {
                        isrightCollider = true;
                        count2 = 0;
                    }
                    else
                    {
                        count2++;
                    }
                    if (count2 == rightTemporary.Count)
                    {
                        isrightCollider = false;
                        count2 = rightTemporary.Count;
                    }
                }
            }
            for (int i = 0; i < bottomTemporary.Count; i++)
            {
                if (bottomTemporary[i] != null)
                {
                    int layerMask = (1 << LayerMask.NameToLayer("Rows"));
                    layerMask = ~layerMask;
                    bottomVec = bottomTemporary[i].position + Vector3.down * 0.3f;
                    RaycastHit2D bottomCast = Physics2D.Raycast(bottomVec, Vector2.down, 0.3f, layerMask);
                    Debug.DrawRay(bottomVec, Vector2.down * 0.3f, Color.red);
                    if (bottomCast.collider != null)
                    {
                        isbottomCollider = true;
                        if (BlockProperty.instance.currentSimulation != null)
                        {
                            BlockProperty.instance.currentSimulation.SetActive(false);
                        }
                        count3 = 0;
                    }
                    else
                    {
                        count3++;
                    }
                    if (count3 == bottomTemporary.Count)
                    {
                        isbottomCollider = false;
                        if (BlockProperty.instance.currentSimulation != null)
                        {
                            BlockProperty.instance.currentSimulation.SetActive(true);
                        }
                        count3 = bottomTemporary.Count;
                    }
                }
            }
        }
    }
}
