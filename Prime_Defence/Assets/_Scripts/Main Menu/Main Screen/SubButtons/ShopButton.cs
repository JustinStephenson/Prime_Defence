using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour {

    public void GoToShop()
    {
        MenuSound.menuSound.activateClickButtonSound = true;
        if (!GameControl.control.noAds)
        {
            FindObjectOfType<BannerAdd>().bannerView.Destroy();
        }

        SceneManager.LoadScene("Shop");
    }
}
