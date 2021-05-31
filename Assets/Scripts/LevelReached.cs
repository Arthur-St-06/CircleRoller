using UnityEngine;
using UnityEngine.UI;

public class LevelReached : MonoBehaviour
{
    public Text LevelReachedText;

    private Animator _anim;

    private float _timer;
    private float _maxTime;

    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        LevelReachedText.text = "Level:" + LevelManager.ActiveLevel;
        _timer = 0.0f;
        _maxTime = 0.7f;
    }

    void Update()
    {
        if (StartButton._ButtonPlayWasTouched)
        {
            if (LevelManager.LevelHasChanged)
            {
                _anim.Play("LevelReached");
                LevelReachedText.text = "Level:" + LevelManager.ActiveLevel;
            }
            else
            {
                if (_timer <= _maxTime)
                {
                    _anim.Play("ShowOnStart");
                }
                _timer += Time.deltaTime;
            }
        }
    }
}
