using UnityEngine;

public class ShotGunTelegraph : MonoBehaviour
{
    public GameObject shotGunSpray;

    public Rigidbody2D rgBody;

    [SerializeField]
    Vector3 position;

    [SerializeField]
    Vector3 velocity;

    public float startingSpeed;

    public float distanceStop;

    [SerializeField]
    float distance;

    private float startingDistance;

    public float telegraphTime;

    public float stayTime;

    private bool fire = false;

    [SerializeField]
    float timer;

    private ParticleSystem shotGunBlast;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = telegraphTime;

        float angle = transform.rotation.eulerAngles.z + 90;
        velocity = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0).normalized * startingSpeed;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        position = transform.position;
        startingDistance = position.magnitude;
        distance = position.magnitude;

        shotGunBlast = GetComponentInChildren<ParticleSystem>();
        shotGunBlast.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        position = transform.position;
        distance = position.magnitude;

        if (!fire)
        {
            if (timer > 0)
            {
              
                timer -= Time.fixedDeltaTime;
                
                
                //velocity = velocity.normalized * startingSpeed * (timer / telegraphTime);
                //position += velocity * Time.fixedDeltaTime;
                

                distance = (timer / telegraphTime) * (startingDistance - distanceStop) + distanceStop;
                position = position.normalized * distance;
            }
            else
            {
                fire = true;
                timer = stayTime;
                Instantiate(shotGunSpray, new Vector3(position.x, position.y, .25f), Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 90));
                shotGunBlast.Play();
            }
        }
        else
        {
            if (timer > 0)
            {
                timer -= Time.fixedDeltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        rgBody.MovePosition(position);
    }
}
