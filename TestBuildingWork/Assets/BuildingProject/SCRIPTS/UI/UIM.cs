using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class UIM : MonoBehaviour // отключает панели и включает + работает с камерами Покачто
{
    [Header("Resurs")]
    public TextMeshProUGUI GOLDtext;
    public TextMeshProUGUI Placetext;

    [Header("VoiewAndControler")]
    public GameObject selectedGO;
    
    public Camera CurCamera;
    // переделать все сделать чисто 3 камеры и менять расположения камеры UnitUpViever MainCamera UnitDownViewer
    //не надо ничего создавать лишь позиции менять и включать их
    public RaycastHit pHit;
    public Ray pRay;

    [Header("AllPanel")]
    public GameObject DownPanel;
    public GameObject CenterPanel;
    public GameObject UPPanel;
    public GameObject SelectinonPanel;

    public AudioSource audioSource;



    private void Start()
    {
        MS.uIM = this;

        audioSource = GetComponent<AudioSource>();
    }


    public void ResRefresh()
    {
        float round = (int)MS.playerM.Gold;
        GOLDtext.text = round.ToString();
        Placetext.text = MS.playerM.Place.ToString();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            pRay = CurCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(pRay, out pHit))
            {
               if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (pHit.collider.GetComponent<ISelectedEntity>() != null)
                    {
                        Selected(pHit.collider.gameObject);
                        
                    }
                    else
                    {
                        if (pHit.collider.tag == "Terrain")
                        {
                        //    Debug.Log("Terrain");
                        }
                        else
                        {
                            Debug.Log(pHit.collider.gameObject);
                        }
                    }
                }

            }
        }
    }


    public void Selected(GameObject _GO)
    {    
        if (selectedGO != null)
        selectedGO.GetComponent<ISelectedEntity>().unSelected();
        selectedGO = _GO;
        selectedGO.GetComponent<ISelectedEntity>().Selected();

    }
  

}
 