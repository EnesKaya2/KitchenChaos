using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] CuttingCounter cuttingCounter;
    [SerializeField] Image barImage;
    // Start is called before the first frame update
    void Start()
    {
        cuttingCounter.OnProgressChange += CuttingCounter_OnProgressChange;
        barImage.fillAmount = 0f;
        Hide();
    }

    private void CuttingCounter_OnProgressChange(object sender, CuttingCounter.OnProgressChangeEventArgs e)
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
