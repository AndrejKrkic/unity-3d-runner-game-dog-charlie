using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    private GroundSpawner groundSpawner;
    [SerializeField]
    private GameObject[] spawnPoints, obstacles;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        for (int i = 0; i < 3; i++)
        {
            Instantiate(obstacles[Random.Range(0, 3)], spawnPoints[i].transform.position, Quaternion.identity, transform.parent);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        groundSpawner.SpawnGround();
        Destroy(gameObject.transform.parent.gameObject, 2);
    }
}
