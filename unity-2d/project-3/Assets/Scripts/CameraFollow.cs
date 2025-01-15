using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 startPos;
    public Transform target;
    private Vector3 targetPos;
    public float speed;

    private void Start() {
        startPos = transform.position;
    }

    private void Update() {
        if (target != null) {
            targetPos = new Vector3(target.position.x, target.position.y,
                transform.position.z);
            Vector3 velocity = (targetPos - transform.position) * speed;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, 
                ref velocity, 1.0f, Time.deltaTime);
        }
    }
}
