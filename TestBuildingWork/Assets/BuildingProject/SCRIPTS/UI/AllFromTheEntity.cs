using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AllFromTheEntity : EntityPanel
{

    public GameObject InfoPanel;
    delegate void butDelegate(byte num);

    butDelegate[] butDel = new butDelegate[10];


    public override void SpawnAll()
    {

        BildUnit = EnvokeObject.GetComponent<Entity>();





        foreach (Transform child in GridGenerator.transform)
        {
            Destroy(child.gameObject);
        }
        //////////////
        if (InfoPanel)
        {
            GameObject clone = Instantiate(BuildingButPref, transform.position, transform.rotation);
            clone.transform.SetParent(GridGenerator.transform);

            clone.GetComponent<Image>().sprite = EnvokeObject.GetComponent<Entity>().spriteU;
            clone.GetComponent<Button>().onClick.AddListener(() => InfoPanelF(0));

            clone.transform.Find("Info(TMP)").GetComponent<TextMeshProUGUI>().text = "INFO";
        }
        ////////////////


        byte i = 0;

        foreach (GameObject b in BildUnit.ImproveToPref)   /// вызываем  
        {
            byte Imp = i;
            GameObject clone1 = Instantiate(BuildingButPref, transform.position, transform.rotation);
            clone1.transform.SetParent(GridGenerator.transform);

            clone1.GetComponent<Image>().sprite = BildUnit.ImproveToPref[i].GetComponent<Entity>().spriteU;
            clone1.GetComponent<Button>().onClick.AddListener(() => numImproveToPref(Imp));
            i++;

        }


        i = 0;
        foreach (SkillData b in BildUnit.skills)   /// вызываем  
        {
            byte ent = i;
            GameObject clone1 = Instantiate(BuildingButPref, transform.position, transform.rotation);
            clone1.transform.SetParent(GridGenerator.transform);

            clone1.GetComponent<Image>().sprite = BildUnit.skills[i].spriteS;
            clone1.GetComponent<Button>().onClick.AddListener(() => NumSkill(ent));
            i++;
        }
    }



    public void InfoPanelF(byte _num)
    {
        // открыть инфо панель потом запустить ее 
        //    InfoPanel.GetComponent<EntityPanel>().EnvokeObject = EnvokeObject;   // Закинуть обхект и панель которая его открыла
        //  InfoPanel.GetComponent<InfoBigPanel>().panelMunipul = this.gameObject;
        if (InfoPanel)
        {
            InfoPanel.gameObject.SetActive(true);
            InfoPanel.GetComponent<InfoBigPanel>().SelectObj(EnvokeObject, this.gameObject);
            // this.gameObject.SetActive(false);
        }
        //   Debug.Log("InfoEnt" + num);
    }


    private void numImproveToPref(byte _num)
    {

        if (BuildingInShopPrefs.Count > 0)
        {
            Entity need = BuildingInShopPrefs[_num].GetComponent<Entity>();


            if (MS.playerM.Gold >= need.needGold)
            {
                MS.playerM.gold -= need.needGold; this.gameObject.SetActive(false);// SayInfoShop.text = "<color=\"green\">Спасибо за покупку!";
            }
            else
            { //SayInfoShop.text = "<color=\"red\">Нехватает Gold!";
            }

            ///  ---- in Consraction ---  //
            foreach (Transform child in GridGenerator.transform)
            {
                Destroy(child.gameObject);
            }


            EnvokeObject.GetComponent<Entity>().StartImproveTo(BuildingInShopPrefs[_num]);
        }
        Debug.Log("numImproveToPref" + _num);
    }

    public void NumSkill(byte _num)
    {
        EnvokeObject.GetComponent<Entity>().UseSkill(_num);
//        Debug.Log("NumSkill" + _num);
    }


}
