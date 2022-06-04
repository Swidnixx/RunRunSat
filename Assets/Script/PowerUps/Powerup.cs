using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    [HideInInspector]
    public bool isActive;
    public float duration = 1;

    public int level = 1;
    public int upgradeCost = 100;
}
