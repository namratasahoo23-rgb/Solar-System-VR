using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 1f;
    public float stopDistance = 6f;
    public float smoothTime = 0.5f;

    private bool isMoving = false;
    private Vector3 currentVelocity;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && target != null)
        {
            isMoving = true;
        }

        if (!isMoving || target == null) return;

        Vector3 targetPosition = target.position;
        targetPosition.y = transform.position.y;

        Vector3 direction = targetPosition - transform.position;
        float distance = direction.magnitude;

        if (distance > stopDistance)
        {
            Vector3 desiredPosition = transform.position + direction.normalized * moveSpeed;
            transform.position = Vector3.SmoothDamp(
                transform.position,
                desiredPosition,
                ref currentVelocity,
                smoothTime
            );
        }
        else
        {
            isMoving = false;
            currentVelocity = Vector3.zero;
        }
    }

    public void MoveToTarget(Transform newTarget)
    {
        target = newTarget;
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
        currentVelocity = Vector3.zero;
    }

    public void ResumeMoving()
    {
        if (target != null)
        {
            isMoving = true;
        }
    }
}
