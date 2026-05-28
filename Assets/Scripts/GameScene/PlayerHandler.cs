using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerHandler : MonoBehaviour
{
#region VARIABLES
    [Header("Player Components")]
    [SerializeField] Rigidbody2D rb; 
    [SerializeField] Transform visualTransform; //will store the child sprite to handle the tilt

    [Header("Player Movement Settings")]
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed = 2f; //how quickly sprite eases into the tilt
    [SerializeField] float tiltAngle = 20f; //chosen tilt angle
    [SerializeField] float timePassed = 0f; //for the future to hold this info, and perhaps function as a score modifier?

    [Header("Shield Power-up")]
    [SerializeField] private GameObject shieldVisual;
    [SerializeField] private float maxShieldTime = 3f;
    private bool hasShield = false;
    private float currentShieldTimer = 0f;

    [Header("Player Dead")]
    [SerializeField] public bool isFalling = false; //when the player object dies, it will fall off screen

    //WASD input becomes X/Y movement
    private float horizontal;
    private float vertical;

    private Quaternion baseRotation; //will hold onto the base rotation set in inspector. Assures correct visual orientation
#endregion

#region VOID_AWAKE
    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>(); //failsafe to ensure rigidbody is assigned from this game object
        }

        if (visualTransform == null)
        {
            Transform playerSprite = transform.Find("PlayerSprite"); //the visual should be assigned, but just another failsafe

            if (playerSprite != null)
            {
                visualTransform = playerSprite;
            }
            else
            {
                visualTransform = transform;
            }
        }

        baseRotation = visualTransform.localRotation; //saves and applies inspector rotation on player at the beginning of the game
    }
#endregion

#region VOID_UPDATE
    private void Update()
    {
        PlayerControls(); //Just for the visual movement of the player object
        HandleShieldTimer();
    }
#endregion

#region VOID_FIXED_UPDATE

    private void FixedUpdate() //best foe the RB movement because its physics based.
    {
        if (rb == null)
        {
            return;
        }

        if (isFalling)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 movement = new Vector2(horizontal, vertical);
        movement = Vector2.ClampMagnitude(movement, 1f); //ensure diagonal movement is not faster than linear

        rb.linearVelocity = movement * speed; //should avoid fighting between physics and transform.position
    }
#endregion

#region PLAYER_CONTROLS

    public void MovementValues(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>(); //checks that WASD is still hooked up

        horizontal = inputValue.x;
        vertical = inputValue.y;
    }

    public void PlayerControls()
    {
        if (visualTransform == null)
        {
            return;
        }

        float targetTilt = 0f; //0 means it will return to the base rotation

        if (!isFalling)
        {
            if (vertical > 0.1f) //tilts up
            {
                targetTilt = tiltAngle;
                timePassed += Time.deltaTime * 1.5f;
            }
            else if (vertical < -0.1f) // tilts down
            {
                targetTilt = -tiltAngle;
                timePassed += Time.deltaTime * 1.5f;
            }
            else //return to base pose
            {
                targetTilt = 0f;
                timePassed = Time.deltaTime;
            }
        }

        Quaternion tiltRotation = Quaternion.Euler(0f, 0f, targetTilt); //sets the tilt amount
        Quaternion targetRotation = baseRotation * tiltRotation; //ensures player stays facing sideways

        //should smoothly rotate towards target
        visualTransform.localRotation = Quaternion.Lerp(
            visualTransform.localRotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

#endregion

#region PLAYER_DEATH
    private void HandleShieldTimer()
    {
        if(hasShield)
        {
            //currentShieldTimer = maxShieldTime;
            currentShieldTimer -= Time.deltaTime;

            if(currentShieldTimer <= 0f)
            {
                hasShield = false;
                if (shieldVisual != null)
                {
                    shieldVisual.SetActive(false);
                    Debug.Log("Shield expired.");
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Debug.Log("Overlapped with: " + collision.gameObject.name + " | Tag: " + collision.tag);
        if(collision.CompareTag("Hazard"))
        {
            if(hasShield)//will consume the shield upon impact and destroy the impacted hazard
            {
                Debug.Log($"Shield has absorbed the impact.");
                hasShield = false;
                if(shieldVisual != null)
                {
                    shieldVisual.SetActive(false);
                }

                Destroy(collision.gameObject);
            }
            else
            {
            Debug.Log($"Player has hit a hazard.");
            if(GameManager.Instance != null)
            {
                GameManager.Instance.TriggerGameOver();
            }

            gameObject.SetActive(false);
            }
        }
        else if (collision.CompareTag("Pickup"))
        {
            Debug.Log("Player has collected a shield!");
            hasShield = true;
            currentShieldTimer = maxShieldTime;
            if(shieldVisual != null)
                shieldVisual.SetActive(true);

            Destroy(collision.gameObject);
        }
    }
#endregion
}