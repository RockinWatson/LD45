using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;
    public float FollowSpeed = 2f;

    public bool Bounds;

    public Vector3 MinCameraPos;
    public Vector3 MaxCameraPos;

    private void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = PlayerTransform.position;
        newPosition.z = -10;
        newPosition.y = PlayerTransform.position.y + 2;
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);

        //Camera Bounds
        if (Bounds)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, MinCameraPos.x, MaxCameraPos.x),
                Mathf.Clamp(transform.position.y, MinCameraPos.y, MaxCameraPos.y),
                Mathf.Clamp(transform.position.z, MinCameraPos.z, MaxCameraPos.z));
        }
    }
}
