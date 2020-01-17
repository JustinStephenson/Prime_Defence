using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAreaHandler : MonoBehaviour{

    public AmmoHandler ammo;
    public int myPlaceInArray;

    private SpriteRenderer mySpR;

    Image[] childImage;

    public bool disabled;

    void Start()
    {
        childImage = GetComponentsInChildren<Image>();
        childImage[1].enabled = false;
        disabled = false;
    }

    public void ChooseMe()
    {
        if (!disabled)
        {
            bool ImClicked = true;
            for (int i = 0; i < ammo.chosenColor.Length; i++)
            {
                if (ammo.chosenColor[i] == true && i == myPlaceInArray)
                {
                    ammo.chosenColor[i] = false;
                    childImage[1].enabled = false;
                    ImClicked = false;
                }
            }

            if (ImClicked)
            {
                ammo.chosenColor[myPlaceInArray] = true;
                childImage[1].enabled = true;
            }
        }
    }

}
