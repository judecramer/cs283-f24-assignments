using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    Animator anim;
    Vector3 velocity;
    CharacterController controller;
    public float MovementSpeed = 9;
    public float TurningSpeed = 400f;
    bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, 0);
        controller = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
        anim.Play("Base Layer.Frog_idle", 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W)) GoForward();
        else if (Input.GetKey(KeyCode.S)) GoBack();
        else isWalking = false;


        if (Input.GetKey(KeyCode.A)) TurnLeft();
        if (Input.GetKey(KeyCode.D)) TurnRight();

        if (isWalking)
        {
            anim.Play("Base Layer.Frog_walk", 0, 0);
        }

    }

    void GoForward()
    {
        velocity = MovementSpeed * this.transform.forward;
        controller.Move(velocity * Time.deltaTime);
        isWalking = true;
    }

    void GoBack()
    {
        velocity = -MovementSpeed * this.transform.forward;
        controller.Move(velocity * Time.deltaTime);
        isWalking = true;
    }

    void TurnLeft()
    {
        transform.Rotate(0, -(TurningSpeed * Time.deltaTime), 0);

    }

    void TurnRight()
    {
        transform.Rotate(0, TurningSpeed * Time.deltaTime, 0);
    }
}
