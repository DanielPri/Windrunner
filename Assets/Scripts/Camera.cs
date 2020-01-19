using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target;

    [Range(0.0f, 1.0f)]
    public float smoothness = 50.0f;

    public float turnSpeed = 1f;
    public Vector3 velocity = Vector3.zero;


    private void Start()
    {
    }

    public void Update()
    {
    }

    private void LateUpdate()
    {
        smoothFollow();
    }

    private void smoothFollow()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothness);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * turnSpeed);
    }
}
