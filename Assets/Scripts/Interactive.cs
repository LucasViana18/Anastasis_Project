using UnityEngine;

/// <summary>
/// Turns an object interactive for the player
/// </summary>
public class Interactive : MonoBehaviour
{
    // Instance variables
        // Interactive enum
    public enum InteractiveType { PICKABLE, INTERACT_GRAVE, INTERACT_MONUMENT, INTERACT_MULTIPLE, INDIRECT };
    private PlayerInteractions interaction;
    private bool             isActive;
    [SerializeField] private InteractiveType  type;
    public InteractiveType Type { get => type; }
    [SerializeField] private string           inventoryName;
    public string InventoryName { get => inventoryName; }
    [SerializeField] private string           requirementText;
    public string RequirementText { get => requirementText; }
    [SerializeField] private string           interactionText;
    public string InteractionText { get => interactionText; }
    [SerializeField] private Interactive[]    inventoryRequirements;
    public Interactive[] InventoryRequirements { get => inventoryRequirements; }
    [SerializeField] private Interactive[]    activationChain;
    public Interactive[] ActivationChain { get => activationChain; }
    [SerializeField] private Interactive[]    interactionChain;
    public Interactive[] InteractionChain { get => interactionChain; }
    [SerializeField] private int presentOrder;
    private Renderer rend;
    public bool GotAmulet { get; private set; }

    private Animator _animator;

    /// <summary>
    /// Start - first call after Awake
    /// </summary>
    public void Start()
    {
        rend = GetComponent<Renderer>();
        GotAmulet = false;
        _animator = GetComponent<Animator>();
        interaction = FindObjectOfType<PlayerInteractions>();
    }

    /// <summary>
    /// Put the isActive variable true
    /// </summary>
    public void Activate()
    {
        isActive = true;
    }

    /// <summary>
    /// Action of objects when interacted
    /// </summary>
    public void Interact()
    {
        if (_animator != null)
            _animator.SetTrigger("Interact");

        if (isActive)
        {
            ProcessActivationChain();
            ProcessInteractionChain();
            
            // Puzzle
            if (type == InteractiveType.INTERACT_MONUMENT && interaction.TryOrder == presentOrder)
            {
                rend.material.SetColor("_Color", Color.red);
                interaction.TryOrder += 1;
                if (presentOrder > 3) GotAmulet = true;
                interaction.ConfirmAmulet = GotAmulet;
            }
        }
    }

    /// <summary>
    /// Case it has an array of objects, it activates all of them
    /// </summary>
    private void ProcessActivationChain()
    {
        if (activationChain != null)
        {
            for (int i = 0; i < activationChain.Length; ++i)
                activationChain[i].Activate();
        }
    }

    /// <summary>
    /// Case it has an array of objects, every object is interacted with
    /// </summary>
    private void ProcessInteractionChain()
    {
        if (interactionChain != null)
        {
            for (int i = 0; i < interactionChain.Length; ++i)
                interactionChain[i].Interact();
        }
    }
}
