using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// https://www.youtube.com/watch?v=1OxePhfzZfs&list=PLYbjKfBW1UWn0hcGCfO0N_86YVI5StttD&index=14

//   [CreateAssetMenu(menuName = "Data/DataItem")] // можно и так
 [CreateAssetMenu(menuName = "Data/DataItem", fileName = "Name Item")] // fileName при создании как будет называеться
public class DataItem : ScriptableObject
{
    [SerializeField] RawImage imageIcon;
    [SerializeField] Sprite sprite;
    public string header;
    public int countInStack;
}
