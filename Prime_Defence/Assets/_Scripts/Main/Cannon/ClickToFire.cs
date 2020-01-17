using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToFire : MonoBehaviour {

    public static bool cannonFired = false;
    public static bool touchedFireScreen = false;

    [HideInInspector]
    public bool paused = false;

    public void CannonFireClick()
    {
        if (!paused)
        {
            touchedFireScreen = true;

            if (CannonHandler.ableToFire)
            {
                cannonFired = true;
                CannonHandler.ableToFire = false;
            }
        }
    }
}
