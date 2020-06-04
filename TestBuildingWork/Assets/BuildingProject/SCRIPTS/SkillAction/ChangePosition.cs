using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "DataAction/ChangePosition")]
public class ChangePosition : DataAction
{
    
        public float amplitude = 1;

    public override void Change(Transform _obj)
        {
        _obj.position = Vector3.right * Mathf.Sin(Time.time) * amplitude;
        }
     
}
