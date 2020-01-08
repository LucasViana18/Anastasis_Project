using UnityEngine;

public class Player : MonoBehaviour
{
    // Instance variables
        //Character movement
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private LayerMask checkMask;
    [SerializeField] private float checkRadius = 0.5f;
    [SerializeField] private Transform checkBody;
    [SerializeField] private float rayDistance;
    [SerializeField] private Dialogue dialogue;

    private float defaultRayDistance;

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

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        lampLight = GetComponent<LampLight>();
        intangibleForm = GetComponent<IntangibleForm>();
        camera = GetComponentInChildren<Camera>().transform;
    }

    private void Start()
    {
        defaultRayDistance = rayDistance;
    }

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

    private void Update()
    {
        // Movement input
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        if (!dialogue.isDialogue)
            rayDistance = defaultRayDistance;

        //Lamp Light input
        if (Input.GetKeyDown(KeyCode.Q))
            lampLight.ChangeLight();
        //Intangible Form input
        if (Input.GetKeyDown(KeyCode.E))
            intangibleForm.ChangeForm();

        if (Input.GetMouseButtonDown(1))
            DoAction();
    }

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
