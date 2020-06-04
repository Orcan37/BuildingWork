using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAI : MonoBehaviour
{

    public GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target )
        {
           
            target.GetComponent<Entity>().Damage(5);

            Destroy(this.gameObject);
        }
    }


}