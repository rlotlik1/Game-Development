using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireLaserAmmo : MonoBehaviour
{
    [SerializeField] private int maxedAmmo = 100;
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject fireParticle;
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject reloadMenu;
    [SerializeField] private GameObject pausedMenu;
    [SerializeField] private Slider ammoSlider;
    [SerializeField] private Image reloadProgress;
    [SerializeField] private Text ammoText;

    private int currentAmmo;

    private Animator fire;
    private bool hold = false;

    private ParticleSystem fireEffect;

    void Start()
    {
        //Initializing
        currentAmmo = maxedAmmo;
        ammoSlider.maxValue = maxedAmmo;
        fire = cannon.GetComponent<Animator>();
        fireEffect = fireParticle.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //Fire laser when ammo is not zero and game is not paused
        if (Input.touchCount > 0 && !hold && currentAmmo > 0 && !pausedMenu.activeSelf)
        {
            AudioManager.PlaySound("laserCannon", 0.4f);
            fire.SetTrigger("Fire");
            fireEffect.Play();

            GameObject laserBullet = Instantiate(laser);

            laserBullet.transform.position = cannon.transform.position + Camera.main.transform.forward;
            laserBullet.transform.forward = Camera.main.transform.forward;
            hold = true;

            currentAmmo--;
        }
        //Prevent bullet from firing if hold
        else if(Input.touchCount == 0)
        {
            hold = false;
            reloadProgress.fillAmount = 0;
        }
        //Hold to reload
        else if (Input.touchCount > 0 && currentAmmo <= 0)
        {
            reloadProgress.fillAmount += Time.deltaTime;
        }

        //Turn off reload screen when done reloading
        if(reloadProgress.fillAmount >= 1)
        {
            reloadProgress.fillAmount = 0;
            currentAmmo = maxedAmmo;
            reloadMenu.SetActive(false);
        }

        Reload();
        UpdateAmmoUI();
    }

    //Update ammo text and slider bar
    void UpdateAmmoUI()
    {
        ammoSlider.value = currentAmmo;
        ammoText.text = currentAmmo.ToString();
    }

    //Turn on reload screen when ammo is 0
    void Reload()
    {
        if (currentAmmo <= 0)
        {
            if(!reloadMenu.activeSelf)
            {
                AudioManager.PlaySound("outOfAmmo", 1f);
            }

            reloadMenu.SetActive(true); 
        }
    }
}
