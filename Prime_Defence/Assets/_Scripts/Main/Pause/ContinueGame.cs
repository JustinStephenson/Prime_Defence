using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGame : MonoBehaviour {

    private float tempSpeed;

    public SpawnController sc;
    public LoadingAreaHandler[] lah;
    public ClickToFire clf;

    public GameObject PauseMenu;
    public PausePlayGame ppg;

    public void StartGame()
    {
        MenuSound.menuSound.activateClickButtonSound = true;
        Time.timeScale = 1;
        tempSpeed = ppg.tempSpeed;

        for (int i = 0; i < sc.newBlock.Count; i++)
        {
            sc.newBlock[i].GetComponent<MoveDown>().speed = tempSpeed;
        }

        for (int i = 0; i < 3; i++)
        {
            lah[i].disabled = false;
        }

        clf.paused = false;
        PauseMenu.SetActive(false);
    }
}
