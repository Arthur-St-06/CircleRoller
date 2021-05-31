using UnityEngine;

public class Center : MonoBehaviour
{
    private static float _circleRotation;

    public static float CircleRotation
    {
        get { return _circleRotation; }
        set { _circleRotation = value; }
    }

    private static float _rotationSpeed;

   public static float RotationSpeed
    {
        get { return _rotationSpeed; }
        set { _rotationSpeed = value; }
    }

   private float _phoneRotation;

   void Update()
   {
       _circleRotation = transform.rotation.eulerAngles.z;

       _phoneRotation = Input.acceleration.x * _rotationSpeed;

       transform.Rotate(0, 0, -_phoneRotation);
    }

   public float phoneRotation()
   {
       return _phoneRotation;
   }
}
