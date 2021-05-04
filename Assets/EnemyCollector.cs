using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollector : Collector
{

    public bool NoUse;
    // Start is called before the first frame update
    protected override void Start()
    {
        inventory = GameControl.instance.player.GetComponent<Inventory>();
        NoUse = true;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (!NoUse)
        {
            base.OnTriggerEnter(other);
        }
    }
}
