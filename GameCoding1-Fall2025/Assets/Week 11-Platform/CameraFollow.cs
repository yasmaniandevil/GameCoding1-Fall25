using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed;
    public Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player != null)
        {

            //calculates the target position the camera should move to
            //creates a new position that considers where the camera is relative to player
            Vector3 desiredPos = player.position + offset;
            //lerp smoothly interpolate btwn the current position and the desired position
            Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            transform.position = smoothPos;
        }
    }
}
