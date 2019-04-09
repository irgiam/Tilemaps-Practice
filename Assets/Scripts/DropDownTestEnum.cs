using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DropDownTestEnum : MonoBehaviour
{
    public enum nama{
        none,
        mahmud,
        ben,
        ten,
        sotoy
    }

    public Dropdown dropdown;
    public Text selectedName;

    public void DropdownIndexChanged(int index)
    {
        nama name = (nama)index;
        selectedName.text = name.ToString();
        if (index == 0)
        {
            selectedName.color = Color.red;
        }
        else
        {
            selectedName.color = Color.white;
        }
    }

    void Start()
    {
        Populasi();
    }

    void Populasi()
    {
        string[] enumNama = Enum.GetNames(typeof(nama));
        List<string> names = new List<string>(enumNama);
        dropdown.AddOptions(names);
    }
}
