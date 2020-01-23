using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main menu components
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Starts the game
    /// </summary>
    public void Play ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Exits the game
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
