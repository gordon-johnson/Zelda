using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject warpToPosition;
    public Vector3 cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ArrowKeyMovement>())
        {
            other.transform.position = warpToPosition.transform.position;
            Camera.main.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, Camera.main.transform.position.z);
        }
    }
}
