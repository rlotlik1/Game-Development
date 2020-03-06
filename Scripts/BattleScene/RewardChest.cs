using System.Collections;
using UnityEngine;

public class RewardChest : MonoBehaviour
{
    [SerializeField] private int health = 40;
    [SerializeField] private GameObject rewards;

    private Animator chest;
    private int currentHealth;
    private bool opened;

    void Start()
    {
        //Initializing
        currentHealth = health;
        opened = false;
        chest = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!opened)
        {
            //If collide with bullet
            if (collision.gameObject.CompareTag("Bullet"))
            {
                //Open chest when health reach zero
                if (currentHealth > 0)
                {
                    AudioManager.PlaySound("enemyHit", 0.4f);

                    //Destroy bullet
                    Destroy(collision.gameObject);
                    chest.SetTrigger("ShotAt");
                    currentHealth--;
                }
                else
                {
                    //Destroy bullet
                    Destroy(collision.gameObject);
                    chest.SetBool("Opened", true);
                    opened = true;

                    AudioManager.PlaySound("chestOpen",0.6f);
                    AudioManager.PlaySound("reward", 0.8f);

                    StartCoroutine(OpenReward());
                }
            }
        }
    }

    //Wait a second before set active reward UI
    private IEnumerator OpenReward()
    {
        yield return new WaitForSeconds(1f);
        rewards.SetActive(true);
    }

}
