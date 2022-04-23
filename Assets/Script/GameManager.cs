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

    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        coinText.text = coins.ToString();
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
        PlayerPrefs.SetInt("HighScore", highScore);
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
}
