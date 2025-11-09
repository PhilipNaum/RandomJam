using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchButton : MonoBehaviour
{
    public SpriteRenderer sprite;

    public GameObject something;

    public string nextScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Input.simulateMouseWithTouches = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount > 0)
        {
            Touch tap = Input.GetTouch(0);

            GameObject somethingNew = Instantiate(something);
            somethingNew.transform.position = tap.position;


            if (sprite.bounds.Contains(tap.position))
            {
                if (tap.phase.Equals(TouchPhase.Ended))
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
}
