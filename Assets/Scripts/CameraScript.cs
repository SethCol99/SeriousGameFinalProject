using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float globalMaxX;
    public float globalMaxY;
    public float globalMinX;
    public float globalMinY;
    public Vector3 offset;

    void Start()
    {

    }

    void Update()
    {
        Vector3 start = transform.position;
        Vector3 goal = target.position + new Vector3(0.0f, 0.0f, -10);
        float t = Time.deltaTime * speed;
        Vector3 newPosition = Vector3.Lerp(start, goal + offset, t);
        //Vector3 newPosition = goal;
        float maxX = globalMaxX - Camera.main.orthographicSize * Camera.main.aspect;
        float maxY = globalMaxY - Camera.main.orthographicSize;
        float minX = globalMinX + Camera.main.orthographicSize * Camera.main.aspect;
        float minY = globalMinY + Camera.main.orthographicSize;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;
    }

    public float getMaxY()
    {
        return globalMaxY;
    }
}
