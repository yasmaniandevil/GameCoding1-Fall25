using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Player playerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find the player script off of the player assign it to our var
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //updating our respawn point to whatever the transform is on the gameobject with the checkpoint script attached
            playerScript.UpdateRespawnPoint(transform);
        }
    }
}
