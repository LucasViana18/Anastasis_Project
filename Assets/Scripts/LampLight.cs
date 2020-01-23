using UnityEngine;

/// <summary>
/// Script that controls the light behaviour
/// </summary>
public class LampLight : MonoBehaviour
{
    //Instance Variables
    [SerializeField] private Light myLight;
    [SerializeField] private string regularLight;
    [SerializeField] private string greenLight;
    [SerializeField] private GameObject[] myFires;
    private Color greenColor;
    private Color regularColor;

    /// <summary>
    /// Awake - first call
    /// </summary>
    private void Awake()
    {
        //Set colors based on given HEX value
        ColorUtility.TryParseHtmlString(regularLight, out regularColor);
        ColorUtility.TryParseHtmlString(greenLight, out greenColor);
    }

    /// <summary>
    /// Changes the light of the flame
    /// </summary>
    public void ChangeLight()
    {
        //Reset player's layer
        gameObject.layer = 0;

        //Change Lantern color
        if (myLight.color == greenColor)
        {
            myFires[0].SetActive(true);
            myFires[1].SetActive(false);
            myFires[2].SetActive(false);
            myLight.color = regularColor;
        }
        else
        {
            myFires[1].SetActive(true);
            myFires[0].SetActive(false);
            myFires[2].SetActive(false);
            myLight.color = greenColor;
        }
    }

    /// <summary>
    /// When close, the object glows
    /// </summary>
    /// <param name="obj">the certain object</param>
    private void OnTriggerStay(Collider obj)
    {

        if (myLight.color == greenColor && obj.CompareTag("Interactable"))
        {
            print(obj.gameObject.name);
            obj.gameObject.GetComponent<Item>().Glow(true);
        }
        else if (myLight.color != greenColor && obj.CompareTag("Interactable"))
        {
            obj?.gameObject?.GetComponent<Item>()?.Glow(false);
        }
    }

    /// <summary>
    /// When far enough, the object doesn't glow
    /// </summary>
    /// <param name="obj">the certain object</param>
    private void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("Interactable"))
        {
            obj?.gameObject?.GetComponent<Item>()?.Glow(false);
        }
    }
}
