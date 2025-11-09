using UnityEngine;

public class SandParticles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    ParticleSystem sandParticles;

    private ParticleSystem sandParticlesInstance;

    private SpriteRenderer sr;

    private Vector3 particlesPos;

    void Start()
    {
        sandParticlesInstance = sandParticles;
        sr = GetComponent<SpriteRenderer>();
        particlesPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        particlesPos = new Vector3(this.transform.position.x, this.transform.position.y - sr.bounds.size.y, 0);
        sandParticles.transform.position = particlesPos;
        sandParticles.transform.rotation = this.transform.rotation;
    }
}
