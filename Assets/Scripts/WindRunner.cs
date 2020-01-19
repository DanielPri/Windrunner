using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindRunner : MonoBehaviour
{

    public float velocity = 5;
    public float rotateSpeed = 5;
    public float mouseSensitivity = 1f;
    public float jumpForce = 10;
    public GameObject cam;
    public float gravity = 9.81f;
    public Transform lash;

    Rigidbody rb;
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
        transform.localRotation = Quaternion.Lerp(rb.rotation, originalRotation * xQuaternion, rotateSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce((gravity * Vector3.down), ForceMode.Acceleration);
        transform.localRotation = lash.rotation;
    }
}
