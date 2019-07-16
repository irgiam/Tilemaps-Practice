using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DigitalClock : MonoBehaviour
{
    public Text textClock;
    void Awake()
    {
        //textClock = GetComponent<Text>();
    }
    void Update()
    {
        DateTime time = DateTime.Now;
        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);
        textClock.text = hour + ":" + minute + ":" + second;
    }
    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0'); //buat nambahin 0 disebelah kiri, klo angka nya 1 digit -> 6 jd 06
    }
}
