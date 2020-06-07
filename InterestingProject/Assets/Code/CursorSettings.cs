using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSettings : MonoBehaviour
{
    [SerializeField] private bool visible = false;
    [SerializeField] private CursorLockMode lockMode = CursorLockMode.Locked;

    private void Start()
    {
        InvokeRepeating("OffCursor", 0, 1);
    }

    private void OffCursor()
    {
        Cursor.visible = visible;
        Cursor.lockState = lockMode;
    }
}
