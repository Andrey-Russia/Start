using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpForce = 10f;
    public int MaxHealth;
    public Image[] Hearts;
    public GameObject DiePanel;
    public GameObject FinishPoint;

    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _isRight;
    private bool _isGrounded;
    private int _currentHealth;
    private bool _finishReached = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentHealth = MaxHealth;
        UpdateHearts();
        DiePanel.SetActive(false);
        _finishReached = false;

        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _rb.linearVelocity = new Vector2(horizontalInput * MoveSpeed, _rb.linearVelocity.y);
        if ((horizontalInput > 0 && !_isRight) || (horizontalInput < 0 && _isRight))
            Flip();
        _animator.SetBool("isRunning", Mathf.Abs(_rb.linearVelocity.x) > 0.1f);
    }

    void Update()
    {
        Jump();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _isGrounded = false;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            _animator.SetTrigger("isJumping");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damage"))
            TakeDamage(1);
        else if (other.CompareTag("UltraDamage"))
            TakeDamage(MaxHealth);
        else if (other.CompareTag("Finish"))
        {
            _finishReached = true;
            GameOver();
        }
    }

    void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        UpdateHearts();
        if (_currentHealth <= 0)
            GameOver();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i].enabled = (i < _currentHealth);
        }
    }

    void GameOver()
    {
        DiePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void Flip()
    {
        _isRight = !_isRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void SetSlowedSpeed(float slowedSpeed)
    {
        MoveSpeed = slowedSpeed;
    }

    public void ResetNormalSpeed(float normalSpeed)
    {
        MoveSpeed = normalSpeed;
    }
}