using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShipRotation : MonoBehaviour
{
    private Rigidbody rb = null;
    [SerializeField] private float rotateSpeed = 1f;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        rb.AddRelativeTorque(new Vector3(-mouseDelta.y, mouseDelta.x, 0) * rotateSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
