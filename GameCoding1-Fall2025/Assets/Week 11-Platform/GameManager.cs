using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> disappearingPlatforms = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlatforms()
    {
        foreach (GameObject platform in disappearingPlatforms )
        {
            disapearPlatform disapearPlatform;
            disapearPlatform = platform.GetComponent<disapearPlatform>();
            disapearPlatform.ResetPlatform();
            
        }
    }
}
