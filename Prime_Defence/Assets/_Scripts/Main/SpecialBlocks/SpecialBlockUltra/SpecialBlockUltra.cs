using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlockUltra : MonoBehaviour {

    public int destroySeconds;

    private SpawnController sc;

    public static bool SPBlockSound;

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
            SpecialBlockProperties();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SPChild") && GetComponent<BlockImmune>().Immune == false)
        {
            SpecialBlockProperties();
        }
    }

    void SpecialBlockProperties()
    {
        //UpdateScore.score++;
        //ComboFill.fillMe = true;
        sc.newBlock.Remove(this.gameObject);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        UltraTrigger.ultraBool = true;
        SPBlockSound = true;

        Invoke("DestroyAfter", destroySeconds);
    }

    void DestroyAfter()
    {
        Destroy(this.gameObject);
    }
}
