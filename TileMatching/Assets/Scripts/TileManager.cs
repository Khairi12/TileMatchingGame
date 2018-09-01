using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TileManager : MonoBehaviour {

    [HideInInspector] public static TileManager tileManager;
    [HideInInspector] public List<Transform> flippedTiles = new List<Transform>();

    public int tileCount;

    private GameObject tilePrefab;

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

            for (int j = 0; j < 4; j++) {
                CreateTile(i + j, armorType, armorQuality);
            }
        }
    }

    private void CreateTile(int i, ArmorType at, ArmorQuality aq) {
        GameObject tileObj = Instantiate(tilePrefab, transform);
        Tile tile = tileObj.transform.GetComponent<Tile>();

        tile.tileID = i;
        tile.armorType = at;
        tile.armorQuality = aq;
        tile.SetImageSprite(tile.armorQuality, tile.armorType);
    }

    public void AddFlippedTile(Transform transform) {
        flippedTiles.Add(transform);
    }

    public IEnumerator RemoveFlippedTiles() {
        Tile.enableFlip = false;
        yield return new WaitForSeconds(1);

        foreach (Transform child in flippedTiles) {
            child.GetComponent<Tile>().FlipTileDown();
            yield return new WaitForSeconds(0.15f);
        }

        flippedTiles.Clear();
        Tile.enableFlip = true;
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
