using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceExplorer : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float mouseSensitivity = 3f;

    float rotationX = 0f;
    float rotationY = 0f;

    void Update()
    {
        // Keyboard movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move * moveSpeed * Time.deltaTime;

        // Mouse look
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);
    }
}
