using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))] // force Renderer component to be attached
public class KeepWithinScreen : MonoBehaviour
{
    private Renderer rend; // rendered attached to an object
    private Camera cam; // camera container (variable)
    private Bounds camBounds; // camera bounds structure
    private float camWidth, camHeight;

    // Use this for initialization
    void Start()
    {
        // set camera variable to main camera
        cam = Camera.main;
        // get the Renderer component attached to this project
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the camera bounds
        UpdateCamBounds();
        // set the position after checking bounds
        transform.position = CheckBounds();
    }
    void UpdateCamBounds()
    {
        // calculate camBounds
        camHeight = 2f * cam.orthographicSize; // height = 2 * orthographi size
        camWidth = camHeight * cam.aspect; // width = height * cam aspect
        camBounds = new Bounds(cam.transform.position, new Vector3(camWidth, camHeight));
    }
    Vector3 CheckBounds()
    {
        Vector3 pos = transform.position;
        Vector3 size = rend.bounds.size;
        float halfWidth = size.x * 0.5f;
        float halfHeight = size.y * 0.5f;
        float halfCamWidth = camWidth * 0.5f;
        float halfCamHeight = camHeight * 0.5f;
        // Check Left
        if (pos.x - halfWidth < camBounds.min.x)
        {
            pos.x = camBounds.min.x + halfWidth;
        }
        // Check right  
        else if (pos.x + halfWidth > camBounds.max.x)
        {
            pos.x = camBounds.max.x - halfWidth;
        }
        // Check down
        if (pos.y - halfHeight < camBounds.min.y)
        {
            pos.y = camBounds.min.y + halfHeight;
        }
        // Check up
        else if (pos.y + halfHeight > camBounds.max.y)
        {
            pos.y = camBounds.max.y - halfHeight;
        }
        return pos; // return adjusted position
    }
}
