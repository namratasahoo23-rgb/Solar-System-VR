using UnityEngine;
using Valve.VR;

public class ShuttleVRMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float turnSpeed = 60f;
    public float verticalSpeed = 6f;

    [Header("SteamVR Input")]
    public SteamVR_Action_Boolean moveForwardAction;
    public SteamVR_Action_Boolean moveBackwardAction;

    public SteamVR_Input_Sources forwardHand = SteamVR_Input_Sources.RightHand;
    public SteamVR_Input_Sources backwardHand = SteamVR_Input_Sources.LeftHand;

    [Header("Controller Reference")]
    public Transform rightHandTransform;

    [Header("Tilt Settings")]
    public float tiltThreshold = 10f;   // minimum tilt before movement starts
    public float maxTiltAngle = 30f;    // tilt amount for full input

    void Update()
    {
        HandleForwardBackwardMovement();
        HandleTurning();
        HandleVerticalMovement();
    }

    void HandleForwardBackwardMovement()
    {
        // Forward
        if (moveForwardAction != null && moveForwardAction.GetState(forwardHand))
        {
            // keep Vector3.back if your shuttle model faces opposite direction
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.Self);
        }

        // Backward
        if (moveBackwardAction != null && moveBackwardAction.GetState(backwardHand))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        }
    }

    void HandleTurning()
    {
        if (rightHandTransform == null) return;

        float yawTilt = rightHandTransform.localEulerAngles.y;

        if (yawTilt > 180f)
            yawTilt -= 360f;

        float turnAmount = Mathf.Clamp(yawTilt / maxTiltAngle, -1f, 1f);

        if (Mathf.Abs(yawTilt) > tiltThreshold)
        {
            transform.Rotate(Vector3.up * turnAmount * turnSpeed * Time.deltaTime, Space.Self);
        }
    }

    void HandleVerticalMovement()
    {
        if (rightHandTransform == null) return;

        float pitchTilt = rightHandTransform.localEulerAngles.x;

        if (pitchTilt > 180f)
            pitchTilt -= 360f;

        float verticalAmount = Mathf.Clamp(pitchTilt / maxTiltAngle, -1f, 1f);

        if (Mathf.Abs(pitchTilt) > tiltThreshold)
        {
            // Tilt controller upward/downward to move shuttle up/down
            transform.Translate(Vector3.up * -verticalAmount * verticalSpeed * Time.deltaTime, Space.World);
        }
    }
}