using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShipRotation : MonoBehaviour
{
    private Rigidbody rb = null;
    [SerializeField] private float rotateSpeed = 1f;
    [SerializeField] private float horizontalRotateSpeed = 1f;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * rotateSpeed;
        rb.AddRelativeTorque(new Vector3(-mouseDelta.y, mouseDelta.x, 
            -Input.GetAxis("Horizontal") * horizontalRotateSpeed)
            * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    
}
