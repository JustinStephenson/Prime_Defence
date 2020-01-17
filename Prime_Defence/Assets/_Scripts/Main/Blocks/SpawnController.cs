using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject block;
    public GameObject specialBlockPlus;
    public GameObject specialBlockSquare;
    public GameObject specialBlockCane;
    public GameObject specialBlockUltra;
    public GameObject coin;
    [System.NonSerialized]
    public List <GameObject> newBlock = new List<GameObject>();
    public Transform[] blockPos;

    //handles spawns
    public int spawnAmount;
    public bool waveSpawned;

    //handles spawns of dif blocks
    private int randomSpecialBlockPlus;
    public int percentSpawnChancePlus;

    private int randomSpecialBlockSquare;
    public int percentSpawnChanceSquare;

    private int randomSpecialBlockCane;
    public int percentSpawnChanceCane;

    private int randomSpecialBlockUltra;
    public int percentSpawnChanceUltra;

    private int randomCoin;
    public int percentSpawnCoin;

    //handles coins related spawning
    public int coinScoreSpawnLimit;

    //private float moveDownPos;

    public Transform lostPos;

    List<int> usedVlaues = new List<int>();

    void Awake()
    {

    }

	void Start()
    {
        SpawnBlock();
	}

	void Update()
    {
        if (BlockTigger.triggered)
        {
            SpawnBlock();
            waveSpawned = true;
            BlockTigger.triggered = false;
        }
}

    //Spawns block in one of the random 7 spots.
    private void SpawnBlock()
    {
        int specialBlockSpawned = 0;
        int coinSpawned = 0;
        randomSpecialBlockPlus = Random.Range(0, percentSpawnChancePlus);
        randomSpecialBlockSquare = Random.Range(0, percentSpawnChanceSquare);
        randomSpecialBlockCane = Random.Range(0, percentSpawnChanceSquare);
        randomSpecialBlockUltra = Random.Range(0, percentSpawnChanceUltra);
        randomCoin = Random.Range(0, percentSpawnCoin);

        if (randomSpecialBlockPlus == 0 && specialBlockSpawned < spawnAmount)
        {
            int spawnPos = UniqueRandomInt(0, 7);
            GameObject thisObject = Instantiate(specialBlockPlus, blockPos[spawnPos].position, blockPos[spawnPos].rotation) as GameObject;
            newBlock.Add(thisObject);
            specialBlockSpawned++;
        }

        if (randomSpecialBlockSquare == 0 && specialBlockSpawned < spawnAmount)
        {
            int spawnPos = UniqueRandomInt(0, 7);
            GameObject thisObject = Instantiate(specialBlockSquare, blockPos[spawnPos].position, blockPos[spawnPos].rotation) as GameObject;
            newBlock.Add(thisObject);
            specialBlockSpawned++;
        }

        if (randomSpecialBlockCane == 0 && specialBlockSpawned < spawnAmount)
        {
            int spawnPos = UniqueRandomInt(0, 7);
            GameObject thisObject = Instantiate(specialBlockCane, blockPos[spawnPos].position, blockPos[spawnPos].rotation) as GameObject;
            newBlock.Add(thisObject);
            specialBlockSpawned++;
        }

        if (randomSpecialBlockUltra == 0 && specialBlockSpawned < spawnAmount)
        {
            int spawnPos = UniqueRandomInt(0, 7);
            GameObject thisObject = Instantiate(specialBlockUltra, blockPos[spawnPos].position, blockPos[spawnPos].rotation) as GameObject;
            newBlock.Add(thisObject);
            specialBlockSpawned++;
        }

        if (UpdateScore.updateScore >= coinScoreSpawnLimit && (coinSpawned + specialBlockSpawned) < spawnAmount)
        {
            Debug.Log("SPAWN COIN");
            int spawnPos = UniqueRandomInt(0, 7);
            GameObject thisObject = Instantiate(coin, blockPos[spawnPos].position, blockPos[spawnPos].rotation) as GameObject;
            newBlock.Add(thisObject);
            coinSpawned++;
            coinScoreSpawnLimit *= 2;
        }
        else if (randomCoin == 0 && (coinSpawned + specialBlockSpawned) < spawnAmount)
        {
            int spawnPos = UniqueRandomInt(0, 7);
            GameObject thisObject = Instantiate(coin, blockPos[spawnPos].position, blockPos[spawnPos].rotation) as GameObject;
            newBlock.Add(thisObject);
            coinSpawned++;
        }

        for (int i = 0; i < spawnAmount - specialBlockSpawned - coinSpawned; i++)
        {   
            int spawnPos = UniqueRandomInt(0, 7);
            GameObject thisObject = Instantiate(block, blockPos[spawnPos].position, blockPos[spawnPos].rotation) as GameObject;
            newBlock.Add(thisObject);
        }
        usedVlaues.Clear();
    }

    //Finds a Random Number and checks it against a List so that the same number wont show up twice.
    private int UniqueRandomInt(int min, int max)
    {
        int val = Random.Range(min, max);
        while (usedVlaues.Contains(val))
        {
            val = Random.Range(min, max);
        }
        usedVlaues.Add(val);
        return val;
    }
}
