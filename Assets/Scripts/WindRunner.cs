using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindRunner : MonoBehaviour
{

    public float velocity = 5;
    public float rotateSpeed = 5;
    [SerializeField]
    float mouseSensitivity = 1f;
    Rigidbody rb;
    public GameObject cam;


    Vector3 lateral_motion;
    Vector3 forward_motion;
    float rotationX;
    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        
        lateral_motion = transform.right * Input.GetAxisRaw("Horizontal");
        forward_motion = transform.forward * Input.GetAxisRaw("Vertical");
        
        rb.MovePosition(rb.position + (lateral_motion + forward_motion).normalized * velocity * Time.deltaTime);
        rotationX += Input.GetAxis("Mouse X") * rotateSpeed;
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        rb.rotation = originalRotation * xQuaternion;
    }
}
