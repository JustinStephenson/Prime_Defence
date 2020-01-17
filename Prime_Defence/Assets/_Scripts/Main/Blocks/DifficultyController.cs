using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour {

    private SpawnController sc;
    public GameObject[] blockPrefabs;

    private int candySpawnAmount;
    public int timeForIncreaseDifficulty;
    private int tempTime;
    private int difficultyTraker;
    private int candySpeedAmount;

    private bool firstDifficuiltyIncreased = false;

    void Awake()
    {
        sc = GetComponent<SpawnController>();
        sc.spawnAmount = 2;
        candySpeedAmount = 4;
        ChangeCandySpeed(candySpeedAmount);
        ChangeSpeicalCandySpawnRate(15, 40);
    }

	void Start()
    {
        tempTime = timeForIncreaseDifficulty;
        difficultyTraker = 1;
	}

	void Update()
    {
        if (Time.timeSinceLevelLoad >= timeForIncreaseDifficulty / 2 && !firstDifficuiltyIncreased)
        {
            IncreaseDifficulty();
            firstDifficuiltyIncreased = true;
        }

        if (Time.timeSinceLevelLoad >= timeForIncreaseDifficulty && difficultyTraker < 6)
        {
            IncreaseDifficulty();
            timeForIncreaseDifficulty += tempTime;
        }

        if (sc.waveSpawned)
        {
            switch (difficultyTraker)
            {
                case 1:
                    candySpawnAmount = 2;
                    break;
                case 2:
                    candySpawnAmount = Random.Range(2, 4);
                    break;
                case 3:
                    candySpawnAmount = 3;
                    break;
                case 4:
                    candySpawnAmount = 3;
                    break;
                case 5:
                    candySpawnAmount = Random.Range(3, 5);
                    break;
                case 6:
                    if (candySpawnAmount == 5)
                    {
                        candySpawnAmount = Random.Range(3, 5);
                    }
                    else
                    {
                        candySpawnAmount = Random.Range(3, 6);
                    }
                break;
        }
            sc.spawnAmount = candySpawnAmount;
            sc.waveSpawned = false;
        }
	}

    void IncreaseDifficulty()
    {
        Debug.Log("increase Difficulty");
        difficultyTraker++;

        switch (difficultyTraker)
        {
            case 2:
                candySpeedAmount = 4;
                break;
            case 3:
                candySpeedAmount = 5;
                break;
            case 4:
                candySpeedAmount = 5;
                ChangeSpeicalCandySpawnRate(13, 37);
                break;
            case 5:
                candySpeedAmount = 6;
                break;
            case 6:
                candySpeedAmount = 6;
                ChangeSpeicalCandySpawnRate(10, 35);
                break;
        }

        ChangeCandySpeed(candySpeedAmount);
        for (int i = 0; i < sc.newBlock.Count; i++)
        {
            sc.newBlock[i].GetComponent<MoveDown>().speed = candySpeedAmount;
        }
    }

    void ChangeCandySpeed(int candySpeed)
    {
        foreach (GameObject i in blockPrefabs)
        {
            i.GetComponent<MoveDown>().speed = candySpeed;
        }
    }

    void ChangeSpeicalCandySpawnRate(int smallCandyPercent, int ultraCandyPercent)
    {
        sc.percentSpawnChanceCane = smallCandyPercent;
        sc.percentSpawnChancePlus = smallCandyPercent;
        sc.percentSpawnChanceSquare = smallCandyPercent;
        sc.percentSpawnChanceUltra = ultraCandyPercent;
    }
}
