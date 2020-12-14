using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text CounterForTime;

    private TimeSpan PlayingTime;

    private float TimeElapsed;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CounterForTime.text = "Time!!! 00:00.00";
    }


    private void Update()
    {
        TimeElapsed += Time.deltaTime;

        PlayingTime = TimeSpan.FromSeconds(TimeElapsed);

        string PlayingTimeStr = "Time!!! " + PlayingTime.ToString("mm':'ss'.'ff");

        CounterForTime.text = PlayingTimeStr;


    }


}
