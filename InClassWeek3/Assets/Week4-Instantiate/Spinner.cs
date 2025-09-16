using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotation on the z axis and multiplying it by speed not frame rate
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }
}
