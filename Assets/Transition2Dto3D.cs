using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition2Dto3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 movement;
    public GameObject Player3D;
    private void Start()
    {
        Player3D.SetActive(false);
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        movement = new Vector3(moveX, moveY, 0f).normalized;

        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleport") && Input.GetKeyDown(KeyCode.Space))
        {
            Player3D?.SetActive(true);
            gameObject?.SetActive(false);
        }
    }
}
