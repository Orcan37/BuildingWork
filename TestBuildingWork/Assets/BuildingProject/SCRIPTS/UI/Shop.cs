using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Shop : EntityPanel //, ISelectPanel
{
    

    // public List<GameObject> ButSpaw;
    public byte ButClickNum = 0;

    //public override void SelectObj(GameObject unit)
    //{
    //    base.SelectObj(unit);

    //}
        public void SelectNum(byte _num)
    {
        ButClickNum = _num;
        Entity BildUnit = BuildingInShopPrefs[_num].GetComponent<Entity>();
        striteBigIcon.sprite = BildUnit.spriteU;
        nameTitleItem.text = BildUnit.nameTitle;
        //   discriptionShortItem.text = BildBref.discriptionShort;
        Gold.text = BildUnit.needGold.ToString() + " Gold";
        discriptionItem.text = BildUnit.discription;
       

    }

    public virtual void buykOnClick()
    { // в ресурсах проверяет сколько там денег меньше или больше и отнимает если больше чем стоит
       
        if (BuildingInShopPrefs.Count > 0) {  
        Entity need = BuildingInShopPrefs[ButClickNum].GetComponent<Entity>();
    

        if (MS.playerM.Gold >= need.needGold)
        {
            MS.playerM.gold -= need.needGold; SayInfoShop.text = "<color=\"green\">Спасибо за покупку!";
        }
        else { SayInfoShop.text = "<color=\"red\">Нехватает Gold!"; }
    
        ///  ---- in Consraction ---  //
        foreach (Transform child in GridGenerator.transform)
        {
            Destroy(child.gameObject);
        }

        EnvokeObject.GetComponent<Entity>().StartImproveTo(BuildingInShopPrefs[ButClickNum]);
        }

    }



    public virtual void cancelOnClick() { EnvokeObject = null; this.gameObject.SetActive(false); }




    void Awake()
    {
        buy.onClick.AddListener(() => buykOnClick());
        cancel.onClick.AddListener(() => cancelOnClick());
        //  BuildingButPref = this.gameObject.transform.Find("BildingPanel/BildingGRID").gameObject;
    }


   
    public override void SpawnAll()
    { 
        { 
            foreach (Transform child in GridGenerator.transform)
            {
                Destroy(child.gameObject);
            }


            byte i = 0;
            
            foreach (GameObject b in BildUnit.ImproveToPref)   /// вызываем все из CurrentEvent
            {
                byte Imp = i;
                GameObject clone = Instantiate(BuildingButPref, transform.position, transform.rotation);
                clone.transform.SetParent(GridGenerator.transform);

                clone.GetComponent<Image>().sprite = BildUnit.ImproveToPref[i].GetComponent<Entity>().spriteU;
                clone.GetComponent<Button>().onClick.AddListener(() => SelectNum(Imp));
                i++; 
            }
        } 
      
    }

}
