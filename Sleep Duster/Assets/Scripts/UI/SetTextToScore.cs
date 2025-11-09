using TMPro;
using UnityEngine;

public class SetTextToScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public string starterText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = starterText + PlayerPrefs.GetFloat("Time").ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
