using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlockSquare : MonoBehaviour {

    public int destroySeconds;
    public float explosionSeconds;

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
            ComboFill.fillMe = true;
            SpecialBlockProperties();
            Destroy(other.gameObject);
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
        GetComponentInChildren<BoxCollider2D>().enabled = true;

        StartCoroutine(ExplosionAnimation());
        SPBlockSound = true;

        Invoke("DestroyAfter", destroySeconds);
    }

    IEnumerator ExplosionAnimation()
    {
        GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;
        yield return new WaitForSeconds(explosionSeconds);
        if (transform.childCount != 0)
        {
            GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
        }
    }

    void DestroyAfter()
    {
        Destroy(this.gameObject);
    }
}
