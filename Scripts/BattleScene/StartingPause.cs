using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPause : MonoBehaviour
{
    [SerializeField] private GameObject laserBlaster;
    [SerializeField] private GameObject radar;

    void Start()
    {
        StartCoroutine(waitIntro());
    }

    //Wait for intro to finish to start the game
    IEnumerator waitIntro()
    {
        yield return new WaitForSeconds(2f);

        AudioManager.PlaySound("mustDestroy", 1f);

        //Turn on gyro
        Camera.main.gameObject.GetComponent<Gyro>().enabled = true;

        //Start spawning enemy
        if (gameObject.GetComponent<EnemySpawn>() != null)
        {
            gameObject.GetComponent<EnemySpawn>().enabled = true;
        }

        //Turn on radar
        radar.SetActive(true);

        //Allow player to shoot
        laserBlaster.gameObject.GetComponent<FireLaserAmmo>().enabled = true;
    }

    //Pause and unpause game
    public void PauseGame()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }
}
