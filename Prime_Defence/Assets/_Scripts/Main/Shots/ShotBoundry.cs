﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBoundry : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shot"))
        {
            Destroy(other.gameObject);
            ComboFill.missedShot = true;
        }
    }
}
