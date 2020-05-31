using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBigPanel : EntityPanel

{

    public GameObject panelMunipul;



    public   void SelectObj(GameObject unit, GameObject _panelMunipul)
    {
        // ButClickNum = num;
        EnvokeObject = unit;
        Entity BildUnit = unit.GetComponent<Entity>();
        striteBigIcon.sprite = BildUnit.spriteU;
        nameTitleItem.text = BildUnit.nameTitle;
        //   discriptionShortItem.text = BildBref.discriptionShort;
        float goldSell = BildUnit.needGold;
        Gold.text = goldSell.ToString() + " Gold Sell";
        discriptionItem.text = BildUnit.discription;
        panelMunipul = _panelMunipul;
        panelMunipul.SetActive(false);


        SpawnAll();
    }
     
    private void Start()
    {
        cancel.onClick.AddListener(() => cancelOnClick());

    }

    private void cancelOnClick()
    {
        this.gameObject.SetActive(false);
        panelMunipul.SetActive(true);
    }
}
