using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerJoint : MonoBehaviour
{
    private UpperJoint _upperJoint;

    public Vector3 position
    {
        get => transform.position;
        set
        {
            transform.position = value;

            //uppwerJoint를 등지는 방향을 바라보게 함
            transform.LookAt(2*transform.position - _upperJoint.position);
        }
    }

    public void RotateZ(float angle)
    {

    }
}
