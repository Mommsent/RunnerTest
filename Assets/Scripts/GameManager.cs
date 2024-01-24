using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        startButton.onClick.AddListener(StartGame);
    }

    public Action GameStarted;
    public Action GameEnded;

    public void StartGame()
    {
        GameStarted.Invoke();
    }

    public void EndGame()
    {
        GameEnded.Invoke();
    }
}
