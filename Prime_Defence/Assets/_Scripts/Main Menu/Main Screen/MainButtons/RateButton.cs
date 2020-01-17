using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateButton : MonoBehaviour {

    private string ANDRIOD_RATE_URL;

    void Start()
    {
        ANDRIOD_RATE_URL = "market://details?id=com.JBoneStudios.primedefensecandyedition";
    }

    public void RateMyApp()
    {
        #if UNITY_ANDROID
        Application.OpenURL(ANDRIOD_RATE_URL);
        #endif
    }
}
