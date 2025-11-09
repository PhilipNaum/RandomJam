using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{
    public string nextScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
