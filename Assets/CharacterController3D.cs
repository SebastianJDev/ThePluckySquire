using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 10f;
    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Captura de la entrada horizontal y vertical
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Definición del movimiento en el plano XZ
        movement = new Vector3(moveX, 0f, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // Movimiento del personaje
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Rotación del personaje en la dirección de movimiento
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
        }
    }
}
