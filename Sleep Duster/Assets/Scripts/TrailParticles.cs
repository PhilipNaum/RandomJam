using UnityEngine;

public class TrailParticles : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem trailParticles;

    private ParticleSystem trailParticlesInstance;

    private SpriteRenderer sr;

    private Vector3 particlePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trailParticlesInstance = Instantiate(trailParticles, this.transform.position, this.transform.rotation);
        sr = GetComponent<SpriteRenderer>();
        particlePos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        particlePos = new Vector3(this.transform.position.x, this.transform.position.y - sr.bounds.size.y/2, 0);
        trailParticlesInstance.transform.position = particlePos;
    }
}
