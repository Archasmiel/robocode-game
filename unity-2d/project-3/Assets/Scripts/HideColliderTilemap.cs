using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HideColliderTilemap : MonoBehaviour {
    void Start() {
        GetComponent<TilemapRenderer>().enabled = false;
    }
}
