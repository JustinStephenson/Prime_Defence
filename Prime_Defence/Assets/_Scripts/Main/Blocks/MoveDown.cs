using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour {

    public float speed;

	void Update () 
    {
		transform.Translate(Vector3.down * (speed / 1000));
	}
}
