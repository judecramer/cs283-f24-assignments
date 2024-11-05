using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringFollowCamera : MonoBehaviour
{
    public Transform target;
    public float FollowHorizontal = 5;
    public float FollowVertical = 4;
    public static float springConstant = 1000;
    public float dampConstant = 2.0f * Mathf.Sqrt(springConstant);
    Vector3 actualPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        actualPosition = target.position - target.forward * FollowHorizontal + target.up * FollowVertical;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tPos = target.position;
        Vector3 tUp = target.up;
        Vector3 tForward = target.forward;
       
        Vector3 velocity = new Vector3(0, 0, 0);
        Vector3 cameraForward = tPos - actualPosition;

        Vector3 idealPosition = tPos - tForward * FollowHorizontal + tUp * FollowVertical;


        Vector3 displacement = actualPosition - idealPosition;

        Vector3 springAccel = (-springConstant * displacement) - (dampConstant * velocity);

        velocity += springAccel * Time.deltaTime;
        actualPosition += velocity * Time.deltaTime;

        transform.position = actualPosition;
        transform.rotation = Quaternion.LookRotation(cameraForward);

        if (Input.GetKey(KeyCode.Space))
        {
            actualPosition = idealPosition;
        }
        

    }
}
