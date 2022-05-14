using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CoinController : MonoBehaviour
{
    bool alreadyPulled;

    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = GameManager.instance.magnet.range;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(GameManager.instance.magnet.isActive && collision.CompareTag("Player") && !alreadyPulled)
        {
            StartCoroutine(MagnetPull(collision.transform));
            alreadyPulled = true; 
        }
    }

    private IEnumerator MagnetPull(Transform magnetPosition)
    {
        while(Vector3.Distance(transform.position, magnetPosition.position) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, magnetPosition.position, 
                Time.deltaTime * GameManager.instance.magnet.coinSpeed );
            yield return null;
        }
    }
}
