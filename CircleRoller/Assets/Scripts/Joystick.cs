using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image _bgImg;
    private Image _joystickImg;
    private float _offset;

    private void Start()
    {
        _bgImg = GetComponent<Image>();
        _joystickImg = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_bgImg.rectTransform, ped.position, ped.pressEventCamera, out var pos))
        {
            pos.x = (pos.x / _bgImg.rectTransform.sizeDelta.x);
            pos.x = pos.x * 2.0f - 1.0f;
            _offset = pos.x;
            _offset = Mathf.Clamp(_offset, -1.0f, 1.0f);
            _joystickImg.rectTransform.anchoredPosition = new Vector2(_offset * (_bgImg.rectTransform.sizeDelta.x * 0.5f),0.0f);
        }
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        _offset = 0.0f;
        _joystickImg.rectTransform.anchoredPosition = new Vector2(_offset, 0.0f);
    }

    public float GetRemappedOffset()
    {
        return Mathf.Pow(_offset, 3.0f);
    }
}