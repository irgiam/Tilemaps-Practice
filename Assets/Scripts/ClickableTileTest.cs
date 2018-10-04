using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class ClickableTileTest : MonoBehaviour {
    /*1. buat grid system pake tile method (kaya di script mygridsystem)
      2. grid system tadi di buat dalam/digabungkan ke fungsi grid manual yg dibuat
      3. dalam gabungan tadi, grid tile method dtambah 0.5f  */
    Tilemap tileMap = null;

    void Awake (){
        tileMap = transform.GetComponentInParent<Tilemap>();
    }
    void Start()
    {
        /*
        GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        Vector3Int cellPosition = gridLayout.WorldToCell(transform.position);
        transform.position = gridLayout.CellToWorld(cellPosition);
        */
    }

    // Update is called once per frame
    void Update () {
		
	}

    public Vector3 GetTileCenterPosition(Vector3 position){
        Vector3Int localPlace;
        Vector3 centerTile = tileMap.CellToWorld(localPlace);
        //blom ditambahin 0.5
        return centerTile;
    }
}
