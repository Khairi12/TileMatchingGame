using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour {
    public int tileCount;

    private GameObject tilePrefab;
    private List<KeyValuePair<ArmorType, ArmorQuality>> pairs = new List<KeyValuePair<ArmorType, ArmorQuality>>();
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
        Image tileImage = tileObj.transform.GetChild(1).GetComponent<Image>();
        Tile tile = tileObj.transform.GetComponent<Tile>();

        tile.armorType = at;
        tile.armorQuality = aq;
        tileImage.sprite = SetImageSprite(tile.armorQuality, tile.armorType);

        tiles.Add(tileObj);
    }

    private void RandomizeTiles() {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).SetSiblingIndex(Random.Range(0, transform.childCount));
        }
    }

    private void AssignTileNeighbors() {
        
    }

    private Sprite SetImageSprite(ArmorQuality aq, ArmorType at) {
        if (aq == ArmorQuality.Basic) {
            switch (at) {
                case ArmorType.Boots: return Resources.Load<Sprite>("Sprites/sprite" + 20);
                case ArmorType.Chest: return Resources.Load<Sprite>("Sprites/sprite" + 1);
                case ArmorType.Gloves: return Resources.Load<Sprite>("Sprites/sprite" + 10);
                case ArmorType.Helmet: return Resources.Load<Sprite>("Sprites/sprite" + 0);
                case ArmorType.Leggings: return Resources.Load<Sprite>("Sprites/sprite" + 15);
            }
        }
        else if (aq == ArmorQuality.Chainmail) {
            switch (at) {
                case ArmorType.Boots: return Resources.Load<Sprite>("Sprites/sprite" + 23);
                case ArmorType.Chest: return Resources.Load<Sprite>("Sprites/sprite" + 4);
                case ArmorType.Gloves: return Resources.Load<Sprite>("Sprites/sprite" + 13);
                case ArmorType.Helmet: return Resources.Load<Sprite>("Sprites/sprite" + 8);
                case ArmorType.Leggings: return Resources.Load<Sprite>("Sprites/sprite" + 18);
            }
        }
        else if (aq == ArmorQuality.Cloth) {
            switch (at) {
                case ArmorType.Boots: return Resources.Load<Sprite>("Sprites/sprite" + 21);
                case ArmorType.Chest: return Resources.Load<Sprite>("Sprites/sprite" + 2);
                case ArmorType.Gloves: return Resources.Load<Sprite>("Sprites/sprite" + 11);
                case ArmorType.Helmet: return Resources.Load<Sprite>("Sprites/sprite" + 6);
                case ArmorType.Leggings: return Resources.Load<Sprite>("Sprites/sprite" + 16);
            }
        }
        else if (aq == ArmorQuality.Iron) {
            switch (at) {
                case ArmorType.Boots: return Resources.Load<Sprite>("Sprites/sprite" + 24);
                case ArmorType.Chest: return Resources.Load<Sprite>("Sprites/sprite" + 5);
                case ArmorType.Gloves: return Resources.Load<Sprite>("Sprites/sprite" + 14);
                case ArmorType.Helmet: return Resources.Load<Sprite>("Sprites/sprite" + 9);
                case ArmorType.Leggings: return Resources.Load<Sprite>("Sprites/sprite" + 19);
            }
        }
        else if (aq == ArmorQuality.Leather) {
            switch (at) {
                case ArmorType.Boots: return Resources.Load<Sprite>("Sprites/sprite" + 22);
                case ArmorType.Chest: return Resources.Load<Sprite>("Sprites/sprite" + 3);
                case ArmorType.Gloves: return Resources.Load<Sprite>("Sprites/sprite" + 12);
                case ArmorType.Helmet: return Resources.Load<Sprite>("Sprites/sprite" + 7);
                case ArmorType.Leggings: return Resources.Load<Sprite>("Sprites/sprite" + 17);
            }
        }

        return Resources.Load<Sprite>("Sprites/sprite" + 0);
    }
    
}
