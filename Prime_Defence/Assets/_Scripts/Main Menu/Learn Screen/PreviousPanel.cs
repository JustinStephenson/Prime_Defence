using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousPanel : MonoBehaviour {

    public GameObject previousPanel;

    public void PreviousPanelClick()
    {
        MenuSound.menuSound.activateClickButtonSound = true;
        transform.parent.gameObject.SetActive(false);
        previousPanel.SetActive(true);
    }   
}
