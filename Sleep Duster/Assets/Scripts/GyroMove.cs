using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GyroMove : MonoBehaviour
{
    [SerializeField]
    Vector3 velocity;

    public float maxSpeed;

    [SerializeField]
    Vector3 acceleration;

    public float gyroWeight;

    public SpriteRenderer sprite;

    private void Awake()
    { 
        //InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Vector3.zero;
        acceleration += GyroForce(gyroWeight);
        //acceleration += SeekCenter(3, 0.5f);

        velocity += acceleration * Time.deltaTime;

        if (velocity.magnitude > maxSpeed)
            velocity = velocity.normalized * maxSpeed;

        transform.position += velocity * Time.deltaTime;

        circleBounds(1.5f);
        Debug.Log("Update");
    }

    private Vector3 GyroForce(float weight)
    {
        Vector3 rotation = Input.gyro.gravity;

        Vector3 desiredVelocity = new Vector3(rotation.x, rotation.y, 0).normalized * maxSpeed;

        Vector3 steeringForce = desiredVelocity - velocity;

        sprite.color = Color.green;

        return steeringForce * weight;
    }

    //
    // Circle Bounds
    //

    private void circleBounds(float radius)
    {
        Vector3 center = Vector3.zero;

        Vector3 distance = (gameObject.transform.position - center);

        if (distance.magnitude > radius)
        {
            gameObject.transform.position = center + distance.normalized * radius;
        }
    }

    //
    // Seek
    //

    protected Vector3 Seek(Vector3 point)
    {
        return Seek(point, 1);
    }

    protected Vector3 Seek(Vector3 point, float weight)
    {
        Vector3 desiredVelocity = point - gameObject.transform.position;
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 steeringForce = desiredVelocity - velocity;
        return steeringForce * weight;
    }

    protected Vector3 SeekCenter()
    {
        return SeekCenter(3, 2);
    }

    protected Vector3 SeekCenter(float radius, float weight)
    {
        Vector3 center = Vector3.zero;

        float distance = (gameObject.transform.position - center).magnitude;

        if (distance > radius)
        {
            return (Seek(center, distance * weight * 0.1f));
        }
        else
        {
            return Vector3.zero;
        }
    }
}
