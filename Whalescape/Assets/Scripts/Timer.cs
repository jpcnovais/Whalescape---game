using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    public Image timerImage;
    public Image timerImage_background;

    private float currentTime;
    private float duration = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //disable the UI elements

        StopTimer();
    }

    public void StarterTime()
    {
        //set the current timer to power up duration
        currentTime = duration;
        //initiate de UI elements
        InitiateTimer();
        //start the count down

        StartCoroutine("UpdateTime");
    }

    IEnumerator UpdateTime()
    {  
        while (currentTime >=0)
        {
            //set the fill amount of the image based on the current time
            timerImage.fillAmount=Mathf.InverseLerp(0f, duration, currentTime);
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        //disable the UI elements
        StopTimer();
        yield return null;
    }

    public void InitiateTimer()
    {
        timerImage.enabled = true;
        timerImage_background.enabled = true;
    }
    public void StopTimer()
    {
        timerImage.enabled = false;
        timerImage_background.enabled = false;
    }

}
