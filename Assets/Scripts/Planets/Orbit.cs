using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public bool isPaused = false;
    public float speed = 10f;

    void Update()
    {
        if (!isPaused)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
