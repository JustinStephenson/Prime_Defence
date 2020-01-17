using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour {

    public void MainMenu()
    {
        MenuSound.menuSound.activateClickButtonSound = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
