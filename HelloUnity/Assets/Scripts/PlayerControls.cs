using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Transform Parent;
    public float MovementSpeed = 10;
    public float TurningSpeed = 500;

    // Start is called before the first frame update
    void Start()
    {
        Parent = this.transform.root; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) GoForward();
        else if (Input.GetKey(KeyCode.S)) GoBack();
        else if (Input.GetKey(KeyCode.A)) TurnLeft();
        else if (Input.GetKey(KeyCode.D)) TurnRight();


    }

    void GoForward(){
        Parent.position += Parent.forward * MovementSpeed * Time.deltaTime;
    }

    void GoBack() {
        Parent.position += -(Parent.forward * MovementSpeed * Time.deltaTime) ;
    }

    void TurnLeft() {
        Parent.Rotate(0, -(TurningSpeed * Time.deltaTime), 0);
    }

    void TurnRight() {
        Parent.Rotate(0, TurningSpeed * Time.deltaTime, 0);
    }
}
