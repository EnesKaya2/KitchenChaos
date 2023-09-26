using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] BaseCounter baseCounter;
    [SerializeField] GameObject[] selectedGameobjects;
    void Start()
    {
        Player.Instance.OnSelectedCounterChange += Instance_OnSelectedCounterChange;
    }

    private void Instance_OnSelectedCounterChange(object sender, Player.OnSelectedCounterChangeEventArgs e)
    {
        if (e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach(GameObject selectedGameObject in selectedGameobjects)
        {
            selectedGameObject.SetActive(true);
        }
    }
    private void Hide()
    {
        foreach (GameObject selectedGameObject in selectedGameobjects)
        {
            selectedGameObject.SetActive(false);
        }
    }

}
