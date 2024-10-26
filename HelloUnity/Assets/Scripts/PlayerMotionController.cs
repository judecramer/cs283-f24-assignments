using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    Transform core_transform;
    Animator anim;
    Vector3 velocity;
    Vector3 facing;
    CharacterController controller;
    //public float singleStep;
    public float MovementSpeed = 5;
    public float TurningSpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        core_transform = this.transform;
        velocity = new Vector3(0, 0, 0);
        controller = GetComponent<CharacterController>();
        //singleStep = TurningSpeed * Time.deltaTime;
        anim = gameObject.GetComponent<Animator>();
        anim.Play("Base Layer.Frog_idle", 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W)) GoForward();
        else if (Input.GetKey(KeyCode.S)) GoBack();
        else if (Input.GetKey(KeyCode.A)) TurnLeft();
        else if (Input.GetKey(KeyCode.D)) TurnRight();

        //velocity = Vector3.RotateTowards(velocity, facing, singleStep, 0.0f);
        controller.Move(velocity * Time.deltaTime);
        velocity = Vector3.Scale(velocity, new Vector3(.9f, .9f, .9f));

        if (velocity.magnitude > 1)
        {
            anim.Play("Base Layer.Frog_walk", 0, 0);
        }

    }

    void GoForward()
    {
        velocity = MovementSpeed * transform.forward;
    }

    void GoBack()
    {
        velocity = -MovementSpeed * transform.forward;
    }

    void TurnLeft()
    {
        core_transform.Rotate(0, -(TurningSpeed * Time.deltaTime), 0);
        //facing = Vector3.forward * core_transform.localEulerAngles.y;        

    }

    void TurnRight()
    {
        core_transform.Rotate(0, TurningSpeed * Time.deltaTime, 0);
        //facing = Vector3.forward * core_transform.localEulerAngles.y;
    }
}
