using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour {

    private AudioSource myAudio;

	void Start () 
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.Play();
	}
}
