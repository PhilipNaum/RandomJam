using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField]
    float explosionTimer = 0;

    public float timeToExplode;
    public float explodeFinalScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (explosionTimer < timeToExplode)
        {
            float sizeChange = (explosionTimer / timeToExplode) * (explodeFinalScale - 1);

            gameObject.transform.localScale = new Vector3(1 + sizeChange, 1 + sizeChange);
            explosionTimer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
