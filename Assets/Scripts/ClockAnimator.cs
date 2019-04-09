using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour
{
    private const float
       hoursToDegrees = 360f / 60f,
       minutesToDegrees = 360f / 60f;

    public Transform hours, minutes;
    public bool analog;

    void Update()
    {
        if (analog)
        {
            TimeSpan timespan = DateTime.Now.TimeOfDay;
            hours.localRotation =
                Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -hoursToDegrees);
            minutes.localRotation =
                Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -minutesToDegrees);
        }
        else
        {
            DateTime time = DateTime.Now;
            hours.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, time.Second * -minutesToDegrees);
        }
    }
}
