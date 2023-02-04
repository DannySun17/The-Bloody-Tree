using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int postion_x;
    public int postion_z;
    public int enemyCount;
    public List<GameObject> enemyList;
    public int maxEnemies;
    public int distance;


private void Update() 
{
    if(Input.GetKeyDown(KeyCode.K))
    {
        ClearEnemy();
    }
}

IEnumerator EnemySpawn()
{
    while(enemyCount < maxEnemies)
{



int i = Random.Range(0,1);
    
postion_x = RandomBool(distance);
postion_z = Random.Range(-distance,distance);


GameObject enemy = Instantiate(enemyPrefab, new Vector3(postion_x, 1, postion_z), Quaternion.identity);
enemyList.Add(enemy);
yield return new WaitForSeconds(0.8f);
enemyCount +=1;

}
}

   void ClearEnemy()
   {
    foreach(GameObject enemy in enemyList)
    {
        Destroy(enemy);
    }

    enemyList.Clear();
    enemyCount =0;
    StartCoroutine(EnemySpawn());    

   }

   int RandomBool(int val)
   {

    int test;

    if (Random.value > 0.5f)
    {
        test = val;
    }
    else
    {
        test = -val;
    }

    return test;
   }
}

