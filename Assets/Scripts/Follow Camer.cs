using UnityEngine;

public class FollowCamer : MonoBehaviour
{
    public Transform playerTransform; 
    public float horizontalOffset = 0f; 
    public float verticalOffset = 0f;   
    public float smoothSpeed = 0.125f;  

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 desiredPosition = new Vector3(
                playerTransform.position.x + horizontalOffset,
                playerTransform.position.y + verticalOffset,
                transform.position.z); 

            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        }
    }

    private Vector3 velocity = Vector3.zero;
}
