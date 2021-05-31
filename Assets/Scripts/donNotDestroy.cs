using UnityEngine;

public class donNotDestroy : MonoBehaviour
{
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Audio").Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
