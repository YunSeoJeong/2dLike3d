using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public List<Joint> NextJoints { get; set; } = new();
    public Transform TargetBone { get;  set; }
    public float Depth { get;  set; }

    private void FixedUpdate()
    {
        //위치 동기화
        TargetBone.position = transform.position;

        //회전 동기화
            //방향 설정
        Vector3 direction = new Vector3();
        foreach (var joint in NextJoints)
        {
            direction += joint.transform.position;
        }
        direction /= NextJoints.Count;
        direction -= transform.position;

            //y축이 타겟을 바라보도록 벡터 조정
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation *= Quaternion.Euler(new Vector3(90, 0, 0));
        TargetBone.rotation = rotation;

        //뎁스 동기화
        Depth = transform.eulerAngles.z;
    }
}
