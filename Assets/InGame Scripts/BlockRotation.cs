using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotation : MonoBehaviour
{
    public static BlockRotation instance;
    private Vector3 originalLeftVec;
    private Vector3 originalBottomVec;
    public Vector3 currentRotation;
    private string str;
    private Transform pivot;
    public float time;

    private void Awake()
    {
        instance = this;
        pivot = transform.GetChild(0);
    }
    void Update()
    {
        str = this.gameObject.name.Substring(7, 1);
        currentRotation = pivot.rotation.eulerAngles;
        if (BlockProperty.instance.isCtrl)
        {
            originalLeftVec = transform.position;
            originalBottomVec = transform.position;
            switch (str)
            {
                case "0":
                    break;
                case "1":
                    if (Mathf.Approximately(currentRotation.z, 180))
                    {
                        originalLeftVec.y += 0.5525f;
                        transform.position = originalLeftVec;
                    }
                    else if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                    {
                    }
                    else if (!Mathf.Approximately(currentRotation.z, 270))
                    {
                        originalLeftVec.y -= 0.5525f;
                        transform.position = originalLeftVec;
                    }

                    if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                    {
                        originalLeftVec.x += 0.5525f;
                        transform.position = originalLeftVec;
                    }
                    else if (Mathf.Approximately(currentRotation.z, 270))
                    {
                        originalLeftVec.x -= 0.5525f;
                        transform.position = originalLeftVec;
                    }
                    if (transform.position.x <= -2.3)
                    {
                        if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            if (!BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 1.105f;
                                transform.position = originalLeftVec;
                            }
                            else
                            {
                                originalLeftVec.x += 1.105f;
                                transform.position = originalLeftVec;
                            }
                        }
                        else if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }
                    else if (transform.position.x <= -1.79)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            originalLeftVec.x += 0.5525f;
                            transform.position = originalLeftVec;
                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 1.105f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }
                    else if (transform.position.x <= -1.22)
                    {
                        if (Mathf.Approximately(currentRotation.z, 180))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x -= 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }
                    else if (transform.position.x > 2.5)
                    {
                        originalLeftVec.x -= 1.105f;
                        transform.position = originalLeftVec;
                    }
                    else if (transform.position.x > 2)
                    {
                        if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            if (BlockProperty.instance.isPutRight)
                            {
                                originalLeftVec.x -= 0.5525f;
                                transform.position = originalLeftVec;
                            }
                            else
                            {
                                originalLeftVec.x -= 1.105f;
                                transform.position = originalLeftVec;
                            }
                            
                        }
                        else if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            if (BlockProperty.instance.isPutRight)
                            {
                                originalLeftVec.x -= 1.105f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }
                    else if (transform.position.x > 1.5)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                        }
                        else if (Mathf.Approximately(currentRotation.z, 180))
                        {

                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {

                        }
                        else
                        {
                            if (BlockProperty.instance.isPutRight)
                            {
                                originalLeftVec.x -= 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }
                    if(transform.position.y <= -4)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {

                        }
                        else if (Mathf.Approximately(currentRotation.z, 180))
                        {

                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {

                        }
                        else
                        {
                            originalBottomVec.y += 0.5525f;
                            transform.position = originalBottomVec;
                        }
                    }
                    else if(transform.position.y <= -3.5)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {

                        }
                        else if (Mathf.Approximately(currentRotation.z, 180))
                        {

                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {

                        }
                        else
                        {
                            transform.position = originalBottomVec;
                        }
                    }
                    else if(transform.position.y <= -3)
                    {
                        if (Mathf.Approximately(currentRotation.z, 180))
                        {
                            originalBottomVec.y += 1.105f;
                            transform.position = originalBottomVec;
                        }
                    }
                    break;
                case "2":
                    if (Mathf.Approximately(currentRotation.z, 270))
                    {
                        originalLeftVec.y -= 0.5525f;
                        transform.position = originalLeftVec;
                    }
                    if (transform.position.x <= -2.2)
                    {
                        if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            originalLeftVec.x += 0.5525f;
                            transform.position = originalLeftVec;
                        }
                    }
                    else if (transform.position.x <= -1.79)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 1.105f;
                                transform.position = originalLeftVec;
                            }
                        }
                        else if (!Mathf.Approximately(currentRotation.z, 180))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }
                    else if (transform.position.x > 2.4)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            originalLeftVec.x -= 0.5525f;
                            transform.position = originalLeftVec;
                        }
                    }
                    if(transform.position.y <= -3.5)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {

                        }
                        else if (Mathf.Approximately(currentRotation.z, 180))
                        {

                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {

                        }
                        else
                        {
                            originalBottomVec.y += 0.5525f;
                            transform.position = originalBottomVec;
                        }
                    }
                    break;
                case "4":
                    if (Mathf.Approximately(currentRotation.z, 270))
                    {
                        originalLeftVec.y -= 0.5525f;
                        transform.position = originalLeftVec;
                    }
                    if (transform.position.x <= -2.2)
                    {
                        if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            originalLeftVec.x += 0.5525f;
                            transform.position = originalLeftVec;
                        }
                    }
                    else if (transform.position.x <= -1.79)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 1.105f;
                                transform.position = originalLeftVec;
                            }
                        }
                        else if (!Mathf.Approximately(currentRotation.z, 180))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }
                    else if (transform.position.x > 2.4)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            originalLeftVec.x -= 0.5525f;
                            transform.position = originalLeftVec;
                        }
                    }
                    if (transform.position.y <= -3.5)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {

                        }
                        else if (Mathf.Approximately(currentRotation.z, 180))
                        {

                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {

                        }
                        else
                        {
                            originalBottomVec.y += 0.5525f;
                            transform.position = originalBottomVec;
                        }
                    }
                    break;
                case "5":
                    if (transform.position.x <= -2.2)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            originalLeftVec.x += 0.5525f;
                            transform.position = originalLeftVec;
                        }
                    }
                    else if (transform.position.x <= -1.79)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }
                    else if (transform.position.x > 2.4)
                    {
                        if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            originalLeftVec.x -= 0.5525f;
                            transform.position = originalLeftVec;
                        }
                    }
                    else if (transform.position.x > 2)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            if (BlockProperty.instance.isPutRight)
                            {
                                originalLeftVec.x -= 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            if (BlockProperty.instance.isPutRight)
                            {
                                originalLeftVec.x -= 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }
                    if(transform.position.y <= -4)
                    {
                        if (Mathf.Approximately(currentRotation.z, 180))
                        {
                            originalBottomVec.y += 0.5525f;
                            transform.position = originalBottomVec;
                        }
                    }
                    break;
                case "6":
                    if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                    {
                        originalLeftVec.y -= 1.105f;
                        transform.position = originalLeftVec;
                    }
                    else if (Mathf.Approximately(currentRotation.z, 270))
                    {
                        originalLeftVec.y += 0.5525f;
                        transform.position = originalLeftVec;
                    }
                    else if (!Mathf.Approximately(currentRotation.z, 180))
                    {
                        originalLeftVec.y += 0.5525f;
                        transform.position = originalLeftVec;
                    }

                    if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                    {
                    }
                    else if (Mathf.Approximately(currentRotation.z, 270))
                    {
                    }
                    else if (Mathf.Approximately(currentRotation.z, 180))
                    {
                        originalLeftVec.x += 1.105f;
                        transform.position = originalLeftVec;
                    }
                    else
                    {
                        originalLeftVec.x -= 1.105f;
                        transform.position = originalLeftVec;
                    }
                    if (transform.position.x <= -2.2)
                    {
                        if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            originalLeftVec.x += 0.5525f;
                            transform.position = originalLeftVec;
                        }
                    }
                    else if (transform.position.x <= -1.79)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 1.105f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }
                    else if (transform.position.x > 1.9)
                    {
                        if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            if (BlockProperty.instance.isPutRight)
                            {
                                originalLeftVec.x -= 0.5525f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }
                    if (transform.position.x > 1.5)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            originalLeftVec.x -= 0.5525f;
                            transform.position = originalLeftVec;
                        }
                        else if (Mathf.Approximately(currentRotation.z, 180))
                        {
                        }
                        else if (Mathf.Approximately(currentRotation.z, 270))
                        {
                        }
                        else if (!Mathf.Approximately(currentRotation.z, 270) || !Mathf.Approximately(currentRotation.z, 90) || !Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            originalLeftVec.x -= 0.5525f;
                            transform.position = originalLeftVec;
                        }
                    }
                    break;
                case "7":
                    if (Mathf.Approximately(currentRotation.z, 180))
                    {
                        originalLeftVec.y += 1.105f;
                        transform.position = originalLeftVec;
                    }
                    else if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                    {
                    }
                    else if (Mathf.Approximately(currentRotation.z, 270))
                    {
                        originalLeftVec.y -= 0.5525f;
                        transform.position = originalLeftVec;
                    }
                    else
                    {
                        originalLeftVec.y -= 0.5525f;
                        transform.position = originalLeftVec;
                    }
                    if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                    {
                        originalLeftVec.x += 1.105f;
                        transform.position = originalLeftVec;
                    }
                    else if (Mathf.Approximately(currentRotation.z, 270))
                    {
                        originalLeftVec.x -= 1.105f;
                        transform.position = originalLeftVec;
                    }
                    if (transform.position.x <= -2.2)
                    {
                        if (Mathf.Approximately(currentRotation.z, 270))
                        {
                            originalLeftVec.x += 0.5525f;
                            transform.position = originalLeftVec;
                        }
                    }
                    if (transform.position.x <= -1.79)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            if (BlockProperty.instance.isPutLeft)
                            {
                                originalLeftVec.x += 1.105f;
                                transform.position = originalLeftVec;
                            }
                            else
                            {
                                originalLeftVec.x += 1.105f;
                                transform.position = originalLeftVec;
                            }
                        }
                    }else if(transform.position.x >= 3.5)
                    {
                        if (Mathf.Approximately(currentRotation.z, 90) || Mathf.Approximately(currentRotation.z, 90.00001f))
                        {
                            originalLeftVec.x -= 0.5525f;
                            transform.position = originalLeftVec;
                        }
                    }
                    break;
            }
            pivot.transform.rotation = BlockProperty.instance.qua;
            RayCastBlock.Instance.isAdd = false;
            BlockProperty.instance.isCtrl = false;
        }

    }
}
