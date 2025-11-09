using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TouchButton : MonoBehaviour
{
    public SpriteRenderer render;

    public GameObject something;

    public string nextScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        render.color = Color.green;
    }

    public void Touch(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(nextScene);
    }
}
