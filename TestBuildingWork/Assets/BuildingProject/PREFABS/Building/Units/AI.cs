using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

public partial class Entity : MonoBehaviour
{

    public GameObject currentTarget;
    private NavMeshAgent agent;
    public List<GameObject> targets;

    bool enterEnemy = false;
    void AIgo()
    {
        {
            agent = GetComponent<NavMeshAgent>();
            FindEnemy();
        }

    }


     

    void FindEnemy()
    {
        targets.Clear();
        Entity[] entity = GameObject.FindObjectsOfType<Entity>();
        for (int j = 0; j < entity.Length; j++)
        {
            if (entity[j].owner != owner)
            {
                targets.Add(entity[j].gameObject);
            }
        }

        //   MainThreadDispatcher.StartUpdateMicroCoroutine(GetClosestTarget());
        StartCoroutine(GetClosestTarget());
    }


    IEnumerator FindEnemyAlways() // постоянно ищем врага
    {
        yield return new WaitForSeconds(5f);
        if (currentTarget == null || !currentTarget.activeSelf)
        {
            StopCoroutine(GetClosestTarget());
            StopCoroutine(GetAttack());
            FindEnemy();
            Debug.Log("FindEnemyAlways");
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine(FindEnemyAlways());
    }


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
        if (currentTarget != null )
        {
            agent.SetDestination(currentTarget.transform.position);
        }
        else
        {
            StartCoroutine(FindEnemyAlways());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>() != null)
        {
            if (speed > 0 && owner != other.gameObject.GetComponent<Entity>().owner)

            {

                enterEnemy = true;
                StartCoroutine(GetAttack());
                //    MainThreadDispatcher.StartUpdateMicroCoroutine(GetClosestTarget());
            }
        }
    }

    IEnumerator GetAttack()
    {

        yield return new WaitForSeconds(3f);
        while (currentTarget != null && currentTarget.GetComponent<Entity>().currentHealth > 1)
        {

            agent.SetDestination(currentTarget.transform.position);

            if (enterEnemy == true) currentTarget.GetComponent<Entity>().Damage(damage);

            yield return new WaitForSeconds(3f);
        }

        enterEnemy = false;
        yield return new WaitForSeconds(1f);
        FindEnemy();

    }



}
