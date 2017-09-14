using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitWithPanAndZoom : MonoBehaviour
{
    public Transform target; // Target object to orbit around
    public float panSpeed = 5f;
    public float sensitivity = 1f;

    // Minimum & maximum zoom distance
    public float distanceMin = 0.5f;
    public float distanceMax = 15f;

    private float distance = 0f; // Current distance betweem target and camera
    // Stored X & Y euler rotation
    private float x = 0.0f;
    private float y = 0.0f;

    // Create an enum to use for mouse input (just for readability)
    public enum MouseButton
    {
        LEFTMOUSE = 0,
        RIGHTMOUSE = 1,
        MIDDLEMOUSE = 2,
    }

    // Use this for initialization
    void Start()
    {
        // CALL target transform's SetParent(null)
        Transform camTarget = transform.FindChild("Cam_Target");
        camTarget.SetParent(null);
        // ...Detaches the target from children

        // SET distance = Vector3.Distance(target's position, transform's position)
        float distance = Vector3.Distance(camTarget.position, transform.position);
        // ...Calculates distance to target

        // LET angles = transform's eulerAngles
        Vector3 angles = transform.eulerAngles;
        // SET x = angles.x
        float x = angles.x;
        //SET y = angles.y
        float y = angles.y;
        // ...Records the current euler rotation
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton((int)MouseButton.RIGHTMOUSE))
        {
            HideCursor(true);
            Orbit();
        }
        else if (Input.GetMouseButton((int)MouseButton.MIDDLEMOUSE))
        {
            HideCursor(true);
            Pan();
        }
        else
        {
            HideCursor(false);    
        }
        Movement();
    }
    void Orbit()
    {
        // SET x = x + Input Axis "Mouse Y" x sensitivity
        x += -Input.GetAxis("Mouse Y") * sensitivity;
        // SET y = y - Input Axis "Mouse X" x sensitivity
        y += -Input.GetAxis("Mouse X") * sensitivity;
    }
    void Movement()
    {
        // IF target != null
        if (target != null)
        {
            // LET rotation = Quaternion Euler(x,y,0)
            Quaternion rotation = Quaternion.Euler(new Vector3(x, y, 0));
            // LET desiredDist = distance - Input Axis "Mouse ScrollWheel"
            float desiredDist = distance - Input.GetAxis("Mouse ScrollWheel");
            // SET desiredDist = desiredDist * sensitivity
            desiredDist *= sensitivity;
            // ...Amplifies desiredDist by sensitivity(Scroll Speed)
            // SET distance = Matf.Clamp(desiredDist,ditanceMin,distanceMax);
            distance = Mathf.Clamp(desiredDist, distanceMin, distanceMax);
            // ...Clamps the result so that distance doesn't go outside of constraints
            // LET invDistanceZ = new Vector3(0,0, -distance)
            Vector3 invDistanceZ = new Vector3(0, 0, -distance);
            // SET invDistanceZ = rotation * invDistancez
            invDistanceZ = rotation * invDistanceZ;
            // ...Rotates the direction of vector to be local to camera
            // LET position = target.position + invDistanceZ
            Vector3 position = target.position + invDistanceZ;
            // SET transform.position = rotation
            transform.rotation = rotation;
            // SET transform.position = position
            transform.position = position;
        }
    }
    // Moves the target using X and Y mouse coordinates to create panning effect
    void Pan()
    {
        // LET inputX = -Input GetAxis "Mouse X"
        float inputX = Input.GetAxis("Mouse X");
        // LET inputY = -Input GetAxis "Mouse Y"
        float inputY = Input.GetAxis("Mouse Y");

        // LET inputDir = new Vector3(inputX,inputY)
        Vector3 inputDir = new Vector3(inputX, inputY);

        // LET movement = transform.TransformDirection(inputDir)
        Vector3 movement = transform.TransformDirection(inputDir);
        // SET target.transform.position += movement x panSpeed x deltaTime
    }
    // Hides / Unhides the cursor
    void HideCursor(bool isHiding)
    {
        if (isHiding)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
