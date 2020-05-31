using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{

    public int addPlace = 3;

    public override void Awake()
    {
        
        base.Awake();
        Invoke("Apply", 0.1f);
 
    }
    void Apply()
    {
        MS.playerM.place += addPlace;
    }

    void OnDestroy()
    {
        MS.playerM.place -= addPlace;
    }

}
