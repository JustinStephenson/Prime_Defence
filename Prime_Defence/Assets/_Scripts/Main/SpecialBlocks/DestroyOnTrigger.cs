using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            FindObjectOfType<SpawnController>().newBlock.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
