using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float disappearTime = 2f;
    public bool playerOnPlatform = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform)
        {
            disappearTime -= Time.deltaTime;
            if(disappearTime < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
        else
        {
            playerOnPlatform = false;
        }
    }

    public void ResetPlatform()
    {
        //turn the platform back on
        gameObject.SetActive(true);
        //reset the time
        disappearTime = 2;
        playerOnPlatform = false;
    }
}
