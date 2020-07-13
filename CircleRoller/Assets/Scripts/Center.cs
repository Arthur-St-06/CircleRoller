using UnityEngine;

public class Center : MonoBehaviour
{
    public float RotationSpeed;
    public Joystick Joystick;

    void Update()
    {
        transform.Rotate(Vector3.back * Joystick.GetRemappedOffset() * Time.deltaTime * RotationSpeed);
    }
}
