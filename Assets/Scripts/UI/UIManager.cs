using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highestScoreText;

    private void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.GameStarted += HideUI;
        gameManager.GameEnded += ShowUI;
    }
    private void OnGUI()
    {
        scoreText.text = gameManager.PrettyScore(GameManager.Instance.currentScore);
    }

    private void HideUI()
    {
        mainMenu.SetActive(false);
    }

    private void ShowUI()
    {
        mainMenu.SetActive(true);
        currentScoreText.text = "Current score " + gameManager.PrettyScore(gameManager.currentScore);
        highestScoreText.text = "Highest score " + gameManager.PrettyScore(gameManager.saveData.highestScore);
    }

    private void OnDisable()
    {
        gameManager.GameStarted -= HideUI;
        gameManager.GameEnded -= ShowUI;
    }
}
