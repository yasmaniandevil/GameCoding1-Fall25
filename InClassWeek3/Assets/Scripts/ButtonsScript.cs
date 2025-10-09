using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{

    //we are making a loadscene function
    //that passes the name of our scene into it when we call the function
    //inside the () is called parameters or arguments
    //we reference this with our button, and then fill in the name of the scene we want to load there
    //we can call the scene we are currently in if we just want to start over!
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
