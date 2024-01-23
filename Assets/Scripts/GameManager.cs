using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    #region Singleton
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        startButton.onClick.AddListener(StartGame);
    }
    #endregion

    public float currentScore = 0;
    public bool isPlaying = false;

    public Action GameStarted;
    public Action GameEnded;

    public SaveData saveData;

    private void Start()
    {
        saveData = new SaveData();
    }

    private void Update()
    {
        if (isPlaying)
            currentScore += Time.deltaTime;
    }

    public void StartGame()
    {
        isPlaying = true;
        currentScore = 0;
        GameStarted.Invoke();
    }

    public void GameOver()
    {
        if(saveData.highestScore < currentScore)
            saveData.highestScore = currentScore;
        
        isPlaying = false;
        GameEnded.Invoke();
    }

    public string PrettyScore(float score)
    {
        return Mathf.RoundToInt(score).ToString();
    }
}
