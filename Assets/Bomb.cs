using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float waitTimer;
    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer -= Time.deltaTime;
        if(waitTimer <= 0)
        {
            if (spawn)
            {
                Instantiate(spawn, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
