using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public int dialogueLine = 0;

    public TextMeshProUGUI dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextDialogueLine();
        }
    }
    
    

    /*switch statements provide a structured way to execute different blocks of code
     based on the value of a single variable or expression. They are an alternative to
     multiple if-else if statements, especially when comparing against a series of constants.*/
    public void ShowDialogueLine()
    {
        switch(dialogueLine)
        {
            case 0:
                dialogueText.text = "Hello";
                break;
            case 1:
                dialogueText.text = "Goodbye";
                break;
            case 2:
                dialogueText.text = "Forever";
                break;
            case 3:
                dialogueText.text = "& Ever";
                break;
        }
    }

    public void NextDialogueLine()
    {
        dialogueLine++;
        ShowDialogueLine();
        
    }
}
