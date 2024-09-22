using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class JointCreateTest
{
    [UnityTest]
    public IEnumerator JointNameTest()
    {
        //Arrange
        var modelPrefab = Resources.Load<GameObject>("Prefabs/X Bot");
        Assert.IsNotNull(modelPrefab, "Model Prefab was not found.");

        var testModel = Object.Instantiate(modelPrefab).transform;
        Assert.IsNotNull(testModel, "Test model instantiation failed.");

        var boneNames = new List<string>();
        GetBoneNames(testModel.GetChild(2), "Joint 0", boneNames);

        var jointCreater = testModel.GetChild(2).GetComponent<JointCreater>();
        Assert.IsNotNull(jointCreater, "JointCreater component was not found.");

        //Act
        yield return null;

        //Assert
        Assert.AreEqual(boneNames.Count, jointCreater.Joints.Count);
        for (int i = 0; i < boneNames.Count; i++)
        {
            Assert.AreEqual(boneNames[i], jointCreater.Joints[i].name);
        }

        void GetBoneNames(Transform currentBone, string currentBoneName, List<string> boneNames)
        {
            boneNames.Add(currentBoneName);
            for (int i = 0; i < currentBone.childCount; i++)
            {
                GetBoneNames(currentBone.GetChild(i), currentBoneName + "." + i, boneNames);
            }
        }
    }

    [UnityTest]
    public IEnumerator JointPositionTest()
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

    [UnityTest]
    public IEnumerator JointRotationTest()
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

        //Assert
        Assert.AreEqual(bones.Count, jointCreater.Joints.Count);
        for (int i = 0; i < bones.Count; i++)
        {
            Assert.AreEqual(bones[i].rotation.x, jointCreater.Joints[i].rotation.x, 0.01f);
            Assert.AreEqual(bones[i].rotation.y, jointCreater.Joints[i].rotation.y, 0.01f);
            Assert.AreEqual(bones[i].rotation.z, jointCreater.Joints[i].rotation.z, 0.01f);
            Assert.AreEqual(bones[i].rotation.w, jointCreater.Joints[i].rotation.w, 0.01f);
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
    public IEnumerator JointScaleTest()
    {
        yield return null;
        //TODO 모델에 맞게 관절 크기가 적용되었는지 테스트
        Assert.Fail();
    }
}