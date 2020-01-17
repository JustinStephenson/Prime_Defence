using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    private Scene currentScene;
    private string currentSceneName;

    //Score
    public int highScore;

    //Coins
    public int coin;
    public int COIN_MAX = 9999;

    //Skins
    public int skinSelected = 0;
    public bool[] skinUnlocked = new bool[18];
    public Sprite[] cannonBallSprites = new Sprite[18];

    //Audio
    public bool muted;

    //Ads
    public bool noAds;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
             Destroy(gameObject);
        }
    }

    void Start()
    {
        cannonBallSprites = Resources.LoadAll<Sprite>("CannonBallSkins");
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        Load();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        Save();
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;

    }

    void Update()
    {
        Debug.Log(currentSceneName);
        if (currentSceneName == "Main Menu" && Input.GetKeyDown(KeyCode.Escape))
        {
            if (LearnButton.learnButton)
            {
                FindObjectOfType<ExitPanels>().ExitPanelsClick();
            }
            else
            {
                Application.Quit();
            }
        }
        else if (currentSceneName == "Main" && Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<PausePlayGame>().PauseGame();
        }
        else if (currentSceneName == "Shop" && Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<BackFromShop>().BackToMainMenu();
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();

        data.highScore = highScore;
        data.coin = coin;
        data.skinSelected = skinSelected;
        data.skinUnlocked = skinUnlocked;
        data.muted = muted;
        data.noAds = noAds;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);

            highScore = data.highScore;
            coin = data.coin;
            skinSelected = data.skinSelected;
            skinUnlocked = data.skinUnlocked;
            muted = data.muted;
            noAds = data.noAds;
        }
    }
}

[Serializable]
class PlayerData
{
    public int highScore;
    public int coin;
    public int skinSelected;
    public bool[] skinUnlocked;
    public bool muted;
    public bool noAds;
}

