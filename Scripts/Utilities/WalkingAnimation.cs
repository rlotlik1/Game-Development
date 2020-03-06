using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimation : MonoBehaviour
{
    Animator walk;
    private float timer;
    private float waitTime;
    private bool walking;
    private Vector3 currentLocation;
    private Vector3 previousLocation;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitTime = 1.5f;
        walking = false;

        currentLocation = new Vector3(0,0,0);

        previousLocation = currentLocation;

        walk = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(previousLocation != currentLocation)
        {
            previousLocation = currentLocation;
            walk.SetBool("Walking", true);
            timer = 0;
            walking = true;

        }
        else if(previousLocation == currentLocation && walking && timer < waitTime)
        {
            timer += Time.deltaTime;
        }
        else if (previousLocation == currentLocation && timer > waitTime)
        {
            timer = 0;
            walk.SetBool("Walking", false);
            walking = false;
        }

            currentLocation = new Vector3(transform.localPosition.x,
                                      transform.position.y,
                                      transform.position.z);
    }
}
