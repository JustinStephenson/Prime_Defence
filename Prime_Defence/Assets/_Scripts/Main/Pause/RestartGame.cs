using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

    public void RestartThisGame()
    {
        //UpdateScore updateScore = (UpdateScore)FindObjectOfType(typeof(UpdateScore));
        if (GameControl.control.highScore < UpdateScore.updateScore)
            {
                GameControl.control.highScore = UpdateScore.updateScore;
                GooglePlay.AddScoreToLeaderboard(GPGSIds.leaderboard_high_score, UpdateScore.updateScore);
            }
        Time.timeScale = 1;
        MenuSound.menuSound.activateClickButtonSound = true;
        SceneManager.LoadScene("Main");
    }
}
