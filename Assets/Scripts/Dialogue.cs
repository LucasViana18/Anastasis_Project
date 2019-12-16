using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private string[] sentences;
    [SerializeField] private float typingSpeed;
    [SerializeField] private Player player;
    [SerializeField] private CameraMovement cameraMove;

    public bool isDialogue { get; private set; }

    private int index;

    private void Update()
    {
        //if (dialogText.text == sentences[index]) 
        if (Input.GetKeyDown(KeyCode.Return))
            NextPhrase();
    }

    public void StartDialogue()
    {
        isDialogue = true;
        player.enabled = false;
        cameraMove.enabled = false;
        ShowDialogPanel();
        StartCoroutine(CharPerSentence());
    }

    IEnumerator CharPerSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

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
            isDialogue = false;
        }
    }

    private void ShowDialogPanel()
    {
        dialogPanel.SetActive(true);
    }

}
