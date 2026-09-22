using UnityEngine;

public class ShuttleFollow : MonoBehaviour
{
    public Transform playerCamera;

    void LateUpdate()
    {
        // Follow player's position
        transform.position = playerCamera.position;
    }
}