using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum ArmorType { Helmet, Chest, Leggings, Boots, Gloves }
public enum ArmorQuality { Basic, Cloth, Leather, Chainmail, Iron }

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public static bool enableFlip = true;

    public Sprite sprite;
    public ArmorType armorType;
    public ArmorQuality armorQuality;
    public int tileID;

    private bool isFlipped = false;

    public void OnPointerEnter(PointerEventData eventData) {

    }

    public void OnPointerExit(PointerEventData eventData) {

    }

    public void OnPointerClick(PointerEventData eventData) {
        if (isFlipped || !enableFlip)
            return;
        
        FlipTileUp();
        TileManager.tileManager.AddFlippedTile(transform);
        GameManager.gameManager.FourTilesFlipped();
    }

    public void FlipTileUp() {
        isFlipped = true;
        transform.GetChild(1).GetComponent<Image>().sprite = sprite;
        transform.GetChild(1).GetComponent<Image>().color = Color.white;
    }

    public void FlipTileDown() {
        isFlipped = false;
        transform.GetChild(1).GetComponent<Image>().sprite = null;
        transform.GetChild(1).GetComponent<Image>().color = Color.black;

    }

    public void SetImageSprite(ArmorQuality aq, ArmorType at) {
        if (aq == ArmorQuality.Basic) {
            switch (at) {
                case ArmorType.Boots: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 20); break;
                case ArmorType.Chest: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 1); break;
                case ArmorType.Gloves: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 10); break;
                case ArmorType.Helmet: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 0); break;
                case ArmorType.Leggings: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 15); break;
            }
        }
        else if (aq == ArmorQuality.Chainmail)   {
            switch (at) {
                case ArmorType.Boots: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 23); break;
                case ArmorType.Chest: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 4); break;
                case ArmorType.Gloves: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 13); break;
                case ArmorType.Helmet: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 8); break;
                case ArmorType.Leggings: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 18); break;
            }
        }
        else if (aq == ArmorQuality.Cloth) {
            switch (at) {
                case ArmorType.Boots: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 21); break;
                case ArmorType.Chest: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 2); break;
                case ArmorType.Gloves: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 11); break;
                case ArmorType.Helmet: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 6); break;
                case ArmorType.Leggings: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 16); break;
            }
        }
        else if (aq == ArmorQuality.Iron) {
            switch (at) {
                case ArmorType.Boots: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 24); break;
                case ArmorType.Chest: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 5); break;
                case ArmorType.Gloves: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 14); break;
                case ArmorType.Helmet: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 9); break;
                case ArmorType.Leggings: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 19); break;
            }
        }
        else if (aq == ArmorQuality.Leather) {
            switch (at) {
                case ArmorType.Boots: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 22); break;
                case ArmorType.Chest: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 3); break;
                case ArmorType.Gloves: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 12); break;
                case ArmorType.Helmet: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 7); break;
                case ArmorType.Leggings: sprite = Resources.Load<Sprite>("Sprites/Equipment/sprite" + 17); break;
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
        int value = Random.Range(0, 100);

        if (value == 0) {
            Debug.Log("ultra rare equipment spawn");
            return ArmorQuality.Iron;
        }
        else if (value > 0 && value <= 5) {
            Debug.Log("rare equipment spawn");
            return ArmorQuality.Chainmail;
        }
        else if (value > 5 && value <= 20) {
            Debug.Log("uncommon equipment spawn");
            return ArmorQuality.Leather;
        }
        else if (value > 20 && value <= 50) {
            Debug.Log("common equipment spawn");
            return ArmorQuality.Cloth;
        }
        else {
            Debug.Log("default equipment spawn");
            return ArmorQuality.Basic;
        }
    }

}
