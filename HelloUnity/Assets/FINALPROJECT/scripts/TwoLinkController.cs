using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TwoLinkController : MonoBehaviour
{

    public Transform Target;
    public Transform Paw;
    public Transform Elbow;
    public Transform Shoulder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //compute distance between shoulder and target (||r||)
        //compute elbow angle such that ||r|| = [distance from shoulder to hand]
        //compute the shoulder rotation "that points the vector P.hand - P.shoulder towards target
        Vector3 r = Target.position - Shoulder.position; //from shoulder to target
        Vector3 e = Target.position - Paw.position; //from paw to target

        float rmag = r.magnitude;
        float l1 = Vector3.Distance(Shoulder.position, Elbow.position);
        float l2 = Vector3.Distance(Elbow.position, Paw.position);

        float cosTheta = (-(rmag * rmag) + (l1 * l1) + (l2 * l2)) / (2 * l1 * l2);
        int cosThetaBonus = (int)cosTheta;
        float res = cosTheta - (float)cosThetaBonus;
        float Theta = ((float)Math.Acos(res) * (float)(180.0 / Math.PI)); //+ 180f;

        
        Debug.Log("rmag: " + rmag + "\nl1: " + l1 + "\nl2: " + l2 + "\ncosTheta: " + cosTheta + "\nTheta: " + Theta + "\n");
        Elbow.localRotation = Quaternion.Euler(Theta, 0, 0);
    }
} 
