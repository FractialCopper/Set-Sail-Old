using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCreator : MonoBehaviour {

    public Tilemap tilemap;
    public Sprite sprite;
    public Tile tile;
    private Vector3Int previous;
    private static int MAP_LENGTH = 34;
    private static int MAP_WIDTH = 10;

    // Use this for initialization
    void Start()
    {
      
        Vector3Int currentCell = tilemap.WorldToCell(transform.position);
        
        for (int i = 0; i < 34; i++)
        {
            currentCell.x +=1;
            for (int j = 0; j < 10; j++)
            {

                currentCell.y += 1;
                // set the new tile
                tilemap.SetTile(currentCell, tile);

            }
            currentCell.y -= MAP_WIDTH;
                // erase previous
                //tilemap.SetTile(previous, null);

                // save the new position for next frame
                //previous = new Vector3Int(currentCell.x,currentCell.y,currentCell.z);

            }
        }
    

	
	// Update is called once per frame
	void Update () {
		
	}
}
