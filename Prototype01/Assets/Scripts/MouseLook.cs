﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerModel;

    float rotateX = 0f;
    float rotateY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotateY -= mouseY;
        rotateY = Mathf.Clamp(rotateY, -45f, 60f);

        transform.localRotation = Quaternion.Euler(rotateY, 0f, 0f);
        playerModel.Rotate(Vector3.up * mouseX);
    }
}
