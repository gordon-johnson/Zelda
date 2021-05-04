using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMasterMovement : MonoBehaviour
{

    public float distance;
    public float horizontal;
    public float vertical;
    public float maxResetTime;
    public float speed;
    private float resetTimer;
    private float distanceTraveled;
    private Vector3 startPosition;
    private GameObject grabbedObject;

    // Start is called before the first frame update
    void Start()
    {
        distanceTraveled = 0;
        resetTimer = 0;
        startPosition = transform.position;
        grabbedObject = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (resetTimer > 0)
        {
            resetTimer -= Time.deltaTime;
        } else
        if (distanceTraveled < distance)
        {
            if (Mathf.Abs(transform.position.x - startPosition.x) < Mathf.Abs(horizontal * 2) || Mathf.Abs(transform.position.y - startPosition.y) < Mathf.Abs(vertical * 2))
            {
                transform.position += new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
                if (Mathf.Abs(transform.position.x - startPosition.x) > Mathf.Abs(horizontal * 2) || Mathf.Abs(transform.position.y - startPosition.y) > Mathf.Abs(vertical * 2))
                {
                    transform.position = new Vector3((horizontal * 2) + startPosition.x, (vertical * 2) + startPosition.y, transform.position.z);
                }
            } else
            {
                transform.position += new Vector3(vertical, horizontal, 0) * speed * Time.deltaTime;
                distanceTraveled += speed * Time.deltaTime;
            }
        } else
        {
            if ((transform.position.y - startPosition.y) * vertical > 0 || (transform.position.x - startPosition.x) * horizontal > 0)
            {
                transform.position -= new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
            } else
            {
                resetTimer = maxResetTime;
                transform.position = startPosition;
                distanceTraveled = 0;
                if (grabbedObject)
                {
                    grabbedObject.transform.position = GameControl.instance.playerStartingPosition;
                    Camera.main.transform.position = GameControl.instance.cameraStartingPosition;
                    grabbedObject.GetComponent<ArrowKeyMovement>().freezePosition = false;
                    grabbedObject.GetComponent<BoxCollider>().enabled = true;
                    grabbedObject = null;
                }
            }
        }

        if (grabbedObject)
        {
            grabbedObject.transform.position = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ArrowKeyMovement>() && !Cheats.godMode)
        {
            grabbedObject = other.gameObject;
            other.GetComponent<ArrowKeyMovement>().freezePosition = true;
            other.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
