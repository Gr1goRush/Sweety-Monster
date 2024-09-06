using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public float speed { get; private set; }
    public float lifeTime { get; private set; }
    private Vector3 posVector;

    private void OnValidate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Activate(Vector3 StartPos, float Speed, float LifeTime, Sprite ObstacleSprite)
    {
        lifeTime = LifeTime;
        transform.position = StartPos;
        speed = Speed;
        spriteRenderer.sprite = ObstacleSprite;

        if (Settings.GameIsPaused) { return; }
        gameObject.SetActive(true);

    }

    public void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (Settings.GameIsPaused) { return; }
            posVector = transform.position - Vector3.right * speed * Time.deltaTime;
            posVector.z = 0;
            transform.position = posVector;
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0 ) DeactivateSelf();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DeactivateSelf();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DeactivateSelf();
        }
    }
}
