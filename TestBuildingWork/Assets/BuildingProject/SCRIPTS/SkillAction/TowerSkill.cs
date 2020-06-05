using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PassivSkill/TowerSkill", fileName = "Name TowerSkill")]
public class TowerSkill : PassivSkill
{
    public GameObject UnitCollayder;
    public override void StartInstanse(GameObject _obj)
    {
        GameObject clon = Instantiate(UnitCollayder, _obj.transform.position, _obj.transform.rotation);
        clon.transform.SetParent(_obj.transform);
        clon.GetComponent<FireInstantiate>().owner = _obj.GetComponent<Entity>().owner;
    }
    
}
