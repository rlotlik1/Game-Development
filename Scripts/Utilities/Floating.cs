using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 20.0f;
    [SerializeField] private float floatAmplitude = 1f;
    [SerializeField] private float floatFrequency = 1f;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        Vector3 temPos = startPos;
        temPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFrequency)
                    * floatAmplitude;
        transform.position = temPos;
    }
}
