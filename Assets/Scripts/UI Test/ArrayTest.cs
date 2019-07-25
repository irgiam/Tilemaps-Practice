using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NameTest
{
    Joko,
    Joni,
    Bambang,
    Hendra
}
public class ArrayTest : MonoBehaviour
{
    public void AddName (NameTest addName, NameTest addName2, NameTest[] test)
    {
        test = new NameTest[2] { addName, addName2 };
    }
}
