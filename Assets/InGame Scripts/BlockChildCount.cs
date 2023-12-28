using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChildCount : MonoBehaviour
{
    public Transform pivot;

    private void Awake()
    {
        pivot = transform.GetChild(0);
    }
    void Update()
    {
        if (pivot.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
