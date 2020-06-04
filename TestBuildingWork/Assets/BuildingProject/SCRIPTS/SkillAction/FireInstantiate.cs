using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireInstantiate : MonoBehaviour
{
    public Owner owner = Owner.Player1;
    public GameObject target;
    public GameObject FireMan;
    public bool enterEnemy =false;
    private void OnTriggerEnter(Collider other)
    {if(other.gameObject.GetComponent<Entity>() != null) { 
        if (other.gameObject.GetComponent<Entity>().owner !=  owner && enterEnemy == false)
        {
                enterEnemy = true;
            Debug.Log("owner" + owner);
            target = other.gameObject;
            StartCoroutine(GetInstanse());
        }
            }
    // запустить процесс создание шаров коронтина 
    }

    // тут должен постоянно делать чуваков  которые будут нападать на пока жив таргет Через 3 секунды убивать
    IEnumerator GetInstanse()
    {  
            // yield return new WaitForSeconds(3f);

            yield return new WaitForSeconds(3f);
            while (target != null)
            {
            GameObject clon = Instantiate(FireMan,  this.transform.position, this.transform.rotation);
            clon.transform.SetParent(this.transform);
       
            var agent = clon.GetComponent<NavMeshAgent>();
            agent.SetDestination(target.transform.position);
                clon.GetComponent<FireAI>().target = target;
            //  Destroy(clon, 3); 
            yield return new WaitForSeconds(3f);
        }
        enterEnemy = false;
    }







}
