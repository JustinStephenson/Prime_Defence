using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanels : MonoBehaviour {

    public GameObject UICanvas;

    public void ExitPanelsClick()
    {
        LearnButton.learnButton = false;
        MenuSound.menuSound.activateClickButtonSound = true;
        transform.parent.gameObject.SetActive(false);
        UICanvas.SetActive(true);
    }
}
