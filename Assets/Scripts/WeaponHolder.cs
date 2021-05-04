using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHolder : MonoBehaviour
{

    public InputToAnimator anim;
    protected Weapon[] weapons;
    protected int currentSecondary;
    protected Weapon[] secondaryWeapons;
    protected Weapon sword;
    public Image secondaryWeaponImage;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        weapons = GetComponentsInChildren<Weapon>();
        anim = GetComponentInParent<InputToAnimator>();
        secondaryWeapons = new Weapon[weapons.Length - 1];
        int j = 0;
        for(int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].GetComponent<Sword>())
            {
                sword = weapons[i];
            } else
            {
                secondaryWeapons[j] = weapons[i];
                j++;
            }
        }
        currentSecondary = 0;
        if(secondaryWeapons.Length > 0)
        {
            secondaryWeaponImage.sprite = secondaryWeapons[currentSecondary].sprite;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (secondaryWeapons.Length > 0 && !secondaryWeapons[currentSecondary].pickedUp)
        {
            cycleWeapon();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            cycleWeapon();
        }
    }

    public void UseWeapon(int weaponNumber)
    {
        if(weaponNumber == 0)
        {
            if (sword)
            {
                sword.Use();
            }
        } else
        {
            secondaryWeapons[currentSecondary].Use();
        }
    }

    private void cycleWeapon()
    {
        currentSecondary++;
        if (currentSecondary >= secondaryWeapons.Length)
        {
            currentSecondary = 0;
        }
        secondaryWeaponImage.sprite = secondaryWeapons[currentSecondary].sprite;
        if (!secondaryWeapons[currentSecondary].pickedUp)
        {
            cycleWeapon();
        }
    }
}
