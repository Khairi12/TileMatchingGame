using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResetBar : MonoBehaviour {

    public int coolDownDuration = 5;
    public int coolDownMultiplier = 1;

    private TileManager tileManager;
    private Slider coolDownSlider;
    private Button coolDownButton;

	private void Start () {
        tileManager = TileManager.Instance;
        coolDownButton = transform.GetChild(1).GetComponent<Button>();
        coolDownButton.onClick.AddListener(CoolDownButtonClick);
        coolDownSlider = transform.GetChild(0).GetComponent<Slider>();
        coolDownSlider.maxValue = coolDownDuration;
        coolDownSlider.value = coolDownDuration;
        StartCoroutine("UpdateCoolDownTime");
	}

    public void CoolDownButtonClick() {
        if (coolDownSlider.value <= 0) {
            StopAllCoroutines();
            coolDownMultiplier++;
            coolDownSlider.maxValue = coolDownDuration + coolDownMultiplier;
            coolDownSlider.value = coolDownDuration + coolDownMultiplier;
            tileManager.ClearTiles();
            tileManager.CreateTiles();
            tileManager.RandomizeTiles();
            StartCoroutine("UpdateCoolDownTime");
        }
    }

    private IEnumerator UpdateCoolDownTime() {
        yield return new WaitForSeconds(1);

        if (coolDownSlider.value <= 0) {
            StopCoroutine("UpdateCoolDownTime");
        }
        else {
            coolDownSlider.value -= 1;
            StartCoroutine("UpdateCoolDownTime");
        }

        yield return null;
    }

}
