using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public TextMeshProUGUI FinalScore;
    string finalScoreDefaultText;

    public Image PaperDisplay;
    public List<NewspaperLevel> newspaperLevels = new List<NewspaperLevel>();

    NewspaperLevel GetBestNewspaperLevel() {
        float score = GameplayManager.CurrentScore;
        NewspaperLevel best = newspaperLevels[0];
        foreach(NewspaperLevel level in newspaperLevels) {
            if(best == null || (best.RequiredScore <= level.RequiredScore && level.RequiredScore <= score)) {
                best = level;
            }
        }
        print("SELECTED " + best.RequiredScore.ToString());
        return best;
    }

    private void Start() {
        if(FinalScore) {
            finalScoreDefaultText = FinalScore.text;
            FinalScore.text = finalScoreDefaultText + GameplayManager.CurrentScore;
        }
        if(PaperDisplay) {
            NewspaperLevel best = GetBestNewspaperLevel();
            if(best != null) {
                PaperDisplay.sprite = best.DisplayedNewspaper;
            }
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("Production");
    }

}

[System.Serializable]
public class NewspaperLevel {
    public float RequiredScore;
    public Sprite DisplayedNewspaper;
}
