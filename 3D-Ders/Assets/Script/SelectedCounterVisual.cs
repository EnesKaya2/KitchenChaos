using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject selectedGameObject;


    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.OnSelectedCounterChange += Instance_OnSelectedCounterChange;
    }

    private void Instance_OnSelectedCounterChange(object sender, Player.OnSelectedCounterChangeEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
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
        selectedGameObject.SetActive(true);
    }

    private void Hide()
    {
        selectedGameObject.SetActive(false);
    }
}
