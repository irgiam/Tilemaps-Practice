using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CustomClock : MonoBehaviour
{
    public double totalGameSeconds;
    public Text time;

    public double seconds;
    public double minutes;
    public double hours;
    public double days;
    public double months;
    public double years;

    private double secondsPerSecond;

    private const float
       hoursToDegrees = 360f / 12f,
       minutesToDegrees = 360f / 60f;

    public Transform hoursClock, minutesClock;

    void Start()
    {
        secondsPerSecond = 3600;
        totalGameSeconds += secondsPerSecond * Time.deltaTime;
    }


    void Update()
    {
        TimeSpan timespan = DateTime.Now.TimeOfDay;
        hoursClock.localRotation =
            Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -hoursToDegrees);
        minutesClock.localRotation =
            Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -minutesToDegrees);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            secondsPerSecond = 3600;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            secondsPerSecond = 86400*1000;
        }
        totalGameSeconds += secondsPerSecond * Time.deltaTime;

        seconds = totalGameSeconds;
        minutes = totalGameSeconds / 60;
        hours = minutes / 60;
        days = hours / 24;
        months = days / (365 / 12);
        years = months / 12;

        time.text = (days + months + years).ToString();
    }
}
