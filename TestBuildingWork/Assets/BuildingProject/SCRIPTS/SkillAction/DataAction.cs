using System.Collections;
using System.Collections.Generic;
using UnityEngine;




// для создание методов Например для магии 
[CreateAssetMenu(menuName = "ScriptableData/DataAction", fileName = "Name Item")] // fileName при создании как будет называеться

public abstract class DataAction : ScriptableObject
{ 
    public abstract void Change(Transform _obj);
  
}
