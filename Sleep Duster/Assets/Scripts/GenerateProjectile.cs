using UnityEngine;

public class GenerateProjectile : MonoBehaviour
{
    [Header("Time Until Generation Begins")]
    public float activationTimer;

    [Header("Projectiles (place in incrementing order of difficulty) and Timer for Progressing to Down List")]
    public GameObject[] projectiles;

    public float diffIncTime = 10;

    [SerializeField]
    float changeTimer;

    private int index;


    [Header("Minimum Time Until a Projectile is Generated and Possible Varation on the Wait Time")]
    public float minGenerationWait;

    public float variation;

    [SerializeField]
    float timer;

    private float generationBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = minGenerationWait;
        generationBounds = Camera.main.orthographicSize * Camera.main.aspect + 0.5f;

        changeTimer = diffIncTime;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (activationTimer < 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                //float
                Generate();
            }

            if (index < projectiles.Length - 1)
            {
                if (changeTimer > 0)
                {
                    changeTimer -= Time.deltaTime;
                }
                else
                {
                    index++;
                    changeTimer = diffIncTime;
                }
            }
        }
        else
        {
            activationTimer -= Time.deltaTime;
        }
    }

    private void Generate()
    {
        int xOrY = Random.Range(0, 2);
        int negOrPos = Random.Range(0, 2);

        Vector3 startPosition;

        if (xOrY == 0)
        {
            if (negOrPos == 0)
            {
                startPosition = new Vector3(Random.Range(-generationBounds, generationBounds), -generationBounds, 0);
            }
            else
            {
                startPosition = new Vector3(Random.Range(-generationBounds, generationBounds), generationBounds, 0);
            }
        }
        else
        {
            if (negOrPos == 0)
            {
                startPosition = new Vector3(-generationBounds, Random.Range(-generationBounds, generationBounds), 0);
            }
            else
            {
                startPosition = new Vector3(generationBounds, Random.Range(-generationBounds, generationBounds), 0);
            }
        }

        Vector3 localLookVect = Vector3.zero - startPosition;
        float lookAngle = Mathf.Atan2(localLookVect.y, localLookVect.x) * Mathf.Rad2Deg - 90;

        lookAngle += Random.Range(-20, 20);

        Quaternion rotation = Quaternion.Euler(0, 0, lookAngle);

        GameObject newProjectile = Instantiate(projectiles[index], startPosition, rotation);

        timer = minGenerationWait + Random.Range(0, variation);
    }
}
