using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager instance { get; private set; }

    [SerializeField] private RecipeListSO recipeListSO;

    [SerializeField] private List<RecipeSO> waitingRecipeListSO;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f;
    private int waitingRecipeListMax = 4;

    private void Awake()
    {
        instance = this;
        waitingRecipeListSO = new List<RecipeSO>();
    }

    void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if (waitingRecipeListSO.Count < waitingRecipeListMax)
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[Random.Range(0, recipeListSO.recipeSOList.Count)];
                waitingRecipeListSO.Add(waitingRecipeSO);
            }
        }
    }

    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecipeListSO.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingRecipeListSO[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                bool plateContentsMatchesRecipe = true;

                foreach (KitchenObjectSO recipekitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    bool ingredientFound = false;

                    foreach (KitchenObjectSO platekitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        if (platekitchenObjectSO == recipekitchenObjectSO)
                        {
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound)
                    {
                        plateContentsMatchesRecipe = false;
                    }
                }

                if (plateContentsMatchesRecipe)
                {
                    Debug.Log("Doðru Malzeme Gönderildi");
                    
                    waitingRecipeListSO.RemoveAt(i);
                    return;
                }
            }
        }

        Debug.Log("Player Doðru Recipe Gönderdi");
    }
}
