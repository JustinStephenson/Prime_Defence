using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackFromShop : MonoBehaviour {
    
    public void BackToMainMenu()
    {
        MenuSound.menuSound.activateClickButtonSound = true;
        SceneManager.LoadScene("Main Menu");
    }
}
