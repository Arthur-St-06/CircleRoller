using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private float _transitionTime;
    //private static string _lastRegimePlayed;

    //public static string LastRegimePlayed
    //{
    //    get { return _lastRegimePlayed; }
    //    set { _lastRegimePlayed = value; }
    //}

    public Animator Anim;

    void Start()
    {
        _transitionTime = 1.0f;
    }

    void Update()
    {

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
