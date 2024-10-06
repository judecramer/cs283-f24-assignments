using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

//Jude Cramer

public class FlyCamera : MonoBehaviour
{
    public float LerpRatio = .05f;
    public float HorizontalMouseSpeed = 2.0f;
    public float VerticalMouseSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Button presses
        if (Input.GetKey(KeyCode.W)) GoForward();
        else if (Input.GetKey(KeyCode.A)) GoLeft();
        else if (Input.GetKey(KeyCode.D)) GoRight();
        else if (Input.GetKey(KeyCode.S)) GoBackwards();
        else if (Input.GetKey(KeyCode.Space)) GoUp();
        else if (Input.GetKey(KeyCode.LeftShift)) GoDown();

        //Mouse movement
        float h = HorizontalMouseSpeed * Input.GetAxis("Mouse X");
        float v = VerticalMouseSpeed * Input.GetAxis("Mouse Y");
        Camera.main.transform.Rotate(-v, h, 0);
    }

    //ALL OUR FUNCTIONS.

    void GoForward()
    {
        Vector3 fwd = Camera.main.transform.forward;
        Vector3 start = Camera.main.transform.position;
        Vector3 end = Camera.main.transform.position + fwd;
        Camera.main.transform.position = Vector3.Slerp(start, end, LerpRatio);
    }

    void GoLeft()
    {
        Vector3 lft = Vector3.Scale(Camera.main.transform.right, new Vector3(-1, -1, -1));
        Vector3 start = Camera.main.transform.position;
        Vector3 end = Camera.main.transform.position + lft;
        Camera.main.transform.position = Vector3.Slerp(start, end, LerpRatio);
    }

    void GoRight()
    {
        Vector3 rght = Camera.main.transform.right;
        Vector3 start = Camera.main.transform.position;
        Vector3 end = Camera.main.transform.position + rght;
        Camera.main.transform.position = Vector3.Slerp(start, end, LerpRatio);

    }

    void GoBackwards()
    {
        Vector3 back = Vector3.Scale(Camera.main.transform.forward, new Vector3(-1, -1, -1));
        Vector3 start = Camera.main.transform.position;
        Vector3 end = Camera.main.transform.position + back;
        Camera.main.transform.position = Vector3.Slerp(start, end, LerpRatio);
    }

    void GoUp()
    {
        Vector3 up = Camera.main.transform.up;
        Vector3 start = Camera.main.transform.position;
        Vector3 end = Camera.main.transform.position + up;
        Camera.main.transform.position = Vector3.Slerp(start, end, LerpRatio);
    }

    void GoDown()
    {
        Vector3 down = Vector3.Scale(Camera.main.transform.up, new Vector3(-1, -1, -1));
        Vector3 start = Camera.main.transform.position;
        Vector3 end = Camera.main.transform.position + down;
        Camera.main.transform.position = Vector3.Slerp(start, end, LerpRatio);
    }
}


//things to remember
//Mathf.Lerp()