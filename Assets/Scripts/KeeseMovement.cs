using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeseMovement : AIMovement
{
    public float maxSpeed = 4;
    private float speed;

    public float accelTime = 2;
    private float accelTimer;

    public float flyTime = 4;
    private float flyTimer;

    public float deccelTime = 2;
    private float deccelTimer;

    public float waitTime = 2;
    private float waitTimer;

    public float directionTime = 0.5f;
    private float directionTimer;

    private int verticalDirection;
    private int horizontalDirection;
    private int mask;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        speed = maxSpeed;
        SetDirections();
        mask = LayerMask.GetMask("Wall");
        waitTimer = 0;
        deccelTimer = 0;
        accelTimer = 0;
        flyTimer = Random.value * flyTime;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForCollision();
        transform.position += new Vector3(horizontalDirection, verticalDirection, 0) * speed * Time.deltaTime;
        directionTimer -= Time.deltaTime;
        if(directionTimer <= 0)
        {
            SetDirections();
        }

        if(flyTimer > 0)
        {
            speed = maxSpeed;
            anim.speed = 1;
            flyTimer -= Time.deltaTime;
            if(flyTimer <= 0)
            {
                deccelTimer = deccelTime;
            }
        }
        if(deccelTimer > 0)
        {
            speed = maxSpeed * (deccelTimer / deccelTime);
            anim.speed = (deccelTimer / deccelTime);
            deccelTimer -= Time.deltaTime;
            if(deccelTimer <= 0)
            {
                waitTimer = waitTime;
            }
        }
        if(waitTimer > 0)
        {
            speed = 0;
            anim.speed = 0;
            waitTimer -= Time.deltaTime;
            if(waitTimer <= 0)
            {
                accelTimer = accelTime;
            }
        }
        if (accelTimer > 0)
        {
            speed = maxSpeed * (1 - (accelTimer / accelTime));
            anim.speed = 1 - (accelTimer / accelTime);
            accelTimer -= Time.deltaTime;
            if (accelTimer <= 0)
            {
                flyTimer = flyTime;
            }
        }
    }

    public void SetDirections()
    {
        float value = Random.value;
        horizontalDirection = (int)Mathf.Floor(Random.value * 3) - 1;
        if(horizontalDirection != 0)
        {
            verticalDirection = (int)Mathf.Floor(Random.value * 3) - 1;
        } else
        {
            verticalDirection = (int)((Mathf.Floor(Random.value * 2) - 0.5)*2);
        }
        directionTimer = directionTime;
    }

    public void CheckForCollision()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, new Vector3(horizontalDirection,0,0), out hit, GameControl.instance.gridSize, mask))
        {
            horizontalDirection = -horizontalDirection;
        }
        if (Physics.Raycast(transform.position, new Vector3(0, verticalDirection, 0), out hit, GameControl.instance.gridSize, mask))
        {
            verticalDirection = -verticalDirection;
        }
    }
}
