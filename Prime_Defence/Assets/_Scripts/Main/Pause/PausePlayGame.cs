using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayGame : MonoBehaviour {

    [HideInInspector]
    public float tempSpeed;

    public SpawnController sc;
    public LoadingAreaHandler[] lah;
    public ClickToFire clf;

    public GameObject PauseMenu;

    void Start()
    {
        tempSpeed = FindObjectOfType<MoveDown>().speed;
    }

    public void PauseGame()
    {
        MenuSound.menuSound.activateClickButtonSound = true;
        Time.timeScale = 0;
        //stops the blocks from moving and saves the speed in a variable.
        for (int i = 0; i < sc.newBlock.Count; i++)
        {
            sc.newBlock[i].GetComponent<MoveDown>().speed = 0;
        }

        //Disable ability to click colors and chnage cannon color.
        for (int i = 0; i < 3; i++)
        {
            lah[i].disabled = true;
        }

        clf.paused = true;
        PauseMenu.SetActive(true);
    }
}
