using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounterVisual : MonoBehaviour
{
    [SerializeField] private PlateCounter plateCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform platePrefabVisual;

    public List<GameObject> platesVisualGameObjectList;

    private void Awake()
    {
        platesVisualGameObjectList = new List<GameObject>();
        Debug.Log(platesVisualGameObjectList.Count);
    }
    // Start is called before the first frame update
    void Start()
    {
        plateCounter.OnPlateSpawned += PlateCounter_OnPlateSpawned;
        plateCounter.OnPlateRemoved += PlateCounter_OnPlateRemoved;
    }

    private void PlateCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {

        Transform plateVisualTransform = Instantiate(platePrefabVisual, counterTopPoint);

        float plateOfsetY = .1f;
        plateVisualTransform.localPosition = new Vector3(0,plateOfsetY*platesVisualGameObjectList.Count, 0);

        platesVisualGameObjectList.Add(plateVisualTransform.gameObject);
    }

    private void PlateCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateGameObject = platesVisualGameObjectList[platesVisualGameObjectList.Count - 1];
        platesVisualGameObjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }

}
