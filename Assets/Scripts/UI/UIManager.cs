using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private Score score;

    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highestScoreText;

    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager.GameStarted += HideUI;
        gameManager.GameEnded += ShowUI;
        ShowUI();
    }

    private void OnGUI()
    {
        scoreText.text = PrettyScore(score.CurrentScore);
    }

    private void HideUI()
    {
        score.SetStarter();
        mainMenu.SetActive(false);
    }

    private void ShowUI()
    {
        mainMenu.SetActive(true);
        score.SetTheBest();
        currentScoreText.text = "Current score " + PrettyScore(score.CurrentScore);
        highestScoreText.text = "Highest score " + PrettyScore(score.TheBestScore);
    }

    private string PrettyScore(float score)
    {
        return Mathf.RoundToInt(score).ToString();
    }

    private void OnDisable()
    {
        gameManager.GameStarted -= HideUI;
        gameManager.GameEnded -= ShowUI;
    }
}
