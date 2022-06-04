using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PowerupManager powerupManager;
    public Text batteryInfoText;
    public Button batteryButton;
    public Text magnetInfoText;
    public Button magnetButton;

    public Text coinsText;
    int coins;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = coins.ToString();
        DisplayBatteryInfo();
        DisplayMagnetInfo();
    }

    void DisplayMagnetInfo()
    {
        string info = "Lvl " + powerupManager.magnet.level + "\n";

        if (powerupManager.magnet.upgraded != null)
        {
            info += "$" + powerupManager.magnet.upgradeCost + " to upgrade";
        }
        else
        {
            info += "Max level!";
            magnetButton.interactable = false;
        }


        magnetInfoText.text = info;
    }

    public void UpgradeMagnet()
    {
        if (coins >= powerupManager.magnet.upgradeCost)
        {
            coins -= powerupManager.magnet.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();
            powerupManager.magnet = powerupManager.magnet.upgraded;
            DisplayMagnetInfo();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    void DisplayBatteryInfo()
    {
        string info = "Lvl " + powerupManager.battery.level + "\n";

        if(powerupManager.battery.upgraded != null)
        {
            info += "$" + powerupManager.battery.upgradeCost + " to upgrade";
        }
        else
        {
            info += "Max level!";
            batteryButton.interactable = false;
        }
  

        batteryInfoText.text = info;
    }

    public void UpgradeButtery()
    {
        if( coins >= powerupManager.battery.upgradeCost )
        {
            coins -= powerupManager.battery.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();
            powerupManager.battery = powerupManager.battery.upgraded;
            DisplayBatteryInfo();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
