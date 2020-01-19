using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{

    [SerializeField]
    float mouseSensitivity = 1f;

    // Camera Fields
    // used https://answers.unity.com/questions/29741/mouse-look-script.html
    enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    RotationAxes axes = RotationAxes.MouseXAndY;
    float rotationX = 0f;
    float rotationY = 0f;
    float minimumX = -360F;
    float maximumX = 360F;
    float minimumY = -60F;
    float maximumY = 60F;
    Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        lookAround();
    }

    private void lookAround()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            //rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
           // rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
           // Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

            //transform.localRotation = originalRotation * xQuaternion * yQuaternion;
            transform.localRotation = originalRotation * yQuaternion;

        }
        else if (axes == RotationAxes.MouseX)
        {
            //rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
            //rotationX = ClampAngle(rotationX, minimumX, maximumX);
            //Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            //transform.localRotation = originalRotation * xQuaternion;
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle <= -360f)
            angle += 360f;
        if (angle >= 360f)
            angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
