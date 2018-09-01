using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public static TileManager tileManager;
    public int tileCount;

    private GameObject tilePrefab;
    private List<GameObject> tiles = new List<GameObject>();
    private List<GameObject> flippedTiles = new List<GameObject>();

    private void Awake() {
        tileManager = this;
    }

    private void Start() {
        tilePrefab = Resources.Load<GameObject>("Prefabs/Tile");

        CreateTiles();
        RandomizeTiles();
        AssignTileNeighbors();
    }

    public void CreateTiles() {
        for (int i = 0; i < tileCount; i += 4) {
            ArmorType armorType = Tile.GetRandomArmorType();
            ArmorQuality armorQuality = Tile.GetRandomArmorQuality();

            CreateTile(i, armorType, armorQuality);
            CreateTile(i + 1, armorType, armorQuality);
            CreateTile(i + 2, armorType, armorQuality);
            CreateTile(i + 3, armorType, armorQuality);
        }
    }

    private void CreateTile(int i, ArmorType at, ArmorQuality aq) {
        GameObject tileObj = Instantiate(tilePrefab, transform);
        Tile tile = tileObj.transform.GetComponent<Tile>();

        tile.armorType = at;
        tile.armorQuality = aq;
        tile.SetImageSprite(tile.armorQuality, tile.armorType);

        tiles.Add(tileObj);
    }

    public void RandomizeTiles() {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).SetSiblingIndex(Random.Range(0, transform.childCount));
        }
    }

    private void AssignTileNeighbors() {
        
    }
    
    public void ClearTiles() {
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
}
