using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20;
    public float panBorderThickness = 10f;
    public float upperBound;
    public float lowerBound;
    public float leftBound;
    public float rightBound;
    public float minHeightBound;
    public float maxHeightBound;

    public float scrollSpeed = 200f;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if ( Input.mousePosition.x <= panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -lowerBound, upperBound);
        pos.y = Mathf.Clamp(pos.y, minHeightBound , maxHeightBound);
        pos.z = Mathf.Clamp(pos.z, -rightBound, leftBound);
        transform.position = pos;

    }
}
