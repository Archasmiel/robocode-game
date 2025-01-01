using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

    private void Start() {
        InvokeRepeating(nameof(SpawnObstacle), 0, 1);
    }

    void SpawnObstacle() {
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
    }
}
