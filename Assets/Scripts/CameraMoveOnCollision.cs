using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveOnCollision : MonoBehaviour
{

    bool active;
    public Vector3 moveCameraToPoint;
    public float timeToMove = 0.5f;
    float moveTimer;
    GameObject collidedObject;
    public Vector3 otherMoveToPoint;
    Camera camera;

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
            camera.transform.position += ((moveCameraToPoint - camera.transform.position) / moveTimer) * Time.deltaTime;
            if (Time.deltaTime >= moveTimer)
            {
                camera.transform.position = moveCameraToPoint;
                collidedObject.transform.position = otherMoveToPoint;
                collidedObject.gameObject.active = true;
                active = false;
            }
            moveTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ArrowKeyMovement>())
        {
            active = true;
            moveTimer = timeToMove;
            other.gameObject.active = false;
            collidedObject = other.gameObject;
        }
    }
}
