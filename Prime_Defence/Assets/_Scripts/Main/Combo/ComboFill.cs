using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboFill : MonoBehaviour {

    public static bool fillMe = false;
    public static bool missedShot = false;

    public float fillAmount;
    public float lerpSpeed;

    public int myComobeState;

    public Image filler;
    public Image comboNum;
    public Sprite[] nums;

	void Start () 
    {
        fillAmount = 0;
        myComobeState = 1;
        comboNum.sprite = nums[0];
	}

	void Update()
    {
        if (fillMe)
        {
            fillMe = false;
            switch (myComobeState)
            {
                case 1:
                    fillAmount += 0.20f;
                    break;
                case 2:
                    fillAmount += 0.10f;
                    break;
                case 3:
                    fillAmount += 0.05f;
                    break;
                case 4:
                    fillAmount += 0.025f;
                    break;
            }
        }
        else if (missedShot)
        {
            myComobeState = 1;
            fillAmount = 0;
            comboNum.sprite = nums[0];
            missedShot = false;
        }

        if (fillAmount >= 1)
        {
            myComobeState ++;
            comboNum.sprite = nums[myComobeState - 1];
            fillAmount = 0;
        }

        if (fillAmount != filler.fillAmount)
        {
            filler.fillAmount = Mathf.Lerp(filler.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
	}
}
