using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    //we have to tell unity what image we want it to toggle!
    public GameObject image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //we are making a loadscene function
    //that passes the name of our scene into it when we call the function
    //inside the () is called parameters or arguments
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //every function we call through the button has to be public
    public void Toggle()
    {
        //if the image is turned on in the hierarchy
        if (image.activeInHierarchy) 
        {
            //turn off the image
            image.SetActive(false);
        }
        else //else if the image is not active in hierarchy
        {
            //then we turn on the image!
            image.SetActive(true);
        }
    }
}
