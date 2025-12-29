using UnityEngine;

public class wind : MonoBehaviour
{
    public float slowFactor = 0.5f;
    public float normalMoveSpeed = 5f;
    public float slowedMoveSpeed;     

    private void Start()
    {
        slowedMoveSpeed = normalMoveSpeed * slowFactor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<CharacterController>().SetSlowedSpeed(slowedMoveSpeed);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<CharacterController>().ResetNormalSpeed(normalMoveSpeed);
    }
}
