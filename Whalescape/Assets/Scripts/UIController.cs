using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image warningImage;

    void Start()
    {
        if (warningImage != null)
        {
            warningImage.enabled = false;
        }
    }

    public void ShowWarning()
    {
        StartCoroutine(ShowWarningCoroutine());
    }

    private IEnumerator ShowWarningCoroutine()
    {
        if (warningImage != null)
        {
            warningImage.enabled = true;
            yield return new WaitForSeconds(4);
            warningImage.enabled = false;
        }
    }
}
