using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    private TrailRenderer _trailRenderer;

    void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.0f, Circle.CircleSize);
        curve.AddKey(1.0f, 0.0f);
        _trailRenderer.widthCurve = curve;
    }
}
