using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] StoveCounter stoveCounter;
    [SerializeField] GameObject stoveOnGameObject;
    [SerializeField] GameObject particalGameObject;

    // Start is called before the first frame update
    void Start()
    {
        stoveCounter.OnStateChange += StoveCounter_OnStateChange;
    }

    private void StoveCounter_OnStateChange(object sender, StoveCounter.OnStateChangeEventArgs e)
    {
        bool showVisual = e.state==StoveCounter.State.Fried || e.state==StoveCounter.State.Frying;
        stoveOnGameObject.SetActive(showVisual);
        particalGameObject.SetActive(showVisual);
    }
}
