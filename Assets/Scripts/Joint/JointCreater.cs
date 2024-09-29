using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//최상위 본에 컴포넌트로 붙어야 함.
public class JointCreater : MonoBehaviour
{
    public List<Transform> Joints = new();
    [SerializeField]
    private GameObject _jointPrefab;

    private void Start()
    {
        CreateJoints(transform, "Joint 0");
    }

    private void CreateJoints(Transform currentJoint, string jointName)
    {
        Transform joint = Instantiate(_jointPrefab).transform;
        joint.position = currentJoint.position;
        joint.rotation = currentJoint.rotation;
        joint.name = jointName;
        Joints.Add(joint);
        for (int i = 0; i < currentJoint.childCount; i++)
        {
            CreateJoints(currentJoint.GetChild(i), jointName + "." + i);
        }
    }
}
