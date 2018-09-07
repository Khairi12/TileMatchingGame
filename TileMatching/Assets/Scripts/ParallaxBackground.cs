using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxBackground : MonoBehaviour {

    public float scrollSpeed = 1f;
    public bool enableScroll = false;
    
    private SpriteRenderer sprite;
    private Vector3 startPosition;
    private float imageSize;

    private void Start () {
        startPosition = transform.position;
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        imageSize = sprite.bounds.size.x;
	}

    private void Update () {
        if (enableScroll) {
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, imageSize);
            transform.position = startPosition + Vector3.left * newPosition;
        }
	}
}
