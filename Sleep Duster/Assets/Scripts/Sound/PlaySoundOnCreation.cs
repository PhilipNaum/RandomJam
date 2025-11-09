using UnityEngine;

public class PlaySoundOnCreation : MonoBehaviour
{
    public AudioSource sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
