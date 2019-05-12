using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CalendarTest : MonoBehaviour
{
    private DateTime _date = new DateTime(2000, 1, 1);
    public Text dateText;
    public float timeTest = 5;
    public float normalizeTest;

    private void FixedUpdate()
    {
        timeTest -= Time.deltaTime;
       if (timeTest <= 0)
        {
            _date = _date.AddMonths(1);
            timeTest = 5;
        }
    }

    private void Start()
    {
        normalizeTest = normalizeTest % 1;
        Debug.Log(normalizeTest);
    }

    void Awake()
    {
        dateText = this.GetComponent<Text>();
    }

    private void Update()
    {
        dateText.text = this.ToString();
    }

    public void AddDay()
    {
        _date = _date.AddDays(1);
    }

    public override string ToString()
    {
        // for formating see https://msdn.microsoft.com/de-de/library/zdtaw1bw(v=vs.110).aspx
        return _date.ToString("dd.MM.yyyy");
    }
}
