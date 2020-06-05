using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : SkillData
{
    public string nameSkill;
    public Sprite spriteS;
 //[HideInInspector]
    public bool passivSkill = false;

    public override void Apply(GameObject entity)
    {
        throw new System.NotImplementedException();
    }
    public override void Change(Transform _obj) {

        throw new System.NotImplementedException();

    }
    public override void StartInstanse(GameObject _obj)
    { 
        throw new System.NotImplementedException(); 
    }

}
