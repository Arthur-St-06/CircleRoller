using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverImage;
    private int _loadThisScene;

    void Start()
    {
        _loadThisScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        GameOverImage.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void RestartGameFunction()
    {
        SceneManager.LoadScene(_loadThisScene);
    }
}
