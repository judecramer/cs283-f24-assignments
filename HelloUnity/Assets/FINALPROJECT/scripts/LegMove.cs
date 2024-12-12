using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LegMove : MonoBehaviour
{
    public Transform LShoulder;
    public Transform RShoulder;
    public Transform LHip;
    public Transform RHip;

    public KittyController ControllerScript;

    private double x = 0; // 0 < x < 2pi, sine wave domain 
    private double y; // 0 < y < 1, sine wave range
    private double stepSize = 10;

    static double ShoulderRange = 60;
    static double ShoulderStart = -90;

    static double HipRange = 50;
    static double HipStart = -160;

    //static double HipRange = 45;
    //double HipStart = -80;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerScript.IsMoving)
        {
            if (x > (2 * Math.PI))
            {
                x = x - (2 * Math.PI);
            }

            x += stepSize * Time.deltaTime;

            double y = (Math.Sin(x) + 1) / 2;
            double yinv = 1.0 - y;

            //calculate the angle by multiplying y by range and adding the start angle
            LShoulder.localRotation = Quaternion.Euler((float)((y * ShoulderRange) + ShoulderStart), 0, 0);
            RShoulder.localRotation = Quaternion.Euler((float)((yinv * ShoulderRange) + ShoulderStart), 0, 0);

            RHip.localRotation = Quaternion.Euler((float)((y * HipRange) + HipStart), 0, 0);
            LHip.localRotation = Quaternion.Euler((float)((yinv * HipRange) + HipStart), 0, 0);
        }
    }
}
