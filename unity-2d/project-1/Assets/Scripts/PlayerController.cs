using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello Unity!");

        // завд1
        Debug.Log("Serhii");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }

        // завд2
        Debug.Log("Edward Elric");

        // завд3
        if (Input.GetMouseButtonDown(1)) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5f * 2, ForceMode2D.Impulse);
        }
    }
}
