using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField]
    float timer = 0;

    public TextMeshProUGUI timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        timerText.text = timer.ToString("0.00");
    }
}
