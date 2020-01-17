using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreInc : MonoBehaviour {

	void OnDestroy () {
		UpdateScore.score++;
	}
}
