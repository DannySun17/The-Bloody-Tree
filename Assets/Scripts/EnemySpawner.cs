using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int postion_x;
    public int postion_z;
    public int enemyCount;

private void Start() 
{
StartCoroutine(EnemySpawn());    
}


   IEnumerator EnemySpawn()
   {
    while(enemyCount < 10)
    {
        postion_x = Random.Range(1,50);
        postion_z = Random.Range(1,30);
        Instantiate(enemy, new Vector3(postion_x, 1, postion_z), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        enemyCount +=1;

    }
   }
}
