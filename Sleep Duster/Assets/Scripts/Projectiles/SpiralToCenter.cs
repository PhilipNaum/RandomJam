using UnityEngine;

public class SpiralToCenter : MonoBehaviour
{
    [SerializeField]
    Vector3 position;

    [SerializeField]
    float angle;

    public float angleChangeRate;

    [SerializeField]
    float distance;

    public float distanceChangeRate;

    public Rigidbody2D rgBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.rotation = Quaternion.identity;

        position = transform.position;

        angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        distance = position.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        position = transform.position;
        angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        distance = position.magnitude;

        angle += angleChangeRate * Time.fixedDeltaTime;
        distance -= distanceChangeRate * Time.fixedDeltaTime;

        if (distance < 0)
            distance = 0;

        position = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0).normalized * distance;

        if (position == Vector3.zero)
        {
            Destroy(gameObject);
        }

        rgBody.MovePosition(position);
    }
}
