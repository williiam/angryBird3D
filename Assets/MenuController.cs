using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public void PlayGame() {
        Debug.Log("Play Game Clicked");
        SceneManager.LoadScene(1);
    }
    public void QuitGame() {
        Debug.Log("Quit Game Clicked");
        Application.Quit();
    }

    public void restartGame() {
        SceneManager.LoadScene(0);
    }
}