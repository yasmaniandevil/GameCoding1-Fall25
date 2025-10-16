using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    //[] means its an array which is a collection of colors!
    public Color[] colors;
    private int index = 0;
    //we have to grab the spriterenderer to access the color
    private SpriteRenderer spriteRendy;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //grabbing the sprite renderer
        spriteRendy = GetComponent<SpriteRenderer>();
        //grab the color part of the componenet and equal it to the index, whatever that number may be
        //in start it will just be 0 (the index)
        spriteRendy.color = colors[index];
    }

    // Update is called once per frame
    void Update()
    {
        //if we hit the space bar
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //add one to the index
            index++;
            //colors.length means the how many things are in our array
            //so if we have 8 colors the length of our array is 7
            //if index equals 7 then we have to loop back to the beginning of the colors bc we ran out
            if(index >= colors.Length)
            {
                index = 0; //loops back around
            }
            //this is us actually changing the color
            spriteRendy.color = colors[index];
        }
        
        
    }
}
