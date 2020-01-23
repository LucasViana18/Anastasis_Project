using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasManager : MonoBehaviour
{
    public GameObject   interactionPanel;
    public Text         interactionText;
    public GameObject bodyAmuletPanel;
    private PlayerInteractions playerinter;
    private int i = 0;

    public void Awake()
    {
        playerinter = FindObjectOfType<PlayerInteractions>();
    }

    public void Start()
    {
        HideInteractionPanel();
    }

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

    public void ShowInteractionPanel(string interactionMessage)
    {
        interactionText.text = interactionMessage;
        interactionPanel.SetActive(true);
    }

    public void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }

    public void ShowAmuletPanel()
    {
        bodyAmuletPanel.SetActive(true);
        StartCoroutine(HideAmuletPanel());
    }

    private IEnumerator HideAmuletPanel()
    {
        yield return new WaitForSeconds(3f);
        bodyAmuletPanel.SetActive(false);
    }
}
