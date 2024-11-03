using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        //transform.LookAt(target, Vector3.up);

        Vector3 directionToTarget = target.position - transform.position;

        // y축이 타겟을 바라보도록 벡터 조정
        Quaternion rotation = Quaternion.LookRotation(directionToTarget);
        rotation *= Quaternion.Euler(new Vector3(90, 0, 0));


        // 회전 설정
        transform.rotation = rotation;
    }
}
