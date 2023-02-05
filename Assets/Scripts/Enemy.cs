using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float health;
    private float maxHealth = 100;
    public float speed;
    public int damage;
    
    public GameObject energyPrefab;

    public Transform target;
    public float chaseRadius;


    private void Start() 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }

    void Update()
    {
        CheckDistance();

        if(Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(50);
        }
        if(health <= 0)
        {
            OnDeath();
        }
    }


    void CheckDistance()
    {  
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed *  Time.deltaTime);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;     
    }


    void OnDeath() 
    {
        Destroy(gameObject);
        Debug.Log("Is Dead");
        
        GameObject energy = Instantiate(energyPrefab, transform.position, Quaternion.identity) as GameObject;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PrincipalRoot"))
        {
            TakeDamage(100);
        }

        if (other.gameObject.CompareTag("Tree"))
        {
            other.gameObject.GetComponent<Tree>().TakeDamage(damage);
            TakeDamage(100);
        }
    }

}

