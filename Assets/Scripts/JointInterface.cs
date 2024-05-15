using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class JointInterface : MonoBehaviour
{
    private UpperJoint _upperJoint;
    private LowerJoint _lowerJoint;

    [Range(0.01f, 10f)]
    public float scale = 1f;

    private void Update()
    {
        _upperJoint.position = transform.position;
        _lowerJoint.position = transform.position;
    }
}
