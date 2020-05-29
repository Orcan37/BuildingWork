using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectResSkill : Skill
{

    public override void Apply(Entity entity)
    {
        entity.GetComponent<Building>().collectResources();
    }

}
