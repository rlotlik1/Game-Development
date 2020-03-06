using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanReceipt : MonoBehaviour
{
    [SerializeField] private GameObject reward;

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(4f);

        AudioManager.PlaySound("levelUp", 0.5f);
        reward.SetActive(true);

        Destroy(gameObject);
    }
}