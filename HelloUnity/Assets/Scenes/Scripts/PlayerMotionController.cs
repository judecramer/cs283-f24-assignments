using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    Animator animator;
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
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = false;
        if (Input.GetKey(KeyCode.W)) GoForward();
        else if (Input.GetKey(KeyCode.S)) GoBack();

        if (Input.GetKey(KeyCode.A)) TurnLeft();
        if (Input.GetKey(KeyCode.D)) TurnRight();

        animator.SetBool("IsMoving", isWalking);
        if (isWalking) controller.Move(velocity * Time.deltaTime);
    }

    void GoForward()
    {
        velocity = MovementSpeed * this.transform.forward;
        isWalking = true;

    }

    void GoBack()
    {
        velocity = -MovementSpeed * this.transform.forward;
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
