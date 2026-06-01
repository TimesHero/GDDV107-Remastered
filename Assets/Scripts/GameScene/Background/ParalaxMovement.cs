using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //These sorts of declarations make more sense when you you haven't set things up prior to scripting it.
public class ParalaxMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float minSpeed = 2f;
    [SerializeField] private float maxSpeed = 6f;
    [SerializeField] private float minRotation = -45f;
    [SerializeField] private float maxRotation = 45f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // TL;DR: Calculates a slightly randomized leftward trajectory and applies velocity/rotation
        float speed = Random.Range(minSpeed, maxSpeed);
        float angleOffset = Random.Range(-15f, 15f);
        
        //converts angles in degrees to a math matrix, rotates it to the left
        Vector2 direction = Quaternion.Euler(0, 0, angleOffset) * Vector2.left;
        
        rb.linearVelocity = direction * speed;//sets exact speed and direction
        rb.angularVelocity = Random.Range(minRotation, maxRotation); //continuous rotation speed, degrees per second
    }

    private void Update()
    {
        //Destroys hazard when it travels off-screen. Set to kinematic so gravity wasn't a problem. Ironic.
        if (transform.position.x < -30f || transform.position.y > 20f || transform.position.y < -20f)
        {
            Destroy(gameObject);
        }
    }
}