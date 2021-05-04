using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTriggerEnter : MonoBehaviour
{

    public bool playerFriendly = false;
    public int damage;
    public bool destroyOnImpact = false;

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Health>() && other.GetComponent<Health>().isPlayer != playerFriendly)
        {
            if ((Cheats.godMode && other.GetComponent<Health>().isPlayer) || other.GetComponent<Knockback>().invincible)
            {
                return;
            }

			if (other.GetComponent<Knockback>() != null)
			{
				if ((other.GetComponent<Knockback>().stunByBommerang || other.GetComponent<Knockback>().immuneToBoomerang) && tag == "p_boomerang")
				{
					return;
				}
			}

            other.GetComponent<Health>().AlterHealth(damage * -1);

			other.GetComponent<Knockback>().GetKnockedBack(transform.position.x, transform.position.y);

            if (destroyOnImpact)
            {
                Destroy(gameObject);
            }
        }
    }
}
