using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowUltimate;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Vector3 offset = new Vector3();
    [SerializeField] private float smooth = 4f;
    [SerializeField] private float rotateSpeed = 30f;

    private void LateUpdate()
    {
        Vector3 newPos = target.position
            + target.right * offset.x
            + target.up * offset.y
            + target.forward * offset.z;
        
        transform.position = new Vector3(
            Mathf.SmoothStep(transform.position.x, newPos.x, smooth * Time.fixedDeltaTime),
            Mathf.SmoothStep(transform.position.y, newPos.y, smooth * Time.fixedDeltaTime),
            Mathf.SmoothStep(transform.position.z, newPos.z, smooth * Time.fixedDeltaTime));

        transform.LookAt(target);
    }
}
