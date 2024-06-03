using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_IrPara : MonoBehaviour
{
    public string nomescene;
    public void IrParaScene()
    {
        SceneManager.LoadScene(nomescene);
    }

}
