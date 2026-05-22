using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] Rigidbody2D rb;

    [Header("Player Settings")]
    [SerializeField] float speed;
    [SerializeField] bool isRotating = false;
    

    private float horizontal;
    private float vertical;

    private void Update()
    {
        if(vertical > 0)
            rb.transform.Rotate(0,0,30f);
        if(vertical < 0)
            rb.transform.Rotate(0,0,-30f);
        else{
            rb.transform.Rotate(0,0,0);
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
    }

    #region PLAYER_CONTROLS
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    #endregion
}

