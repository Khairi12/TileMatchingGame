﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TileManager : MonoBehaviour {
    
    public static TileManager Instance { get; private set; }

    public List<Transform> flippedTiles = new List<Transform>();

    public int tileCount;

    private GameObject tilePrefab;

    private void Awake() {
        transform.SetParent(transform.root);

        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(transform.parent.gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        tilePrefab = Resources.Load<GameObject>("Prefabs/Tile");

        CreateTiles();
        RandomizeTiles();
        AssignTileNeighbors();
    }

    public void CreateTiles() {
        for (int i = 0; i < tileCount; i += 4) {
            for (int j = 0; j < 4; j++) {
                CreateTile(i + j);
            }
        }
    }

    private void CreateTile(int i) {
        GameObject tileObj = Instantiate(tilePrefab, transform);
        Tile tile = tileObj.transform.GetComponent<Tile>();

        // design flaw - randomly creates tiles, not in pairs of 4
        tile.tileID = i;
        tile.SetTileType();
        tile.SetTileQuality();
        tile.SetTileCategory();
        tile.SetTileImage(tile.tileType, tile.tileQuality);
    }

    public void AddFlippedTile(Transform t) {
        flippedTiles.Add(t);

        if (ShouldResetFlippedTiles()) {
            StartCoroutine("ResetFlippedTiles");
        }
    }

    public void RemoveFlippedTile(Transform t) {
        foreach (Transform flippedTile in flippedTiles) {
            if (flippedTile == t) {
                flippedTiles.Remove(flippedTile);
                break;
            }
        }
    }

    public IEnumerator ResetFlippedTiles() {
        Tile.enableFlip = false;
        yield return new WaitForSeconds(1);
        
        foreach (Transform child in flippedTiles) {
            child.GetComponent<Tile>().FlipTileDown();
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

        flippedTiles.Clear();
    }

    private bool ShouldResetFlippedTiles() {
        return flippedTiles.Count >= 4 ? true : false;
    }
}
