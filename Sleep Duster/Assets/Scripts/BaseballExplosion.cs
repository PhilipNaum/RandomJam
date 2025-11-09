using UnityEngine;

public class BaseballExplosion : MonoBehaviour
{
    [SerializeField]
    float timer = 0;

    public float minTimeToSet;
    public float maxTimeToSet;

    public float radius;

    public GameObject explosion;

    public SpriteRenderer ballRender;

    public Sprite aboutToExplode;

    private bool exploding = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!exploding)
        {
            if (transform.position.magnitude < radius)
            {
                exploding = true;
                timer = Random.Range(minTimeToSet, maxTimeToSet);
            }
        }
        else 
        { 
            if (timer > 0)
            {
                ballRender.sprite = aboutToExplode;
                ballRender.color = Color.red;

                timer -= Time.deltaTime;
            }
            else
            {
                GameObject newExplosion = Instantiate(explosion);
                newExplosion.transform.position = transform.position;

                Destroy(gameObject);
            }
        }
    }
}
