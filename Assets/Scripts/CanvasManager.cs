using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    //public GameObject   interactionPanel;
   // public Text         interactionText;
    //public GameObject bodyAmuletPanel;
    public PlayerInteractions playerinter;

    public void Start()
    {
        HideInteractionPanel();
    }

    public void Update()
    {
        if (playerinter.ConfirmAmulet || Input.GetKeyDown(KeyCode.C))
            ShowAmuletPanel();
    }

    public void ShowInteractionPanel(string interactionMessage)
    {
  //      interactionText.text = interactionMessage;
   //     interactionPanel.SetActive(true);
    }

    public void HideInteractionPanel()
    {
    //    interactionPanel.SetActive(false);
    }

    public void ShowAmuletPanel()
    {
      //  bodyAmuletPanel.SetActive(true);
    }

    public void HideAmuletPanel()
    {
     //   bodyAmuletPanel.SetActive(false);
    }
}
