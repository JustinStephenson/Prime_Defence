using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockExplosionSound : MonoBehaviour {

    private AudioSource myAudio;

	void Start () 
    {
        myAudio = GetComponent<AudioSource>();	
	}

    void Update()
    {
        if (BlockHandler.playBlockSound)
        {
            myAudio.Play();
            BlockHandler.playBlockSound = false;
        }
    }
}
