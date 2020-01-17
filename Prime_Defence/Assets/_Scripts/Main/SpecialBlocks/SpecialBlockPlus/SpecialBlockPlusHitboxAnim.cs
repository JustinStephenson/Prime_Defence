using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlockPlusHitboxAnim : MonoBehaviour {

    public float xDir;
    public float yDir;

    private SpecialBlockPlus parent;

    private Rigidbody2D myRb;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        parent = GetComponentInParent<SpecialBlockPlus>();

        myRb.velocity = new Vector3(xDir, yDir, 0.0f);
        myRb.velocity = myRb.velocity * parent.childSpeed;
    }
}
