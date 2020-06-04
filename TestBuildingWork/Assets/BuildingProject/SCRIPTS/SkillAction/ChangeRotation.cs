using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "DataAction/ChangeRotation")]
public class ChangeRotation : Skill
{
    public float speed = 1;
    public float culdawn = 10;
    public float timerWork = 3;
    public override void Apply(GameObject _obj)
    {
        _obj.transform.Rotate(Vector3.one * speed);
    }




}
