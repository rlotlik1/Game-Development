using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TO BE REPLACE WITH ROBOT SCRIPT IN THE FUTURE
public class Enemy : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 20;
    [SerializeField] private int rotateSpeed = 10;
    [SerializeField] private int health = 2;
    [SerializeField] private GameObject explosion;
    
    private Transform target;

    void Start()
    {
        GameObject playerPosition = GameObject.FindGameObjectWithTag("Player");
        target = playerPosition.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotateSpeed * Time.deltaTime);

        //Move to player
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if(health == 50)
            {
                explosion.SetActive(true);
                Instantiate(explosion, explosion.transform.position, Quaternion.identity);
                AudioManager.PlaySound("explosion", 0.8f);
            }

            if (health > 0)
            {
                AudioManager.PlaySound("enemyHit", 0.4f);
                Destroy(collision.gameObject);
                health--;
            }
            else
            {
                explosion.SetActive(true);
                Instantiate(explosion, explosion.transform.position, Quaternion.identity);
                AudioManager.PlaySound("explosion", 0.8f);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }

        }
        else if (collision.gameObject.CompareTag("Center"))
        {
                explosion.SetActive(true);
                AudioManager.PlaySound("explosion", 0.8f);
                Destroy(collision.gameObject);
                Instantiate(explosion, explosion.transform.position, Quaternion.identity);
                Destroy(gameObject);
        }
    }
}
