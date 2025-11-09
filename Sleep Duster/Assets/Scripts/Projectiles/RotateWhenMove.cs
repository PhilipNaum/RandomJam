using UnityEngine;

public class RotateWhenMove : MonoBehaviour
{
    [SerializeField]
    float rotSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, rotSpeed * Time.deltaTime);
    }
}
