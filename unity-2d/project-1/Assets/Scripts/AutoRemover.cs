using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRemover : MonoBehaviour
{
    [SerializeField] float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
