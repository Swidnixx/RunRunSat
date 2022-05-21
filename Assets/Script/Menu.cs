using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text coinsText;
    public Text highscoreText;

    int coins;
    int highscore;

    public GameObject menuPanel;
    public GameObject shopPanel;

    private void Start()
    {
        BackToMenu();

        coins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = coins.ToString();

        highscore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = highscore.ToString();
    }

    public void GoToShop()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SoundButton()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
