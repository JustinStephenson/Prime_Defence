using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraTrigger : MonoBehaviour {

    public static bool ultraBool = false;

    private BoxCollider2D myCollider;
    private SpriteRenderer mySpriteRend;

    public float spriteDisplayTime = 0.0f;

    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        mySpriteRend = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (ultraBool)
        {
            myCollider.enabled = true;
            mySpriteRend.enabled = true;
            Invoke("ColliderStop", spriteDisplayTime);
        }
    }

    void ColliderStop()
    {
        myCollider.enabled = false;
        mySpriteRend.enabled = false;
        ultraBool = false;
    }
}
