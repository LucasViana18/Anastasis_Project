using UnityEngine;

public class Interactive : MonoBehaviour
{
    public enum InteractiveType { PICKABLE, INTERACT_GRAVE, INTERACT_MONUMENT, INTERACT_MULTIPLE, INDIRECT };
    private PlayerInteractions interaction;
    public bool             isActive;
    public InteractiveType  type;
    public string           inventoryName;
    public string           requirementText;
    public string           interactionText;
    public Interactive[]    inventoryRequirements;
    public Interactive[]    activationChain;
    public Interactive[]    interactionChain;
    public int presentOrder;
    Renderer rend;
    public bool GotAmulet { get; private set; }

    private Animator _animator;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        GotAmulet = false;
        _animator = GetComponent<Animator>();
        interaction = FindObjectOfType<PlayerInteractions>();
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Interact()
    {
        if (_animator != null)
            _animator.SetTrigger("Interact");

        if (isActive)
        {
            ProcessActivationChain();
            ProcessInteractionChain();
            
            // First puzzle
            if (type == InteractiveType.INTERACT_MONUMENT && interaction.TryOrder == presentOrder)
            {
                rend.material.SetColor("_Color", Color.red);
                interaction.TryOrder += 1;
                if (presentOrder > 3) GotAmulet = true;
                interaction.ConfirmAmulet = GotAmulet;
            }

            // Second puzzle

        }
    }

    private void ProcessActivationChain()
    {
        if (activationChain != null)
        {
            for (int i = 0; i < activationChain.Length; ++i)
                activationChain[i].Activate();
        }
    }

    private void ProcessInteractionChain()
    {
        if (interactionChain != null)
        {
            for (int i = 0; i < interactionChain.Length; ++i)
                interactionChain[i].Interact();
        }
    }
}
