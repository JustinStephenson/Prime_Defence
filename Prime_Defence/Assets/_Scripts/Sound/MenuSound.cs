using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour {

    private AudioSource myAudio;

    public static MenuSound menuSound;
    public bool activateClickButtonSound;

    void Awake()
    {
        if (menuSound == null)
        {
            DontDestroyOnLoad(gameObject);
            menuSound = this;
        }
        else if (menuSound != this)
        {
            Destroy(gameObject);
        }
    }

	void Start () 
    {
		myAudio = GetComponent<AudioSource>();
        activateClickButtonSound = false;
	}

	void Update()
    {
        if (activateClickButtonSound)
        {
            myAudio.Play();
            activateClickButtonSound = false;
        }
	}
}
