using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    public float animationSpeed = 0.1f;

    private SpriteRenderer sprite;

	private void Start () {
        sprite = GetComponent<SpriteRenderer>();

        StartCoroutine("Idle");
    }

    private IEnumerator Idle() {
        while (true) {
            for (int i = 0; i < 4; i++) {
                sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Player/adventurer-idle-0" + i);
                yield return new WaitForSeconds(animationSpeed);
            }
        }
    }

    private IEnumerator Run() {
        while (true) {
            for (int i = 0; i < 6; i++) {
                sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Player/adventurer-run-0" + i);
                yield return new WaitForSeconds(animationSpeed);
            }
        }

    }
}
