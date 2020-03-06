using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginStart : MonoBehaviour
{
    private Image image;
    private bool pause;
    private byte apperance;

    // Start is called before the first frame update
    void Start()
    {
        apperance = 255;
        pause = true;
        image = GetComponent<Image>();

        StartCoroutine(Fade());
    }

    // Update is called once per frame
    void Update()
    {
        if(!pause)
        {
            if (apperance > 1)
            {
                image.color = new Color32(255, 255, 255, apperance);
                apperance--;
                apperance--;
                apperance--;
            }
            else 
            {
                Destroy(gameObject);
            }
        }
        

    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(2f);

        pause = false;
    }
}
