using UnityEngine;

public class PlayersSprite : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject player;

    private void Start()
    {
        gameManager.GameStarted += Show;
        gameManager.GameEnded += Hide;
    }

    private void Show()
    {
        player.SetActive(true);
    }

    private void Hide()
    {
        player.SetActive(false);
    }

    private void OnDisable()
    {
        gameManager.GameStarted -= Show;
        gameManager.GameEnded -= Hide;
    }
}
