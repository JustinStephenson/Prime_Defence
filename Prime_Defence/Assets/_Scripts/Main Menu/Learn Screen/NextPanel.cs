using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPanel : MonoBehaviour {

    public GameObject nextPanel;

    public void NextPanelClick()
    {
        MenuSound.menuSound.activateClickButtonSound = true;
        transform.parent.gameObject.SetActive(false);
        nextPanel.SetActive(true);
    }   
}
