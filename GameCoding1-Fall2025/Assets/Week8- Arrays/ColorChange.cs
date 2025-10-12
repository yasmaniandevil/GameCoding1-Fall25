using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color[] colors;
    private int index = 0;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        //grab the sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        //grab the color part of component equal it to the index, whatever index number it is
        //is whatever color its going to be
        spriteRenderer.color = colors[index];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            if(index >= colors.Length)
            {
                index = 0;//loop back
            }
            spriteRenderer.color = colors[index];
        }
        
    }
}
