using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class HeroControler : MonoBehaviour
{
    public float Speed = 5f;
    public float Jump_Force = 1f;
    public GameObject Bullet;
    public Transform Fire_Point;

    private Rigidbody2D rb;
    private bool _isFasingRight = true;
    private bool _isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
        Shoot();
    }
    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * Speed, rb.linearVelocity.y);

        if ((moveInput > 0 && !_isFasingRight) || (moveInput < 0 && _isFasingRight))
            Flip();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, Fire_Point.position, Fire_Point.rotation);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            rb.AddForce(Vector2.up * Jump_Force, ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        _isFasingRight = !_isFasingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
