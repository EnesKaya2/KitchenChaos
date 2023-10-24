using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateComplateVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject kitchenObject;
    }

    [SerializeField] PlateKitchenObject plateKitchenObject;
    [SerializeField] List<KitchenObjectSO_GameObject> kitchenObjectSO_GameObjectsList;

    void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
        foreach(KitchenObjectSO_GameObject kitchenObjectSO_GameObject in kitchenObjectSO_GameObjectsList)
        {
            kitchenObjectSO_GameObject.kitchenObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (KitchenObjectSO_GameObject kitchenObjectSO_GameObject in kitchenObjectSO_GameObjectsList)
        {
            if (kitchenObjectSO_GameObject.kitchenObjectSO==e.kitchenObjectSO)
            {
                kitchenObjectSO_GameObject.kitchenObject.SetActive(true);
            }
        }
    }
}
