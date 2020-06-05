 
using UnityEngine;
 

public class EnemyWalk : MonoBehaviour
{
    public GameObject Enemy;
    public float timer;
    public bool yes;
    public float newtimer;
    public Entity thisEnt;
    private void Start()
    {
        newtimer = timer;
        thisEnt = GetComponent<Entity>();
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Entity>().owner != thisEnt.owner)
   //   if(other.tag == "Player")
        {
            //Enemy.GetComponent<NavMeshAgent>().enabled = true;
            //Enemy.GetComponent<Animator>().SetTrigger("walk");
            Enemy = other.gameObject;

            other.gameObject.GetComponent<Entity>().Damage(thisEnt.damage);
              Debug.Log("ВОЙНА!!!  ");
        }
    }
     

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player") ;
    //    yes = true;
    //}

    //private void Update()
    //{
    //    if(yes == true)
    //    {
    //        timer -= Time.deltaTime;
    //    }

    //    if (timer < 0)
    //    {
    //        Enemy.GetComponent<NavMeshAgent>().enabled = false;
    //        yes = false;
    //        timer = newtimer;
    //            Enemy.GetComponent<Animator>().SetTrigger("idle");
    //    }



    //}





}
