using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ֻ��� ���� ������Ʈ�� �پ�� ��.
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
