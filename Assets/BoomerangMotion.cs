using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangMotion : MonoBehaviour
{
    public float distance;
    public float timeToTravel;
    public float accelerationCoefficient;
    public GameObject startPosition;
    private Vector3 target;
    private float timer;
    private bool comingBack;
    private int mask;

    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Wall");
    }

    private void OnEnable()
    {
        RaycastHit hit;
        target = transform.position + (transform.up.normalized * distance);
        for (float i = distance; Physics.Raycast(transform.position, transform.up.normalized, out hit, i+1, mask); i -= 1){
            target = transform.position + (transform.up.normalized * i);
        }
        timer = 0;
        comingBack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!comingBack)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition.transform.position, target, Mathf.Pow(timer, 1 / accelerationCoefficient) / Mathf.Pow(timeToTravel, 1 / accelerationCoefficient));
            if(timer >= timeToTravel)
            {
                comingBack = true;
                timer = timeToTravel;
            }
        } else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                gameObject.active = false;
            } else
            {
                transform.position = Vector3.Lerp(startPosition.transform.position, target, Mathf.Pow(timer, 1 / accelerationCoefficient) / Mathf.Pow(timeToTravel, 1 / accelerationCoefficient));
            }
        }
    }
}
