using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum ArmorType { Helmet, Chest, Leggings, Boots, Gloves }
public enum ArmorQuality { Basic, Cloth, Leather, Chainmail, Iron }

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public ArmorType armorType;
    public ArmorQuality armorQuality;
    public Sprite sprite;
    public int xID;
    public int yID;

    private bool isFlipped = false;

    private void Start() {
        
    }

    public void OnPointerEnter(PointerEventData eventData) {

    }

    public void OnPointerExit(PointerEventData eventData) {

    }

    public void OnPointerClick(PointerEventData eventData) {
        if (isFlipped) {
            FlipTileDown();
        }
        else {
            FlipTileUp();
        }

        // pass tile information to gamemanager
        // prevent fliptiledown() while tile is the only flipped tile
    }

    public void FlipTileUp() {
        isFlipped = true;
        transform.GetChild(1).GetComponent<Image>().sprite = null;
        transform.GetChild(1).GetComponent<Image>().color = Color.black;
    }

    public void FlipTileDown() {
        isFlipped = false;
        transform.GetChild(1).GetComponent<Image>().sprite = sprite;
        transform.GetChild(1).GetComponent<Image>().color = Color.white;
    }

    public void SetImageSprite(ArmorQuality aq, ArmorType at) {
        if (aq == ArmorQuality.Basic) {
            switch (at) {
                case ArmorType.Boots: sprite = Resources.Load<Sprite>("Sprites/sprite" + 20); break;
                case ArmorType.Chest: sprite = Resources.Load<Sprite>("Sprites/sprite" + 1); break;
                case ArmorType.Gloves: sprite = Resources.Load<Sprite>("Sprites/sprite" + 10); break;
                case ArmorType.Helmet: sprite = Resources.Load<Sprite>("Sprites/sprite" + 0); break;
                case ArmorType.Leggings: sprite = Resources.Load<Sprite>("Sprites/sprite" + 15); break;
            }
        }
        else if (aq == ArmorQuality.Chainmail)   {
            switch (at) {
                case ArmorType.Boots: sprite = Resources.Load<Sprite>("Sprites/sprite" + 23); break;
                case ArmorType.Chest: sprite = Resources.Load<Sprite>("Sprites/sprite" + 4); break;
                case ArmorType.Gloves: sprite = Resources.Load<Sprite>("Sprites/sprite" + 13); break;
                case ArmorType.Helmet: sprite = Resources.Load<Sprite>("Sprites/sprite" + 8); break;
                case ArmorType.Leggings: sprite = Resources.Load<Sprite>("Sprites/sprite" + 18); break;
            }
        }
        else if (aq == ArmorQuality.Cloth) {
            switch (at) {
                case ArmorType.Boots: sprite = Resources.Load<Sprite>("Sprites/sprite" + 21); break;
                case ArmorType.Chest: sprite = Resources.Load<Sprite>("Sprites/sprite" + 2); break;
                case ArmorType.Gloves: sprite = Resources.Load<Sprite>("Sprites/sprite" + 11); break;
                case ArmorType.Helmet: sprite = Resources.Load<Sprite>("Sprites/sprite" + 6); break;
                case ArmorType.Leggings: sprite = Resources.Load<Sprite>("Sprites/sprite" + 16); break;
            }
        }
        else if (aq == ArmorQuality.Iron) {
            switch (at) {
                case ArmorType.Boots: sprite = Resources.Load<Sprite>("Sprites/sprite" + 24); break;
                case ArmorType.Chest: sprite = Resources.Load<Sprite>("Sprites/sprite" + 5); break;
                case ArmorType.Gloves: sprite = Resources.Load<Sprite>("Sprites/sprite" + 14); break;
                case ArmorType.Helmet: sprite = Resources.Load<Sprite>("Sprites/sprite" + 9); break;
                case ArmorType.Leggings: sprite = Resources.Load<Sprite>("Sprites/sprite" + 19); break;
            }
        }
        else if (aq == ArmorQuality.Leather) {
            switch (at) {
                case ArmorType.Boots: sprite = Resources.Load<Sprite>("Sprites/sprite" + 22); break;
                case ArmorType.Chest: sprite = Resources.Load<Sprite>("Sprites/sprite" + 3); break;
                case ArmorType.Gloves: sprite = Resources.Load<Sprite>("Sprites/sprite" + 12); break;
                case ArmorType.Helmet: sprite = Resources.Load<Sprite>("Sprites/sprite" + 7); break;
                case ArmorType.Leggings: sprite = Resources.Load<Sprite>("Sprites/sprite" + 17); break;
            }
        }
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
