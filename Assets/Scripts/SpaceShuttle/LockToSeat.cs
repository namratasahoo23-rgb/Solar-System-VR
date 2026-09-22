using UnityEngine;

public class LockToShuttle : MonoBehaviour
{
    void LateUpdate()
    {
        transform.localPosition = Vector3.zero;
    }
}