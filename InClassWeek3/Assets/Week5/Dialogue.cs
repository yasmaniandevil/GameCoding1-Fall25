using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public int dialogueLine = 0;
    public TextMeshProUGUI dialogueText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if we hit space
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //call our function that changes our variable (increases it)
            //and changes the text
            NextDialogueLine();
        }
    }

    private void ShowDialogueLine()
    {
        //switch statements provie a structred way to execute different blocks of code
        //based on the value of a single variable. they are an alternative to a if statement
        switch(dialogueLine)
        {
            //we are accessing the text box in TMPro to change the text to hello
            case 0: dialogueText.text = "Hello";
                break;
            case 1: dialogueText.text = "I am in class";
                break;
            case 2: dialogueText.text = "Okay, sure";
                break;
            case 3: dialogueText.text = "Goodbye";
                break;
            
        }

        // a different way to write it with if statements
        if(dialogueLine == 0)
        {
            dialogueText.text = "Hello";
        }

        if(dialogueLine == 1)
        {
            //then change to i am in class
        }
    }

    private void NextDialogueLine()
    {
        int totalLines = 4;
        dialogueLine = dialogueLine % totalLines;

        //then after we change the value we call our function which updates where we are in the switch statement
        ShowDialogueLine();

        //if dialogue line is 0 we are going to add 1
        //if dialogueline is 1 we are going to add 1 so it equals 2
        //dialogueLine + 1;
        dialogueLine++;
       

    }
}
