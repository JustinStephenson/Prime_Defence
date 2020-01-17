using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTigger : MonoBehaviour {

    public static bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block") || other.CompareTag("SpecialBlock"))
        {
            triggered = true;
        }
    }
}
