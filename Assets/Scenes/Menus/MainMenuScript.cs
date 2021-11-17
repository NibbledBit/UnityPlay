using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    public void TestScene() {
        SceneManager.LoadScene("TestScene");
    }

    public void NetworkGame() {
        SceneManager.LoadScene("QuickNetworkGame");
    }

    public void QuitGame() {
        Debug.Log("Quit Game.");
        Application.Quit();
    }
}