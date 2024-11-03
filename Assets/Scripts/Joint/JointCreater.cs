using System.Collections.Generic;
using UnityEngine;

//최상위 본에 컴포넌트로 붙어야 함.
public class JointCreater : MonoBehaviour
{
    public List<Joint> Joints = new();
    [SerializeField]
    private GameObject _jointPrefab;

    private void Start()
    {
        CreateJoints(transform, null, "Joint 0");
    }

    private void CreateJoints(Transform currentBone, Joint latestJoint, string jointName)
    {
        Transform jointTransform = Instantiate(_jointPrefab).transform;
        jointTransform.position = new Vector3(currentBone.position.x, currentBone.position.y, 0);
        jointTransform.name = jointName;

        Joint joint = jointTransform.GetComponent<Joint>();
        joint.TargetBone = currentBone;
        if(latestJoint != null)
        {
            latestJoint.NextJoints.Add(joint);
        }

        Joints.Add(joint);
        for (int i = 0; i < currentBone.childCount; i++)
        {
            CreateJoints(currentBone.GetChild(i), joint, jointName + "." + i);
        }
    }
}
