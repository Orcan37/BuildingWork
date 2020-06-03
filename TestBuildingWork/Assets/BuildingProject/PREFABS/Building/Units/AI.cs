using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    public GameObject currentTarget;
    private NavMeshAgent agent;
    public List<GameObject> targets;
    public Entity entityThis;
    bool enterEnemy =false;
    void Start()
    {
        entityThis = GetComponent<Entity>(); // находим все цели которые нужно убить

        agent = GetComponent<NavMeshAgent>();
        FindEnemy();
    }

    void FindEnemy()
    {
        targets.Clear();
        Entity[] entity = GameObject.FindObjectsOfType<Entity>();
        for (int j = 0; j < entity.Length; j++)
        {
            if (entity[j].owner != entityThis.owner)
            {
                targets.Add(entity[j].gameObject);
            }
        }
        StartCoroutine(GetClosestTarget());
    }




    //void FixedUpdate()
    //{
    //    if(curTarget == null)
    //    { 
    //    agent.SetDestination(curTarget.position);
    //    }
    //}

    IEnumerator GetClosestTarget()
    {
        float tmpDist = float.MaxValue;
        currentTarget = null;
        for (int i = 0; i < targets.Count; i++)
        {
            if (agent.SetDestination(targets[i].transform.position))
            {
                //ждем пока вычислится путь до цели
                while (agent.pathPending)
                {
                    //    Debug.Log("Бегу"); ;
                    yield return null;
                }
                //  Debug.Log(agent.pathStatus.ToString()  + "5555");
                // проверяем, можно ли дойти до цели
                if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
                {
                    float pathDistance = 0;
                    //вычисляем длину пути
                    pathDistance += Vector3.Distance(transform.position, agent.path.corners[0]);
                    for (int j = 1; j < agent.path.corners.Length; j++)
                    {
                        pathDistance += Vector3.Distance(agent.path.corners[j - 1], agent.path.corners[j]);
                    }

                    if (tmpDist > pathDistance)
                    {
                        tmpDist = pathDistance;
                        currentTarget = targets[i];
                        agent.ResetPath();
                    }
                }
                else
                {
                    Debug.Log("невозможно дойти до " + targets[i].name);
                }

            }

        }
        if (currentTarget != null)
        {
            agent.SetDestination(currentTarget.transform.position);
            //  entityThis.Attack();
            //  Debug.Log("Дошел ");

            //  дальше ваша логика движения к цели
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>().owner != entityThis.owner)
        //   if(other.tag == "Player")
        {
            //Enemy.GetComponent<NavMeshAgent>().enabled = true;
            //Enemy.GetComponent<Animator>().SetTrigger("walk");
            // Enemy = other.gameObject;

            //  other.gameObject.GetComponent<Entity>().Damage(entityThis.damage);
            //  Debug.Log("ВОЙНА!!!  ");
            enterEnemy = true;
            StartCoroutine(GetAttack());
        }
    }

    IEnumerator GetAttack()
    {

        // yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(3f);
        while (currentTarget != null && currentTarget.GetComponent<Entity>().currentHealth > 1)
        {
            
          agent.SetDestination(currentTarget.transform.position);
            //yield return null;
           if( enterEnemy == true) currentTarget.GetComponent<Entity>().Damage(entityThis.damage);
            Debug.Log(Time.deltaTime);
            yield return new WaitForSeconds(3f);
        }
       
        enterEnemy = false;
        yield return new WaitForSeconds(1f);
        FindEnemy();
    }



}
