using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Has main control of the player
/// </summary>
public class Player : MonoBehaviour
{
    // Instance variables
    // Character movement
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private LayerMask checkMask;
    [SerializeField] private float checkRadius = 0.5f;
    [SerializeField] private Transform checkBody;
    [SerializeField] private float rayDistance;
    [SerializeField] private Dialogue dialogue;

    private float defaultRayDistance;
    private LanternColor lanternColor;
    private float baseMoveSpeed;
    private float moveSpeedLight;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private Transform camera;
    //Character mechanics
    private LampLight lampLight;
    private IntangibleForm intangibleForm;
    //Input variables
    private float moveX;
    private float moveZ;
    private Vector3 move;

    private AudioManager audio;

    /// <summary>
    /// Awake - first call
    /// </summary>
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        lampLight = GetComponent<LampLight>();
        intangibleForm = GetComponent<IntangibleForm>();
        camera = GetComponentInChildren<Camera>().transform;

        audio = FindObjectOfType<AudioManager>();
    }

    /// <summary>
    /// Start - first call after Awake
    /// </summary>
    private void Start()
    {
        defaultRayDistance = rayDistance;
        lanternColor = LanternColor.orange;
        baseMoveSpeed = moveSpeed;
        moveSpeedLight = moveSpeed / 2;
    }

    /// <summary>
    /// FixedUpdate - updates every frame for physics
    /// </summary>
    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(checkBody.position, checkRadius, checkMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // Calculation of movement
        move = transform.right * moveX + transform.forward * moveZ;

        // Gravity
        velocity.y += gravity * Time.deltaTime;

        // Action of movement to the character controller
        controller.Move(((Vector3.ClampMagnitude(move, 1f) * moveSpeed) + velocity) * Time.deltaTime);
    }

    /// <summary>
    /// Update - updates every frame
    /// </summary>
    private void Update()
    {
        // Movement input
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        if (!dialogue.IsDialogue)
            rayDistance = defaultRayDistance;

        //Lamp Light input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (lanternColor == LanternColor.green)
            {
                moveSpeed = baseMoveSpeed;
                lanternColor = LanternColor.orange;
            }
            else
            {
                moveSpeed = moveSpeedLight;
                lanternColor = LanternColor.green;
            }

            lampLight.ChangeLight();
        }
        //Intangible Form input
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (lanternColor == LanternColor.blue)
            {
                moveSpeed = baseMoveSpeed;
                lanternColor = LanternColor.orange;
            }
            else
            {
                moveSpeed = moveSpeedLight;
                lanternColor = LanternColor.blue;
            }
        
            intangibleForm.ChangeForm();
        }

        if (Input.GetMouseButtonDown(1))
            DoAction();

        if (Input.GetKeyDown(KeyCode.P))
            SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Interact with objects for dialog
    /// </summary>
    private void DoAction()
    {
        Physics.Raycast(camera.position, camera.forward, out RaycastHit hit, rayDistance);

        if (hit.collider == null) return;

        if (hit.collider.CompareTag("Talkable"))
        {
            rayDistance = 0f;
            dialogue.StartDialogue();
        }
    }

}
