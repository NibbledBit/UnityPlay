using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {
    void Start() {
        StartCoroutine(DelayThenLoadMainMenu());
    }

    IEnumerator DelayThenLoadMainMenu() {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("MainMenuScene");
    }
}
