using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveOnLeave : MonoBehaviour
{
    bool active;
    Vector3 moveCameraToPoint;
    public float timeToMove = 0.5f;
    float moveTimer;
    Vector3 otherMoveToPoint;
    Camera camera;
    public float roomSizeX;
    public float roomSizeY;
    public float offsetY;
    public float otherMoveDistance;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<ArrowKeyMovement>().enabled = false;
            camera.transform.position += ((moveCameraToPoint - camera.transform.position) / moveTimer) * Time.deltaTime;
            if (Time.deltaTime >= moveTimer)
            {
                camera.transform.position = moveCameraToPoint;
                transform.position = otherMoveToPoint;
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<ArrowKeyMovement>().enabled = true;
                active = false;
            }
            moveTimer -= Time.deltaTime;
        }
        else if (transform.position.x - camera.transform.position.x > roomSizeX/2)
        {
            active = true;
            moveCameraToPoint = new Vector3(camera.transform.position.x + roomSizeX, camera.transform.position.y, camera.transform.position.z);
            otherMoveToPoint = new Vector3(transform.position.x + otherMoveDistance, transform.position.y, transform.position.z);
            moveTimer = timeToMove;
        }
        else if (camera.transform.position.x - transform.position.x > roomSizeX / 2)
        {
            active = true;
            moveCameraToPoint = new Vector3(camera.transform.position.x - roomSizeX, camera.transform.position.y, camera.transform.position.z);
            otherMoveToPoint = new Vector3(transform.position.x - otherMoveDistance, transform.position.y, transform.position.z);
            moveTimer = timeToMove;
        }
        else if ((camera.transform.position.y - offsetY) - transform.position.y > roomSizeY / 2)
        {
            active = true;
            moveCameraToPoint = new Vector3(camera.transform.position.x, camera.transform.position.y - roomSizeY, camera.transform.position.z);
            otherMoveToPoint = new Vector3(transform.position.x, transform.position.y - otherMoveDistance, transform.position.z);
            moveTimer = timeToMove;
        }
        else if (transform.position.y - (camera.transform.position.y - offsetY) > roomSizeY / 2)
        {
            active = true;
            moveCameraToPoint = new Vector3(camera.transform.position.x, camera.transform.position.y + roomSizeY, camera.transform.position.z);
            otherMoveToPoint = new Vector3(transform.position.x, transform.position.y + otherMoveDistance, transform.position.z);
            moveTimer = timeToMove;
        }
    }
}
