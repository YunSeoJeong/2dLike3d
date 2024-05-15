using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperJoint : MonoBehaviour
{
    private List<LowerJoint> _lowerJoints = new List<LowerJoint>();

    public Vector3 position
    {
        get => transform.position;
        set
        {
            transform.position = value;

            //lowerJoints의 평균 위치를 바라보게 함
            Vector3 targetPos = new Vector3();
            foreach (var lowerJoint in _lowerJoints)
            {
                targetPos += lowerJoint.position;
            }
            targetPos /= _lowerJoints.Count;
            transform.LookAt(targetPos);
        }
    }

    public void AddLowerJoint(LowerJoint lowerJoint)
    {
        _lowerJoints.Add(lowerJoint);
    }

    public void RotateZ(float angle)
    {

    }
}
