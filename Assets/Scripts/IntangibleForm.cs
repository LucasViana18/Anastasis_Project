using UnityEngine;

/// <summary>
/// Script that implements the intangible form mechanic
/// </summary>
public class IntangibleForm : MonoBehaviour
{
    //Instance Variables
    [SerializeField] private Light myLight;
    [SerializeField] private string regularLight;
    [SerializeField] private string blueLight;
    [SerializeField] private GameObject[] myFires;
    [SerializeField] private int[] ignoredLayers;
    private Color blueColor;
    private Color regularColor;

    /// <summary>
    /// Awake - first call
    /// </summary>
    private void Awake()
    {
        //Set colors based on given HEX value
        ColorUtility.TryParseHtmlString(regularLight, out regularColor);
        ColorUtility.TryParseHtmlString(blueLight, out blueColor);
        //Ignore colision between layers
        Physics.IgnoreLayerCollision(ignoredLayers[0], ignoredLayers[1]);
    }

    /// <summary>
    /// Changes the form of the light
    /// </summary>
    public void ChangeForm()
    {
        //Change Lantern color and player's layer
        if (myLight.color == blueColor)
        {
            myLight.color = regularColor;
            myFires[0].SetActive(true);
            myFires[1].SetActive(false);
            myFires[2].SetActive(false);
            gameObject.layer = 0;
        }
        else
        {
            myLight.color = blueColor;
            myFires[2].SetActive(true);
            myFires[1].SetActive(false);
            myFires[0].SetActive(false);
            gameObject.layer = 10;
        }
    }
}
