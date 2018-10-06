using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class ClickableTileTest : MonoBehaviour {
    /*1. buat grid system pake tile method (kaya di script mygridsystem)
      2. grid system tadi di buat dalam/digabungkan ke fungsi grid manual yg dibuat
      3. dalam gabungan tadi, grid tile method dtambah 0.5f  */
    Tilemap tilemap;
    [SerializeField] private float size = 1f;

    void Awake (){
        
    }
    void Start()
    {
        tilemap = transform.GetComponentInParent<Tilemap>();
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
        Vector3Int localPlace = Vector3Int.zero;
        Vector3 centerTile = tilemap.CellToWorld(localPlace);
        centerTile.x += 0.5f;
        centerTile.y += 0.5f;
        return centerTile;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < tilemap.cellBounds.xMax; x += size)
        {
            for (float y = 0; y < tilemap.cellBounds.yMax; y += size)
            {
                var point = GetTileCenterPosition(new Vector3(x, y, 0f));
                Gizmos.DrawSphere(point, 0.1f);
            }

        }
    }
}
