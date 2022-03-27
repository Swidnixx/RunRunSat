using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    [SerializeField] Transform tile1;
    [SerializeField] Transform tile2;

    [SerializeField] GameObject[] tiles;

    private float tileWidth;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = tile1.GetComponent<BoxCollider2D>();
        tileWidth = boxCollider.bounds.size.x;
    }

    void FixedUpdate()
    {
        Vector2 moveStep = new Vector2(GameManager.instance.WorldSpeed, 0);
        tile1.position -= (Vector3)moveStep;
        tile2.position -= (Vector3)moveStep;

        if(tile2.position.x <= 0)
        {
            var tile = tiles[Random.Range(0, tiles.Length)];
            Vector3 position = tile2.position + Vector3.right * tileWidth;

            Destroy(tile1.gameObject);

            tile1 = tile2;
            tile2 = Instantiate(tile, position, Quaternion.identity).transform;
        }
    }
}
