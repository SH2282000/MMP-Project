using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuHandler : MonoBehaviour
{
    public void startGame() {
        SceneManager.LoadScene("Level01");
    }

    public void continueGame() {

    }

    public void quit() {
        Application.Quit();
    }
}
