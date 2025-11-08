using UnityEngine;
using UnityEngine.InputSystem;

public class GyroMove : MonoBehaviour
{
    [SerializeField]
    Vector3 velocity;

    [SerializeField]
    Vector3 acceleration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
    }

    public void OnGyro(InputAction.CallbackContext context)
    {
        Vector3 gyro = context.ReadValue<Vector3>();

        acceleration = new Vector3(gyro.x, gyro.z, 0);
    }
}
