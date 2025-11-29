using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}