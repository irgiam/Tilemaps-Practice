using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleControl : MonoBehaviour
{
    Toggle thisToggle;
    public ButtonArrayTest thisButton;

    private void Awake()
    {
        thisToggle = GetComponent<Toggle>();
    }

    public void ToggleChange(bool toggleValue)
    {
        int k = 0;
        for (int i=0; i<thisButton.nameTests.Count; i++)
        {
            if (thisButton.nameTests[i].isOn == true)
            {
                k += 1;
            }
        }
        if (k > 2)
        {
            ToggleOff(thisToggle);
        }
    }

    void ToggleOff(Toggle thisToggle)
    {
        thisToggle.isOn = false;
    }
}
