using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int postion_x;
    public int postion_z;
    public int enemyCount;
    public int xRange1;
    public int xRange2;
    public int zRange1;
    public int zRange2;
    public List<GameObject> enemyList;
    public int maxEnemies;

private void Start() 
{
}


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

    postion_x = Random.Range(xRange1,xRange2);
    postion_z = Random.Range(zRange1,zRange2);

    GameObject enemy = Instantiate(enemyPrefab, new Vector3(postion_x, 1, postion_z), Quaternion.identity);
    enemyList.Add(enemy);
    yield return new WaitForSeconds(0.5f);
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
}
