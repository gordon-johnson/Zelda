using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangHolder : Weapon
{

    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        active = false;
        projectile.active = false;
        ready = true;
        projectile.GetComponent<BoomerangMotion>().startPosition = gameObject;
        pickedUp = false;
    }

    private void Update()
    {
        base.Update();
        if(active && !projectile.active)
        {
            active = false;
            //anim.GetComponent<ArrowKeyMovement>().freezePosition = false;
            ready = true;
        }
    }

    protected override void OnUse()
    {
        base.OnUse();
        projectile.transform.position = transform.position;
        projectile.active = true;
        ready = false;
        //anim.GetComponent<ArrowKeyMovement>().freezePosition = true;
        active = true;
    }
}
