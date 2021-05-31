using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private float _transitionTime;

    public Animator Anim;

    void Start()
    {
        _transitionTime = 0.625f;
    }      

    public void loadLevel(string levelName)
    {
        StartCoroutine(LoadLevel(levelName));
    }

    IEnumerator LoadLevel(string levelName)
    {
        Anim.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        LevelManager.setLevelConfig();
        SceneManager.LoadScene(levelName);
    }
}
