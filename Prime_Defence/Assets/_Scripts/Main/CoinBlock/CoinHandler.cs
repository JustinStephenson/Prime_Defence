using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour {

    private SpawnController sc;

    public static bool coinExplosionSound;

    void Start()
    {
        sc = FindObjectOfType<SpawnController>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Shot"))
        {
            Destroy(other.gameObject);
            ComboFill.fillMe = true;
            CoinDeath();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SPChild") && GetComponent<BlockImmune>().Immune == false)
        {
            CoinDeath();
        }
    }

    void CoinDeath()
    {
        sc.newBlock.Remove(this.gameObject);
        GameControl.control.coin++;
        coinExplosionSound = true;
        Destroy(this.gameObject);
    }
}
