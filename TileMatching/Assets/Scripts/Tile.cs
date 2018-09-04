using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum TileCategory {
    Armor,
    Item,
    Weapon
}

public enum TileType {
    Helmet,
    Chestplate,
    Boots,
    Axe,
    Sword,
    Dagger,
    Hammer,
    Bow,
    Wand,
    Shield
}

public enum TileQuality {
    Basic,
    Common,
    Uncommon,
    Rare,
    Legendary
}

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public static bool enableFlip = true;

    public Sprite sprite;
    public TileType tileType;
    public TileQuality tileQuality;
    public TileCategory tileCategory;
    public int tileID;

    private bool isFlipped = false;

    public void OnPointerEnter(PointerEventData eventData) {

    }

    public void OnPointerExit(PointerEventData eventData) {

    }

    public void OnPointerClick(PointerEventData eventData) {
        if (!enableFlip) {
            return;
        }

        if (isFlipped) {
            FlipTileDown();
            TileManager.Instance.RemoveFlippedTile(transform);
        }
        else {
            FlipTileUp();
            TileManager.Instance.AddFlippedTile(transform);
        }
    }

    public void FlipTileUp() {
        isFlipped = true;
        transform.GetChild(0).GetComponent<Image>().sprite = sprite;
    }

    public void FlipTileDown() {
        isFlipped = false;
        transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Equipment/Default");
    }

    public void SetTileCategory() {
        switch (tileType) {
            case TileType.Boots: tileCategory = TileCategory.Armor; break;
            case TileType.Chestplate: tileCategory = TileCategory.Armor; break;
            case TileType.Helmet: tileCategory = TileCategory.Armor; break;

            case TileType.Axe: tileCategory = TileCategory.Weapon; break;
            case TileType.Bow: tileCategory = TileCategory.Weapon; break;
            case TileType.Dagger: tileCategory = TileCategory.Weapon; break;
            case TileType.Hammer: tileCategory = TileCategory.Weapon; break;
            case TileType.Shield: tileCategory = TileCategory.Weapon; break;
            case TileType.Sword: tileCategory = TileCategory.Weapon; break;
            case TileType.Wand: tileCategory = TileCategory.Weapon; break;
        }
    }

    public void SetTileType() {
        switch (Random.Range(0, 10)) {
            case 0: tileType = TileType.Boots; break;
            case 1: tileType = TileType.Chestplate; break;
            case 2: tileType = TileType.Helmet; break;

            case 3: tileType = TileType.Axe; break;
            case 4: tileType = TileType.Bow; break;
            case 5: tileType = TileType.Dagger; break;
            case 6: tileType = TileType.Hammer; break;
            case 7: tileType = TileType.Shield; break;
            case 8: tileType = TileType.Sword; break;
            case 9: tileType = TileType.Wand; break;
        }
    }

    public void SetTileQuality() {
        int value = Random.Range(0, 100);

        if (value == 0) {
            tileQuality = TileQuality.Legendary;
        }
        else if (value > 0 && value <= 5) {
            tileQuality = TileQuality.Rare;
        }
        else if (value > 5 && value <= 20) {
            tileQuality = TileQuality.Uncommon;
        }
        else if (value > 20 && value <= 50) {
            tileQuality = TileQuality.Common;
        }
        else {
            tileQuality = TileQuality.Basic;
        }
    }

    public void SetTileImage(TileType tt, TileQuality tq) {
        //------------------------------------------------------------------------------------------------------
        // Weapon Sprites
        //------------------------------------------------------------------------------------------------------
        if (tt == TileType.Axe) {
            switch (tq) {
                case TileQuality.Basic: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/AxeI"); return;
                case TileQuality.Common: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/AxeII"); return;
                case TileQuality.Uncommon: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/AxeIII"); return;
                case TileQuality.Rare: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/AxeIV"); return;
                case TileQuality.Legendary: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/AxeV"); return;
            }
        }
        else if (tt == TileType.Bow) {
            switch (tq) {
                case TileQuality.Basic: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/BowI");  return;
                case TileQuality.Common: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/BowII"); return;
                case TileQuality.Uncommon: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/BowIII"); return;
                case TileQuality.Rare: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/BowIV"); return;
                case TileQuality.Legendary: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/BowV"); return;
            }
        }
        else if (tt == TileType.Dagger) {
            switch (tq) {
                case TileQuality.Basic: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/DaggerI"); return;
                case TileQuality.Common: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/DaggerII"); return;
                case TileQuality.Uncommon: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/DaggerIII"); return;
                case TileQuality.Rare: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/DaggerIV"); return;
                case TileQuality.Legendary: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/DaggerV"); return;
            }
        }
        else if (tt == TileType.Hammer) {
            switch (tq) {
                case TileQuality.Basic: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/HammerI"); return;
                case TileQuality.Common: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/HammerII"); return;
                case TileQuality.Uncommon: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/HammerIII"); return;
                case TileQuality.Rare: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/HammerIV"); return;
                case TileQuality.Legendary: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/HammerV"); return;
            }
        }
        else if (tt == TileType.Shield) {
            switch (tq) {
                case TileQuality.Basic: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/ShieldI"); return;
                case TileQuality.Common: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/ShieldII"); return;
                case TileQuality.Uncommon: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/ShieldIII"); return;
                case TileQuality.Rare: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/ShieldIV"); return;
                case TileQuality.Legendary: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/ShieldV"); return;
            }
        }
        else if (tt == TileType.Sword) {
            switch (tq) {
                case TileQuality.Basic: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/SwordI"); return;
                case TileQuality.Common: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/SwordII"); return;
                case TileQuality.Uncommon: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/SwordIII"); return;
                case TileQuality.Rare: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/SwordIV"); return;
                case TileQuality.Legendary: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/SwordV"); return;
            }
        }
        else if (tt == TileType.Wand) {
            switch (tq) {
                case TileQuality.Basic: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/WandsI"); return;
                case TileQuality.Common: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/WandsII"); return;
                case TileQuality.Uncommon: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/WandsIII"); return;
                case TileQuality.Rare: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/WandsIV"); return;
                case TileQuality.Legendary: sprite = Resources.Load<Sprite>("Sprites/Equipment/Weapons/WandsV"); return;
            }
        }

        //------------------------------------------------------------------------------------------------------
        // Armor Sprites
        //------------------------------------------------------------------------------------------------------
        else if (tt == TileType.Boots) {
            switch (tq) {
                case TileQuality.Basic: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/BootI"); return;
                case TileQuality.Common: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/BootII"); return;
                case TileQuality.Uncommon: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/BootIII"); return;
                case TileQuality.Rare: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/BootIV"); return;
                case TileQuality.Legendary: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/BootV"); return;
            }
        }
        else if (tt == TileType.Chestplate) {
            switch (tq) {
                case TileQuality.Basic: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/ChestplateI"); return;
                case TileQuality.Common: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/ChestplateII"); return;
                case TileQuality.Uncommon: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/ChestplateIII"); return;
                case TileQuality.Rare: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/ChestplateIV"); return;
                case TileQuality.Legendary: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/ChestplateV"); return;
            }
        }
        else if (tt == TileType.Helmet) {
            switch (tq) {
                case TileQuality.Basic: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/HelmetI"); return;
                case TileQuality.Common: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/HelmetII"); return;
                case TileQuality.Uncommon: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/HelmetIII"); return;
                case TileQuality.Rare: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/HelmetIV"); return;
                case TileQuality.Legendary: sprite = Resources.Load<Sprite>("Sprites/Equipment/Armor/HelmetV"); return;
            }
        }
    }

}
