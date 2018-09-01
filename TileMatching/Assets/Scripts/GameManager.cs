using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    private void Awake() {
        gameManager = this;
    }

    private void Start() {
        
    }

    public void FourTilesFlipped() {
        if (TileManager.tileManager.flippedTiles.Count >= 4) {
            TileManager.tileManager.StartCoroutine("RemoveFlippedTiles");
        }
    }

    public void ResetTiles() {

    }
}
