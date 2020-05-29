using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class universalBut : MonoBehaviour
{
   // public GameObject Entity;
    public GameObject universal; //потом сделать как  scriptible object
    public GameObject Entity; 

    public GameObject Bouder;


    void Awake()
    {

        //     Bouder = this.transform.Find("Bouder").gameObject;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Bouder) Bouder.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //  if(!universal.GetComponent<Skill>())

      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Bouder) Bouder.SetActive(false);
    }







}
