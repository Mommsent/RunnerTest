using UnityEngine.UI;
using UnityEngine;


public class ExitButtonScript : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    private void Awake()
    {
        exitButton.onClick.AddListener(ExitAp);
    }

    private void ExitAp()
    {
        Application.Quit();
    }
}
