using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [Header("Specifications")]
    [SerializeField] float xVelocity;
    [SerializeField] float yForce;
    [SerializeField] Vector3 startedPosition;

    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        transform.position = startedPosition;
    }

    public void MoveLeft()
    {
        if (rb)
        {
            rb.AddForce(Vector3.up * yForce, ForceMode.Impulse);
            rb.velocity = Vector3.right * -xVelocity;
        }
    }

    public void MoveRight()
    {
        if (rb)
        {
            rb.AddForce(Vector3.up * yForce, ForceMode.Impulse);
            rb.velocity = Vector3.right * xVelocity;
        }
    }
}
