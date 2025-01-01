using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMover : MonoBehaviour
{
    [SerializeField] private float speed;

    private void FixedUpdate() {
        transform.Translate(Vector3.left * speed);
    }
}
