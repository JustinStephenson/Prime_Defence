using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHandler : MonoBehaviour {

    private Rigidbody2D myRB;
    public Vector2 initialVelocity;
    public Color myColor;

    private int myCannonBallSkinNum;
    public int ROTATION_SPEED;

	void Start () {
		myRB = GetComponent<Rigidbody2D>();
        myRB.AddRelativeForce(initialVelocity);
        myColor = GetComponent<SpriteRenderer>().color;

        GetComponent<SpriteRenderer>().sprite = GameControl.control.cannonBallSprites[GameControl.control.skinSelected];
	}

    void Update()
    {
        transform.Rotate(Vector3.forward * ROTATION_SPEED);
    }
}
