using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this implementation doesn't check if the object's spawning position is valid
//because of this, flowers may spawn inside other objects. oops.
//want to spawn an object other than a flower? drag a prefab into the guyToSpawn parameter before playing

public class Spawner : MonoBehaviour
{

    public GameObject guyToSpawn;
    public float range = 20f;   //spawns in a radius of range size around the spawner
    public int maxObjects = 3;  

    int objCount;

    // Start is called before the first frame update
    void Start()
    {
        if (guyToSpawn == null) guyToSpawn = GameObject.FindWithTag("collectable");
        objCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (objCount < maxObjects) SpawnGuy();
    }

    public void FoundOne()
    {
        objCount--;
    }

    public void SpawnGuy()
    {
        float newX = UnityEngine.Random.Range(-range, range);
        float newZ = UnityEngine.Random.Range(-range, range);

        GameObject newGuy = UnityEngine.Object.Instantiate(guyToSpawn,this.transform, false);
        newGuy.transform.localPosition = new Vector3(newX, 0, newZ);
        objCount++;
    }
}
