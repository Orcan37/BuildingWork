using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    public List<DataItem> item;
    private void Start()
    {
        Debug.Log("HELLO ItemView");
        foreach (var i in item)  // напишет называния СО
            Debug.Log(i.header);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { item[0].countInStack++; } // в файле самом преобразование делает прибавляя к пеерменной

        if (Input.GetKeyDown(KeyCode.M)) 
        {
            DataItem tempObj = ScriptableObject.CreateInstance<DataItem>();

            tempObj.header = "Мясо";
            tempObj.countInStack = 20;
            // создаст в этой папке по время игры данный файл с заданными тут характеристиками и с нозванием
            UnityEditor.AssetDatabase.CreateAsset(tempObj, "Assets/Items/NewItemNameEat.asset"); 
        }

    }


}
