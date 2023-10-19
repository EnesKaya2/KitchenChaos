using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : BaseCounter

{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] KitchenObjectSO plateKitchenObject;

    private float spawnPlateTimer;
    [SerializeField] private float spawnPlateTimerMax;
    private int spawnedPlateAmount;
    [SerializeField] private int spawnedPlateAmountMax;

    // Update is called once per frame
    void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;
            if (spawnedPlateAmount<spawnedPlateAmountMax)
            {
                spawnedPlateAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);

            }
        
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            if (spawnedPlateAmount>0)
            {
                spawnedPlateAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObject, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
