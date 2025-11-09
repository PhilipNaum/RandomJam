using UnityEngine;

public class PlayOnCollision : MonoBehaviour
{
    public AudioSource sound;
    public string tagName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            sound.enabled = true;
            sound.Play();
        }
    }
}
