using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //we can call it like a normal function
        //and pass in the string name
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadScene("Week2");
            
        }

        
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Toggle()
    {
        if (image.activeInHierarchy)
        {
            image.SetActive(false);
        }
        else
        {
            image.SetActive(true);
        }
    }
}
