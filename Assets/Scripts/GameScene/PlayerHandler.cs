using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using System;

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

    [Header("Toxic Cloud Hazard")]
    [SerializeField] private float gasDisableTime = 2f;
    private bool canMove = true;
    private int activeToxicClouds = 0;
    private float currentToxicTimer = 0f;

    [Header("Screen Space FX")]
    [SerializeField] private GameObject shieldFX;
    [SerializeField] private GameObject toxicCloudFX;
    [SerializeField] private float fxFadeDuration = 0.5f;

    [Header("Particle Systems")]
    [SerializeField] private GameObject deathParticlesPrefab;

    [Header("Dynamic Boundaries")]
    [SerializeField] private float boundaryPadding =0.5f;
    private float xMin, xMax, yMin, yMax;

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

#region VOID_START
    private void Start()
    {
        Camera cam = Camera.main;
        float distance = Mathf.Abs(cam.transform.position.z - transform.position.z);

        float frustumHeight = 2.0f * distance * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustumWidth = frustumHeight * cam.aspect;



        xMin = -(frustumWidth / 2f) + boundaryPadding;
        xMax = (frustumWidth / 2f) - boundaryPadding;
        yMin = -(frustumHeight / 2f) + boundaryPadding;
        yMax = (frustumHeight / 2f) - boundaryPadding;
    }
#endregion

#region VOID_UPDATE
    private void Update()
    {
        PlayerControls(); //Just for the visual movement of the player object
        HandleShieldTimer();
        HandleToxicCloudTimer();
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

        if (!canMove) 
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }


        Vector2 movement = new Vector2(horizontal, vertical);
        movement = Vector2.ClampMagnitude(movement, 1f); //ensure diagonal movement is not faster than linear

        rb.linearVelocity = movement * speed; //should avoid fighting between physics and transform.position

        Vector2 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, xMin, xMax);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, yMin, yMax);
        rb.position = clampedPosition;
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
                    GameManager.Instance.ShieldDownSFX();
                    Debug.Log("Shield expired.");
                }

                if (shieldFX != null)
                {
                    StartCoroutine(FadeOutFX(shieldFX, fxFadeDuration));
                }

                Debug.Log("Shield Expired");

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Debug.Log("Overlapped with: " + collision.gameObject.name + " | Tag: " + collision.tag);
        if(collision.CompareTag("Hazard"))
        {
            if(hasShield)
            {
                Debug.Log($"Shield has absorbed the impact.");
                hasShield = false;
                if(shieldVisual != null) shieldVisual.SetActive(false);
                GameManager.Instance.ShieldDownSFX();
                
                if(shieldFX != null) StartCoroutine(FadeOutFX(shieldFX, fxFadeDuration));
                
                Destroy(collision.gameObject);
                GameManager.Instance.ObjectDestroyedSFX();
                GameManager.Instance.ShieldDownSFX();
            }
            else
            {
                Debug.Log($"Player has hit a hazard.");
                
                if(GameManager.Instance != null) GameManager.Instance.TriggerGameOver();
                
                // TL;DR: Spawns the particle burst at the exact coordinates of the player ship
                if (deathParticlesPrefab != null)
                {
                    Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
                }

                gameObject.SetActive(false);
            }
        }
        else if (collision.CompareTag("Pickup"))
        {
            Debug.Log("Player has collected a shield!");
            hasShield = true;
            GameManager.Instance.ShieldUpSFX();
            currentShieldTimer = maxShieldTime;
            if(shieldVisual != null) shieldVisual.SetActive(true);

            if(shieldFX != null)
            {
                //Restores full opacity in case the object was previously faded out
                ResetFXAlpha(shieldFX);
                shieldFX.SetActive(true);
            }

            Destroy(collision.gameObject);
        }
        // activates the visual effect immediately upon entering the cloud
        else if (collision.CompareTag("ToxicCloud"))
        {
            activeToxicClouds++;
            if (GameManager.Instance != null && activeToxicClouds == 1) GameManager.Instance.PowerDownSFX();

            if(activeToxicClouds >= 1)
            {
                Debug.Log("Entered Toxic Cloud. Controls Disabled.");
                canMove = false;
                horizontal = 0f;
                vertical = 0f;
                if (rb != null) rb.linearVelocity = Vector2.zero;

                if (toxicCloudFX != null)
                {
                    ResetFXAlpha(toxicCloudFX);
                    toxicCloudFX.SetActive(true);
                }
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("NearMiss"))
        {
            Debug.Log($"Hazard Near Miss!");
            if (GameManager.Instance != null) GameManager.Instance.RegisterNearMiss();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("ToxicCloud"))
        {
            // Decrements the overlap counter.
            activeToxicClouds--;
            if (activeToxicClouds < 0) activeToxicClouds = 0; // Failsafe
            
            if (activeToxicClouds == 0)
            {
                Debug.Log("Exited all Toxic Clouds. Countdown started.");
            }
        }
    }

    private void HandleToxicCloudTimer()
    {
        if (activeToxicClouds > 0)
        {
            // While inside ANY cloud, keeps the timer topped off at max.
            currentToxicTimer = gasDisableTime;
        }
        else if (currentToxicTimer > 0f)
        {
            // Only ticks down once the player has fully exited all clouds.
            currentToxicTimer -= Time.deltaTime;

            if (currentToxicTimer <= 0f)
            {
                // Timer expired. Restore controls and trigger the fade.
                currentToxicTimer = 0f;
                if (GameManager.Instance != null && currentToxicTimer == 0)
                {
                    GameManager.Instance.PowerUpSFX();
                }
                canMove = true;
                Debug.Log("Controls restored.");


                if (toxicCloudFX != null)
                {
                    StartCoroutine(FadeOutFX(toxicCloudFX, fxFadeDuration));
                }
            }
        }
    }
#endregion

#region FX_TRANSITIONS

    private IEnumerator FadeOutFX(GameObject fxObject, float duration)
    {
        if (fxObject == null) yield break;

        // gathers all visual components within the external prefab
        Renderer[] renderers = fxObject.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0)
        {
            fxObject.SetActive(false);
            yield break;
        }

        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / duration;

            foreach (Renderer r in renderers)
            {
                Material mat = r.material;
                // identifies URP shaders vs Standard shaders and lerps the alpha channel to 0
                if (mat.HasProperty("_BaseColor")) 
                {
                    Color c = mat.GetColor("_BaseColor");
                    mat.SetColor("_BaseColor", new Color(c.r, c.g, c.b, Mathf.Lerp(1f, 0f, normalizedTime)));
                }
                else if (mat.HasProperty("_Color")) 
                {
                    Color c = mat.GetColor("_Color");
                    mat.SetColor("_Color", new Color(c.r, c.g, c.b, Mathf.Lerp(1f, 0f, normalizedTime)));
                }
            }
            yield return null; //pauses execution until the next frame to create a smooth loop over time
        }

        fxObject.SetActive(false);
    }

    private void ResetFXAlpha(GameObject fxObject)
    {
        if (fxObject == null) return;
        
        Renderer[] renderers = fxObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            Material mat = r.material;
            if (mat.HasProperty("_BaseColor"))
            {
                Color c = mat.GetColor("_BaseColor");
                mat.SetColor("_BaseColor", new Color(c.r, c.g, c.b, 1f));
            }
            else if (mat.HasProperty("_Color"))
            {
                Color c = mat.GetColor("_Color");
                mat.SetColor("_Color", new Color(c.r, c.g, c.b, 1f));
            }
        }
    }

#endregion
}