using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    public TextMeshProUGUI FinalScore;
    string finalScoreDefaultText;

    private void Start() {
        if(FinalScore) {
            finalScoreDefaultText = FinalScore.text;
            FinalScore.text = finalScoreDefaultText + GameplayManager.CurrentScore;
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("Production");
    }

}
