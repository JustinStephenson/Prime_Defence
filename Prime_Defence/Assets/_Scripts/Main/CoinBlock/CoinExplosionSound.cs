using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinExplosionSound : MonoBehaviour {

    private AudioSource myAudio;

    void Start () 
    {
        myAudio = GetComponent<AudioSource>();  
    }

    void Update()
    {
        if (CoinHandler.coinExplosionSound)
        {
            myAudio.Play();
            CoinHandler.coinExplosionSound = false;
        }
    }
}
