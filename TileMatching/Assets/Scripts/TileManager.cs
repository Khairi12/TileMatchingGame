using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour {

    public static TileManager tm;
    public int tileCount;

    private GameObject tilePrefab;
    private List<GameObject> tiles = new List<GameObject>();

    private void Awake() {
        tm = this;
    }

    private void Start() {
        tilePrefab = Resources.Load("Prefabs/Tile") as GameObject;

        CreateTiles();
        AssignTileNeighbors();
    }

    public void CreateTiles() {
        for (int i = 0; i < tileCount; i += 2) {
            CreateTile(i);
            CreateTile(i+1);
        }
    }

    public void CreateTile(int i) {
        GameObject tile = Instantiate(tilePrefab, transform);
        tile.transform.GetChild(1).GetComponent<Image>().sprite = SpriteUtils.GetRandomSprite();
        tiles.Add(tile);
    }

    public void AssignTileNeighbors() {
        //
    }
    
}
