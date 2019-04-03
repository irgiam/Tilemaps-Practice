using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateName : MonoBehaviour
{
    public List<string> names;

    public string[] lines;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset nameText = Resources.Load<TextAsset>("SampleName");

        lines = nameText.text.Split("\n"[0]);

        Debug.Log(lines[Random.Range(0, lines.Length)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
