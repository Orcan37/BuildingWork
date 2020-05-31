using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectResSkill : Skill
{

    public override void Apply(GameObject entity)
    {
        entity.GetComponent<Building>().collectResources();
    }

}
