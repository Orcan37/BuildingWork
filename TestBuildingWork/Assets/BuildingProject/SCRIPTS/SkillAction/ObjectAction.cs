using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAction : MonoBehaviour
{
    public List<DataAction> dataAction;
    private void Update() // поставить на 10 секунд
    {
        foreach(var i in dataAction)
        {
            i?.Change(transform);
        }
    }
}
