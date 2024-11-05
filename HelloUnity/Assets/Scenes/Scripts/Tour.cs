using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jude Cramer

public class Tour : MonoBehaviour
{

    Camera mainCamera;                  //the main camera object
    public int CurrentView = 0;         //index of which POI is being viewed
    Transform[] POIs;                   //Array of POI transform components
    int NumOfPOIs = 3;                  //Total number of POI objects (update manually!)

    public int Duration = 60;
    int elapsedFrames = 0;
    bool Lerping = false;
    Vector3 startPos;
    Vector3 endPos;
    Quaternion startRot;
    Quaternion endRot;

    // Start is called before the first frame update
    void Start()
    {
        //Access main camera and create array of POI transforms
        mainCamera = Camera.main;
        POIs = GetComponentsInChildren<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
    
        //Detect keypress
        if (Input.GetKeyDown(KeyCode.N))
        {
            Lerping = true;
            //jank indexing stuff
            CurrentView++;
            if (CurrentView > NumOfPOIs) 
            {
                CurrentView = CurrentView % (NumOfPOIs + 1);
            }
            if (CurrentView == 0) CurrentView++;

            startPos = mainCamera.transform.position;
            endPos = POIs[CurrentView].position;
            startRot = mainCamera.transform.rotation;
            endRot = POIs[CurrentView].rotation;


        }

        //Only runs when N is pressed
        //Transform current camera pos and rotation to the new POI
        if (Lerping == true)
        {
            float LerpRatio = (float)elapsedFrames / Duration;

            Vector3 lerpedPos = Vector3.Lerp(startPos, endPos, LerpRatio);
            Quaternion lerpedRot = Quaternion.Lerp(startRot, endRot, LerpRatio);

            elapsedFrames++;

            if (elapsedFrames >= Duration)
            {
                Lerping = false;
                elapsedFrames = 0;
            }
            else 
            { 
                mainCamera.transform.position = lerpedPos;
                mainCamera.transform.rotation = lerpedRot;
            }
            
            

        }

    }
}
