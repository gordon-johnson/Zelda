using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelMovement : AIMovement
{

    public float maxWaitTime;
    public float minWaitTime;
    public float moveTime;
    public int moveDistance;
    private float moveTimer;
    private float waitTimer;
    private Vector3 target;
    private int mask;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        waitTimer = minWaitTime;
        moveTimer = 0;
        mask = LayerMask.GetMask("Wall") | LayerMask.GetMask("LowWall");
    }

    // Update is called once per frame
    void Update()
    {
        if(moveTimer > 0)
        {
            transform.position += ((target - transform.position) / moveTimer) * Time.deltaTime;
            moveTimer -= Time.deltaTime;
            if(moveTimer <= 0)
            {
                transform.position = target;
                waitTimer = (Random.value * (maxWaitTime - minWaitTime)) + minWaitTime;
            }
        }
        if(waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;
            if(waitTimer <= 0)
            {
                updateDirection();
            }
        }
    }

    private void updateDirection()
    {
        RaycastHit hit;
        if (Random.value > 0.5)
        {
            target = transform.position + new Vector3(0, (Mathf.Floor(Random.value * 2) - 0.5f) * 2 * moveDistance, 0);
            if (Physics.Raycast(transform.position, new Vector3(0, target.y - transform.position.y, 0), out hit, moveDistance, mask))
            {
                updateDirection();
            }
        }
        else
        {
            target = transform.position + new Vector3((Mathf.Floor(Random.value * 2) - 0.5f) * 2, 0, 0);
            if (Physics.Raycast(transform.position, new Vector3(target.x - transform.position.x, 0, 0), out hit, moveDistance, mask))
            {
                updateDirection();
            }
        }
        moveTimer = moveTime;
    }
}
