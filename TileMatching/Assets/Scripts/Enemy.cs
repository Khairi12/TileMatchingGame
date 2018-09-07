using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float animationSpeed = 0.1f;

    private SpriteRenderer sprite;
    private Transform playerTransform;
    private Vector3 originalPosition;

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        originalPosition = transform.position;
        StartCoroutine("IdleAnimation");
    }

    private IEnumerator Attack() {
        yield return StartCoroutine("MoveToPlayerPos");

        yield return StartCoroutine("AttackAnimation");
        // Damage player animation here ?
        // Damage player code here ?

        yield return StartCoroutine("MoveToDefaultPos");

        yield return null;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StopAllCoroutines();
            StartCoroutine("Attack");
        }
    }

    private IEnumerator MoveToPlayerPos() {
        sprite.flipX = false;
        StopCoroutine("IdleAnimation");
        StartCoroutine("RunAnimation");

        while (Vector3.Distance(transform.position, playerTransform.position) > 1.5f) {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, 3 * Time.deltaTime);
            yield return null;
        }

        StopCoroutine("RunAnimation");
        StartCoroutine("IdleAnimation");

        yield return new WaitForSeconds(1);
        yield return null;
    }

    private IEnumerator MoveToDefaultPos() {
        sprite.flipX = true;
        StopCoroutine("IdleAnimation");
        StartCoroutine("RunAnimation");

        while (Vector3.Distance(transform.position, originalPosition) > 0f) {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, 3 * Time.deltaTime);
            yield return null;
        }

        StopCoroutine("RunAnimation");
        StartCoroutine("IdleAnimation");
        sprite.flipX = false;

        yield return new WaitForSeconds(1);
        yield return null;
    }

    private IEnumerator FaintAnimation() {
        while (true) {
            for (int i = 0; i < 8; i++) {
                sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Enemy/heavy-bandit-faint-0" + i);
                yield return new WaitForSeconds(animationSpeed);
            }
        }
    }

    private IEnumerator AttackAnimation() {
        StopCoroutine("IdleAnimation");

        for (int i = 0; i < 8; i++) {
            sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Enemy/heavy-bandit-attack-0" + i);
            yield return new WaitForSeconds(animationSpeed);
        }

        StartCoroutine("IdleAnimation");
        yield return null;
    }

    private IEnumerator RunAnimation() {
        while (true) {
            for (int i = 0; i < 8; i++) {
                sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Enemy/heavy-bandit-run-0" + i);
                yield return new WaitForSeconds(animationSpeed);
            }
        }
    }

    private IEnumerator IdleAnimation() {
        while (true) {
            for (int i = 0; i < 4; i++) {
                sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Enemy/heavy-bandit-idle-0" + i);
                yield return new WaitForSeconds(animationSpeed);
            }
        }
    }
}
