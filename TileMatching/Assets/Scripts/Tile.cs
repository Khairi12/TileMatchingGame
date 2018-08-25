using UnityEngine;
using UnityEngine.EventSystems;

public enum ArmorType { Helmet, Chest, Leggings, Boots, Gloves }
public enum ArmorQuality { Basic, Cloth, Leather, Chainmail, Iron }

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public ArmorType armorType;
    public ArmorQuality armorQuality;

    private Sprite sprite;

    private void Start() {
        
    }

    public void OnPointerEnter(PointerEventData eventData) {

    }

    public void OnPointerExit(PointerEventData eventData) {

    }

    public static ArmorType GetRandomArmorType() {
        switch (Random.Range(0, 4)) {
            case 0: return ArmorType.Boots;
            case 1: return ArmorType.Chest;
            case 2: return ArmorType.Gloves;
            case 3: return ArmorType.Helmet;
            case 4: return ArmorType.Leggings;
            default: return ArmorType.Boots;
        }
    }

    public static ArmorQuality GetRandomArmorQuality() {
        switch (Random.Range(0, 4)) {
            case 0: return ArmorQuality.Basic;
            case 1: return ArmorQuality.Chainmail;
            case 2: return ArmorQuality.Cloth;
            case 3: return ArmorQuality.Iron;
            case 4: return ArmorQuality.Leather;
            default: return ArmorQuality.Basic;
        }
    }

}
