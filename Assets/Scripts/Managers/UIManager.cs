using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text LifeText;
    [SerializeField] private GameObject EndMenu;
    [SerializeField] private Text PlayText;

    public void SetScore(int score) => ScoreText.text = $"Score: {score}";
    public void SetLife(int lives) => LifeText.text = $"Life: {lives}";

    public void ShowEndMenu()
    {
        EndMenu.SetActive(true);
    }

    public void ReturnToMainMenu() => SceneManager.LoadScene(0);
}