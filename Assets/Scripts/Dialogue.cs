using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>
/// Script that manages the dialogue
/// </summary>
public class Dialogue : MonoBehaviour
{
    // Instance variables
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private string[] sentences;
    [SerializeField] private float typingSpeed;
    [SerializeField] private Player player;
    [SerializeField] private CameraMovement cameraMove;
    public bool IsDialogue { get; private set; }
    private int index;

    /// <summary>
    /// Update - updates every frame
    /// </summary>
    private void Update()
    {
        //if (dialogText.text == sentences[index]) 
        if (Input.GetKeyDown(KeyCode.Return))
            NextPhrase();
    }

    /// <summary>
    /// Starts the ceratin dialogue
    /// </summary>
    public void StartDialogue()
    {
        IsDialogue = true;
        player.enabled = false;
        cameraMove.enabled = false;
        ShowDialogPanel();
        StartCoroutine(CharPerSentence());
    }

    /// <summary>
    /// Goes through each character on the sentences
    /// </summary>
    /// <returns>Each char</returns>
    IEnumerator CharPerSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    /// <summary>
    /// Goes to the next sentence
    /// </summary>
    private void NextPhrase()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            dialogText.text = " ";
            StartCoroutine(CharPerSentence());
        }
        else
        {
            index = 0;
            dialogText.text = " ";
            dialogPanel.SetActive(false);
            player.enabled = true;
            cameraMove.enabled = true;
            IsDialogue = false;
        }
    }

    /// <summary>
    /// Shows the dialog panel
    /// </summary>
    private void ShowDialogPanel()
    {
        dialogPanel.SetActive(true);
    }

}
