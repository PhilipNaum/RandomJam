using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchButton : MonoBehaviour
{
    public SpriteRenderer sprite;

    string nextScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Touch touch = Input.GetTouch(0);

        if (sprite.bounds.Contains(touch.position))
        {
            if (touch.phase == TouchPhase.Ended)
            {
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                sprite.color = Color.cyan;
            }
        }
        else
        {
            sprite.color = Color.white;
        }
    }
        
}
