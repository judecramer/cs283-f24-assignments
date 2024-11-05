using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidFollowCamera : MonoBehaviour
{
    public Transform target;
    public float FollowHorizontal = 5;
    public float FollowVertical = 4;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log(target.name);

        Vector3 tPos = target.position;
        Vector3 tUp = target.up;
        Vector3 tForward = target.forward;

        Vector3 eye = tPos - tForward * FollowHorizontal + tUp * FollowVertical;
        Vector3 cameraForward = tPos - eye;

        transform.position = eye;
        transform.rotation = Quaternion.LookRotation(cameraForward);
        
    }
}

//UnityEngine.Debug.Log(target.name);
