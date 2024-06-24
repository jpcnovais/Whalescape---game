using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ajuda_Menu : MonoBehaviour
{

    [SerializeField] GameObject ajuda_menu;

    // Start is called before the first frame update
    void Start()
    {
        ajuda_menu.SetActive(false);
    }

    public void AjudaOpen()
    {
        ajuda_menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void AjudaClose()
    {
        ajuda_menu.SetActive(false);
        Time.timeScale = 1;
    }


    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
