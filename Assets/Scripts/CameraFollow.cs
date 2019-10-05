using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;
    public float FollowSpeed = 2f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = PlayerTransform.position;
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
    }
}
