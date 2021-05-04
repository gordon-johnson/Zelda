using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoomerang : Weapon
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
    }

    private void Update()
    {
        base.Update();
        if (active && !projectile.active)
        {
            active = false;
            health.GetComponent<ArrowKeyMovement>().freezePosition = false;
            ready = true;
            health.GetComponent<Collector>().enabled = true;
        }
    }

    protected override void OnUse()
    {
        base.OnUse();
        projectile.transform.position = transform.position;
        projectile.active = true;
        ready = false;
        health.GetComponent<ArrowKeyMovement>().freezePosition = true;
        active = true;
        health.GetComponent<Collector>().enabled = false;
    }
}
