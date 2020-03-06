using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidExit : MonoBehaviour
{
    [SerializeField] private GameObject exitMenu;
    [SerializeField] private GameObject blocker;

    IEnumerator Start()
    {
        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start();

    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                exitMenu.SetActive(true);
                blocker.SetActive(true);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
