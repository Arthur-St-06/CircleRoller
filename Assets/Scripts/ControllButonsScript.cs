using UnityEngine;
using UnityEngine.UI;

public class ControllButonsScript : MonoBehaviour
{
    public Image _fullScreenButtonLeft;
    public Image _fullScreenButtonRight;

    void Start()
    {

    }

    void Update()
    {
        Camera cam = Camera.main;

        Debug.Log(Screen.width);

        CanvasScaler canvasScaler = GameObject.Find("Canvas").gameObject.GetComponent<CanvasScaler>();
        Vector2 referenceResolution = canvasScaler.referenceResolution;

        float ratio = Screen.height / referenceResolution.x;

        _fullScreenButtonLeft.rectTransform.sizeDelta = new Vector2(referenceResolution.x / 2, referenceResolution.y / ratio);
        _fullScreenButtonLeft.rectTransform.anchoredPosition = new Vector2(-referenceResolution.x / 4, 0);

        _fullScreenButtonRight.rectTransform.sizeDelta = new Vector2(referenceResolution.x / 2, referenceResolution.y / ratio);
        _fullScreenButtonRight.rectTransform.anchoredPosition = new Vector2(referenceResolution.x / 4, 0);
    }
}
