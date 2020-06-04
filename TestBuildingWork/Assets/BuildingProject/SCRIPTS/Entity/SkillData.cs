using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/SkillData", fileName = "Name Item")]
public abstract class SkillData : ScriptableObject
{
    public abstract  void Apply(GameObject entity);
    public abstract void Change(Transform _obj);
    public abstract void StartInstanse(GameObject _obj);
}


