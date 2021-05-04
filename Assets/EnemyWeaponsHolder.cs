using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponsHolder : WeaponHolder
{

    public Health health;

    // Start is called before the first frame update
    protected override void Start()
    {
        weapons = GetComponentsInChildren<Weapon>();
        health = GetComponentInParent<Health>();
        secondaryWeapons = new Weapon[1];
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].GetComponent<ReturnToLink>())
            {
                secondaryWeapons[0] = weapons[i];
            }
            else
            {
                sword = weapons[i];
            }
        }
        currentSecondary = 0;
    }
}
