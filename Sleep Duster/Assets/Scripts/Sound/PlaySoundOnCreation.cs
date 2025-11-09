using UnityEngine;

public class PlaySoundOnCreation : MonoBehaviour
{
    public GameObject sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject newSound = Instantiate(sound);
        AudioSource clip = newSound.GetComponent<AudioSource>();
        clip.Play();

        Destroy(newSound, clip.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
