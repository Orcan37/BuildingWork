using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class BuildMng : MonoBehaviour
{
     
    public BildField bildField;
     
}

[System.Serializable]
public class BildField
{
    [SerializeField] public GameObject BildingArea;
    [SerializeField] public GameObject BildNameInField;

}
