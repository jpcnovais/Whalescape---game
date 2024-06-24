using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image warningImage; // A imagem de aviso que será mostrada

    void Start()
    {
        if (warningImage != null)
        {
            warningImage.enabled = false; // Inicialmente invisível
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
            warningImage.enabled = true; // Torna a imagem visível
            yield return new WaitForSeconds(4); // Espera 4 segundos
            warningImage.enabled = false; // Torna a imagem invisível novamente
        }
    }
}
