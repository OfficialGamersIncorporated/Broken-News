using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayManager : MonoBehaviour {

    public static GameplayManager Singleton;
    public WorldGenerator World;
    public CarSpawner Spawner;
    public TextMeshProUGUI ScoreText;

    [Space, Tooltip("this is only visible for debugging.")]
    public DifficultyState currentDifficultyState;
    [SerializeField] private float CurrentScore = 0;
    public List<DifficultyState> DifficultyStates = new List<DifficultyState>();
    public List<Vector3> AlreadyHitHouses = new List<Vector3>();
    public List<GameObject> AlreadyHitPedestrian = new List<GameObject>();

    public List<Vector3> AlreadyPassedDoors = new List<Vector3>();

    string ScoreTextDefault;

    IEnumerator Start() {
        Singleton = this;
        ScoreTextDefault = ScoreText.text;
        ScoreText.text = ScoreTextDefault + CurrentScore.ToString();

        foreach(DifficultyState state in DifficultyStates) {
            yield return new WaitForSeconds(state.DelayBeforeApply);
            currentDifficultyState = state;
            World.Speed = state.WorldSpeed;
            Spawner.SpawnRate = state.CarSpawnRate;
        }
    }
    public void IncrementScore(float _deltaScore = 1) {
        CurrentScore += _deltaScore;
        ScoreText.text = ScoreTextDefault + CurrentScore.ToString();
    }
}

[System.Serializable]
public class DifficultyState {
    public float DelayBeforeApply;
    public float WorldSpeed;
    public float CarSpawnRate;
}