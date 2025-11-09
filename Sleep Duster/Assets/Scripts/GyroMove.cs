using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GyroMove : MonoBehaviour
{
    [SerializeField]
    Vector3 position;

    [SerializeField]
    Vector3 velocity;

    public float maxSpeed;

    [SerializeField]
    Vector3 acceleration;

    public float gyroWeight;

    public Rigidbody2D rgBody;

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
        /*
        position = gameObject.transform.position;

        acceleration = Vector3.zero;
        acceleration += GyroForce(gyroWeight);
        //acceleration += SeekCenter(3, 0.5f);

        velocity += acceleration * Time.deltaTime;

        if (velocity.magnitude > maxSpeed)
            velocity = velocity.normalized * maxSpeed;

        transform.position += velocity * Time.deltaTime;

        CircleBounds(1.5f);
        */
    }

    private void FixedUpdate()
    {
        position = gameObject.transform.position;

        acceleration = Vector3.zero;
        acceleration += GyroForce(gyroWeight);
        //acceleration += SeekCenter(3, 0.5f);

        velocity += acceleration * Time.fixedDeltaTime;

        if (velocity.magnitude > maxSpeed)
            velocity = velocity.normalized * maxSpeed;

        AngleByVelocity();

        position += velocity * Time.fixedDeltaTime;

        CircleBounds(2f);

        rgBody.MovePosition(position);
    }

    private Vector3 GyroForce(float weight)
    {
        Vector3 rotation = Input.gyro.gravity;

        Vector3 desiredVelocity = new Vector3(rotation.x, rotation.y, 0).normalized * maxSpeed;

        Vector3 steeringForce = desiredVelocity - velocity;

        return steeringForce * weight;
    }

    //
    // Circle Bounds
    //

    private void CircleBounds(float radius)
    {
        Vector3 center = Vector3.zero;

        Vector3 distance = (position - center);

        if (distance.magnitude > radius)
        {
            position = center + distance.normalized * radius;
        }
    }

    private void AngleByVelocity()
    {
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg + 90;

        rgBody.MoveRotation(angle);
    }
}
