using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSummoning : MonoBehaviour
{
    //default position the particle spawner starts at 
    public Vector3 defaultPos = new Vector3(0f, -30f, 0f);
    ParticleSystem particles;


    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = defaultPos;
        particles = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void PlayEffect(Vector3 location)
    {

        this.transform.position = location;
        particles.Play();
        //this.transform.position = defaultPos;
    }
}
