using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField]
    Vector3 velocity;

    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float angle = transform.rotation.eulerAngles.z + 90;
        velocity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += velocity * Time.deltaTime;
    }
}
