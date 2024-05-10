using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointBone
{
    private UpperJoint _upperJoint;
    private List<LowerJoint> _lowerJoints;

    private Vector3 _centerofLowerJoints
    {
        get
        {
            if(_lowerJoints == null)
            {
                Debug.LogError("LowerJoint를 찾을 수 없습니다.");
                return Vector3.zero;
            }
            Vector3 center = new Vector3();
            foreach(var lowerJoint in _lowerJoints)
            {
                center += lowerJoint.position;
            }
            center /= _lowerJoints.Count;
            return center;
        }
    }

    public void BoneUpdate()
    {
        
    }
}
