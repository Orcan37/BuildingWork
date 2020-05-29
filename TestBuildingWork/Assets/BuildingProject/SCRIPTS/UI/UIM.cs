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



    [Header("Switch Panel && Camera")]
    public GameObject сenterDownPanel;
    //  public Camera camDown;   // на объектах самих должна быть камера и выключать ее не надо от сюда на объекте
    public GameObject сenterCenterPanel;
    public GameObject сenterUPPanel;
    public GameObject сenterSelectinonPanel;
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


    private void Start()
    {
        MS.uIM = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void SwitchPanel(GameObject _pDown, int _closePanel = 0) // камеру удалить наверно надо хотел несколько разных UI
    {

        //  if (!_camera) _camera.enabled = false;
        switch (_closePanel) // какую панель вместе с ним нужно закрыть или не надо
        {

            case 1:
                if (сenterDownPanel) сenterDownPanel.SetActive(false); сenterDownPanel = _pDown;
                break;
            case 2:
                if (сenterCenterPanel) сenterCenterPanel.SetActive(false); сenterCenterPanel = _pDown;
                break;
            case 3:
                if (сenterUPPanel) сenterUPPanel.SetActive(false); сenterUPPanel = _pDown;
                break;
            case 4:
                if (сenterSelectinonPanel) сenterSelectinonPanel.SetActive(false); сenterSelectinonPanel = _pDown;
                break;
            case 5:

                if (сenterDownPanel) сenterDownPanel.SetActive(false);
                if (сenterCenterPanel) сenterCenterPanel.SetActive(false);
                if (сenterUPPanel) сenterUPPanel.SetActive(false);
                if (сenterSelectinonPanel) сenterSelectinonPanel.SetActive(false);
                break;
            default:

                break;
        }
        _pDown.SetActive(true);
        Debug.Log(_closePanel);
    }

    public void PullPanel(GameObject _pDown, int _closePanel = 0) // камеру удалить намерно надо
    {

        //  if (!_camera) _camera.enabled = false;
        switch (_closePanel) // какую панель вместе с ним нужно закрыть или не надо
        {

            case 1:
                if (сenterDownPanel) сenterDownPanel.SetActive(false); сenterDownPanel = _pDown;
                break;
            case 2:
                if (сenterCenterPanel) сenterCenterPanel.SetActive(false); сenterCenterPanel = _pDown;
                break;
            case 3:
                if (сenterUPPanel) сenterUPPanel.SetActive(false); сenterUPPanel = _pDown;
                break;
            case 4:
                if (сenterSelectinonPanel) сenterSelectinonPanel.SetActive(false); сenterSelectinonPanel = _pDown;
                break;
            case 5:

                if (сenterDownPanel) сenterDownPanel.SetActive(false);
                if (сenterCenterPanel) сenterCenterPanel.SetActive(false);
                if (сenterUPPanel) сenterUPPanel.SetActive(false);
                if (сenterSelectinonPanel) сenterSelectinonPanel.SetActive(false);
                break;
            default:

                break;
        }
        _pDown.SetActive(true);
        Debug.Log(_closePanel);
    }


}
