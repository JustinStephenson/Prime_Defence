using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour {

    public AudioMixer masterMixer;
    public Sprite soundOn;
    public Sprite soundOff;
    private Image[] myImage;
    private bool muted;

    void Start()
    {
        myImage = GetComponentsInChildren<Image>();
        muted = GameControl.control.muted;
        OnClickMusic();
    }

    public void OnClickMusic()
    {
        if (muted)
        {
            masterMixer.SetFloat("Master", -80.0f);
            myImage[1].sprite = soundOff;
            GameControl.control.muted = muted;
            muted = false;
        }
        else
        {
            masterMixer.SetFloat("Master", 0.0f);
            myImage[1].sprite = soundOn;
            GameControl.control.muted = muted;
            muted = true;
        }
    }
}
