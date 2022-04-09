using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 1;

    private void Start()
    {
        speed = Random.Range(0.5f * speed, 1.5f * speed);
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, speed));
    }
}
