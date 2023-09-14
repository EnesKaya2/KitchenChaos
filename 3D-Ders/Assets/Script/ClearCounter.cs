using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    [SerializeField] Transform counterTopPoint;

    [SerializeField] KitchenObject kitchenObject;

    [SerializeField] ClearCounter secondClearCounter;
    [SerializeField] bool testing;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T ) && kitchenObject != null)
        {
            kitchenObject.SetClearCounter(secondClearCounter);
            Debug.Log(kitchenObject.GetClearCounter());
        }
    }
    public void Interact()
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.preFab, counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;

            Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObject().objectName);
            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.SetClearCounter(this);
        }
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
        }
    }
    
    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }
}
