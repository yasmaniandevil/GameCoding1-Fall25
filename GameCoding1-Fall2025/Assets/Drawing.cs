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

        if(lastPos != mousePos)
        {
            //call our add point void
            AddPoint (mousePos);
            lastPos = mousePos;

        }

    }


    void Draw()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateStroke();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        else 
        { 
            currentLineRenderer = null;        
        }
    }

    //void to instantiate our pencil stroke
    public void CreateStroke()
    {
        //instantiate the stroke, and grab the line renderer to render it
        GameObject strokeInstance = Instantiate(pencil);  
        currentLineRenderer = strokeInstance.GetComponent<LineRenderer>();
        //must have two points to form a line
        Vector2 mousePos = m_camera.ScreenToWorldPoint (Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(0, mousePos);
    }


    
   
}
