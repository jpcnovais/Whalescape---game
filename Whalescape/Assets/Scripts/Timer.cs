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


    void Start()
    {

        StopTimer();
    }

    public void StarterTime()
    {
        currentTime = duration;
        InitiateTimer();

        StartCoroutine("UpdateTime");
    }

    IEnumerator UpdateTime()
    {
        while (currentTime >=0)
        {
            timerImage.fillAmount=Mathf.InverseLerp(0f, duration, currentTime);
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
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
