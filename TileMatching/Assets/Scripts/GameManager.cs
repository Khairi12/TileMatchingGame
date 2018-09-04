using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    private void Awake() {
        gameManager = this;
    }

    private void Start() {
        
    }

    public void ResetTiles() {

    }
}
