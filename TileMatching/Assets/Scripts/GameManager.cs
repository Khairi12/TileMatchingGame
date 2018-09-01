using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;
    public List<Transform> flippedTiles = new List<Transform>();

    private void Awake() {
        gameManager = this;
    }

    private void Start() {
        
    }

    public void AddTile(Transform tileTransform) {
        flippedTiles.Add(tileTransform);
    }

    public void ResetTiles() {

    }
}
