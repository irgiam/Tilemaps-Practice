using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownTest : MonoBehaviour
{
    List<string> names = new List<string>() { "Liz", "Barney", "Zayn", "Batu" };

    public Dropdown dropdown;
    public Text selectedName;
    
    
    public void DropdownIndexChanged(int index)
    {
        selectedName.text = names[index];
    }
    
    void Start()
    {
        Populasi();
    }

    void Populasi()
    {
        dropdown.AddOptions(names);
    }

    
}
