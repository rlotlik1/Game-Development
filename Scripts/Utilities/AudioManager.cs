using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip clickS, poiCollect, mustDestroy, robotRock,
                            levelUp, thump, laserCannon, explosion, enemyHit,
                            reward, chestOpen, outOfAmmo;
    static AudioSource audioSrc;

    // Use this for initialization
    void Start()
    {
        clickS = Resources.Load<AudioClip>("Audio/click");
        levelUp = Resources.Load<AudioClip>("Audio/levelUp");
        poiCollect = Resources.Load<AudioClip>("Audio/poiCollect");
        mustDestroy = Resources.Load<AudioClip>("Audio/mustDestroy");
        robotRock = Resources.Load<AudioClip>("Audio/rockRobot");
        thump = Resources.Load<AudioClip>("Audio/thump");
        laserCannon = Resources.Load<AudioClip>("Audio/laserCannon");
        explosion = Resources.Load<AudioClip>("Audio/boom");
        enemyHit = Resources.Load<AudioClip>("Audio/bulletBounce");
        reward = Resources.Load<AudioClip>("Audio/goodResult");
        chestOpen = Resources.Load<AudioClip>("Audio/chestCrack");
        outOfAmmo = Resources.Load<AudioClip>("Audio/emptyAmmo");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip,float vol)
    {
        switch (clip)
        {
            case "click":
                audioSrc.PlayOneShot(clickS, vol);
                break;
            case "poiCollect":
                audioSrc.PlayOneShot(poiCollect, vol);
                break;
            case "mustDestroy":
                audioSrc.PlayOneShot(mustDestroy, vol);
                break;
            case "robotRock":
                audioSrc.PlayOneShot(robotRock, vol);
                break;
            case "levelUp":
                audioSrc.PlayOneShot(levelUp, vol);
                break;
            case "thump":
                audioSrc.PlayOneShot(thump, vol);
                break;
            case "laserCannon":
                audioSrc.PlayOneShot(laserCannon, vol);
                break;
            case "explosion":
                audioSrc.PlayOneShot(explosion, vol);
                break;
            case "enemyHit":
                audioSrc.PlayOneShot(enemyHit, vol);
                break;
            case "reward":
                audioSrc.PlayOneShot(reward, vol);
                break;
            case "chestOpen":
                audioSrc.PlayOneShot(chestOpen, vol);
                break;
            case "outOfAmmo":
                audioSrc.PlayOneShot(outOfAmmo, vol);
                break;
        }
    }

    public static void StopSound()
    {
        audioSrc.Stop();
    }
}
