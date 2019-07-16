using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MyCustomClock : MonoBehaviour
{
    public double totalGameSeconds;

    public double seconds;
    public double minutes;
    public double hours;
    public double days;
    public double months;
    public double years;

    private double secondsPerSecond;

    public Transform analogHours, analogMinutes;
    public Text digitalClock;
    void Start()
    {
        //secondsPerSecond = 1;
        //totalGameSeconds += secondsPerSecond * Time.deltaTime;
    }

    void Update()
    {
        secondsPerSecond = 3600;

        //totalGameSeconds += secondsPerSecond * Time.deltaTime;

        //seconds = totalGameSeconds;
        minutes += secondsPerSecond * Time.deltaTime / 60;
        hours = minutes / 60;
        days = hours / 24;
        months = days / 2;
        years = months / 12;

        analogHours.localRotation = Quaternion.Euler(0f, 0f, ((float)-hours % 24) * 30);
        analogMinutes.localRotation = Quaternion.Euler(0f, 0f, ((float)-minutes % 60) * 6);

        string digitalHour = LeadingZero((int)hours % 24);
        string digitalMinute = LeadingZero((int)minutes % 60);
        digitalClock.text = digitalHour + ":" + digitalMinute;
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0'); //buat nambahin 0 disebelah kiri, klo angka nya 1 digit -> 6 jd 06
    }

}
