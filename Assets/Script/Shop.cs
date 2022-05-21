using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Immortality battery;
    public Text batteryInfoText;

    private void Start()
    {
        DisplayBatteryInfo();
    }

    void DisplayBatteryInfo()
    {
        string info = "Lvl " + battery.level + "\n";
        info += "$" + battery.upgradeCost + " to upgrade";

        batteryInfoText.text = info;
    }

    public void UpgradeButtery()
    {

    }
}
