using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum NameTest
{
    Joko,
    Joni,
    Bambang,
    Hendra
}
public class ArrayTest : MonoBehaviour
{
    public ButtonArrayTest button;
    public List<ButtonArrayTest> buttons;
    public Transform contentPanel;
    public void AddName (NameTest addName, NameTest addName2, NameTest[] test)
    {
        test = new NameTest[2] { addName, addName2 };
    }

    public ButtonArrayTest GenerateButton()
    {
        ButtonArrayTest thisButton = button;
        thisButton = (ButtonArrayTest)GameObject.Instantiate(thisButton);
        thisButton.transform.SetParent(contentPanel, false);
        thisButton.gameObject.SetActive(true);
        return thisButton;
    }

    public void GetNameTest()
    {
        for (int i=0; i<buttons.Count; i++)
        {
            int k = 0;
            buttons[i].test = new List<NameTest>();
            for (int j=0; j<button.nameTests.Count; j++)
            {
                if (buttons[i].nameTests[j].isOn == true)
                {
                    buttons[i].test.Add((NameTest)j);
                    k+=1;
                }
                if (k > 1)
                    break;
            }
        }
    }

    private void Start()
    {
        for(int i=0; i<3; i++)
        {
            buttons.Add(GenerateButton());
        }
    }
}

