using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementVersionTutorial : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    AudioManager audioManager;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        movement = inputManager.GetPlayerMovementInput();
        GetMousePos();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void AddMaxSpeed()
    {
        moveSpeed += 5;
    }

    private void GetMousePos()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
