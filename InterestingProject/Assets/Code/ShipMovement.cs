using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody rb = null;
    private Camera cam = null;

    private void Awake()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        float speedMultiply = Input.GetAxis("Vertical");
        float currentSpeed = 1f + speedMultiply * speed;
        rb.AddForce(transform.forward * currentSpeed, ForceMode.Impulse);
    }
}
