using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> disappearingPlatforms = new List<GameObject>();

    private void Awake()
    {
        //if we have no instance of the game manager
        if(instance == null)
        {
            //then dont destroy this one
            DontDestroyOnLoad(gameObject);
            //and this script is the current instance
            instance = this;
        }
        else
        {
            //otherwise destroy it (if we already have a game manager in the scene, so there is only 1 at a time)
            Destroy(gameObject);
        }

        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void RespawnPlatforms()
    {
        foreach(GameObject platform in disappearingPlatforms)
        {
            //we are making a variable for our disappearing platform script
            DisappearingPlatform disPlatform;
            //every platform we have on our list we want to grab the script off of it and assign it to our var
            disPlatform = platform.GetComponent<DisappearingPlatform>();
            //call our function that resets our platform by turning them back on
            disPlatform.ResetPlatform();
        }
    }
}
