using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/SkillData", fileName = "Name Item")]
public abstract class SkillData : ScriptableObject
{
    public abstract  void Apply(GameObject entity);
}


