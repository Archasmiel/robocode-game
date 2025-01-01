using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jewelPrefab;

    private void Start() {
        InvokeRepeating(nameof(SpawnJewel), 0, 1);
    }

    void SpawnJewel() {
        Instantiate(jewelPrefab, transform.position, Quaternion.identity);
    }
}
