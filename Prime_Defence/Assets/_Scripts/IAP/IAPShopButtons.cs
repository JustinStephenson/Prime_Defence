using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPShopButtons : MonoBehaviour {

    private IAPManager manager;

    void Start()
    {
        manager = GetComponent<IAPManager>();
    }

    public void Buy200Coin()
    {
        if (GameControl.control.coin <= GameControl.control.COIN_MAX - 200)
        {
            manager.Buy200Coin();
        }
        else
        {
            DenyBuy();
        }
    }

    public void Buy500Coin()
    {
        if (GameControl.control.coin <= GameControl.control.COIN_MAX - 500)
        {
            manager.Buy500Coin();
        }
        else
        {
            DenyBuy();
        }
    }

    public void Buy900Coin()
    {
        if (GameControl.control.coin <= GameControl.control.COIN_MAX - 900)
        {
            manager.Buy900Coin();
        }
        else
        {
            DenyBuy();
        }
    }

    public void DenyBuy()
    {
        Debug.Log("You have to many coins");
    }
}
