using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float health;
    public float speed;
    public float damage;

    public Transform target;
    public float chaseRadius;


private void Start() 
{
    target = GameObject.FindGameObjectWithTag("Player").transform;

}

    void Update()
    {
    CheckDistance();
    }


    void CheckDistance()
   {  
     if(Vector3.Distance(target.position, transform.position) <= chaseRadius)
     {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed *  Time.deltaTime);
     }
}
}
