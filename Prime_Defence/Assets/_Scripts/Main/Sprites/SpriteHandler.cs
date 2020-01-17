using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour {

    [System.Serializable]
    public class CandyList
    {
        public Sprite[] candy;
    }

    public CandyList[] candyList;
}