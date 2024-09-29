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
            jointCreater.Joints[i].Translate(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        }

        yield return null;


        //Assert
        Assert.AreEqual(bones.Count, jointCreater.Joints.Count);
        for (int i = 0; i < bones.Count; i++)
        {
            Assert.AreEqual(bones[i].position.x, jointCreater.Joints[i].position.x, 0.01f);
            Assert.AreEqual(bones[i].position.y, jointCreater.Joints[i].position.y, 0.01f);
            Assert.AreEqual(bones[i].position.z, jointCreater.Joints[i].position.z, 0.01f);
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
}
