using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossOnTouch : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block") || other.CompareTag("SpecialBlock"))
        {
            if (GameControl.control.highScore < UpdateScore.updateScore)
            {
                GameControl.control.highScore = UpdateScore.updateScore;
                GooglePlay.AddScoreToLeaderboard(GPGSIds.leaderboard_high_score, (long)UpdateScore.updateScore);

                if (GameControl.control.highScore >= 1000)
                {
                    GooglePlay.UnlockAchievement(GPGSIds.achievement_ultimate_prime_defender);
                }
            }
            GooglePlay.IncrementalAchievement(GPGSIds.achievement_prime_novice, 1);
            GooglePlay.IncrementalAchievement(GPGSIds.achievement_prime_intermediate, 1);
            GooglePlay.IncrementalAchievement(GPGSIds.achievement_prime_expert, 1);
            SceneManager.LoadScene("Main");
        }

        if (other.CompareTag("SPChild"))
        {
            Destroy(other.gameObject);
        }
    }
}