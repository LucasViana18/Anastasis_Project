using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Manages the UI of the game
/// </summary>
public class CanvasManager : MonoBehaviour
{
    // Instance variables
    [SerializeField] private GameObject interactionPanel;
    [SerializeField] private Text interactionText;
    [SerializeField] private GameObject bodyAmuletPanel;
    private PlayerInteractions playerinter;
    private int i = 0;

    /// <summary>
    /// Awake - first call
    /// </summary>
    public void Awake()
    {
        playerinter = FindObjectOfType<PlayerInteractions>();
    }

    /// <summary>
    /// Start - first call after Awake
    /// </summary>
    public void Start()
    {
        HideInteractionPanel();
    }

    /// <summary>
    /// Update - updates every frame
    /// </summary>
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
            FindObjectOfType<AudioManager>().Play("Body Amulet");

        if (playerinter.ConfirmAmulet || Input.GetKeyDown(KeyCode.M))
        {
            if (i == 0)
            {
                i++;
                ShowAmuletPanel();
                playerinter.ConfirmAmulet = true;
            }
        }
    }

    /// <summary>
    /// Displays the interaction panel
    /// </summary>
    /// <param name="interactionMessage">The message</param>
    public void ShowInteractionPanel(string interactionMessage)
    {
        interactionText.text = interactionMessage;
        interactionPanel.SetActive(true);
    }

    /// <summary>
    /// Hide the interaction panel
    /// </summary>
    public void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }

    /// <summary>
    /// Displays the Body Amulet panel
    /// </summary>
    public void ShowAmuletPanel()
    {
        bodyAmuletPanel.SetActive(true);
        StartCoroutine(HideAmuletPanel());
    }

    /// <summary>
    /// Set to hide the Amulet Panel after 3 seconds
    /// </summary>
    /// <returns>three seconds</returns>
    private IEnumerator HideAmuletPanel()
    {
        yield return new WaitForSeconds(3f);
        bodyAmuletPanel.SetActive(false);
    }
}
