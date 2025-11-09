using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthTracker : MonoBehaviour
{
    public SpriteRenderer playerSprite;

    //normal sprite
    [SerializeField]
    Sprite hurtSprite;

    //hurt sprite
    [SerializeField]
    Sprite normalSprite;

    [SerializeField]
    float maxHealth = 100;

    [SerializeField]
    float health;

    private float healthDivision;

    public Sprite[] spriteFrames;

    public SpriteRenderer sprRender;

    public string nextScene;

    [SerializeField]
    float sceneChangeTimer = 3;

    private float timer = 0;

    public GameObject blackOut;

    //hurt timer
    [SerializeField]
    float hurtSpriteTimer = 1;

    //bool to see if player got hit
    private bool hit;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hit = false;
        health = maxHealth;
        healthDivision = maxHealth / (spriteFrames.Length - 1) ;

        Debug.Log($"Health: {health}, Division: {healthDivision}");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;   

        UpdateSprite();
        DeadYet();

        //if hurt, start hurt timer
        hurtSpriteTimer -= Time.deltaTime;

        if(hurtSpriteTimer <= 0)
        {
            //reset sprite
            playerSprite.sprite = normalSprite;
            //set hurt to false
            hit = false;
            //reset timer
            hurtSpriteTimer = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "sand")
        {
            health -= 10;

            Destroy(collision.gameObject);

            //change sprite to hurt sprite
            playerSprite.sprite = hurtSprite;
            //set hit to true
            hit = true;

        }
    }

    private void UpdateSprite()
    {
        int index = spriteFrames.Length - 1;

        if (health > 0)
            index = (int) (maxHealth - health) / (int) healthDivision;

        sprRender.sprite = spriteFrames[index];
    }

    private void DeadYet()
    {
        if (health <= 0)
        {
            //playerSprite.color = Color.red;
            Instantiate(blackOut);

            sceneChangeTimer -= Time.deltaTime;

            if (sceneChangeTimer <= 0)
            {
                PlayerPrefs.SetFloat("Time", timer);
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
