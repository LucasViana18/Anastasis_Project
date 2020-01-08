using UnityEngine;

public class Interactive : MonoBehaviour
{
    public enum InteractiveType { PICKABLE, INTERACT_ONCE, INTERACT_MULTIPLE, INDIRECT };
    public PlayerInteractions interaction;
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
    private int[] order;
    public bool GotAmulet { get; private set; }
    //public int TryOrder { get; private set; }

    private Animator _animator;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        order = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
        GotAmulet = false;
        _animator = GetComponent<Animator>();
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

            if (type == InteractiveType.INTERACT_ONCE && interaction.TryOrder == presentOrder)
            {
                rend.material.SetColor("_Color", Color.blue);
                interaction.TryOrder += 1;
                if (presentOrder > 6) GotAmulet = true;
                interaction.ConfirmAmulet = GotAmulet;
            }
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
