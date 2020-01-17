using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHandler : MonoBehaviour {

    public CannonHandler colorMatch;

    public Color[] ammoColors = new Color[8];

    public bool[] chosenColor = new bool[3];

	void Awake()
    {
        for (int i = 0; i < chosenColor.Length; i++)
        {
            chosenColor[i] = false;
        }
        //If no color is selected, the color starts as white
        chosenColor[0] = true;
	}

    void Update()
    {
        if (chosenColor[1] && chosenColor[2] && chosenColor[3])
        {
            colorMatch.ammoColor = ammoColors[7];
        }
        else if (chosenColor[1] && chosenColor[2])
        {
            colorMatch.ammoColor = ammoColors[4];
        }
        else if (chosenColor[2] && chosenColor[3])
        {
            colorMatch.ammoColor = ammoColors[5];
        }
        else if (chosenColor[1] && chosenColor[3])
        {
            colorMatch.ammoColor = ammoColors[6];
        }
        else if (chosenColor[1])
        {
            colorMatch.ammoColor = ammoColors[1];
        }
        else if (chosenColor[2])
        {
            colorMatch.ammoColor = ammoColors[2];
        }
        else if (chosenColor[3])
        {
            colorMatch.ammoColor = ammoColors[3];
        }
        else
        {
            colorMatch.ammoColor = ammoColors[0];
        }
    }
}
