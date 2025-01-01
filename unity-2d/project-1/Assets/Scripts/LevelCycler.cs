using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCycler : MonoBehaviour
{
    [SerializeField] private float pathLength;
    Vector3 startPosition;

    private void Start() {
        startPosition = transform.position;
    }

    private void Update() {
        if (transform.position.x < startPosition.x - pathLength) {
            transform.position = startPosition;
        }
    }
}
