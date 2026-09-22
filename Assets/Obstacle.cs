using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    KeyboardHandling player;
    public GameObject obstacle;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<KeyboardHandling>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.y -= player.thrust * Time.deltaTime;

        transform.position = pos;

        if (player.spawnedObstacles >= player.maxSpawnRate)
        {
            Destroy(this);
        }

        Destroy(obstacle,10f);
    }
}
