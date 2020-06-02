using UnityEngine;
[CreateAssetMenu(menuName = "Data/SkillData/collectResSkill")]
public class collectResSkill : Skill 
{
    public override void Apply(GameObject entity)
    {
        entity.GetComponent<Building>().collectResources();
    }
}
