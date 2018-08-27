using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour {
    public int tileCount;

    private GameObject tilePrefab;
    private List<GameObject> tiles = new List<GameObject>();

    private void Start() {
        tilePrefab = Resources.Load<GameObject>("Prefabs/Tile");

        CreateTiles();
        RandomizeTiles();
        AssignTileNeighbors();
    }

    private void CreateTiles() {
        for (int i = 0; i < tileCount; i += 2) {
            ArmorType armorType = Tile.GetRandomArmorType();
            ArmorQuality armorQuality = Tile.GetRandomArmorQuality();

            CreateTile(i, armorType, armorQuality);
            CreateTile(i+1, armorType, armorQuality);
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

    private void RandomizeTiles() {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).SetSiblingIndex(Random.Range(0, transform.childCount));
        }
    }

    private void AssignTileNeighbors() {
        
    }
    
}
