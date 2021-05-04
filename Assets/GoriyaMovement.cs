using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoriyaMovement : AIMovement2
{

    public bool freezeMovement;
    private Animator anim;
    public GameObject boomerang;
    public float timeBetweenThrows;
    private float throwTimer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        throwTimer = timeBetweenThrows;
        boomerang.GetComponent<BoomerangMotion>().startPosition = gameObject;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!freezeMovement)
        {
            anim.speed = 1;
            base.Update();
            if(direction == N)
            {
                anim.SetInteger("vertical_speed", 1);
                anim.SetInteger("horizontal_speed", 0);
                boomerang.transform.eulerAngles = new Vector3(0,0,0);
            } else if(direction == S)
            {
                anim.SetInteger("vertical_speed", -1);
                anim.SetInteger("horizontal_speed", 0);
                boomerang.transform.eulerAngles = new Vector3(0, 0, 180);
            } else if(direction == E)
            {
                anim.SetInteger("vertical_speed", 0);
                anim.SetInteger("horizontal_speed", 1);
                boomerang.transform.eulerAngles = new Vector3(0, 0, 270);
            } else  if(direction == W)
            {
                anim.SetInteger("vertical_speed", 0);
                anim.SetInteger("horizontal_speed", -1);
                boomerang.transform.eulerAngles = new Vector3(0, 0, 90);
            }
            throwTimer -= Time.deltaTime;
            if(throwTimer <= 0)
            {
                throwTimer = timeBetweenThrows;
                boomerang.transform.localPosition = Vector3.zero;
                boomerang.active = true;
                freezeMovement = true;
            }
        } else
        {
            anim.speed = 0;
            if (!boomerang.active)
            {
                freezeMovement = false;
            }
        }
    }
}
