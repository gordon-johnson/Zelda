using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ready = true;
        pickedUp = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnUse()
    {
        base.OnUse();
        if (anim.GetComponent<Inventory>().getRupees() > 0)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            anim.GetComponent<Inventory>().AddRupees(-1);
        }
    }
}
