using System.Collections;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    //variable for drawing item
    public GameObject pencil;
    //variable for camera, lets us know to put our pencil inside of camera view
    public Camera m_camera;
    
    //variable to render lines drawn
    LineRenderer currentLineRenderer;
    Vector2 lastPos;
    private float currentSharpness; //current ink amount
    private bool canDraw = true; //false when sharpness hits zero
    
    //sharpness settings
    public float maxSharpness = 1f;
    public float sharpnessDrainPerSec = .25f;
    public Color lineColor;
    
    //stroke fade settings
    public float visibleTime = 2f;
    public float fadeTime = 1f;

    void Start()
    {
        //star off with a sharp pencil!
        currentSharpness = maxSharpness;
    }
    // Update is called once per frame
    void Update()
    {
        Draw();
    }

    //void to add a point where seeker clicks
    void AddPoint(Vector2 pointPos)
    { 
        //adds new point to line renderer 
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        //sets the renderer position based on input of pos variables
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
    //having trouble getting my line to start where my mouse clicks
    void PointToMousePos()
    {
        //recognize the point on the camera where mouse is clicked
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        
        if(lastPos != mousePos)
        {
            //call our add point void
            AddPoint (mousePos);
            lastPos = mousePos;

        }

    }


    void Draw()
    {
        //the problem was we are calling createstroke every frame the mouse is help
        //and you ever increased the ppositionCont before setting positions, and thats why it spawns from 0, 0, 0
        if (Input.GetKeyDown(KeyCode.Mouse0)) //create stroke once on press
        {
            //if we cant draw exit the function
            if(!canDraw) return;
            
            CreateStroke();
            PointToMousePos(); //add first point here
        }
        //keep drawing while mouse is held
        if (Input.GetKey(KeyCode.Mouse0)) //keep adding while its held
        {
            if (!canDraw) return;
            //drain sharpness over time
            currentSharpness -= sharpnessDrainPerSec * Time.deltaTime;
            //if our current sharpness is 0
            if (currentSharpness <= 0f)
            {
                //then we set it to 0
                currentSharpness = 0f;
                //then this is where we say we cant draw
                canDraw = false;
                currentLineRenderer = null;
                return;
            }
            
            //update line transparency based on sharpness
            float alpha = Mathf.Clamp01(currentSharpness / maxSharpness);
            SetLineAlpha(currentLineRenderer, alpha);
            PointToMousePos();
        }
        //if the mouse is released
        if(Input.GetKeyUp(KeyCode.Mouse0)) 
        { 
            currentLineRenderer = null;        
        }

       
    }
    

    //we need to add a reset
    //void to instantiate our pencil stroke
    public void CreateStroke()
    {
        //instantiate the stroke, and grab the line renderer to render it
        GameObject strokeInstance = Instantiate(pencil);  
        currentLineRenderer = strokeInstance.GetComponent<LineRenderer>();
        currentLineRenderer.positionCount = 0;
        currentLineRenderer.useWorldSpace = true;
        //set the inital alpha based on how much ink we have left
        SetLineAlpha(currentLineRenderer, currentSharpness / maxSharpness);
        //start corotune that will wait, then fade this exact stroke over Fadetime Seconds, then destroy it
        StartCoroutine(FadeAndDestroy(strokeInstance, currentLineRenderer, visibleTime, fadeTime));
    }

    //helper function that sets both start and end colors to the same apha
    void SetLineAlpha(LineRenderer lr, float alpha)
    {
        //making a new variable called C that makes a new color, the line colors stary the same but the alpha is assigned to our parameter
        Color c = new Color(lineColor.r, lineColor.g, lineColor.b, alpha);
        lr.startColor = c;
        lr.endColor = c;
    }

    IEnumerator FadeAndDestroy(GameObject strokeGO, LineRenderer lr, float wait, float fade)
    {
        //wait before fading
        yield return new WaitForSeconds(wait);
        
        //remember the alpha line  we are starting from could be less than 1 if ink was low
        float startAlpha = lr.startColor.a;
        //fade out alpha 0 over fade seconds 
        float t = 0f;
        //over fade seconds, lerp the alpha from its current value to 0
        while (t < fade)
        {
            //make a new float that gets decided by mathf.lerp and its interpolating between our start alpha and what it should be
            //which is 0, over time
            float a = Mathf.Lerp(startAlpha, 0, t / fade);
            //so we are just passing in the line renderer parameter, and the alpha we made above
            SetLineAlpha(lr, a);
            t += Time.deltaTime;
            yield return null;
        } 
        //force fully invisible
       SetLineAlpha(lr, 0f);
       //we are destroying the line renderer 
       Destroy(strokeGO);
    }

    //we will call this function through our button
    //resets ink to full and allows drawing
    public void Sharpen()
    {
        currentSharpness = maxSharpness;
        canDraw = true;
    }


    
   
}
