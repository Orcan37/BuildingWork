using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityPanel : MonoBehaviour
{
    public GameObject EnvokeObject;
     
    public Image striteBigIcon;
    public GameObject GridGenerator;// генератор кнопок 
    public GameObject BuildingButPref; // префаб кнопки
    public List<GameObject> BuildingInShopPrefs;
    //  public List<GameObject> BuildingInShopPrefsTest;

    public string nameTitleShop;
    public string nameTitleShopText;
    public TextMeshProUGUI nameTitleItem;
    public TextMeshProUGUI Gold;
    public TextMeshProUGUI discriptionShortItem;

    public TextMeshProUGUI discriptionItem;
    public TextMeshProUGUI SayInfoShop;
    public Button buy;
    public Button cancel;

    public virtual void SelectObj(Entity unit)
    {
        // ButClickNum = num;
        Entity BildUnit = unit.GetComponent<Entity>();
        striteBigIcon.sprite = BildUnit.spriteU;
        nameTitleItem.text = BildUnit.nameTitle;
        //   discriptionShortItem.text = BildBref.discriptionShort;
        float goldSell = BildUnit.needGold;
        Gold.text = goldSell.ToString() + " Gold Sell";
        discriptionItem.text = BildUnit.discription;

        EnvokeObject = unit.gameObject;
    }
}
