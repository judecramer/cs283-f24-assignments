using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    GameObject player;
    GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawner = GameObject.FindWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("COLLISION");
        player.SendMessage("Increment");

        GameObject particles = GameObject.Find("Particles");
        particles.SendMessage("PlayEffect", this.transform.position);

        spawner.SendMessage("FoundOne");

        gameObject.SetActive(false);
    }
}
