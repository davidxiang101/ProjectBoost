using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustForce = 100;
    [SerializeField] float rotationForce = 100;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
         if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-1f);
        }
    }

    void ApplyRotation(float scale)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * scale * rotationForce * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
