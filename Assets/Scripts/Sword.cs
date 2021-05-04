using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    public float attackLength;
    protected float attackTimer;
    protected BoxCollider hurtBox;
    public float projecttileCoolDown;
    protected float coolDownTimer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hurtBox = GetComponent<BoxCollider>();
        hurtBox.enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            if(attackTimer <= 0)
            {
                hurtBox.enabled = false;
                anim.animator.SetBool("sword", false);
                anim.overRideGo = false;
                anim.GetComponent<ArrowKeyMovement>().freezePosition = false;
                if (projectile && anim.GetComponent<Health>().GetHealth() == anim.GetComponent<Health>().maxHealth && coolDownTimer <= 0)
                {
                    Instantiate(projectile, transform.position, transform.rotation);
                    coolDownTimer = projecttileCoolDown;
                }
            }
        } else
        {
            ready = true;
        }
    }

    protected override void OnUse()
    {
        base.OnUse();
        hurtBox.enabled = true;
        attackTimer = attackLength;
        ready = false;
        anim.animator.SetBool("sword", true);
        anim.overRideGo = true;
        anim.GetComponent<ArrowKeyMovement>().freezePosition = true;
    }
}
