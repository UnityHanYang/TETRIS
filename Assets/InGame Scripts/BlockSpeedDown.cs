using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockSpeedDown : MonoBehaviour
{
    public static BlockSpeedDown instance;
    private bool iswhile = true;
    public float remainV;
    private Vector3 currentRotation;
    private float fl = 0f;
    public float distance;
    private bool isNumOne;
    private bool isNumThree;
    private bool isNumOne180;
    private bool isNumThree180;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        currentRotation = BlockProperty.instance.pivot.transform.rotation.eulerAngles;
        this.transform.rotation = Quaternion.identity;
        if (iswhile && BlockProperty.instance.islive && !BlockProperty.instance.isGameEnd)
        {
            if (BlockProperty.instance.isBlockNum)
            {
                switch (BlockProperty.instance.str)
                {
                    case "0":
                        remainV = 0.1f;
                        break;
                    case "1":
                        remainV = 0.1f;
                        break;
                    case "2":
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            int n = 0;
                            fl = RayCastBlock.Instance.targetMaxY[0];
                            for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                            {
                                if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                                {
                                    n = j;
                                }
                            }
                            if (RayCastBlock.Instance.targetMaxY.Count > 1)
                            {
                                for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                                {
                                    if (fl < RayCastBlock.Instance.targetMaxY[i])
                                    {
                                        for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                        {
                                            if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                            {
                                                n = j;
                                            }
                                        }
                                        fl = RayCastBlock.Instance.targetMaxY[i];
                                    }
                                }
                                if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.05)
                                {
                                    remainV = -0.6f;
                                }
                                else
                                {
                                    if (n == 0)
                                    {
                                        if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.65)
                                        {
                                            remainV = -0.2f;
                                        }
                                        else
                                        {
                                            remainV = 0.2f;
                                        }
                                    }
                                    else
                                    {
                                        remainV = 0.5f;
                                    }
                                }
                            }
                            else
                            {
                                if (n == 0)
                                {
                                    if (fl > -4)
                                    {
                                        remainV = 0.3f;
                                    }
                                    else
                                    {
                                        remainV = -0.5f;
                                    }
                                }
                                else
                                {
                                    remainV = 0.5f;
                                }
                            }
                        }
                        else if (Mathf.Approximately(currentRotation.z, 180))
                        {
                            for (int i = 0; i < RayCastBlock.Instance.strings.Count; i++)
                            {
                                if (RayCastBlock.Instance.strings[i].name.Substring(5).Equals("1"))
                                {
                                    isNumOne180 = true;
                                }
                                else if (RayCastBlock.Instance.strings[i].name.Substring(5).Equals("4"))
                                {
                                    isNumThree180 = true;
                                }
                            }
                            if (isNumOne180 && isNumThree180)
                            {
                                remainV = 0.4f;
                            }
                            else
                            {
                                remainV = 0.1f;
                            }
                        }
                        else
                        {
                            remainV = 0.1f;
                        }
                        break;
                    case "4":
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            int n = 0;
                            fl = RayCastBlock.Instance.targetMaxY[0];
                            for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                            {
                                if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                                {
                                    n = j;
                                }
                            }
                            if (RayCastBlock.Instance.targetMaxY.Count > 1)
                            {
                                for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                                {
                                    if (fl < RayCastBlock.Instance.targetMaxY[i])
                                    {
                                        for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                        {
                                            if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                            {
                                                n = j;
                                            }
                                        }
                                        fl = RayCastBlock.Instance.targetMaxY[i];
                                    }
                                }
                                if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.05)
                                {
                                    remainV = 0.1f;
                                }
                                else
                                {
                                    if (n == 0)
                                    {
                                        if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.65)
                                        {
                                            remainV = 0.1f;
                                        }
                                        else
                                        {
                                            remainV = 0.2f;
                                        }
                                    }
                                    else
                                    {
                                        remainV = 0.5f;
                                    }
                                }
                            }
                            else
                            {
                                if (n == 0)
                                {
                                    if (fl > -4)
                                    {
                                        remainV = 0.3f;
                                    }
                                    else
                                    {
                                        remainV = -0.5f;
                                    }
                                }
                                else
                                {
                                    remainV = 0.5f;
                                }
                            }
                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            int n = 0;
                            fl = RayCastBlock.Instance.targetMaxY[0];
                            for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                            {
                                if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                                {
                                    n = j;
                                }
                            }
                            if (RayCastBlock.Instance.targetMaxY.Count > 1){
                                if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.05)
                                {
                                    remainV = -0.6f;
                                }
                                else if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.65)
                                {
                                    if (RayCastBlock.Instance.targetMaxY.Count > 1)
                                    {
                                        for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                                        {
                                            if (fl < RayCastBlock.Instance.targetMaxY[i])
                                            {
                                                for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                                {
                                                    if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                                    {
                                                        n = j;
                                                    }
                                                }
                                                fl = RayCastBlock.Instance.targetMaxY[i];
                                            }
                                        }
                                    }
                                    if (n == 0)
                                    {
                                        remainV = -0.3f;
                                    }
                                    else
                                    {
                                        remainV = 0.1f;
                                    }
                                }
                                else
                                {
                                    remainV = 0.1f;
                                }
                            }
                            else
                            {
                                remainV = 0.1f;
                            }
                        }
                        else
                        {
                            remainV = 0.1f;
                        }
                        break;
                    case "5":
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            if (RayCastBlock.Instance.targetMaxY.Count > 1)
                            {
                                if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.05)
                                {
                                    remainV = -0.2f;
                                }
                                else
                                {
                                    remainV = 0.1f;
                                }
                            }
                            else
                            {
                                remainV = 0.1f;
                            }
                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            if (RayCastBlock.Instance.targetMaxY.Count > 1 && Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.05)
                            {
                                remainV = -0.3f;
                            }
                            else
                            {
                                int n = 0;
                                fl = RayCastBlock.Instance.targetMaxY[0];
                                for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                {
                                    if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                                    {
                                        n = j;
                                    }
                                }
                                if (RayCastBlock.Instance.targetMaxY.Count > 1)
                                {
                                    for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                                    {
                                        if (fl < RayCastBlock.Instance.targetMaxY[i])
                                        {
                                            for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                            {
                                                if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                                {
                                                    n = j;
                                                }
                                            }
                                            fl = RayCastBlock.Instance.targetMaxY[i];
                                        }
                                    }
                                }
                                if (n == 3)
                                {
                                    remainV = 0.3f;
                                }
                                else
                                {
                                    remainV = 0.1f;
                                }
                            }
                        }
                        else
                        {
                            remainV = 0.1f;
                        }
                        break;
                    case "6":
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            int n = 0;
                            fl = RayCastBlock.Instance.targetMaxY[0];
                            for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                            {
                                if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                                {
                                    n = j;
                                }
                            }
                            if (RayCastBlock.Instance.targetMaxY.Count > 1)
                            {
                                for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                                {
                                    if (fl < RayCastBlock.Instance.targetMaxY[i])
                                    {
                                        for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                        {
                                            if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                            {
                                                n = j;
                                            }
                                        }
                                        fl = RayCastBlock.Instance.targetMaxY[i];
                                    }
                                }
                                if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.05)
                                {
                                    remainV = -0.2f;
                                }
                                else
                                {
                                    if (n == 1)
                                    {
                                        remainV = 0.2f;
                                    }
                                    else
                                    {
                                        remainV = 0.5f;
                                    }
                                }
                            }
                            else
                            {
                                if (n == 1)
                                {
                                    remainV = 0.2f;
                                }
                                else
                                {
                                    remainV = 0.3f;
                                }
                            }
                        }
                        else
                        {
                            remainV = 0.1f;
                        }
                        break;
                    case "7":
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            int n = 0;
                            fl = RayCastBlock.Instance.targetMaxY[0];
                            for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                            {
                                if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                                {
                                    n = j;
                                }
                            }
                            if (RayCastBlock.Instance.targetMaxY.Count > 1)
                            {
                                for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                                {
                                    if (fl < RayCastBlock.Instance.targetMaxY[i])
                                    {
                                        for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                        {
                                            if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                            {
                                                n = j;
                                            }
                                        }
                                        fl = RayCastBlock.Instance.targetMaxY[i];
                                    }
                                }
                                if (RayCastBlock.Instance.targetMaxY.Count == 2)
                                {
                                    if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.05)
                                    {
                                        remainV = 0.2f;
                                    }
                                }
                                if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) >= 0.05)
                                {
                                    if (n == 1)
                                    {
                                        remainV = 0.2f;
                                    }
                                    else
                                    {
                                        remainV = 0.5f;
                                    }
                                }
                            }
                            else
                            {
                                if (n == 0)
                                {
                                    remainV = 0.3f;
                                }
                                else
                                {
                                    remainV = 0.5f;
                                }
                            }
                        }
                        else if (Mathf.Approximately(currentRotation.z, 180))
                        {
                            if (RayCastBlock.Instance.targetMaxY.Count == 3)
                            {
                                if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.05 && Mathf.Abs(RayCastBlock.Instance.targetMaxY[1] - RayCastBlock.Instance.targetMaxY[2]) < 0.05 && Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[2]) < 0.05)
                                {
                                    remainV = 0.4f;
                                }
                            }
                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            if (RayCastBlock.Instance.targetMaxY.Count > 1 && Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.05)
                            {
                                remainV = -0.3f;
                            }
                            else
                            {
                                int n = 0;
                                fl = RayCastBlock.Instance.targetMaxY[0];
                                for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                {
                                    if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                                    {
                                        n = j;
                                    }
                                }
                                if (RayCastBlock.Instance.targetMaxY.Count > 1)
                                {
                                    for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                                    {
                                        if (fl < RayCastBlock.Instance.targetMaxY[i])
                                        {
                                            for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                            {
                                                if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                                {
                                                    n = j;
                                                }
                                            }
                                            fl = RayCastBlock.Instance.targetMaxY[i];
                                        }
                                    }
                                }
                                if (n == 1)
                                {
                                    remainV = 0.4f;
                                }
                            }
                        }
                        else
                        {
                            if (RayCastBlock.Instance.targetMaxY.Count == 3)
                            {
                                if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.05 && Mathf.Abs(RayCastBlock.Instance.targetMaxY[1] - RayCastBlock.Instance.targetMaxY[2]) < 0.05 && Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[2]) < 0.05)
                                {
                                    remainV = -0.2f;
                                }
                                else
                                {
                                    remainV = 0.1f;
                                }
                            }
                            else if (RayCastBlock.Instance.targetMaxY.Count == 2)
                            {
                                if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) < 0.05)
                                {
                                    for (int i = 0; i < RayCastBlock.Instance.strings.Count; i++)
                                    {
                                        if (RayCastBlock.Instance.strings[i].name.Substring(5).Equals("1"))
                                        {
                                            isNumOne = true;
                                        }
                                        else if (RayCastBlock.Instance.strings[i].name.Substring(5).Equals("4"))
                                        {
                                            isNumThree = true;
                                        }
                                    }
                                    if (isNumOne && isNumThree)
                                    {
                                        remainV = -0.2f;
                                    }
                                    else if (isNumOne)
                                    {
                                        remainV = 0.2f;
                                    }
                                    else
                                    {
                                        remainV = 0.3f;
                                    }
                                }
                                else
                                {
                                    remainV = 0.1f;
                                }
                            }
                            else
                            {
                                remainV = 0.2f;
                            }
                        }
                        break;
                }
                iswhile = false;
            }
        }
    }
}
