using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    public class MoveWithinBounds : MonoBehaviour
    {
        /*public float panSpeed = 30f;
        public float panBorderThickness = 10f;

        public float scrollSpeed = 2f;
        public float minY = 10f;
        public float maxY = 50f;

        void Update()
        {

            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");

            Vector3 pos = transform.position;

            pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            transform.position = pos;
        }*/
        public float movementSpeed = 20f;
        public float zoomSensitivity = 10f;
        public CamBounds bounds;

        void Update()
        {
            Vector3 pos = transform.position;
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");
            Vector3 inputDir = new Vector3(inputH, 0f, inputV);
            pos += inputDir * movementSpeed * Time.deltaTime;
            float inputScroll = Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
            Vector3 scrollDir = transform.forward * inputScroll;
            pos += scrollDir;
            pos = bounds.GetAdjustedPos(pos);
            transform.position = pos;
        }
    }
}