using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuHandler : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void continueGame()
    {
        Debug.Log("Not implemented");
    }

    public void quit()
    {
        Application.Quit();
    }
}
