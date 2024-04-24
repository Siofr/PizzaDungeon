using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private EntityStats playerStatsScript;
    private Gun gunScript;
    [Header("Rigidbody")]
    public Rigidbody2D rgdBody;

    public Transform cameraTarget;

    // Player Inputs
    public PlayerInputs playerInputs;
    private InputAction move;
    private InputAction look;
    private InputAction fire;
    private InputAction swap;
    private InputAction dash;

    // Input Vectors
    private Vector2 directionInput;
    private Vector2 lookInput;

    // Art Stuff
    [Header("Transforms")]
    [SerializeField] private Camera playerCam;
    [SerializeField] private Transform weaponTransform;
    [SerializeField] private SpriteRenderer weaponRenderer;
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private Transform crosshair;

    public bool isGamepad;

    private void OnEnable()
    {
        move = playerInputs.Player.Move;
        move.Enable();

        look = playerInputs.Player.Look;
        look.Enable();

        fire = playerInputs.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        swap = playerInputs.Player.Swap;
        swap.Enable();
        swap.performed += Swap;

        dash = playerInputs.Player.Dash;
        dash.Enable();
        dash.performed += Dash;
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
        fire.Disable();
        swap.Disable();
        dash.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;

        playerInputs = new PlayerInputs();
        rgdBody = GetComponent<Rigidbody2D>();

        playerStatsScript = GetComponent<EntityStats>();
        gunScript = GetComponentInChildren<Gun>();

        weaponRenderer = weaponTransform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
        cameraTarget.position = (bodyTransform.position + crosshair.position) / 2;
    }

    private void FixedUpdate()
    {
        rgdBody.velocity = directionInput * playerStatsScript.entitySpeed;
    }

    private void Move()
    {
        directionInput = move.ReadValue<Vector2>();

        if (directionInput != Vector2.zero && lookInput == Vector2.zero)
        {
            FlipSprite(directionInput);
        }
    }

    private void Fire(InputAction.CallbackContext context)
    {
        gunScript.Fire();
    }

    private void Look()
    {
        // Read Mouse Movement
        lookInput = playerCam.ScreenToWorldPoint(look.ReadValue<Vector2>());
        crosshair.position = lookInput;

        if (lookInput != Vector2.zero)
        {
            FlipSprite(lookInput);
        }

        Vector2 aimDirection = (lookInput - new Vector2(transform.position.x, transform.position.y)).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        weaponTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Swap(InputAction.CallbackContext context)
    {
        float swapDirection = swap.ReadValue<float>();

        gunScript.SwapWeapon(swapDirection);
    }

    private void Dash(InputAction.CallbackContext context)
    {

    }

    private void FlipSprite(Vector2 directionalInput)
    {
        if (directionalInput.x > 0)
        {
            bodyTransform.localScale = new Vector3(1, bodyTransform.localScale.y, bodyTransform.localScale.z);
            weaponRenderer.flipY = false;
            weaponRenderer.flipX = false;
        }
        else if (directionalInput.x < 0)
        {
            bodyTransform.localScale = new Vector3(-1, bodyTransform.localScale.y, bodyTransform.localScale.z);
            weaponRenderer.flipY = true;
            weaponRenderer.flipX = true;
        }
    }
}