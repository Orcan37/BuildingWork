using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/TowerSkill", fileName = "Name TowerSkill")]
public class TowerSkill : Skill
{
    public GameObject UnitCollayder;
    public override void StartInstanse(GameObject _obj)
    {
        GameObject clon = Instantiate(UnitCollayder, _obj.transform.position, _obj.transform.rotation);
        clon.transform.SetParent(_obj.transform);
        clon.GetComponent<FireInstantiate>().owner = _obj.GetComponent<Entity>().owner;
    }
    
}
