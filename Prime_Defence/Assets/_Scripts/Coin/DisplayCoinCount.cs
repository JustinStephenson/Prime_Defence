using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCoinCount : MonoBehaviour {

    private Image[] childImage;

    public Sprite[] nums = new Sprite[10];

    private int tempCoinCount;

    void Start()
    {
        DisplayCoin(GameControl.control.coin);
        tempCoinCount = GameControl.control.coin;
    }

    void Update()
    {
        if (GameControl.control.coin != tempCoinCount)
        {
            DisplayCoin(GameControl.control.coin);
            tempCoinCount = GameControl.control.coin;   
        }
    }

    public void DisplayCoin(int value)
    {
        if (value >= 0)
        {
            childImage = GetComponentsInChildren<Image>();
            int digit = 0;
            bool skip100 = false;
            bool skip10 = false;

            if (value > 999 && value <= 9999)
            {
                digit = (value / 1000) % 10;
                value -= (digit * 1000);
                childImage[3].enabled = true;
                childImage[3].sprite = nums[digit];

                if (value <= 9)
                {
                    childImage[2].enabled = true;
                    childImage[1].enabled = true;
                    childImage[2].sprite = nums[0];
                    childImage[1].sprite = nums[0];
                    skip100 = true;
                    skip10 = true;
                }
                else if (value <= 99)
                {
                    childImage[2].enabled = true;
                    childImage[2].sprite = nums[0];
                    skip100 = true;
                }
            }
            else
            {
                childImage[3].enabled = false;
            }

            if (value > 99 && value <= 999)
            {
                digit = (value / 100) % 10;
                value -= (digit * 100);
                childImage[2].enabled = true;
                childImage[2].sprite = nums[digit];

                if (value <= 9)
                {
                    childImage[1].enabled = true;
                    childImage[1].sprite = nums[0];
                    skip10 = true;
                }
            }
            else if (!skip100)
            {
                childImage[2].enabled = false;
            }

            if (value > 9 && value <= 99)
            {
                digit = (value / 10) % 10;
                value -= (digit * 10);
                childImage[1].enabled = true;
                childImage[1].sprite = nums[digit];
            }
            else if (!skip10)
            {
                childImage[1].enabled = false;
            }

            if (value <= 9)
            {
                digit = value;
                childImage[0].enabled = true;
                childImage[0].sprite = nums[digit];
            }
            else
            {
                childImage[0].sprite = nums[0];
            }
        }
    }
}
