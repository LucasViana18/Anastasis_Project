using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Takes care of the interactions made by the player
/// </summary>
public class PlayerInteractions : MonoBehaviour
{
    // Instance variables
    private const float     MAX_INTERACTION_DISTANCE    = 10f;
    public int TryOrder { get; set; }
    public bool ConfirmAmulet { get; set; }
    [SerializeField] private GameObject[] objects;

    public CanvasManager canvasManager;

    private Transform           _cameraTransform;
    private Interactive         _currentInteractive;
    private bool                _hasRequirements;
    private List<Interactive>   _inventory;

    [SerializeField] private Player player;
    [SerializeField] private GameObject spinPanel;

    /// <summary>
    /// Start - first call after Awake
    /// </summary>
    public void Start()
    {
        _cameraTransform    = GetComponentInChildren<Camera>().transform;
        _currentInteractive = null;
        _inventory          = new List<Interactive>();
        TryOrder = 0;
    }

    /// <summary>
    /// Update - updates every frame
    /// </summary>
    public void Update()
    {
        CheckForInteractive();
        CheckForInteraction();
    }

    /// <summary>
    /// Checks if the player detected for an interactive
    /// </summary>
    private void CheckForInteractive()
    {
        if (Physics.Raycast(_cameraTransform.position,
                            _cameraTransform.forward,
                            out RaycastHit hitInfo,
                            MAX_INTERACTION_DISTANCE))
        {
            Interactive newInteractive = hitInfo.collider.GetComponent<Interactive>();

            if (newInteractive != null && newInteractive != _currentInteractive)
                SetCurrentInteractive(newInteractive);
            else if (newInteractive == null)
                ClearCurrentInteractive();
        }
        else
            ClearCurrentInteractive();
    }

    /// <summary>
    /// Sets what to do with the certain interactive once detected
    /// </summary>
    /// <param name="newInteractive"></param>
    private void SetCurrentInteractive(Interactive newInteractive)
    {
        _currentInteractive = newInteractive;
        if (_currentInteractive.Type == Interactive.InteractiveType.INDIRECT)
            FindObjectOfType<AudioManager>().Play("Chapel");
        if (_currentInteractive.Type == Interactive.InteractiveType.PICKABLE || 
            _currentInteractive.Type == Interactive.InteractiveType.INDIRECT ||
            _currentInteractive.Type == Interactive.InteractiveType.INTERACT_MONUMENT ||
            _currentInteractive.Type == Interactive.InteractiveType.INTERACT_GRAVE)
        {
            canvasManager.ShowInteractionPanel(_currentInteractive.InventoryName);
        }
        else if (HasInteractionRequirements())
        {
            _hasRequirements = true;
            canvasManager.ShowInteractionPanel(_currentInteractive.InteractionText);
        }
        else
        {
            _hasRequirements = false;
            canvasManager.ShowInteractionPanel(_currentInteractive.RequirementText);
        }
    }

    /// <summary>
    /// If the interaction has the requirements
    /// </summary>
    /// <returns>true if it has</returns>
    private bool HasInteractionRequirements()
    {
        if (_currentInteractive.InventoryRequirements == null)
            return true;

        for (int i = 0; i < _currentInteractive.InventoryRequirements.Length; ++i)
            if (!HasInInventory(_currentInteractive.InventoryRequirements[i]))
                return false;

        return true;
    }

    /// <summary>
    /// Clears the current interactive
    /// </summary>
    private void ClearCurrentInteractive()
    {
        _currentInteractive = null;
        canvasManager.HideInteractionPanel();
    }

    /// <summary>
    /// Once pressed a button, it interacts doing a certain objective
    /// </summary>
    private void CheckForInteraction()
    {
        if (Input.GetKeyDown(KeyCode.X) && _currentInteractive != null)
        {
            if (_currentInteractive.Type == Interactive.InteractiveType.PICKABLE)
                Pick();
            else
                Interact();
        }
    }

    /// <summary>
    /// Picks up the object
    /// </summary>
    private void Pick()
    {
        player.enabled = true;
        spinPanel.SetActive(false);
        AddToInventory(_currentInteractive);
        _currentInteractive.gameObject.SetActive(false);
    }

    /// <summary>
    /// Interacts with the object
    /// </summary>
    private void Interact()
    {
        if (_hasRequirements)
        {
            Debug.Log("GET IN");
            if (_currentInteractive.Type == Interactive.InteractiveType.INTERACT_GRAVE)
            {
                foreach (GameObject o in objects)
                    o.SetActive(true);
            }
            for (int i = 0; i < _currentInteractive.InventoryRequirements.Length; ++i)
                RemoveFromInventory(_currentInteractive.InventoryRequirements[i]);

            _currentInteractive.Activate();
            _currentInteractive.Interact();
        }
        _currentInteractive.Activate();
        _currentInteractive.Interact();
    }

    /// <summary>
    /// Adds to the inventory
    /// </summary>
    /// <param name="item"></param>
    private void AddToInventory(Interactive item)
    {
        _inventory.Add(item);
    }

    /// <summary>
    /// Remove from inventory
    /// </summary>
    /// <param name="item"></param>
    private void RemoveFromInventory(Interactive item)
    {
        _inventory.Remove(item);
    }

    /// <summary>
    /// Verifies if it has a certain object in the inventory
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private bool HasInInventory(Interactive item)
    {
        return _inventory.Contains(item);
    }
}
