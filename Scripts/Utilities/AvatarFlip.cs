using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarFlip : MonoBehaviour
{
    [SerializeField] private GameObject av1;
    [SerializeField] private GameObject av2;
    [SerializeField] private GameObject av3;
    [SerializeField] private GameObject av4;
    [SerializeField] private GameObject av5;
    [SerializeField] private GameObject av6;

    // Start is called before the first frame update

    public void ClickedOn()
    {
        if (av1.activeSelf)
        {
            av1.SetActive(false);
            av2.SetActive(true);
            av3.SetActive(false);
            av4.SetActive(false);
            av5.SetActive(false);
            av6.SetActive(false);
        }
        else if(av2.activeSelf)
        {
            av1.SetActive(false);
            av2.SetActive(false);
            av3.SetActive(true);
            av4.SetActive(false);
            av5.SetActive(false);
            av6.SetActive(false);
        }
        else if (av3.activeSelf)
        {
            av1.SetActive(false);
            av2.SetActive(false);
            av3.SetActive(false);
            av4.SetActive(true);
            av5.SetActive(false);
            av6.SetActive(false);
        }
        else if (av4.activeSelf)
        {
            av1.SetActive(false);
            av2.SetActive(false);
            av3.SetActive(false);
            av4.SetActive(false);
            av5.SetActive(true);
            av6.SetActive(false);
        }
        else if (av5.activeSelf)
        {
            av1.SetActive(false);
            av2.SetActive(false);
            av3.SetActive(false);
            av4.SetActive(false);
            av5.SetActive(false);
            av6.SetActive(true);
        }
        else
        {
            av1.SetActive(true);
            av2.SetActive(false);
            av3.SetActive(false);
            av4.SetActive(false);
            av5.SetActive(false);
            av6.SetActive(false);
        }

    }
}
