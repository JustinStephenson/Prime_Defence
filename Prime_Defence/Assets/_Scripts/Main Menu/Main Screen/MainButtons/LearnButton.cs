using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnButton : MonoBehaviour {

    public GameObject LearnCanvas;
    public static bool learnButton = false;

    public void LearnGame()
    {
        learnButton = true;
        MenuSound.menuSound.activateClickButtonSound = true;
        transform.parent.gameObject.SetActive(false);
        LearnCanvas.SetActive(true);
    }

}
