using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField]
    Vector3 velocity = Vector3.zero;

    public float maxSpeed;

    [SerializeField]
    Vector3 acceleration;

    public float accelMag;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float angle = transform.rotation.eulerAngles.z + 90;
        acceleration = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0).normalized * accelMag;
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity.magnitude < maxSpeed)
        { 
            velocity += acceleration * Time.deltaTime;

            if (velocity.magnitude > maxSpeed) 
                velocity = velocity.normalized * maxSpeed; 
        }

        gameObject.transform.position += velocity * Time.deltaTime;
    }
}
