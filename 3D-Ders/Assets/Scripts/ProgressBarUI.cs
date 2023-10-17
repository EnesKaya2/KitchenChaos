using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    
    [SerializeField] GameObject hasProgressGameObje;
    [SerializeField] Image barImage;

    private IHasProgress hasProgress;
    // Start is called before the first frame update
    void Start()
    {
        hasProgress=hasProgressGameObje.GetComponent<IHasProgress>();
        if (hasProgress==null)
        {
            Debug.Log("Does Not have Componet");
        }
        hasProgress.OnProgressChange += HasProgress_OnProgressChange;
        barImage.fillAmount = 0f;
        Hide();
    }

    private void HasProgress_OnProgressChange(object sender, IHasProgress.OnProgressChangeEventArgs e)
    {

        barImage.fillAmount = e.progressNormalized;
        if (e.progressNormalized == 0 || e.progressNormalized == 1)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
