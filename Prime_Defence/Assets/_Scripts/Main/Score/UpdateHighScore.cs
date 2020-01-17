using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHighScore : MonoBehaviour {

    private Image[] childImage;

    public Sprite[] nums;

    void Start()
    {
        childImage = GetComponentsInChildren<Image>();
        foreach (Image img in childImage)
        {
            if (img.CompareTag("NumPos"))
            {
                img.enabled = false;
            }
        }

        DisplayScore(GameControl.control.highScore);
    }


    void DisplayScore(int value)
    {
        childImage = GetComponentsInChildren<Image>();

        if (value <= 9)
        {
            int digit = value;

            childImage[0].enabled = true;
            childImage[0].sprite = nums[digit];
        }
        else if (value > 9 && value <= 99)
        {
            childImage[0].enabled = false;
            while (value > 0)
            {
                int digit = value % 10;

                if (value <= 9)
                {
                    childImage[1].enabled = true;
                    childImage[1].sprite = nums[digit];
                }

                if (value > 9 && value <= 99)
                {
                    childImage[2].enabled = true;
                    childImage[2].sprite = nums[digit];
                }

                value /= 10;
            }
        }
        else if (value > 99 && value <= 999)
        {
            childImage[1].enabled = false;
            childImage[2].enabled = false;
            while (value > 0)
            {
                int digit = value % 10;

                if (value <= 9)
                {
                    childImage[3].enabled = true;
                    childImage[3].sprite = nums[digit];
                }

                if (value > 9 && value <= 99)
                {
                    childImage[4].enabled = true;
                    childImage[4].sprite = nums[digit];
                }

                if (value > 99 && value <= 999)
                {
                    childImage[5].enabled = true;
                    childImage[5].sprite = nums[digit];
                }
         
                value /= 10;
            }
        }
        else if (value > 999 && value <= 9999)
        {
            childImage[3].enabled = false;
            childImage[4].enabled = false;
            childImage[5].enabled = false;
            while (value > 0)
            {
                int digit = value % 10;

                if (value <= 9)
                {
                    childImage[6].enabled = true;
                    childImage[6].sprite = nums[digit];
                }

                if (value > 9 && value <= 99)
                {
                    childImage[7].enabled = true;
                    childImage[7].sprite = nums[digit];
                }

                if (value > 99 && value <= 999)
                {
                    childImage[8].enabled = true;
                    childImage[8].sprite = nums[digit];
                }

                if (value > 999 && value <= 9999)
                {
                    childImage[9].enabled = true;
                    childImage[9].sprite = nums[digit];
                }
         
                value /= 10;
            }
        }
    }
}
