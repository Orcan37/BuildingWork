 
using UnityEngine;
[CreateAssetMenu(menuName = "Data/SkillData/cameraViewSkill")]
public class cameraView : Skill
{
    public Vector3 positionFromUnit;
    public Vector3 rotationFromUnit;
    public GameObject pref;
     
    public override void Apply(GameObject entity)
        // переделать все сделать чисто 3 камеры и менять расположения камеры UnitUpViever MainCamera UnitDownViewer
        //не надо ничего создавать лишь позиции менять и включать их
    {

        Transform cameraSkill = entity.transform.Find("cameraSkill(Clone)") ;
        if (cameraSkill == null) {  

        GameObject clone1 = Instantiate(pref, positionFromUnit, Quaternion.Euler(rotationFromUnit));
          
        clone1.transform.SetParent(entity.transform, false);
            MS.uIM.CurCamera = clone1.GetComponent<Camera>();
    }
        else{ Destroy(cameraSkill.gameObject); MS.uIM.CurCamera = Camera.main; }
}

 
}
