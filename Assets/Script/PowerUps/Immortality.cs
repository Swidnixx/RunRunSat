using UnityEngine;

[CreateAssetMenu]
public class Immortality : Powerup
{
    [Range(0.01f, 1f)]
    public float speedBoost = 0.1f;

    public Immortality upgraded;
}
