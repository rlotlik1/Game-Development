using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIsZone : MonoBehaviour
{
    [SerializeField] private int xpPoints = 100;
    [SerializeField] private int coins = 100;
    [SerializeField] private int ammo = 1;

    [SerializeField] private GameObject infoSign;
    [SerializeField] private GameObject topCover;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject outOfRange;
    [SerializeField] private GameObject collectButton;
    [SerializeField] private GameObject businessImage;

    private bool insideZone;
    private bool collected;

    private void Start()
    {
        insideZone = false;
        collected = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            insideZone = true;
            RevealInfo(insideZone);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            insideZone = false;
            RevealInfo(insideZone);
        }
    }

    private void RevealInfo(bool inside)
    {
        if (inside)
        {
            if(!collected)
            {
                businessImage.SetActive(true);
                collectButton.SetActive(true);
                continueButton.SetActive(false);
            }
            
            infoSign.SetActive(true);
            topCover.SetActive(false);
            outOfRange.SetActive(false);

        }
        else
        {
            if (!collected)
            {
                businessImage.SetActive(true);
                collectButton.SetActive(false);
                continueButton.SetActive(true);
            }

            infoSign.SetActive(false);
            topCover.SetActive(true);
            outOfRange.SetActive(true);
        }

    }

    public void Collect()
    {
        collected = true;
        collectButton.SetActive(false);
        continueButton.SetActive(true);
        businessImage.SetActive(false);

        AudioManager.PlaySound("poiCollect", 1);
        GameManager.Instance.CurrentPlayer.AddVar(xpPoints, coins, ammo);
    }
}
