using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlockCane : MonoBehaviour {

    public int destroySeconds;
    public float fallingRotationSpeed;
    public float shotRotationSpeed;
    public float force;

    private bool isHit = false;

    private SpawnController sc;
    private Vector3 mySpriteRotation;
    private SpriteRenderer mySprite;

    private Rigidbody2D myRb;

    public static bool SPBlockSound;

    void Start()
    {
        sc = FindObjectOfType<SpawnController>();
        mySprite = GetComponentInChildren<SpriteRenderer>();
        mySpriteRotation = Vector3.zero;
        mySpriteRotation = new Vector3(transform.rotation.x, transform.rotation.y, fallingRotationSpeed);

        myRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mySprite.transform.Rotate(mySpriteRotation * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Shot"))
        {
            Destroy(other.gameObject);

            myRb.velocity = Vector3.zero;

            transform.gameObject.tag = "MovingCane";
            transform.gameObject.layer = 10;
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 10;
            }

            Vector3 dir = (Vector3)other.contacts[0].point - transform.position;
            dir = new Vector3(Mathf.Clamp(dir.x, -0.4f, 0.4f), -0.4f, 0.0f);
            dir = -dir.normalized;
            myRb.AddForce(dir * force);

            ComboFill.fillMe = true;
            SpecialBlockProperties();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SPChild") && !isHit && GetComponent<BlockImmune>().Immune == false)
        {
            myRb.velocity = Vector3.zero;
            
            transform.gameObject.tag = "MovingCane";
            transform.gameObject.layer = 10;
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 10;
            }

            Vector3 dir = new Vector3(Random.Range(-0.44f, 0.44f), -0.4f, 0.0f);
            dir = -dir.normalized;
            GetComponent<Rigidbody2D>().AddForce(dir * force);

            SpecialBlockProperties();
        }
    }

    void SpecialBlockProperties()
    {
        //UpdateScore.score++;
        //ComboFill.fillMe = true;
        sc.newBlock.Remove(this.gameObject);
        SPBlockSound = true;

        isHit = true;
        mySpriteRotation = new Vector3(transform.rotation.x, transform.rotation.y, shotRotationSpeed);
    }
}
