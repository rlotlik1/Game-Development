using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject reward;
    [SerializeField] private GameObject ground;
    [SerializeField] private int enemyCount = 20;
    [SerializeField] private float minRange = 50.0f;
    [SerializeField] private float maxRange = 120.0f;
    [SerializeField] private float spawnTime = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            float x = player.transform.position.x + GenerateRange();
            float y = player.transform.position.y + Random.Range(-20, 30);
            float z = player.transform.position.z + GenerateRange();

            Instantiate(enemy, new Vector3(x, y, z), Quaternion.identity);

            yield return new WaitForSeconds(spawnTime - (i/20));
        }

        yield return new WaitForSeconds(10f);
        AudioManager.PlaySound("levelUp", 1f);
        reward.SetActive(true);
        ground.SetActive(true);
        winText.SetActive(true);
    }

    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);
    }
}
