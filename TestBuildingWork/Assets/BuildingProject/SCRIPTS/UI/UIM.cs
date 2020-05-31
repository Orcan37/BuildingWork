using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;


public class UIM : MonoBehaviour // отключает панели и включает + работает с камерами Покачто
{
    [Header("Resurs")]
    public TextMeshProUGUI GOLDtext;
    public TextMeshProUGUI Placetext;

    public GameObject selectedGO;
 
    public Camera CurCamera;

    [Header("AllPanel")]
    public GameObject DownPanel;
    public GameObject CenterPanel;
    public GameObject UPPanel;
    public GameObject SelectinonPanel;

    public AudioSource audioSource;

    public void ResRefresh()
    {
        float round = (int)MS.playerM.Gold;
        GOLDtext.text = round.ToString();
        Placetext.text = MS.playerM.Place.ToString();
    }



    public void Selected(GameObject _GO)
    {
      
     if(selectedGO != null)   selectedGO.GetComponent<ISelectedEntity>().unSelected();
        selectedGO = _GO;
        selectedGO.GetComponent<ISelectedEntity>().Selected();

    }
     

    private void Start()
    {
        MS.uIM = this;

        audioSource = GetComponent<AudioSource>();
    } 

}
 