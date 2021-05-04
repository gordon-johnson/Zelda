using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpOnTriggerEnter : MonoBehaviour
{

    public Weapon pickup;

    public void Start()
    {
        if (!pickup)
        {
            pickup = GameControl.instance.player.GetComponentInChildren<BoomerangHolder>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Health>() && other.GetComponent<Health>().isPlayer)
        {
            pickup.pickedUp = true;
            Destroy(gameObject);
        }
    }
}
