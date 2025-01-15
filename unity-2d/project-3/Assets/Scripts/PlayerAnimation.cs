using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public static readonly string[] staticDirections = {
        "Static N", "Static NW", "Static W", "Static SW",
        "Static S", "Static SE", "Static E", "Static NE" };

    public static readonly string[] runDirections = { 
        "Run N", "Run NW", "Run W", "Run SW", 
        "Run S", "Run SE", "Run E", "Run NE" };
    
    Animator animator;
    int lastDirection;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction) {
        string[] directionArray = null;
        if (direction.magnitude < 0.01) {
            directionArray = staticDirections;
        }
        else {
            directionArray = runDirections;
        }
        lastDirection = DirectionToIndex(direction);
        animator.Play(directionArray[lastDirection]);
    }

    private int DirectionToIndex(Vector2 direction) {
        Vector2 normDir = direction.normalized;
        float step = 360.0f / 8;
        float offset = step / 2;

        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        angle += offset;
        if (angle < 0) {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }


}
