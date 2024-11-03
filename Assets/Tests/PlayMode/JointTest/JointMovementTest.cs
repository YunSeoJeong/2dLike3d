using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class JointMovementTest
{
    [UnityTest]
    public IEnumerator BoneJointPositionSynchronizationTest()
    {
        //Arrange
        var modelPrefab = Resources.Load<GameObject>("Prefabs/X Bot");
        Assert.IsNotNull(modelPrefab, "Model Prefab was not found.");

        var testModel = Object.Instantiate(modelPrefab).transform;
        Assert.IsNotNull(testModel, "Test model instantiation failed.");

        var bones = new List<Transform>();
        GetBoneTransforms(testModel.GetChild(2), bones);

        var jointCreater = testModel.GetChild(2).GetComponent<JointCreater>();
        Assert.IsNotNull(jointCreater, "JointCreater component was not found.");

        //Act
        yield return null;

        Assert.AreEqual(bones.Count, jointCreater.Joints.Count);
        for (int i = 0; i < bones.Count; i++)
        {
            jointCreater.Joints[i].transform.Translate(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
        }

        yield return null;
        yield return null;
        yield return null;
        yield return null;

        //Assert
        Assert.AreEqual(bones.Count, jointCreater.Joints.Count);
        for (int i = 0; i < bones.Count; i++)
        {
            Assert.AreEqual(bones[i].position.x, jointCreater.Joints[i].transform.position.x, 0.01f);
            Assert.AreEqual(bones[i].position.y, jointCreater.Joints[i].transform.position.y, 0.01f);
        }

        void GetBoneTransforms(Transform currentBone, List<Transform> bones)
        {
            bones.Add(currentBone);
            for (int i = 0; i < currentBone.childCount; i++)
            {
                GetBoneTransforms(currentBone.GetChild(i), bones);
            }
        }
    }

    [UnityTest]
    public IEnumerator BoneFacingNextJointTest()
    {
        //Arrange
        var modelPrefab = Resources.Load<GameObject>("Prefabs/X Bot");
        Assert.IsNotNull(modelPrefab, "Model Prefab was not found.");

        var testModel = Object.Instantiate(modelPrefab).transform;
        Assert.IsNotNull(testModel, "Test model instantiation failed.");

        var jointCreater = testModel.GetChild(2).GetComponent<JointCreater>();
        Assert.IsNotNull(jointCreater, "JointCreater component was not found.");

        //Act
        yield return null;

        for (int i = 0; i < jointCreater.Joints.Count; i++)
        {
            jointCreater.Joints[i].transform.Translate(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        }

        yield return null;
        yield return null;
        yield return null;
        yield return null;


        //Assert
        for (int i = 0; i < jointCreater.Joints.Count; i++)
        {
            //더 이상 NextJoint가 없는 말단 관절이면
            if (jointCreater.Joints[i].NextJoints.Count == 0) continue;

            //targetPosition == 하위 본들 position의 무게중심
            Vector3 targetPosition = new Vector3();
            foreach (var joint in jointCreater.Joints[i].NextJoints)
            {
                targetPosition += joint.transform.position;
            }
            targetPosition /= jointCreater.Joints[i].NextJoints.Count;

            //본이 targetPosition을 바라보고 있는지 검사
            Vector3 direction = (targetPosition - jointCreater.Joints[i].TargetBone.position).normalized;
            Assert.AreEqual(jointCreater.Joints[i].transform.up.x, direction.x, 0.01f);
            Assert.AreEqual(jointCreater.Joints[i].transform.up.y, direction.y, 0.01f);
            Assert.AreEqual(jointCreater.Joints[i].transform.up.z, direction.z, 0.01f);
        }
    }
}
