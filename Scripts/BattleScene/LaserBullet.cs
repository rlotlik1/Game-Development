using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [SerializeField] private float speed = 240f;
    [SerializeField] private float duration = 1.2f;

    private float lifeTimer;

    private void Start()
    {
        //Initializing
        lifeTimer = duration;
        transform.Rotate(90, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moving object forward based on speed
        transform.position += transform.up * speed * Time.deltaTime;

        //Destroy object when based on lifetimer
        lifeTimer -= Time.deltaTime;

        if(lifeTimer <=0)
        {
            Destroy(gameObject);
        }
    }
}
