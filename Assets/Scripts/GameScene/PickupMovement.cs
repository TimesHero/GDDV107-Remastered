using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PickupMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 3f;
    
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // constantly moves pickup to the left
        rb.linearVelocity = Vector2.left * speed;
    }

    private void Update()
    {
        // removes when it goes off screen
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}