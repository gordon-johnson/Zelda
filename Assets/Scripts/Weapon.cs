using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    protected bool ready;
    public InputToAnimator anim;
    public GameObject projectile;
    public Sprite sprite;
    protected Health health;

    public bool pickedUp;

    protected virtual void Start()
    {
        pickedUp = true;
        anim = GetComponentInParent<WeaponHolder>().anim;
        if (GetComponentInParent<EnemyWeaponsHolder>())
        {
            health = GetComponentInParent<EnemyWeaponsHolder>().health;
        }
        ready = true;
    }

    protected virtual void Update()
    {
        if (!anim)
        {
            anim = GetComponentInParent<WeaponHolder>().anim;
        }
    }

    public virtual void Use()
    {
        if (ready)
        {
            OnUse();
        }
    }

    protected virtual void OnUse()
    {

    }
}
