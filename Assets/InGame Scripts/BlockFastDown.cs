using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BlockFastDown : MonoBehaviour
{
    public static BlockFastDown Instance;
    private Vector3 currentRotation;
    public Transform pivot;
    private Vector3 originalVec;
    private Vector3 original90Vec;
    private Vector3 originalMinus90Vec;
    private Vector3 original180Vec;
    bool isSpaceEnd = false;
    Rigidbody2D rigid;
    private Vector3 topVec = new Vector3();
    private bool isFirst = true;
    public float fl = 0f;
    public bool isEqual;
    public float distance;
    public List<int> indexList = new List<int>();
    public List<string> collidedNames = new List<string>();

    private void Awake()
    {
        Instance = this;
        rigid = GetComponent<Rigidbody2D>();
        originalVec = new Vector3(transform.position.x, -4.23f, transform.position.z);
        original90Vec = new Vector3(transform.position.x, -3.121f, transform.position.z);
        originalMinus90Vec = new Vector3(transform.position.x, -4.221f, transform.position.z);
        original180Vec = new Vector3(transform.position.x, -4.226001f, transform.position.z);
    }

    void Update()
    {
        string str = this.gameObject.name.Substring(7, 1);
        currentRotation = pivot.transform.rotation.eulerAngles;
        originalVec = new Vector3(transform.position.x, -4.23f, transform.position.z);
        original90Vec = new Vector3(transform.position.x, -3.121f, transform.position.z);
        originalMinus90Vec = new Vector3(transform.position.x, -4.221f, transform.position.z);
        original180Vec = new Vector3(transform.position.x, -4.226001f, transform.position.z);

        if (BlockProperty.instance.isSpace && !RightLeftArrowMove.instance.isbottomCollider)
        {
            if (!BlockProperty.instance.isContain)
            {
                if (BlockProperty.instance.bottomGame != null)
                {
                    if (Mathf.Approximately(currentRotation.z, 90) && BlockProperty.instance.bottomGame.position.y < -4.221)
                    {
                        transform.position = original90Vec;
                        while (true)
                        {
                            if (BlockProperty.instance.bottomGame.position.y <= -3.68)
                            {
                                break;
                            }
                            else
                            {
                                original90Vec.y -= 0.5525f;
                                transform.position = original90Vec;
                            }
                        }
                        isSpaceEnd = true;
                    }
                    else if (Mathf.Approximately(currentRotation.z, 270) && BlockProperty.instance.bottomGame.position.y < -4.2213)
                    {
                        transform.position = originalMinus90Vec;
                        while (true)
                        {
                            if (BlockProperty.instance.bottomGame.position.y >= -4.2213)
                            {
                                break;
                            }
                            else
                            {
                                originalMinus90Vec.y += 0.5525f;
                                transform.position = originalMinus90Vec;
                            }
                        }
                        isSpaceEnd = true;
                    }
                    else if (Mathf.Approximately(currentRotation.z, 180) && BlockProperty.instance.bottomGame.position.y < -4.23)
                    {
                        transform.position = original180Vec;
                        while (true)
                        {
                            if (BlockProperty.instance.bottomGame.position.y >= -4.23)
                            {
                                break;
                            }
                            else
                            {
                                original180Vec.y += 0.5525f;
                                transform.position = original180Vec;
                            }
                        }
                        isSpaceEnd = true;
                    }
                    else
                    {
                        if (BlockProperty.instance.bottomGame.position.y < -4.22)
                        {
                            transform.position = originalVec;
                            while (true)
                            {
                                if (BlockProperty.instance.bottomGame.position.y >= -4.24)
                                {
                                    break;
                                }
                                else
                                {
                                    originalVec.y += 0.5525f;
                                    transform.position = originalVec;
                                }
                            }
                            isSpaceEnd = true;
                        }
                    }
                }
            }
            else
            {
                topVec = transform.position;
                if (Mathf.Approximately(currentRotation.z, 180))
                {
                    int cnt = 0;
                    int n = 0;
                    fl = RayCastBlock.Instance.targetMaxY[0];
                    for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                    {
                        if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                        {
                            indexList.Add(j);
                            n = j;
                            break;
                        }
                    }
                    if (RayCastBlock.Instance.targetMaxY.Count > 1)
                    {
                        for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                        {
                            if (Mathf.Abs(fl - RayCastBlock.Instance.targetMaxY[i]) < 0.05)
                            {
                                cnt++;
                                for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                {
                                    if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                    {
                                        indexList.Add(j);
                                    }
                                }
                            }
                            else if (fl < RayCastBlock.Instance.targetMaxY[i])
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
                        if (cnt == RayCastBlock.Instance.targetMaxY.Count - 1)
                        {
                            isEqual = true;
                        }
                        switch (str)
                        {
                            case "0":
                                if (isEqual || n == 0 || n == 1)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                break;
                            case "1":
                                if (isEqual || n == 0 || n == 1 || n == 2 || n == 3)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                break;
                            case "2":
                                if (isEqual)
                                {
                                    if (indexList.Contains(0) && indexList.Contains(2) && indexList.Contains(3))
                                    {
                                        topVec.y = fl + 1.6575f;
                                    }
                                    else if (indexList.Contains(2) && indexList.Contains(3))
                                    {
                                        topVec.y = fl + 1.105f;
                                    }
                                    else if (indexList.Contains(0) && indexList.Contains(2))
                                    {
                                        topVec.y = fl + 1.6575f;
                                    }
                                    else if (indexList.Contains(0) && indexList.Contains(3))
                                    {
                                        topVec.y = fl + 1.6575f;
                                    }
                                }
                                else if (n == 0)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 2)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                break;
                            case "4":
                                if (isEqual)
                                {
                                    if (indexList.Contains(0) && indexList.Contains(1) && indexList.Contains(2))
                                    {
                                        topVec.y = fl + 1.6575f;
                                    }
                                    else if (indexList.Contains(1) && indexList.Contains(2))
                                    {
                                        topVec.y = fl + 1.105f;
                                    }
                                    else if (indexList.Contains(0) && indexList.Contains(2))
                                    {
                                        topVec.y = fl + 1.6575f;
                                    }
                                    else if (indexList.Contains(0) && indexList.Contains(1))
                                    {
                                        topVec.y = fl + 1.6575f;
                                    }
                                }
                                else if (n == 0)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                else if (n == 2)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                break;
                            case "5":
                                if (isEqual)
                                {
                                    if (indexList.Contains(0) && indexList.Contains(1) && indexList.Contains(3))
                                    {
                                        topVec.y = fl + 0.5525f;
                                    }
                                    else if (indexList.Contains(1) && indexList.Contains(3))
                                    {
                                        topVec.y = fl;
                                    }
                                    else
                                    {
                                        topVec.y = fl + 0.5525f;
                                    }
                                }
                                else if (n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 1 || n == 3)
                                {
                                    topVec.y = fl;
                                }
                                break;
                            case "6":
                                if (isEqual || n == 0 || n == 1)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl;
                                }
                                break;
                            case "7":
                                if (isEqual || n == 0 || n == 1)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl;
                                }
                                break;
                        }
                        transform.position = topVec;
                        isSpaceEnd = true;
                    }
                    else if (RayCastBlock.Instance.targetMaxY.Count == 1)
                    {
                        for (int i = 0; i < BlockProperty.instance.blocks.Length; i++)
                        {
                            if (BlockProperty.instance.blocks[i].gameObject == RayCastBlock.Instance.strings[0])
                            {
                                n = i;
                                break;
                            }
                        }
                        switch (str)
                        {
                            case "0":
                                topVec.y = fl + 0.5525f;
                                break;
                            case "1":
                                topVec.y = fl + 1.105f;
                                break;
                            case "2":
                                if (n == 0)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 2)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                break;
                            case "4":
                                if (n == 0)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                else if (n == 2)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                            case "5":
                                if (n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl;
                                }
                                break;
                            case "6":
                                if (n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl;
                                }
                                break;
                            case "7":
                                if (n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl;
                                }
                                break;
                        }
                    }
                    transform.position = topVec;
                    isSpaceEnd = true;
                }
                else if (Mathf.Approximately(currentRotation.z, 90))
                {
                    int n = 0;
                    fl = RayCastBlock.Instance.targetMaxY[0];
                    for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                    {
                        if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                        {
                            n = j;
                            break;
                        }
                    }
                    if (RayCastBlock.Instance.targetMaxY.Count > 1)
                    {
                        for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                        {
                            if (Mathf.Abs(fl - RayCastBlock.Instance.targetMaxY[i]) < 0.05)
                            {
                                isEqual = true;
                            }
                            else if (fl < RayCastBlock.Instance.targetMaxY[i])
                            {
                                for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                {
                                    if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                    {
                                        n = j;
                                    }
                                }
                                fl = RayCastBlock.Instance.targetMaxY[i];
                                distance = Mathf.Abs(RayCastBlock.Instance.targetMaxY[i] - fl);
                            }
                            else if (fl > RayCastBlock.Instance.targetMaxY[i])
                            {
                                distance = Mathf.Abs(fl - RayCastBlock.Instance.targetMaxY[i]);
                            }
                        }
                        switch (str)
                        {
                            case "0":
                                if (isEqual || n == 2)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 0)
                                {
                                    if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) > 0.6)
                                    {
                                        topVec.y = fl + 0.5525f;
                                    }
                                    else
                                    {
                                        topVec.y = fl + 1.105f;
                                    }
                                }
                                break;
                            case "2":
                                if (isEqual)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 0)
                                {
                                    if (distance < 0.7)
                                    {
                                        topVec.y = fl + 1.105f;
                                    }
                                    else
                                    {
                                        topVec.y = fl + 0.5525f;
                                    }
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                            case "4":
                                if (isEqual || n == 0 || n == 3)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                            case "5":
                                if (isEqual || n == 1)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                else if (n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                break;
                            case "6":
                                if (isEqual)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                break;
                            case "7":
                                if (isEqual || n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 2)
                                {
                                    topVec.y = fl;
                                }
                                break;
                        }
                        transform.position = topVec;
                        isSpaceEnd = true;
                    }
                    else if (RayCastBlock.Instance.targetMaxY.Count == 1)
                    {
                        switch (str)
                        {
                            case "0":
                                topVec.y = fl + 0.5525f;
                                break;
                            case "1":
                                if (n == 0)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                            case "2":
                                if (n == 0)
                                {
                                    if (RayCastBlock.Instance.targetMaxY[0] > -4)
                                    {
                                        topVec.y = fl + 0.5525f;
                                    }
                                    else
                                    {
                                        topVec.y = fl + 1.105f;
                                    }
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                            case "4":
                                if (n == 0)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                            case "5":
                                if (n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                break;
                            case "6":
                                if (n == 1)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                            case "7":
                                if (n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 2)
                                {
                                    topVec.y = fl;
                                }
                                break;
                        }
                    }
                    transform.position = topVec;
                    isSpaceEnd = true;
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
                            break;
                        }
                    }
                    if (RayCastBlock.Instance.targetMaxY.Count > 1)
                    {
                        for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                        {
                            if (Mathf.Abs(fl - RayCastBlock.Instance.targetMaxY[i]) < 0.05)
                            {
                                isEqual = true;
                            }
                            else if (fl < RayCastBlock.Instance.targetMaxY[i])
                            {
                                for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                {
                                    if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                    {
                                        n = j;
                                        break;
                                    }
                                }
                                fl = RayCastBlock.Instance.targetMaxY[i];
                                distance = Mathf.Abs(RayCastBlock.Instance.targetMaxY[i] - fl);
                            }
                            else if (fl > RayCastBlock.Instance.targetMaxY[i])
                            {
                                distance = Mathf.Abs(fl - RayCastBlock.Instance.targetMaxY[i]);
                            }
                        }
                        switch (str)
                        {
                            case "0":
                                if (isEqual)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                break;
                            case "2":
                                if (isEqual)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 0)
                                {
                                    if (distance < 0.7)
                                    {
                                        topVec.y = fl + 1.6575f;
                                    }
                                    else
                                    {
                                        topVec.y = fl + 1.6575f;
                                    }
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                            case "4":
                                if (isEqual)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 0)
                                {
                                    if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[1] - RayCastBlock.Instance.targetMaxY[0]) > 0.6)
                                    {
                                        topVec.y = fl + 0.5525f;
                                    }
                                    else
                                    {
                                        topVec.y = fl + 1.105f;
                                    }
                                }
                                break;
                            case "5":
                                if (isEqual || n == 3)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                else if (n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                break;
                            case "6":
                                if (isEqual)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 2)
                                {
                                    topVec.y = fl;
                                }
                                break;
                            case "7":
                                if (isEqual)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                        }
                        transform.position = topVec;
                        isSpaceEnd = true;
                    }
                    else if (RayCastBlock.Instance.targetMaxY.Count == 1)
                    {
                        switch (str)
                        {
                            case "0":
                                if (n == 1)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                break;
                            case "1":
                                if (n == 3)
                                {
                                    topVec.y = fl + 2.21f;
                                }
                                break;
                            case "2":
                                if (n == 0)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                            case "4":
                                if (n == 0)
                                {
                                    if (RayCastBlock.Instance.targetMaxY[0] > -4)
                                    {
                                        topVec.y = fl + 0.5525f;
                                    }
                                    else
                                    {
                                        topVec.y = fl + 1.105f;
                                    }
                                }
                                else if (n == 1)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                            case "5":
                                if (n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                break;
                            case "6":
                                if (n == 0)
                                {
                                    topVec.y = fl + 0.5525f;
                                }
                                else if (n == 2)
                                {
                                    topVec.y = fl;
                                }
                                break;
                            case "7":
                                if (n == 1)
                                {
                                    topVec.y = fl + 1.105f;
                                }
                                else if (n == 3)
                                {
                                    topVec.y = fl + 1.6575f;
                                }
                                break;
                        }
                    }
                    transform.position = topVec;
                    isSpaceEnd = true;
                }
                else
                {
                    int n = 0;
                    fl = RayCastBlock.Instance.targetMaxY[0];
                    for (int i = 0; i < BlockProperty.instance.blocks.Length; i++)
                    {
                        if (BlockProperty.instance.blocks[i].gameObject == RayCastBlock.Instance.strings[0])
                        {
                            n = i;
                            break;
                        }
                    }
                    if (RayCastBlock.Instance.targetMaxY.Count > 1)
                    {
                        for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                        {
                            if (str.Equals("0"))
                            {
                                if (fl <= RayCastBlock.Instance.targetMaxY[i])
                                {
                                    isFirst = false;
                                    fl = RayCastBlock.Instance.targetMaxY[i];
                                    for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                    {
                                        if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                        {
                                            n = j;
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (str.Equals("6") || str.Equals("7"))
                            {
                                if (fl < RayCastBlock.Instance.targetMaxY[i] || Mathf.Abs(fl - RayCastBlock.Instance.targetMaxY[i]) < 0.05)
                                {
                                    isFirst = false;
                                    fl = RayCastBlock.Instance.targetMaxY[i];
                                    for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                    {
                                        if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                        {
                                            n = j;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (fl <= RayCastBlock.Instance.targetMaxY[i])
                                {
                                    isFirst = false;
                                    fl = RayCastBlock.Instance.targetMaxY[i];
                                }
                            }
                        }
                    }
                    if (str.Equals("6") || str.Equals("7"))
                    {
                        if (isFirst)
                        {
                            if (n == 3)
                            {
                                topVec.y = fl + 1.105f;
                            }
                            else if (n == 2)
                            {
                                topVec.y = fl + 1.105f;
                            }
                            else if (n == 0)
                            {
                                topVec.y = fl + 0.5525f;
                            }
                        }
                        else
                        {
                            if (n == 0)
                            {
                                topVec.y = fl + 1.105f;
                            }
                            else if (n == 2)
                            {
                                topVec.y = fl + 1.105f;
                            }
                            else if (n == 3)
                            {
                                topVec.y = fl + 1.105f;
                            }
                        }
                    }
                    else if (str.Equals("0"))
                    {
                        if (isFirst)
                        {
                            topVec.y = fl + 1.105f;
                        }
                        else
                        {
                            if (n == 2)
                            {
                                topVec.y = fl + 1.6575f;
                            }
                            else if (n == 3)
                            {
                                topVec.y = fl + 1.105f;
                            }
                        }
                    }
                    else
                    {
                        topVec.y = fl + 1.105f;
                    }
                    transform.position = topVec;
                    isSpaceEnd = true;
                }
            }

        }
        if (isSpaceEnd)
        {
            BlockDie();
        }
    }
    void BlockDie()
    {
        if (isSpaceEnd)
        {
            BlockProperty.instance.isSpace = false;
            //BlockProperty.instance.TopRayCast();
            for (int i = 0; i < pivot.childCount; i++)
            {
                if (pivot.GetChild(i).position.y >= 6.7)
                {
                    BlockProperty.instance.isGameEnd = true;
                    BlockManager.Instance.isEnd = true;
                    break;
                }
            }
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            if (!BlockProperty.instance.isGameEnd)
            {
                if (BlockSpawn.instance.nextIndex.Count > 0)
                {
                    BlockSpawn.instance.nextIndex.RemoveAt(0);
                }
                for (int i = 0; i < BlockProperty.instance.blocks.Length; i++)
                {
                    if (BlockProperty.instance.blocks[i].position.y >= 5.12)
                    {
                        WarningBlock.Instance.lastBlockPivot.Add(BlockProperty.instance.blocks[i]);
                    }
                    else
                    {
                        continue;
                    }
                }
                for (int i = 0; i < BlockProperty.instance.blocks.Length; i++)
                {
                    OnTriggerBlock onTriggerBlock = BlockProperty.instance.blocks[i].GetComponent<OnTriggerBlock>();
                    onTriggerBlock.isLive = false;
                }
                PicecManager.instance.picecValue++;
                PicecManager.instance.isWrite = true;
                WarningBlock.Instance.bigF = BlockProperty.instance.topBlocks[0].transform.position.y;
                for (int i = 1; i < BlockProperty.instance.topBlocks.Count; i++)
                {
                    if (WarningBlock.Instance.bigF < BlockProperty.instance.topBlocks[i].transform.position.y)
                    {
                        WarningBlock.Instance.bigF = BlockProperty.instance.topBlocks[i].transform.position.y;
                    }
                }
                BlockProperty.instance.islive = false;
                this.GetComponent<RightLeftArrowMove>().enabled = false;
                this.GetComponent<BlockSpeedDown>().enabled = false;
                this.GetComponent<BlockFastDown>().enabled = false;
                this.GetComponent<BlockRotation>().enabled = false;
                if (BlockProperty.instance.currentSimulation != null)
                {
                    if (BlockProperty.instance.currentSimulation.GetComponent<BlockSimulation>() != null)
                    {
                        BlockProperty.instance.currentSimulation.GetComponent<BlockSimulation>().enabled = false;
                    }
                }
                Destroy(BlockProperty.instance.currentSimulation);
            }
            isSpaceEnd = false;
            GetComponent<BlockProperty>().enabled = false;
        }
    }
}
