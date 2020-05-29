using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    [Header("RESURS")]
   public int Place;
    public float Gold ;

    private void Start()
    {
        MS.playerM = this;
    }

    public float gold
    {
        get { return Gold; }
        set { Gold =  value ; MS.uIM.ResRefresh();  }
    }
    public int place
    {
        get { return Place; }
        set { Place = value; MS.uIM.ResRefresh(); }
    }

}

