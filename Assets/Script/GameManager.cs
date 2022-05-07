using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Multiple gameManagers in the scene");
        }
    }

    // Game settings
    [SerializeField]private float worldScrollingSpeed = 0.2f;
    public float WorldSpeed { get { return worldScrollingSpeed; } }
    private float score;
    private int coins = 0;
    private int highScore;

    // UI
    [SerializeField] Text scoreText;
    [SerializeField] Text coinText;
    [SerializeField] GameObject resetButton;

    // Powerups
    public Immortality immortality;
    public Magnet magnet;

    void Start()
    {
        //PlayerPrefs.DeleteAll();

        coins = PlayerPrefs.GetInt("Coins", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        coinText.text = coins.ToString();

        SceneManager.sceneUnloaded += s => PlayerPrefs.SetInt("HighScore", highScore);

        immortality.isActive = false;
    }

    void FixedUpdate()
    {
        score += WorldSpeed;
        scoreText.text = score.ToString("0");

        if(score > highScore)
        {
            highScore = (int)score;
        }
    }

    private void OnApplicationQuit()
    {
       PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        resetButton.SetActive(true);
    }

    public void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CoinCollected()
    {
        coins++;
        PlayerPrefs.SetInt("Coins", coins);
        coinText.text = coins.ToString();
    }

    public void BatteryCollected()
    {
        if(immortality.isActive)
        {
            CancelBattery();
            CancelInvoke(nameof(CancelBattery));
        }

        immortality.isActive = true;
        worldScrollingSpeed += immortality.speedBoost;
        Invoke(nameof(CancelBattery), immortality.duration);
    }

    private void CancelBattery()
    {
        worldScrollingSpeed -= immortality.speedBoost;
        immortality.isActive = false;
    }

    public void MagnetCollected()
    {
        if(magnet.isActive)
        { 
            CancelInvoke(nameof(CancelMagnet));
        }
        magnet.isActive = true;
        Invoke(nameof(CancelMagnet), magnet.duration);
    }

    private void CancelMagnet()
    {
        magnet.isActive = false;
    }
}
