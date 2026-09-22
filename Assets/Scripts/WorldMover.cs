using UnityEngine;

public class WorldMover : MonoBehaviour
{
    public float speed = 15f;
    public float rotationSpeed = 80f;

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        // Move world opposite direction
        transform.Translate(Vector3.back * move * speed * Time.deltaTime);

        // Rotate world
        transform.Rotate(Vector3.up * turn * rotationSpeed * Time.deltaTime);
    }
}