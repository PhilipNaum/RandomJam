using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthTracker : MonoBehaviour
{
    public Collider2D player;

    [SerializeField]
    float maxHealth = 100;

    [SerializeField]
    float health;

    private float healthDivision;

    public Sprite[] spriteFrames;

    public SpriteRenderer sprRender;

    public string nextScene;

    [SerializeField]
    float sceneChangeTimer = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        healthDivision = maxHealth / spriteFrames.Length;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();
        DeadYet();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "sand")
        {
            health -= 10;

            Destroy(collision.gameObject);
        }
    }

    private void UpdateSprite()
    {
        sprRender.sprite = spriteFrames[(int) health % (int) healthDivision];
    }

    private void DeadYet()
    {
        if (health <= 0)
        {
            if (player.gameObject != null)
                Destroy(player.gameObject);

            sceneChangeTimer -= Time.deltaTime;

            if (sceneChangeTimer <= 0)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
