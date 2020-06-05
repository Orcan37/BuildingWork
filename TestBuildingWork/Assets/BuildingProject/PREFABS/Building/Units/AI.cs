using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.AI;

public partial class Entity : MonoBehaviour
{

    public GameObject currentTarget;
    private NavMeshAgent agent;
    public List<GameObject> targets;

    public bool enterEnemy = false;
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
        if (targets.Count <= 0)
        {
            StartCoroutine(GetFindEnemyAlways()); return;
        }
        //   MainThreadDispatcher.StartUpdateMicroCoroutine(GetClosestTarget());
        StartCoroutine(GetClosestTarget());
    }

    void currentTargetObs()
    {

    }

    IEnumerator GetFindEnemyAlways()
    {
        yield return new WaitForSeconds(5f);
        FindEnemy();

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
        if (currentTarget != null)
        {
            agent.SetDestination(currentTarget.transform.position);
            //currentTargetObs();
        }

    }

    static object block = new object();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>() != null)
        {
         
            if (enterEnemy == false && speed > 0 && owner != other.gameObject.GetComponent<Entity>().owner)
            {
        
                enterEnemy = true;
                StartCoroutine(GetAttack());
           
                //    MainThreadDispatcher.StartUpdateMicroCoroutine(GetClosestTarget());
            }
        }
    }

    IEnumerator GetAttack()
    {
        int r = 0;
        currentTarget.OnDestroyAsObservable()
   .Select(_ => currentTarget.gameObject.name)
 .Subscribe(_ => enterEnemy = false, __ => FindEnemy()).AddTo(this.gameObject);

        yield return new WaitForSeconds(3f);
     
        while (currentTarget != null && currentTarget.GetComponent<Entity>().currentHealth > 1 && enterEnemy == true)
        {

            agent.SetDestination(currentTarget.transform.position);
            r++;
            currentTarget.GetComponent<Entity>().Damage(damage); Debug.Log("Аатка " + r);

            yield return new WaitForSeconds(3f);
        }

        enterEnemy = false;
        yield return new WaitForSeconds(1f);
        FindEnemy();

    }




}
