using System.Collections;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int enemyCount = 20;
    [SerializeField] private float minRange = -90.0f;
    [SerializeField] private float maxRange = 90.0f;

    private float randNum;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            yield return new WaitForSeconds(7f);

            SpawnBot();
            SpawnBot();
            SpawnBot();
            SpawnBot();
            SpawnBot();
        }
    }

    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);
    }

    private void SpawnBot()
    {
        float x = transform.position.x + GenerateRange();
        float y = transform.position.y + Random.Range(180, 190);
        float z = transform.position.z + GenerateRange();

        Instantiate(enemy, new Vector3(x, y, z), Quaternion.identity);
    }
}
