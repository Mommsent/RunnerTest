using UnityEngine;

public class PlayersSprite : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject player;

    private void Start()
    {
        GameManager.Instance.GameStarted += Show;
        GameManager.Instance.GameEnded += Hide;
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
        GameManager.Instance.GameStarted -= Show;
        GameManager.Instance.GameEnded -= Hide;
    }
}
