using UnityEngine;

public class BecomeOpaque : MonoBehaviour
{
    public SpriteRenderer render;

    public float blackOutTime;

    [SerializeField]
    float timer = 0;

    private float grayScale = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        render.color = new Color(0,0,0,grayScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < blackOutTime)
        {
            timer += Time.deltaTime;

            grayScale = timer / blackOutTime;

            render.color = new Color(0, 0, 0, grayScale);
        }
    }
}
