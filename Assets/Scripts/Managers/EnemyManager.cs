using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public EnemyHealth enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    public int poolAmt;
    public ObjectPool<EnemyHealth> pool;


    void Start()
    {
        pool = new ObjectPool<EnemyHealth>(CreateEnemy, OnTakeEnemyFromPool, OnReturnEnemyToPool, DestroyEnemy, true, 50, 100);

        //InvokeRepeating("Spawn", spawnTime, spawnTime);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (playerHealth.currentHealth > 0f)
        {
            pool.Get();

            yield return new WaitForSeconds(spawnTime);
        }
    }

    EnemyHealth CreateEnemy()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        EnemyHealth pool_enemy = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        pool_enemy.SetPool(pool);

        return pool_enemy;
    }

    void OnTakeEnemyFromPool(EnemyHealth pool_enemy)
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //reset the location
        pool_enemy.transform.position = spawnPoints[spawnPointIndex].position;
        pool_enemy.transform.rotation = spawnPoints[spawnPointIndex].rotation;

        //activate
        pool_enemy.gameObject.SetActive(true);
    }

    void OnReturnEnemyToPool(EnemyHealth pool_enemy)
    {
        pool_enemy.gameObject.SetActive(false);
    }

    void DestroyEnemy(EnemyHealth pool_enemy)
    {
        Destroy(pool_enemy.gameObject);
    }
}
