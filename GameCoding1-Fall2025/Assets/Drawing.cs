using UnityEngine;

public class Drawing : MonoBehaviour
{
    //variable for drawing item
    public GameObject pencil;
    
    //variable to render lines drawn
    LineRenderer currentLineRenderer;

    Vector2 lastPos;

    //variable for camera, lets us know to put our pencil inside of camera view
    public Camera m_camera;

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
        Debug.Log("Mouse position: " + mousePos);
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
            
            CreateStroke();
            PointToMousePos(); //add first point here
        }
        
        else if (Input.GetKey(KeyCode.Mouse0)) //keep adding while its held
        {
            PointToMousePos();
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0)) 
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
        //must have two points to form a line
        //Vector2 mousePos = m_camera.ScreenToWorldPoint (Input.mousePosition);
        //currentLineRenderer.SetPosition(0, mousePos);
        //currentLineRenderer.SetPosition(0, mousePos);

        currentLineRenderer.positionCount = 0;
        currentLineRenderer.useWorldSpace = true;
    }


    
   
}
