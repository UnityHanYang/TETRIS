using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockSimulation : MonoBehaviour
{
    public static BlockSimulation instance;
    public GameObject go;
    private Vector2 originalVec = new Vector2();
    private float firstValue;
    private bool isFirst = true;
    public bool isEqual;
    private Vector3 currentRotation;
    public List<int> indexList = new List<int>();
    public float distance;
    private bool isUPOne = true;
    private bool isThree;
    public bool isEnter;
    public Transform pivot;
    private bool isBig;
    public bool isReturn;
    int cnt = 0;
    public float bestTopF;

    private void Awake()
    {
        instance = this;
        pivot = transform.GetChild(0);
    }

    private void Start()
    {
        string str = this.gameObject.name.Substring(7, 1);
        originalVec = go.transform.position;
        //if (RayCastBlock.Instance.targetMaxY.Count > 0)
        //{
        //    firstValue = RayCastBlock.Instance.targetMaxY[0];
        //}
        //if (RayCastBlock.Instance.targetMaxY.Count == 3)
        //{
        //    for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
        //    {
        //        if (str.Equals("6") || str.Equals("7"))
        //        {
        //            isThree = true;
        //            if (firstValue < RayCastBlock.Instance.targetMaxY[i] || Mathf.Abs(firstValue - RayCastBlock.Instance.targetMaxY[i]) < 0.05)
        //            {
        //                isUPOne = false;
        //            }
        //        }
        //    }
        //}
        //if (str.Equals("6") || str.Equals("7"))
        //{
        //    if (isThree && isUPOne)
        //    {
        //        isEnter = true;
        //        firstValue += 0.5525f;
        //        originalVec.y = firstValue;
        //        transform.position = originalVec;
        //    }
        //}
        //if (WarningBlock.Instance.bigF > 6 && BlockProperty.instance.islive)
        //{
        //    this.gameObject.SetActive(false);
        //}
    }

    void Update()
    {
        if(WarningBlock.Instance.bigF < 6 && BlockProperty.instance.islive && !RightLeftArrowMove.instance.isbottomCollider)
        {
            this.gameObject.SetActive(true);
        }
        if (LineTextManager.instance.cnt >= 40 || !BlockProperty.instance.islive)
        {
            Destroy(this.gameObject);
        }
        if (go != null)
        {
            originalVec = go.transform.position;
        }
        indexList.Clear();
        cnt = 0;
        if (BlockProperty.instance.isCtrlSimulation)
        {
            pivot.transform.rotation = BlockProperty.instance.qua;
            BlockProperty.instance.isCtrlSimulation = false;
        }
        if (!BlockProperty.instance.isContain)
        {
            string str = this.gameObject.name.Substring(7, 1);
            if (BlockFastDown.Instance.pivot != null)
            {
                currentRotation = BlockFastDown.Instance.pivot.transform.rotation.eulerAngles;
            }
            if (Mathf.Approximately(currentRotation.z, 180))
            {
                switch (str)
                {
                    case "1":
                        originalVec.y = -3.68f;
                        this.transform.position = originalVec;
                        break;
                    case "2":
                        originalVec.y = -3.68f;
                        originalVec.y += 0.5525f;
                        this.transform.position = originalVec;
                        break;
                    case "4":
                        originalVec.y = -3.68f;
                        originalVec.y += 0.5525f;
                        this.transform.position = originalVec;
                        break;
                    case "5":
                        originalVec.y = -3.68f;
                        originalVec.y -= 0.5525f;
                        this.transform.position = originalVec;
                        break;
                    case "6":
                        originalVec.y = -3.68f;
                        originalVec.y -= 0.5525f;
                        this.transform.position = originalVec;
                        break;
                    case "7":
                        originalVec.y = -3.68f;
                        originalVec.y -= 0.5525f;
                        this.transform.position = originalVec;
                        break;
                }
            }
            else if (Mathf.Approximately(currentRotation.z, 90))
            {
                switch (str)
                {
                    case "1":
                        originalVec.y = -3.68f;
                        originalVec.y += 0.5525f;
                        this.transform.position = originalVec;
                        break;
                    case "2":
                        originalVec.y = -3.68f;
                        originalVec.y += 0.5525f;
                        this.transform.position = originalVec;
                        break;
                    case "4":
                        originalVec.y = -3.68f;
                        originalVec.y += 0.5525f;
                        this.transform.position = originalVec;
                        break;
                    case "5":
                        originalVec.y = -3.68f;
                        this.transform.position = originalVec;
                        break;
                    case "6":
                        originalVec.y = -3.68f;
                        originalVec.y += 0.5525f;
                        this.transform.position = originalVec;
                        break;
                    case "7":
                        originalVec.y = -3.68f;
                        originalVec.y -= 0.5525f;
                        this.transform.position = originalVec;
                        break;
                }
            }
            else if (Mathf.Approximately(currentRotation.z, 270))
            {
                switch (str)
                {
                    case "1":
                        originalVec.y = -3.68f;
                        originalVec.y += 1.105f;
                        this.transform.position = originalVec;
                        break;
                    case "2":
                        originalVec.y = -3.68f;
                        originalVec.y += 0.5525f;
                        this.transform.position = originalVec;
                        break;
                    case "4":
                        originalVec.y = -3.68f;
                        originalVec.y += 0.5525f;
                        this.transform.position = originalVec;
                        break;
                    case "5":
                        originalVec.y = -3.68f;
                        this.transform.position = originalVec;
                        break;
                    case "6":
                        originalVec.y = -3.68f;
                        originalVec.y -= 0.5525f;
                        this.transform.position = originalVec;
                        break;
                    case "7":
                        originalVec.y = -3.68f;
                        originalVec.y += 0.5525f;
                        this.transform.position = originalVec;
                        break;
                }
            }
            else
            {
                originalVec.y = -3.68f;
                this.transform.position = originalVec;
            }
        }
        else
        {
            string str = this.gameObject.name.Substring(7, 1);
            if (BlockFastDown.Instance.pivot != null)
            {
                currentRotation = BlockFastDown.Instance.pivot.transform.rotation.eulerAngles;
            }
            if (Mathf.Approximately(currentRotation.z, 180))
            {
                int n = 0;
                firstValue = RayCastBlock.Instance.targetMaxY[0];
                for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                {
                    if (BlockProperty.instance.blocks[j] != null && RayCastBlock.Instance.strings[0] != null)
                    {
                        if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                        {
                            indexList.Add(j);
                            n = j;
                            break;
                        }
                    }
                }
                if (RayCastBlock.Instance.targetMaxY.Count > 1)
                {
                    for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                    {
                        if (Mathf.Abs(firstValue - RayCastBlock.Instance.targetMaxY[i]) < 0.05)
                        {
                            cnt++;
                            for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                            {
                                if (BlockProperty.instance.blocks[j] != null && RayCastBlock.Instance.strings[0] != null)
                                {
                                    if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                    {
                                        indexList.Add(j);
                                    }
                                }
                            }
                        }
                        else if (firstValue < RayCastBlock.Instance.targetMaxY[i])
                        {
                            for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                            {
                                if (BlockProperty.instance.blocks[j] != null && RayCastBlock.Instance.strings[0] != null)
                                {
                                    if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                    {
                                        n = j;
                                        break;
                                    }
                                }
                            }
                            firstValue = RayCastBlock.Instance.targetMaxY[i];
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
                                firstValue += 0.5525f;
                            }
                            break;
                        case "1":
                            if (isEqual || n == 0 || n == 1 || n == 2 || n == 3)
                            {
                                firstValue += 1.105f;
                            }
                            break;
                        case "2":
                            if (isEqual)
                            {
                                if (indexList.Contains(0) && indexList.Contains(2) && indexList.Contains(3))
                                {
                                    firstValue += 1.6575f;
                                }
                                else if (indexList.Contains(2) && indexList.Contains(3))
                                {
                                    firstValue += 1.105f;
                                }
                                else if (indexList.Contains(0) && indexList.Contains(2))
                                {
                                    firstValue += 1.6575f;
                                }
                                else if (indexList.Contains(0) && indexList.Contains(3))
                                {
                                    firstValue += 1.6575f;
                                }
                            }
                            else if (n == 0)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 2)
                            {
                                firstValue += 1.105f;
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.105f;
                            }
                            break;
                        case "4":
                            if (isEqual)
                            {
                                if (indexList.Contains(0) && indexList.Contains(1) && indexList.Contains(2))
                                {
                                    firstValue += 1.6575f;
                                }
                                else if (indexList.Contains(1) && indexList.Contains(2))
                                {
                                    firstValue += 1.105f;
                                }
                                else if (indexList.Contains(0) && indexList.Contains(2))
                                {
                                    firstValue += 1.6575f;
                                }
                                else if (indexList.Contains(0) && indexList.Contains(1))
                                {
                                    firstValue += 1.6575f;
                                }
                            }
                            else if (n == 0)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 1)
                            {
                                firstValue += 1.105f;
                            }
                            else if (n == 2)
                            {
                                firstValue += 1.105f;
                            }
                            break;
                        case "5":
                            if (isEqual)
                            {
                                if (indexList.Contains(0) && indexList.Contains(1) && indexList.Contains(3))
                                {
                                    firstValue += 0.5525f;
                                }
                                else if (indexList.Contains(1) && indexList.Contains(3))
                                {
                                }
                                else
                                {
                                    firstValue += 0.5525f;
                                }
                            }
                            else if (n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            break;
                        case "6":
                            if (isEqual || n == 0 || n == 1)
                            {
                                firstValue += 0.5525f;
                            }
                            break;
                        case "7":
                            if (isEqual || n == 0 || n == 1)
                            {
                                firstValue += 0.5525f;
                            }
                            break;
                    }
                    originalVec.y = firstValue;
                    transform.position = originalVec;
                    isEqual = false;
                }
                else if (RayCastBlock.Instance.targetMaxY.Count == 1)
                {
                    for (int i = 0; i < BlockProperty.instance.blocks.Length; i++)
                    {
                        if (BlockProperty.instance.blocks[i] != null && RayCastBlock.Instance.strings[0] != null)
                        {
                            if (BlockProperty.instance.blocks[i].gameObject == RayCastBlock.Instance.strings[0])
                            {
                                n = i;
                                break;
                            }
                        }
                    }
                    switch (str)
                    {
                        case "0":
                            firstValue += 0.5525f;
                            break;
                        case "1":
                            firstValue += 1.105f;
                            break;
                        case "2":
                            if (n == 0)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 2)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.105f;
                            }
                            break;
                        case "4":
                            if (n == 0)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 1)
                            {
                                firstValue += 1.105f;
                            }
                            else if (n == 2)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "5":
                            if (n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            break;
                        case "6":
                            if (n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            else if (n == 1)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "7":
                            if (n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            break;
                    }
                    originalVec.y = firstValue;
                    transform.position = originalVec;
                }
            }
            else if (Mathf.Approximately(currentRotation.z, 90))
            {
                if (RayCastBlock.Instance.targetMaxY.Count > 1)
                {
                    int n = 0;
                    firstValue = RayCastBlock.Instance.targetMaxY[0];
                    for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                    {
                        if (BlockProperty.instance.blocks[j] != null && RayCastBlock.Instance.strings[0] != null)
                        {
                            if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                            {
                                n = j;
                                break;
                            }
                        }
                    }
                    for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                    {
                        if (Mathf.Abs(firstValue - RayCastBlock.Instance.targetMaxY[i]) < 0.05)
                        {
                            isEqual = true;
                            isBig = false;
                        }
                        else if (firstValue < RayCastBlock.Instance.targetMaxY[i])
                        {
                            for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                            {
                                if (BlockProperty.instance.blocks[j] != null && RayCastBlock.Instance.strings[0] != null)
                                {
                                    if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                    {
                                        n = j;
                                        break;
                                    }
                                }
                            }
                            firstValue = RayCastBlock.Instance.targetMaxY[i];
                            distance = Mathf.Abs(RayCastBlock.Instance.targetMaxY[i] - firstValue);
                            isEqual = false;
                            isBig = false;
                        }
                        else if (firstValue > RayCastBlock.Instance.targetMaxY[i])
                        {
                            distance = Mathf.Abs(firstValue - RayCastBlock.Instance.targetMaxY[i]);
                            isEqual = false;
                            isBig = true;
                        }
                    }
                    switch (str)
                    {
                        case "0":
                            if (isEqual || n == 2)
                            {
                                firstValue += 0.5525f;
                            }
                            else if (n == 0)
                            {
                                if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[0] - RayCastBlock.Instance.targetMaxY[1]) > 0.6)
                                {
                                    firstValue += 0.5525f;
                                }
                                else
                                {
                                    firstValue += 1.105f;
                                }
                            }
                            break;
                        case "2":
                            if (isEqual)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 0)
                            {
                                if (distance < 0.7)
                                {
                                    firstValue += 1.105f;
                                }
                                else
                                {
                                    firstValue += 0.5525f;
                                }
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "4":
                            if (isEqual || n == 0 || n == 3)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "5":
                            if (isEqual || n == 1)
                            {
                                firstValue += 1.105f;
                            }
                            else if (n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            break;
                        case "6":
                            if (isEqual)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 1)
                            {
                                firstValue += 1.105f;
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (isBig && n == 1)
                            {
                                firstValue += 1.105f;
                            }
                            break;
                        case "7":
                            if (isEqual || n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            break;
                    }
                }
                else if (RayCastBlock.Instance.targetMaxY.Count == 1)
                {
                    int n = 0;
                    firstValue = RayCastBlock.Instance.targetMaxY[0];
                    for (int i = 0; i < BlockProperty.instance.blocks.Length; i++)
                    {
                        if (BlockProperty.instance.blocks[i] != null && RayCastBlock.Instance.strings[0] != null)
                        {
                            if (BlockProperty.instance.blocks[i].gameObject == RayCastBlock.Instance.strings[0])
                            {
                                n = i;
                                break;
                            }
                        }
                    }
                    switch (str)
                    {
                        case "0":
                            firstValue += 0.5525f;
                            break;
                        case "1":
                            if (n == 0)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "2":
                            if (n == 0)
                            {
                                if (RayCastBlock.Instance.targetMaxY[0] > -4)
                                {
                                    firstValue += 0.5525f;
                                }
                                else
                                {
                                    firstValue += 1.105f;
                                }
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "4":
                            if (n == 0)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "5":
                            if (n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            else if (n == 1)
                            {
                                firstValue += 1.105f;
                            }
                            break;
                        case "6":
                            if (n == 1)
                            {
                                firstValue += 1.105f;
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "7":
                            if (n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            break;
                    }
                }
                originalVec.y = firstValue;
                transform.position = originalVec;
            }
            else if (Mathf.Approximately(currentRotation.z, 270))
            {
                int n = 0;
                firstValue = RayCastBlock.Instance.targetMaxY[0];
                for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                {
                    if (BlockProperty.instance.blocks[j] != null && RayCastBlock.Instance.strings[0] != null)
                    {
                        if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[0])
                        {
                            n = j;
                            indexList.Add(j);
                            break;
                        }
                    }
                }
                if (RayCastBlock.Instance.targetMaxY.Count > 1)
                {
                    for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                    {
                        if (Mathf.Abs(firstValue - RayCastBlock.Instance.targetMaxY[i]) < 0.05)
                        {
                            isEqual = true;
                        }
                        else if (firstValue < RayCastBlock.Instance.targetMaxY[i])
                        {
                            for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                            {
                                if (BlockProperty.instance.blocks[j] != null && RayCastBlock.Instance.strings[0] != null)
                                {
                                    if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                    {
                                        n = j;
                                        break;
                                    }
                                }
                            }
                            firstValue = RayCastBlock.Instance.targetMaxY[i];
                            isEqual = false;
                        }
                        else
                        {
                            isEqual = false;
                        }
                    }
                    switch (str)
                    {
                        case "0":
                            if (isEqual)
                            {
                                firstValue += 1.105f;
                            }
                            else if (n == 1)
                            {
                                firstValue += 0.5525f;
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.105f;
                            }
                            break;
                        case "2":
                            if (isEqual)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 0)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 1)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "4":
                            if (isEqual)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 0)
                            {
                                if (Mathf.Abs(RayCastBlock.Instance.targetMaxY[1] - RayCastBlock.Instance.targetMaxY[0]) > 0.6)
                                {
                                    firstValue += 0.5525f;
                                }
                                else
                                {
                                    firstValue += 1.105f;
                                }
                            }
                            else if (n == 1)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "5":
                            if (isEqual || n == 3)
                            {
                                firstValue += 1.105f;
                            }
                            else if (n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            break;
                        case "6":
                            if (isEqual)
                            {
                                firstValue += 0.5525f;
                            }
                            else if (n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            break;
                        case "7":
                            if (isEqual)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 1)
                            {
                                firstValue += 1.105f;
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                    }
                    originalVec.y = firstValue;
                    transform.position = originalVec;
                }
                else if (RayCastBlock.Instance.targetMaxY.Count == 1)
                {
                    switch (str)
                    {
                        case "0":
                            if (n == 1)
                            {
                                firstValue += 1.105f;
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.105f;
                            }
                            break;
                        case "1":
                            if (n == 3)
                            {
                                firstValue += 2.21f;
                            }
                            break;
                        case "2":
                            if (n == 0)
                            {
                                firstValue += 1.6575f;
                            }
                            else if (n == 1)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "4":
                            if (n == 0)
                            {
                                if (RayCastBlock.Instance.targetMaxY[0] > -4)
                                {
                                    firstValue += 0.5525f;
                                }
                                else
                                {
                                    firstValue += 1.105f;
                                }
                            }
                            else if (n == 1)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                        case "5":
                            if (n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.105f;
                            }
                            break;
                        case "6":
                            if (n == 0)
                            {
                                firstValue += 0.5525f;
                            }
                            else if (n == 1)
                            {
                                firstValue -= 0.5525f;
                            }
                            break;
                        case "7":
                            if (n == 1)
                            {
                                firstValue += 1.105f;
                            }
                            else if (n == 3)
                            {
                                firstValue += 1.6575f;
                            }
                            break;
                    }
                    originalVec.y = firstValue;
                    transform.position = originalVec;
                }
            }
            else
            {
                int n = 0;
                firstValue = RayCastBlock.Instance.targetMaxY[0];
                for (int i = 0; i < BlockProperty.instance.blocks.Length; i++)
                {
                    if (BlockProperty.instance.blocks[i] != null && RayCastBlock.Instance.strings[0] != null)
                    {
                        if (BlockProperty.instance.blocks[i].gameObject == RayCastBlock.Instance.strings[0])
                        {
                            n = i;
                            break;
                        }
                    }
                }
                if (RayCastBlock.Instance.targetMaxY.Count > 1)
                {
                    for (int i = 1; i < RayCastBlock.Instance.targetMaxY.Count; i++)
                    {
                        if (str.Equals("0"))
                        {
                            if (firstValue <= RayCastBlock.Instance.targetMaxY[i])
                            {
                                isFirst = false;
                                firstValue = RayCastBlock.Instance.targetMaxY[i];
                                for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                {
                                    if (BlockProperty.instance.blocks[j] != null && RayCastBlock.Instance.strings[0] != null)
                                    {
                                        if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                        {
                                            n = j;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else if (str.Equals("6") || str.Equals("7"))
                        {
                            if (firstValue < RayCastBlock.Instance.targetMaxY[i] || Mathf.Abs(firstValue - RayCastBlock.Instance.targetMaxY[i]) < 0.05)
                            {
                                isFirst = false;
                                firstValue = RayCastBlock.Instance.targetMaxY[i];
                                for (int j = 0; j < BlockProperty.instance.blocks.Length; j++)
                                {
                                    if (BlockProperty.instance.blocks[j] != null && RayCastBlock.Instance.strings[0] != null)
                                    {
                                        if (BlockProperty.instance.blocks[j].gameObject == RayCastBlock.Instance.strings[i])
                                        {
                                            n = j;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (firstValue <= RayCastBlock.Instance.targetMaxY[i])
                            {
                                isFirst = false;
                                firstValue = RayCastBlock.Instance.targetMaxY[i];
                            }
                        }
                    }
                }
                else if (RayCastBlock.Instance.targetMaxY.Count == 1)
                {
                    isFirst = true;
                }
                if (str.Equals("6") || str.Equals("7"))
                {
                    if (isFirst)
                    {
                        if (n == 3)
                        {
                            firstValue += 1.105f;
                        }
                        else if (n == 2)
                        {
                            firstValue += 1.105f;
                        }
                        else if (n == 0)
                        {
                            firstValue += 0.5525f;
                        }
                    }
                    else
                    {
                        if (n == 0)
                        {
                            firstValue += 0.5525f;
                        }
                        else if (n == 2)
                        {
                            firstValue += 1.105f;
                        }
                        else if (n == 3)
                        {
                            firstValue += 1.105f;
                        }
                    }
                }
                else if (str.Equals("0"))
                {
                    if (isFirst)
                    {
                        firstValue += 1.105f;
                    }
                    else
                    {
                        if (n == 2)
                        {
                            firstValue += 1.105f;
                        }
                        else if (n == 3)
                        {
                            firstValue += 1.105f;
                        }
                    }
                }
                else
                {
                    firstValue += 1.105f;
                }
                if (str.Equals("6") || str.Equals("7"))
                {
                    if (!isEnter)
                    {
                        originalVec.y = firstValue;
                        transform.position = originalVec;
                    }
                    if (transform.position.y < -4.6)
                    {
                        transform.position = new Vector3(transform.position.x, -4.6f, transform.position.z);
                    }
                }
                else
                {
                    originalVec.y = firstValue;
                    transform.position = originalVec;
                }
            }
            if (BlockProperty.instance.isCtrlSimulation)
            {
                pivot.transform.rotation = BlockProperty.instance.qua;
                BlockProperty.instance.isCtrlSimulation = false;
            }
        }
    }
}
