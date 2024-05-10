using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerJoint : MonoBehaviour
{
    public JointBone Bone { get; private set; }
    public Vector3 position { get => transform.position; }

    public void SetRotation(Vector3 targetPos)
    {
        transform.LookAt(targetPos);
    }
}
