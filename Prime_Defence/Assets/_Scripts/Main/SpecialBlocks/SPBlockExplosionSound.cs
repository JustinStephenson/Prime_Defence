using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPBlockExplosionSound : MonoBehaviour {

    private AudioSource myAudio;

    void Start () 
    {
        myAudio = GetComponent<AudioSource>();  
    }

    void Update()
    {
        if (SpecialBlockPlus.SPBlockSound || SpecialBlockSquare.SPBlockSound || SpecialBlockCane.SPBlockSound || SpecialBlockUltra.SPBlockSound)
        {
            myAudio.Play();
            SpecialBlockPlus.SPBlockSound = false;
            SpecialBlockSquare.SPBlockSound = false;
            SpecialBlockCane.SPBlockSound = false;
            SpecialBlockUltra.SPBlockSound = false;
        }
    }
}
