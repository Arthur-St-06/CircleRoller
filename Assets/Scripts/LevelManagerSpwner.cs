using UnityEngine;

public class LevelManagerSpwner : MonoBehaviour
{

    public GameObject LevelManager;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("LevelManager").Length == 0)
        {
            Instantiate(LevelManager);
        }
    }
}
