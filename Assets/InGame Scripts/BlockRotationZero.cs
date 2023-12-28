using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotationZero : MonoBehaviour
{
    void Update()
    {
        if (BlockProperty.instance.isGameEnd)
        {
            this.transform.localRotation = Quaternion.identity;
        }
    }
}
