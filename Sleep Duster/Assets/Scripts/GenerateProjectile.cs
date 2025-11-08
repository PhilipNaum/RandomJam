using UnityEngine;

public class GenerateProjectile : MonoBehaviour
{
    public GameObject projectile;

    public float minGenerationWait;

    public float generationFrequency;

    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            //float 
        }
    }

    private void Generate()
    {


        timer = minGenerationWait;
    }
}
