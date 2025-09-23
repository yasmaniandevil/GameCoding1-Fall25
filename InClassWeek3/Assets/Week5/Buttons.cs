using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Toggle()
    {
        //if the image is toggled on, and is not greyed out in the inspector
        //then when we click the button turn it off
        if(image.activeInHierarchy)
        {
            image.SetActive(false);
        }
        else //if the image is not active (greyed out) then turn it on
        {
            image.SetActive(true);
        }
    }
    
}
