using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalfosSword : Sword
{

    protected override void Start()
    {
        base.Start();
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Start is called before the first frame update
    protected override void Update()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                hurtBox.enabled = false;
                health.GetComponent<ArrowKeyMovement>().freezePosition = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            ready = true;
        }
    }

    protected override void OnUse()
    {
        hurtBox.enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        attackTimer = attackLength;
        ready = false;
    }
}
