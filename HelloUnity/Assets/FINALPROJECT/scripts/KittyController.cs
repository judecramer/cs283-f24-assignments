using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class KittyController : MonoBehaviour
{
    CharacterController controller;

    public Transform cursor;

    public float duration = 3.0F;
    public float speed = 1f;
    public float GRAVITY = -9.8f;
    public float TurnSpeed = 1f;

    private Vector3 playerVelocity;

    public bool IsMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

        playerVelocity = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            PickPoint(Input.mousePosition);
            StopAllCoroutines();
            StartCoroutine(GoSomewhere());
        }

        //apply gravity
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        playerVelocity.y += GRAVITY * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    IEnumerator GoSomewhere()
    {
        //each frame, turn x degrees towards target. then walk forwards
        while (Vector3.Distance(transform.position, cursor.position) > .2) //loop each frame until [this] and cursor meet
        {
            IsMoving = true;


            Vector3 newDirection = Vector3.RotateTowards(transform.forward, (cursor.position - transform.position), (TurnSpeed * Time.deltaTime), 0.0f);

            transform.rotation = Quaternion.LookRotation(newDirection);

            UnityEngine.Debug.Log(newDirection + ", deltaTime: " + Time.deltaTime);

            controller.Move(newDirection * Time.deltaTime * speed);

            yield return null;
        }


        IsMoving = false;
    }

   void PickPoint(Vector3 mousePosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            cursor.position = hit.point;
            //Vector3 fromCatToEnd = cursor.position - transform.position;
            //cursor.rotation = Quaternion.LookRotation(fromCatToEnd, Vector3.up);

        }
    }
}
