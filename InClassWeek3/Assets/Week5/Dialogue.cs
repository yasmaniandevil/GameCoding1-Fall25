using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private int dialogueLine = -1;
    public TextMeshProUGUI dialogueText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //everytime we hit space it adds one and changes the dialogue line
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //calling our function
            NextDialogueLine();
        }
    }

    //switch statment provides a structeeed way to execute code based on the value of a single variable
    //this is an alternative to writing multiple if statements
    private void ShowDialogueLine()
    {
        switch(dialogueLine)
        {
            case 0:
                dialogueText.text = "Hello";
                break;
            case 1:
                dialogueText.text = "What is up mi friend";
                break;
            case 2:
                dialogueText.text = "Nothing much";
                break;
            case 3:
                dialogueText.text = "hush hush";
                break;
        }

        //this is how we would write it if it was if statements
        /*if(dialogueLine == 0)
        {
            dialogueText.text = "Hello";
        }
        if(dialogueLine == 1)
        {
            dialogueText.text = "something";
        }*/
    }



    private void NextDialogueLine()
    {
        //++ means it adds 1
        //dialogueline is -1 at start
        //then we add 1 which equals 0
        //then we add 1 again which equals 1
        //then we add 1 again which equals 2
        dialogueLine++;
        ShowDialogueLine();
    }
}
