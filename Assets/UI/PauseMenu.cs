using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseMenuUI;
    [Tooltip("They're on the main camera.")]
    public AudioListener Ears;

    void Start() {

    }
    void Update() {
        if(Input.GetButtonDown("Cancel"))
            TogglePause();
    }
    public void TogglePause() {
        if(PauseMenuUI.activeSelf)
            Unpause();
        else
            Pause();
    }
    public void Pause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.volume = .25f;
    }
    public void Unpause() {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
    public void GoTo_MainMenu() {
        Unpause();
        SceneManager.LoadScene("MainMenu");
    }
    public void GoTo_Restart() {
        Unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
