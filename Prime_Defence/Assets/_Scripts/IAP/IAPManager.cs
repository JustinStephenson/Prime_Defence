using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener {

    public static IAPManager Instance {get;set;}

    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    public static string PRODUCT_200_COIN = "coin200";
    public static string PRODUCT_500_COIN = "coin500";
    public static string PRODUCT_900_COIN = "coin900";
    public static string PRODUCT_NO_ADS = "noads";

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }
    
    public void InitializePurchasing()
    {
    // If we have already connected to Purchasing ...
    if (IsInitialized())
    {
        // ... we are done here.
        return;
    }
        
    // Create a builder, first passing in a suite of Unity provided stores.
    var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

    builder.AddProduct(PRODUCT_200_COIN, ProductType.Consumable);
    builder.AddProduct(PRODUCT_500_COIN, ProductType.Consumable);
    builder.AddProduct(PRODUCT_900_COIN, ProductType.Consumable);
    builder.AddProduct(PRODUCT_NO_ADS, ProductType.NonConsumable); 

    UnityPurchasing.Initialize(this, builder);
    }
    
    
    private bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }
    
    //Call these functions via buttons
    public void Buy200Coin()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(PRODUCT_200_COIN);
    }

    public void Buy500Coin()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(PRODUCT_500_COIN);
    }

    public void Buy900Coin()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(PRODUCT_900_COIN);
    }

    public void BuyNoAds()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(PRODUCT_NO_ADS);
    }

    private void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);
            
            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }
    
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");
        
        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }
    
    
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }
    

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
    {
        if (System.String.Equals(args.purchasedProduct.definition.id, PRODUCT_200_COIN, System.StringComparison.Ordinal))
        {
           Debug.Log("You bought 200 Coins");
           GameControl.control.coin += 200;
            GameControl.control.Save();
        }
        else if (System.String.Equals(args.purchasedProduct.definition.id, PRODUCT_500_COIN, System.StringComparison.Ordinal))
        {
            Debug.Log("You bought 500 Coins");
            GameControl.control.coin += 500;
            GameControl.control.Save();
        }
        else if (System.String.Equals(args.purchasedProduct.definition.id, PRODUCT_900_COIN, System.StringComparison.Ordinal))
        {
            Debug.Log("You bought 900 Coins");
            GameControl.control.coin += 900;
            GameControl.control.Save();
        }
        else if (System.String.Equals(args.purchasedProduct.definition.id, PRODUCT_NO_ADS, System.StringComparison.Ordinal))
        {
            Debug.Log("No Ads");
            GameControl.control.noAds = true;
            GameControl.control.Save();
        }
        // Or ... an unknown product has been purchased by this user. Fill in additional products here....
        else 
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        // Return a flag indicating whether this product has completely been received, or if the application needs 
        // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
        // saving purchased products to the cloud, and when that save is delayed. 
        return PurchaseProcessingResult.Complete;
    }
    
    
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
