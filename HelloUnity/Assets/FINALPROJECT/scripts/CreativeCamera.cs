using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class CreativeCamera : MonoBehaviour
{

    private float movementSpeed = 5f;

    public float HorizontalMouseSpeed = 5.0f;
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
        else if (Input.GetKey(KeyCode.S)) GoBackwards();

        if (Input.GetKey(KeyCode.A)) GoLeft();
        else if (Input.GetKey(KeyCode.D)) GoRight();
        
        if (Input.GetKey(KeyCode.Space)) GoUp();
        else if (Input.GetKey(KeyCode.LeftShift)) GoDown();


        //Mouse movement
        float h = HorizontalMouseSpeed * Input.GetAxis("Mouse X");
        //float v = VerticalMouseSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(transform.up, h, Space.Self);
        //transform.Rotate(transform.right, v, Space.Self);

        //QUIT
        if (Input.GetKey("escape"))
        {
            UnityEngine.Application.Quit();
        }

    }

    //ALL OUR FUNCTIONS.

    void GoForward()
    {
        transform.position = transform.position + (transform.forward * Time.deltaTime * movementSpeed);
    }

    void GoLeft()
    {
        transform.position = transform.position - (transform.right * Time.deltaTime * movementSpeed);
    }

    void GoRight()
    {
        transform.position = transform.position + (transform.right * Time.deltaTime * movementSpeed);

    }

    void GoBackwards()
    {
        transform.position = transform.position - (transform.forward * Time.deltaTime * movementSpeed);
    }

    void GoUp()
    {
        transform.position = transform.position + (transform.up * Time.deltaTime * movementSpeed);
    }

    void GoDown()
    {
        transform.position = transform.position - (transform.up * Time.deltaTime * movementSpeed);
    }

}
