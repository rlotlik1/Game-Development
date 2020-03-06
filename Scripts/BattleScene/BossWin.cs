using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWin : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject reward;
    [SerializeField] private GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(boss == null)
        {
            AudioManager.PlaySound("levelUp", 1f);
            reward.SetActive(true);
            ground.SetActive(true);
            winText.SetActive(true);
            Destroy(gameObject);
        }
    }
}
