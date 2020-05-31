using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityPanel : MonoBehaviour
{
    public GameObject EnvokeObject;
    public Entity BildUnit;
    public Image striteBigIcon;
    public GameObject GridGenerator;// генератор кнопок 
    public GameObject BuildingButPref; // префаб кнопки

    [Header("PanelTable")]
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

    public virtual void SelectObj(GameObject _unit)
    {
        //        ButClickNum = num;
        EnvokeObject = _unit;
        Debug.Log("SelectObj= " + _unit.name);
         BildUnit = EnvokeObject.GetComponent<Entity>();
        if (striteBigIcon != null) striteBigIcon.sprite = BildUnit.spriteU;
        if (nameTitleItem != null) nameTitleItem.text = BildUnit.nameTitle;
        //   discriptionShortItem.text = BildBref.discriptionShort;
        float goldSell = BildUnit.needGold;
        if (Gold != null) Gold.text = goldSell.ToString() + " Gold Sell";
        if (discriptionItem != null) discriptionItem.text = BildUnit.discription;

        SpawnAll();
    }
    public virtual void SpawnAll()
    {



    }
}
