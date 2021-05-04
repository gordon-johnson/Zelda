using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : Weapon
{
    public float range;

    protected override void OnUse()
    {
        base.OnUse();
		if (anim.GetComponent<Inventory>().getBombs() > 0)
		{
			Instantiate(projectile, transform.position + (transform.up.normalized * range), Quaternion.identity);
			anim.GetComponent<Inventory>().AddBombs(-1);
		}
	}
}
