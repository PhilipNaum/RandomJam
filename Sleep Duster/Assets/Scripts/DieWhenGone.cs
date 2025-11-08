using UnityEngine;

public class DieWhenGone : MonoBehaviour
{
    private float xBounds;
    private float yBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yBounds = Camera.main.orthographicSize + 1;
        xBounds = yBounds * Camera.main.aspect + 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
    }

    private void CheckBounds()
    {
        Vector2 position = gameObject.transform.position;

        if (position.x > xBounds || position.x < -xBounds || position.y > yBounds || position.y < -yBounds)
        {
            Destroy(gameObject);
        }
    }
}
