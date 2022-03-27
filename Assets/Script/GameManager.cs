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

    // UI
    [SerializeField] Text scoreText;
    [SerializeField] GameObject resetButton;

    void FixedUpdate()
    {
        score += WorldSpeed;
        scoreText.text = score.ToString("0");
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
}
