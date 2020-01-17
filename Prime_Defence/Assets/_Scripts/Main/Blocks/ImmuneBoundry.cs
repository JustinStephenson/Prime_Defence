using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneBoundry : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block") || other.CompareTag("SpecialBlock"))
        {
            other.GetComponent<BlockImmune>().Immune = false;
        }
    }
}
