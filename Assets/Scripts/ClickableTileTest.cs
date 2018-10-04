using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class ClickableTileTest : MonoBehaviour {
    /*1. buat grid system pake tile method (kaya di script mygridsystem)
      2. grid system tadi di buat dalam/digabungkan ke fungsi grid manual yg dibuat
      3. dalam gabungan tadi, grid tile method dtambah 0.5f  */
    // Use this for initialization
    void Start()
    {
        GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        Vector3Int cellPosition = gridLayout.WorldToCell(transform.position);
        transform.position = gridLayout.CellToWorld(cellPosition);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
