using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMyColor : MonoBehaviour {

    public Color[] myColor;
    private Image myImage;
    private Sprite tempSprite;
    private int incColor = 0;

    void Start()
    {
        myImage = GetComponent<Image>();
        tempSprite = myImage.sprite;
    }

	void Update()
    {
        if (myImage.sprite != tempSprite)
        {
            myImage.color = myColor[incColor];
            incColor++;
            if (incColor >= 2)
            {
                incColor = 0;
            }
            tempSprite = myImage.sprite;
        }
	}
}
