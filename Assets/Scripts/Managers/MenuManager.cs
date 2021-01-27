using UnityEngine.SceneManagement;

public class MenuManager : Singleton<MenuManager>
{
    public void LoadGameScene() => SceneManager.LoadScene(1);
}