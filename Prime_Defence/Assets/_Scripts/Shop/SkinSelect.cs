using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinSelect : MonoBehaviour, IPointerClickHandler {

    public int skinNumber;
    public int coinValue;

    public bool unlocked = false;

    private GameObject ButtonSelection;

    void Awake()
    {
        ButtonSelection = transform.parent.gameObject;
    }

	void Start()
    {
        if (skinNumber == GameControl.control.skinSelected)
        {
            RemoveHighlightFromAllSkins();
            HighlightMyskin();
        }

        if (GameControl.control.skinUnlocked[skinNumber] == true)
        {
            Unlocked();
        }
	}

    public void OnPointerClick(PointerEventData eventdata)
    {
        if (!unlocked)
        {
            if (GameControl.control.coin >= coinValue)
            {
                Unlocked();

                GooglePlay.UnlockAchievement(GPGSIds.achievement_new_cannonball);
                GooglePlay.IncrementalAchievement(GPGSIds.achievement_skin_to_win, 1);

                GameControl.control.skinUnlocked[skinNumber] = true;
                GameControl.control.coin -= coinValue;
            }
            else
            {
                Debug.Log("Not Enough Coins");
            }
        }
        else
        {
            RemoveHighlightFromAllSkins();
            HighlightMyskin();
            GameControl.control.skinSelected = this.skinNumber;
        }
    }

    void RemoveHighlightFromAllSkins()
    {
        Component[] buttons;
        buttons = ButtonSelection.GetComponentsInChildren<SkinSelect>();

        foreach (SkinSelect i in buttons)
        {
            if (i.unlocked)
            {
                i.transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    void HighlightMyskin()
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    void Unlocked()
    {
        unlocked = true;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
