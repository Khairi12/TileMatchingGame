﻿using UnityEngine;

public class SpriteUtils : MonoBehaviour {

    public static Sprite GetRandomSprite() {
        int value = Random.Range(1, 24);
        Sprite sprite = Resources.Load<Sprite>("sprite1");
        return sprite;
    }
}
