using UnityEngine;
using Valve.VR;

public class VRFreeFlyMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float turnSpeed = 60f;

    public SteamVR_Action_Vector2 moveAxisAction;
    public SteamVR_Action_Boolean moveForwardAction;
    public SteamVR_Input_Sources hand = SteamVR_Input_Sources.RightHand;

    public Transform headTransform;

    void Update()
    {
        if (headTransform == null || moveAxisAction == null) return;

        Vector2 axis = moveAxisAction.GetAxis(hand);

        // Use headset forward direction, but flatten Y so movement stays level
        Vector3 forward = headTransform.forward;
        Vector3 right = headTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = (forward * axis.y + right * axis.x) * moveSpeed * Time.deltaTime;
        transform.position += move;

        if (moveForwardAction != null && moveForwardAction.GetState(hand))
        {
            transform.position += forward * moveSpeed * Time.deltaTime;
        }
    }
}