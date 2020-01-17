using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public Sprite[] myNum = new Sprite[3];
    public GameObject[] myChildrenObjects = new GameObject[2];

    private Image counter;

    void Start()
    {
        counter = myChildrenObjects[0].GetComponent<Image>();
        myChildrenObjects[0].SetActive(true);
    }

	void Update()
    {
        if (Time.timeSinceLevelLoad <= 1)
        {
            counter.sprite = myNum[0];
            counter.color = new Color32(252, 31, 26, 255);
        }
        else if (Time.timeSinceLevelLoad <= 2)
        {
            counter.sprite = myNum[1];
            counter.color = new Color32(0, 98, 255, 255);
        }
        else if (Time.timeSinceLevelLoad <= 3)
        {
            counter.sprite = myNum[2];
            counter.color = new Color32(255, 210, 0, 255);
        }
        else if (Time.timeSinceLevelLoad <= 5)
        {
            counter.enabled = false;
            myChildrenObjects[1].SetActive(true);
            foreach (Image childImage in myChildrenObjects[1].GetComponentsInChildren<Image>())
            {
                childImage.color = new Color32(252, 31, 26, 255);
            }
        }
        else
        {
            myChildrenObjects[1].SetActive(false);
            return;
        }
	}
}
