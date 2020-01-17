using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneBoundryBottomDeath : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingCane"))
        {
            Destroy(other.gameObject);
        }
    }
}
