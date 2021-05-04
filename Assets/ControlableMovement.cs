using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlableMovement : ArrowKeyMovement
{

    public Sprite weaponImage;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        GetComponent<ControlableMovement>().enabled = false;
    }
}
