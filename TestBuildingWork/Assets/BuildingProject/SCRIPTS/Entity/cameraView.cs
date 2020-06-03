 
using UnityEngine;
[CreateAssetMenu(menuName = "Data/SkillData/cameraViewSkill")]
public class cameraView : Skill
{
    public Vector3 positionFromUnit;
    public Vector3 rotationFromUnit;
    public  GameObject pref;

    public override void Apply(GameObject entity)
    {    //Vector3.x.
      
        GameObject clone1 = Instantiate(pref,  positionFromUnit, Quaternion.Euler(rotationFromUnit)   );

        clone1.transform.SetParent(entity.transform, false);

        //    GameObject clone1 = Instantiate(prefabHealing).transform.SetParent(Instantiate(prefabPlayer).transform)
        //      entity.transform.rotation);

        //     entity.GetComponent<Building>().collectResources();
    }

}
